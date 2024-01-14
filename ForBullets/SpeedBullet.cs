using Interface;
using UnityEngine;

public class SpeedBullet : Bullets
{
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
}
