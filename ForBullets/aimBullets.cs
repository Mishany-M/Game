using Interface;
using UnityEngine;

public class aimBullets : Bullets
{
    public float DistanceDetected;
    public LayerMask mask;
    public float SpeedAim;
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

    Quaternion Dista(Collider2D[] coll)
    {
        float f = Vector2.Distance(transform.position, coll[0].transform.position);
        Vector3 q = coll[0].transform.position;

        foreach (Collider2D a in coll)
        {
            float w = Vector2.Distance(transform.position, a.transform.position);
            if (w < f)
            {
                q = a.transform.position;
                f = w;
            }
        }

        Vector2 we = q - transform.position;
        float ang = Mathf.Atan2(we.y, we.x) * Mathf.Rad2Deg;
        Quaternion s = Quaternion.Euler(0, 0, ang);
        return s;
    }

    public override void Move()
    {
        Collider2D[] coll = Physics2D.OverlapCircleAll(transform.position, DistanceDetected, mask);

        if (coll.Length > 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Dista(coll), SpeedAim * Time.deltaTime);
        }

        base.Move();
    }
}
