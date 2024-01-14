using Interface;
using UnityEngine;

public class SlowBullet : Bullets
{
    public override void Intarget(Collider2D collision)
    {
        Enemys en = collision.GetComponent<Enemys>();
        Instantiate(part, transform.position, transform.rotation);
        if (en != null)
        {
            en.GetDamage(Player.instance.CurrentDamage);
            if (en.speed > 5)
            {
                en.speed--;
            }
        }

        Stop();
    }
}
