using Interface;
using UnityEngine;

public class VampirBullet : Bullets
{
    Player player;

    public override void Start()
    {
        base.Start();
        player = Player.instance;
    }

    public override void Intarget(Collider2D collision)
    {
        Instantiate(part, transform.position, transform.rotation);
        if (collision.GetComponent<Enemys>())
        {
            collision.GetComponent<Enemys>().GetDamage(player.CurrentDamage);
            player.ChangeHp(player.CurrentDamage / 15);
        }

        Stop();
    }
}
