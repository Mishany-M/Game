using Interfaces;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public interface IState
{
    public void ChooseAttac(Enemys en);
}

public class Flying : IState
{
    public void ChooseAttac(Enemys en)
    {

    }
}

public class Running : IState
{
    public void ChooseAttac(Enemys en)
    {
    }
}

public class Stay : IState
{
    public void ChooseAttac(Enemys en)
    {
        en.AttacHit();
    }
}

public class Player : MonoBehaviour
{
    public Animator anim;
    public AudioSource Sound;
    public Rigidbody2D rb;
    public Transform tf;
    public MoveGun Gun;
    public HealthBar healthbar;
    public GameObject particlDeath;
    public Text textCoin;
    public Manager manager;
    public float Axis;
    public float Speed = 10;
    public float MaxHealth = 100;
    private float SpeedFall = 0;
    public float Health;
    public float SpeedRegen = 1;
    public int CountJump = 1;
    private int Jumps;
    public int Coins = 0;
    [SerializeField] public static float DamageKof = 1;
    public IState state = new Stay();
    public Save sv = new();
    public Canvas canv;
    public GameObject OnDead;
    public bool Dead = false;

    public void SaveGame(int scene)
    {
        sv.CurrentScene = scene;
        sv.Choose = Gun.module.choose;
        sv.Coins = Coins;
        sv.sprite = Gun.GetComponent<SpriteRenderer>().sprite;
        PlayerPrefs.SetString("Save", JsonUtility.ToJson(sv));
    }

    public void OnDeadMove()
    {
        canv.gameObject.SetActive(false);
        transform.rotation *= Quaternion.Euler(0, 0, 90);
        OnDead.SetActive(true);
        PlayerPrefs.DeleteAll();
        Dead = true;
        Axis = 0;
        Sound.Stop();
        anim.SetBool("Run", false);
        StopAllCoroutines();
        manager.Defoult();
    }

    private void Awake()
    {
        manager.pl = GetComponent<Transform>();
        Application.targetFrameRate = 120;
        manager.pl = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        Debug.Log(SceneManager.GetActiveScene().name);
        if (PlayerPrefs.HasKey("Save"))
        {
            sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("Save"));
            Coins = sv.Coins;
            Gun.module = sv.pool[sv.Choose];
            Gun.module.Use(Gun);
            Gun.GetComponent<SpriteRenderer>().sprite = sv.sprite;
            sv.CurrentScene = SceneManager.GetActiveScene().buildIndex;
        }
        else
        {
            SaveGame(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Start()
    {
        Health = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
        healthbar.SetHealth(Health);
        manager.MaxHp = MaxHealth;
        anim.SetBool("Run", false);
        Jumps = CountJump;
        UpdateCoins();
        StartCoroutine(Regen());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            if (SpeedFall < -20)
            {
                Health += SpeedFall;
                if (Health < 0 && !Dead)
                {
                    OnDeadMove();
                }
                healthbar.SetHealth(Health);
                SpeedFall = 0;
                particlDeath.SetActive(true);
            }
            Jumps = CountJump;
            anim.SetBool("Jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            anim.SetBool("Jump", true);
        }
    }

    private void FixedUpdate()
    {
        if (SpeedFall > rb.velocity.y) SpeedFall = rb.velocity.y;
        MovementLogic();
    }

    public void UpdateCoins()
    {
        textCoin.text = "COINS:" + Coins;
    }

    IEnumerator Regen()
    {
        while (true)
        {
            if (Health < MaxHealth)
            {
                Health += 1;
                healthbar.SetHealth(Health);
            }
            yield return new WaitForSeconds(SpeedRegen);
        }
    }

    private void MovementLogic()
    {
        float moveHorizontal = Axis * Speed;
        float moveVertical = rb.velocity.y;
        Vector3 movement = new(moveHorizontal, moveVertical);
        rb.velocity = movement;
    }

    public void Jump()
    {
        if (Jumps > 0)
        {
            SpeedFall = 0;
            Jumps--;
            Vector2 vec = new(0, 15);
            Vector2 vecstop = new(rb.velocity.x, 0);
            rb.velocity = vecstop;
            rb.AddForce(vec, ForceMode2D.Impulse);
        }
    }

    public void LeftD()
    {
        Sound.Play();
        anim.SetBool("Run", true);
        Vector2 vec = new(-1, 1);
        Axis = -1;
        tf.localScale = vec;
    }

    public void LeftRightUp()
    {
        Sound.Stop();
        anim.SetBool("Run", false);
        Axis = 0;
    }

    public void RightD()
    {
        Sound.Play();
        anim.SetBool("Run", true);
        Vector2 vec = new(1, 1);
        Axis = 1;
        tf.localScale = vec;
    }
}
