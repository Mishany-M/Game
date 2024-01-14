using Interface;
using UnityEngine;

public class EnemyBullet : Bullets
{
    public float Damage;

    public override void Stop()
    {
        Destroy(gameObject);
    }

    public override void Intarget(Collider2D collision)
    {
        Instantiate(part, transform.position, transform.rotation);
        if (collision.GetComponent<Player>()) collision.GetComponent<Player>().TakeDamage(-Damage);
        Destroy(gameObject);
    }
}
