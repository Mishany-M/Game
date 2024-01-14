using Interface;
using UnityEngine;

public class HeavyBullet : Bullets
{
    public float ForceDown;

    public override void Move()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0, -90), ForceDown * Time.deltaTime);
        base.Move();
    }
}
