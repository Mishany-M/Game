using Interface;
using UnityEngine;

public class BombBullet : Bullets
{
    public float ForceDown;
    public float DistanceDetected;
    public LayerMask mask;

    public override void Move()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -90), ForceDown * Time.deltaTime);
        base.Move();
    }

    public override void Intarget(Collider2D collision)
    {
        Collider2D[] coll = Physics2D.OverlapCircleAll(transform.position, DistanceDetected, mask);

        if (coll.Length > 0)
        {
            foreach (Collider2D coll2 in coll)
            {
                coll2.GetComponent<Enemys>().GetDamage(Player.instance.CurrentDamage);
            }
        }
        Instantiate(part, transform.position, transform.rotation);
        Stop();
    }
}
