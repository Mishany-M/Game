using Interface;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunHolder", menuName = "Managers/GunHolder")]
public class ManagerGuns : ScriptableObject
{
    public Sprite[] poolSprites;
    public List<ModuleSpawnBullets> poolModules = new()
    {   new GunAk0(),
        new ShotGun1(),
        new Aksu2(),
        new Cz3(),
        new DuableShot4(),
        new Pp5(),
        new Rifle6(),
        new RPK7(),
        new Val8(),
        new DualPistol9(),
        new Blaster10(),
        new BMG11(),
        new Famas12(),
        new FastShot13(),
        new Uzi14(),
        new MiniGun15(),
        new BlusterTwo16(),
        new HzFire17(),
        new MoreUzi18(),
        new Pistol19(),
        new RailGun20(),
        new ShotOne21(),
        new TheeGun22(),
        new ThreePistol23(),
        new TwoGun24()
    };
    public List<GameObject> poolBullets = new();
    public List<SmallModules> smallModules = new() { new MoreDamage(), new MoreHp(), new MoreJumps(), new MoreSpeed(), new MoreMaxHp() };
}

