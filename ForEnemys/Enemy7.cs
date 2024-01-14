using Interface;
using System.Collections;
using UnityEngine;

public class Enemy7 : Enemys
{
    public GameObject bullet;
    float rot;

    public override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(shoot());
    }

    public override void OnDisable()
    {
        base.OnDisable();
        StopCoroutine(shoot());
    }

    public override void DestroyEnemy()
    {
        Destroy(GetComponentsInParent<Transform>()[1].gameObject);
    }

    public override void MainMove()
    {
        Vector2 vec = player.tf.position - transform.position;
        rot = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, rot), Time.deltaTime * 2);
    }

    IEnumerator shoot()
    {
        while (true)
        {
            Instantiate(bullet, Check.position, Quaternion.Euler(0, 0, rot)).SetActive(true);
            yield return new WaitForSeconds(2);
        }
    }
}
