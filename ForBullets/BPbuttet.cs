using Interface;
using UnityEngine;

public class BPbuttet : Bullets
{
    public override void Intarget(Collider2D collision)
    {
        Instantiate(part, transform.position, transform.rotation);
        if (collision.GetComponent<Enemys>()) collision.GetComponent<Enemys>().GetDamage(Player.instance.CurrentDamage);
        else Stop();
    }
}
