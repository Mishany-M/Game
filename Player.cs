using Interface;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sprite;
    public AudioSource audTakeItem;
    public AudioSource audTakeDamage;
    public AudioSource audJump;
    public AudioSource audEnDead;
    public AudioSource audMusic;
    public AudioSource audTakeSoul;
    [SerializeField] AudioSource audRun;
    public Animator anim;
    [SerializeField] ManagerForEn mnr;
    public Saves saves;
    public static Player instance;
    public Text textJumps;
    public Text textDamage;
    #region Movement
    public LayerMask floorLayer;
    public Transform tf;
    float speedLerp = 10;
    public float speed = 30;
    float weighJump = 90;
    public bool onFloor = true;
    public float speedFall = 0;
    public int countJump = 2;
    public int maxCountJump = 2;
    #endregion
    #region particle
    public GameObject particlDeath;
    public GameObject[] particSoul;
    public GameObject partSellSoul;
    public GameObject partHeal;
    public GameObject partSeet;
    public ParticleSystem partRun;
    public GameObject partJump;
    #endregion
    public MoveGun Gun;
    public HealthBar healthBar;
    public float hp = 845;
    public int soul = 0;
    public int MaxSoul = 100;
    public float maxHp = 1000;
    public float PowerForce = 50;
    public float koifDamage = 1;
    public Canvas canv;
    public GameObject canvMenu;
    public GameObject OnDead;
    public bool Dead = false;
    public float koifGun;
    public float koifBullet;
    public float Damage;
    public float CurrentDamage;
    public int CurrentLevel;
    public Transform cur;
    public AudioMixerGroup Audio;
    public Slider sliderSound;
    public Slider sliderMusic;
    public ManagerAud mAud;
    public GameObject HpPart;
    public GameObject changeSoul;

    private void Awake()
    {
        instance = this;
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        saves = Saves.instance;
        mnr.pl = this;
        mnr.plTf = tf;
        mnr.mg = Gun;
        textJumps.text = "Jumps: " + countJump;
        Application.targetFrameRate = 120;
        mnr.Defoult();
        ChangeValue();
    }

    private void OnEnable()
    {
        anim.SetBool("Dead", false);
        Dead = false;
        ResetHp();
        healthBar.SetMaxSoul(MaxSoul);
        healthBar.SetSoul(soul);
        StartCoroutine(mAud.SwitchSound(audMusic));
    }

    private void OnDisable()
    {
        anim.SetBool("Dead", false);
        anim.StopPlayback();
        anim.StopRecording();
    }

    private void Start()
    {
        koifBullet = Gun.bulletUse.GetComponent<Bullets>().koifBullet;
        Gun.module.Use(Gun);
        OnChangeDamage();
        sliderMusic.value = saves.ValueMusic;
        sliderSound.value = saves.ValueSound;
        ChangeSound();
        ChangeMusic();
    }

    public void ResetHp()
    {
        hp = maxHp;
        healthBar.SetMaxHp(maxHp);
        healthBar.SetHp(hp);
    }

    public void OnChangeDamage()
    {
        CurrentDamage = (float)System.Math.Round(Damage * koifBullet * koifGun, 1);
        textDamage.text = "Damage: " + CurrentDamage;
    }

    public void OnChangeJumps()
    {
        textJumps.text = "Jumps: " + countJump;
    }

    public void OnChangeSoul(int count)
    {
        soul += count;
        healthBar.SetSoul(soul);
        changeSoul.SetActive(true);
        audTakeSoul.Play();
        if (soul > MaxSoul) soul = MaxSoul;
        if (soul < 0) soul = 0;
        if (count > 0)
            TakeSoul().SetActive(true);
        else partSellSoul.SetActive(true);
    }

    public GameObject TakeSoul()
    {
        for (int i = 0; i < particSoul.Length; i++)
        {
            if (!particSoul[i].activeInHierarchy) return particSoul[i];
        }
        return particSoul[0];
    }

    void JumpMove()
    {
        if (Input.GetKeyDown(KeyCode.Space) && countJump > 0)
        {
            if (!onFloor) Instantiate(partJump, transform.position, Quaternion.identity);
            rb.velocity = new(rb.velocity.x, 0);
            speedFall = 0;
            rb.AddForce(weighJump * Vector2.up, ForceMode2D.Impulse);
            countJump--;
            audJump.Play();
            textJumps.text = "Jumps: " + countJump;
        }
    }

    public void RunPlay()
    {
        partRun.Play();
        if (onFloor) audRun.Play();
    }

    public void RunStop()
    {
        partRun.Stop();
        audRun.Stop();
    }

    void Move()
    {
        if (rb.velocity.y < speedFall) speedFall = rb.velocity.y;

        Vector2 stop = new(0, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.A) && !Gun.FireOn)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKeyDown(KeyCode.D) && !Gun.FireOn)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(speed, rb.velocity.y), Time.deltaTime * speedLerp);
            anim.SetBool("Run", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(-speed, rb.velocity.y), Time.deltaTime * speedLerp);
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
            rb.velocity = Vector2.Lerp(rb.velocity, stop, Time.deltaTime * speedLerp);
        }
    }

    public void TakeDamage(float damage)
    {
        if (!Dead)
        {
            if (!particlDeath.activeInHierarchy)
            {
                rb.AddForce(Vector2.up * PowerForce, ForceMode2D.Impulse);
            }
            anim.Play("PlDamage");
            ChangeHp(damage);
            particlDeath.SetActive(true);
            audTakeDamage.Play();
            if (hp <= 0) OnDeadMove();
        }
    }

    public void ChangeHp(float much)
    {
        hp += much;
        HpPart.SetActive(true);
        if (hp > maxHp) hp = maxHp;
        healthBar.SetHp(hp);
    }

    public void OnDeadMove()
    {
        canv.gameObject.SetActive(false);
        Dead = true;
        saves.ResetData();
        anim.SetBool("Dead", true);
        anim.SetBool("Run", false);
        StopAllCoroutines();
    }

    private void Update()
    {
        JumpMove();
        Move();
    }

    #region menu

    public void ChangeValue()
    {
        sliderSound.value = saves.ValueSound;
        sliderMusic.value = saves.ValueMusic;
    }

    public void ChangeSound()
    {
        Audio.audioMixer.SetFloat("sound", sliderSound.value);
        saves.ValueSound = sliderSound.value;
    }

    public void ChangeMusic()
    {
        Audio.audioMixer.SetFloat("music", sliderMusic.value);
        saves.ValueMusic = sliderMusic.value;
    }

    public void LoadLevel(int level)
    {
        Time.timeScale = 1;
        anim.SetBool("Dead", false);
        if (level != 0)
            CurrentLevel = level;
        canvMenu.gameObject.SetActive(false);
        canv.gameObject.SetActive(true);
        saves.LoadLevel(level);
    }

    public void SwitchPause()
    {
        if (Time.timeScale == 0)
        {
            Saves.instance.fullPlayer.transform.parent = cur;
            canvMenu.gameObject.SetActive(false);
            canv.gameObject.SetActive(true);
            Time.timeScale = 1;
        }
        else
        {
            cur = Saves.instance.fullPlayer.transform.parent;
            Saves.instance.fullPlayer.transform.parent = null;
            DontDestroyOnLoad(Saves.instance.fullPlayer);
            audRun.Stop();
            canv.gameObject.SetActive(false);
            canvMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnApplicationPause(bool pause)
    {
        cur = Saves.instance.fullPlayer.transform.parent;
        Saves.instance.fullPlayer.transform.parent = null;
        DontDestroyOnLoad(Saves.instance.fullPlayer);
        audRun.Stop();
        canv.gameObject.SetActive(false);
        canvMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    #endregion
}
