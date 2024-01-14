using Interface;
using UnityEngine;

public class ManageBullet : Bullets
{
    MoveGun mg;
    public GameObject Trail;
    public GameObject CurrentTrail;
    public override void OnEnable()
    {
        Invoke(nameof(Stop), 6);
        CurrentTrail = Instantiate(Trail, transform.position, Quaternion.identity);
        CurrentTrail.transform.SetParent(transform);
    }

    public override void OnDisable()
    {
        Destroy(CurrentTrail);
        base.OnDisable();
    }

    public override void Start()
    {
        base.Start();
        mg = MoveGun.instance;
    }

    public override void Move()
    {
        base.Move();
        transform.rotation = Quaternion.Lerp(tf.rotation, mg.whereBull, Time.deltaTime * 10);
    }
}
