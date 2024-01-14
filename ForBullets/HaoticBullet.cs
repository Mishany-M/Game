using Interface;
using System.Collections;
using UnityEngine;

public class HaoticBullet : Bullets
{
    public float SpeedAim;
    public float Range;
    public GameObject Trail;
    public GameObject CurrentTrail;

    public override void OnEnable()
    {
        base.OnEnable();
        CurrentTrail = Instantiate(Trail, transform.position, Quaternion.identity);
        CurrentTrail.transform.SetParent(transform);
    }

    public override void OnDisable()
    {
        Destroy(CurrentTrail);
        base.OnDisable();
    }

    public override void Intarget(Collider2D collision)
    {
        base.Intarget(collision);
    }

    public override void Move()
    {
        Quaternion w = transform.rotation * Quaternion.Euler(0, 0, Random.Range(-Range, Range));
        transform.rotation = Quaternion.Lerp(transform.rotation, w, SpeedAim * Time.deltaTime);
        base.Move();
    }
}
