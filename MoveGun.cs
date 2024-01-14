using Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveGun : MonoBehaviour
{
    public Joystick joystick;
    public Animator anim;
    public AudioSource shotSound;
    public AudioSource audSwitchBullet;
    public AudioSource audSwitchGun;
    public Transform from;
    public GameObject obj;
    public ModuleSpawnBullets module = new BlusterTwo16();
    public ModuleSpawnBullets module1 = new ShotGun1();
    public int CurrentGun = 0;
    public int SecondGun = 1;
    public int CurrentBullet = 0;
    public int SecondBullet = 1;
    private float rotBullet;
    public Quaternion whereBull;
    public Transform tf;
    public Vector2 dir;
    public float rotGun;
    public Camera camera1;
    public Player Pl;
    public Canvas canvas;
    public List<GameObject> pooledbullets = new List<GameObject>();
    public List<GameObject> pooledbullets1 = new List<GameObject>();
    public GameObject bulletUse;
    public GameObject bulletUse1;
    private bool isfill = true;
    public bool FireOn = false;
    float CurrentWaitTime = 0;
    public float WaitShot = 1;
    public ManagerGuns GunMng;
    public int[] poolGuns;
    public static MoveGun instance;
    public Image imageBullet;
    public SpriteRenderer spriteRenderer;
    [SerializeField] GameObject SwitchPart;
    public GameObject FireBegin;


    private void OnDestroy()
    {
        module.Clear();
    }

    private void OnDisable()
    {
        pooledbullets.Clear();
    }

    private void Awake()
    {
        instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            poolGuns[i] = Random.Range(0, 14);
        }
        tf = GetComponent<Transform>();
        shotSound = GetComponent<AudioSource>();
        bulletUse1 = GunMng.poolBullets[Random.Range(0, GunMng.poolBullets.Count)];
        module1 = GunMng.poolModules[Random.Range(0, GunMng.poolModules.Count)];
        SetColor();
    }

    void FixedUpdate()
    {
        if (FireOn)
        {
            MoveWeapone();
            Shot();
        }
    }

    public void SetColor()
    {
        imageBullet.sprite = bulletUse.GetComponent<SpriteRenderer>().sprite;
        imageBullet.color = bulletUse.GetComponent<SpriteRenderer>().color;
    }

    public void SwitchGun()
    {
        FireBegin.transform.position = from.position;
        (module, module1) = (module1, module);
        (CurrentGun, SecondGun) = (SecondGun, CurrentGun);
        module.Use(this);
        Pl.OnChangeDamage();
        audSwitchGun.Play();
        SwitchPart.SetActive(true);
    }

    public void SwitchBullet()
    {
        (bulletUse, bulletUse1) = (bulletUse1, bulletUse);
        (pooledbullets, pooledbullets1) = (pooledbullets1, pooledbullets);
        (CurrentGun, SecondGun) = (SecondGun, CurrentGun);
        (CurrentBullet, SecondBullet) = (SecondBullet, CurrentBullet);
        Pl.koifBullet = bulletUse.GetComponent<Bullets>().koifBullet;
        SetColor();
        Pl.OnChangeDamage();
        audSwitchBullet.Play();
    }

    void Shot()
    {
        if (Time.time > CurrentWaitTime)
        {
            module.Spawn(whereBull, from.position);
            CurrentWaitTime = Time.time + WaitShot;
            FireBegin.SetActive(true);
            shotSound.Play();
        }
    }

    public GameObject GetBullet()
    {
        for (int i = 0; i < pooledbullets.Count; i++)
        {
            if (!pooledbullets[i].activeInHierarchy)
            {
                return pooledbullets[i];
            }
        }
        if (isfill)
        {
            GameObject obj = Instantiate(bulletUse);
            pooledbullets.Add(obj);
            return obj;
        }
        return null;
    }

    public void MoveWeapone()
    {
        rotGun = Mathf.Atan2(joystick.Vertical, System.Math.Abs(joystick.Horizontal)) * Mathf.Rad2Deg;
        rotBullet = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
        tf.localRotation = Quaternion.Euler(0, 0, rotGun);
        Pl.tf.localScale = new(Mathf.Sign(joystick.Horizontal), 1, 1);
        whereBull = Quaternion.Euler(0, 0, rotBullet);
    }

    public void Courotine(IEnumerator enumerator)
    {
        StartCoroutine(enumerator);
    }
}
