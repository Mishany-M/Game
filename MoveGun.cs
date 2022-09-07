using Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGun : MonoBehaviour
{
    public Joystick joystick;
    public AudioSource shotSound;
    public Transform from;
    private Transform tf;
    public GameObject bulletUse;
    public GameObject obj;
    public Vector2 dir;
    private Vector3 mousePos;
    private Quaternion whre;
    private float rotBullet;
    public List<GameObject> pooledbullets = new List<GameObject>();
    private bool isfill = true;
    private float rotGun;
    public UnityEngine.Camera camera1;
    private Quaternion zero = Quaternion.Euler(0, 0, 0);
    public Player Pl;
    public ModuleSpawnBullets module = new Modul3();
    public List<ModuleSpawnBullets> modules = new List<ModuleSpawnBullets> { new Modul6() };
    public int CurrentGun = 0;
    public float timershot = 1;
    public float timer;
    public Canvas canvas;
    public List<GameObject> forModules = new();
    public GameObject buff;
    public GameObject buffType;

    private void Start()
    {
        module.mg = GetComponent<MoveGun>();
        timer = timershot * module.Timershot;
        tf = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (timer > 0) timer -= Time.deltaTime;
        if (joystick.background.gameObject.activeInHierarchy)
        {
            MoveWeapone();
            module.Spawn(whreBullet(), from.position);
        }
        else
        {
            tf.localRotation = zero;
        }
    }

    public GameObject Inst(GameObject obj)
    {
        return Instantiate(obj);
    }
    public void Begun(GameObject obj)
    {
        StartCoroutine(More(obj));
    }
    private IEnumerator More(GameObject obj)
    {
        WaitForSeconds wait = new(0.2f);
        GameObject obj1;
        while (Vector2.Distance(obj.transform.position, transform.position) < 30 && obj.activeInHierarchy)
        {
            yield return wait;
            for (int i = 0; i < 3; i++)
            {
                obj1 = GetBullet();
                obj1.transform.SetPositionAndRotation(obj.transform.position, obj.transform.rotation * Quaternion.Euler(0, 0, Random.Range(-20, 20)));
                obj1.SetActive(true);
            }
            yield return wait;
        }
    }

    public void Destroy1(GameObject obj)
    {
        Destroy(obj);
    }
    public void MoveWeapone()
    {
        mousePos = camera1.ScreenToWorldPoint(Input.mousePosition);
        dir = mousePos - tf.position;
        rotGun = Mathf.Atan2(joystick.Vertical, System.Math.Abs(joystick.Horizontal)) * Mathf.Rad2Deg;
        Quaternion qq = Quaternion.Euler(0, 0, rotGun);
        tf.localRotation = qq;
        Vector2 vec = new Vector2(Mathf.Sign(joystick.Horizontal), 1);
        Pl.tf.localScale = vec;
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

    public Quaternion whreBullet()
    {
        mousePos = camera1.ScreenToWorldPoint(Input.mousePosition);
        dir = mousePos - tf.position;
        rotBullet = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
        whre = Quaternion.Euler(0, 0, rotBullet); ;
        return whre;
    }
}
