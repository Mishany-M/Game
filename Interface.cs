namespace Interface
{
    using System.Collections;
    using UnityEngine;

    #region Modules
    public abstract class ModuleSpawnBullets
    {
        public MoveGun mg;
        public GameObject obj;
        public abstract void Use(MoveGun gun);
        public abstract void Spawn(Quaternion where, Vector2 vec);
        public virtual void Clear() { }
    }

    public class GunAk0 : ModuleSpawnBullets
    {
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 1;
            mg.WaitShot = 0.2f;
            Player.instance.koifGun = 0.7f;
            mg.from.localPosition = new Vector2(6, 0.65f);
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[0];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            obj = mg.GetBullet();
            obj.transform.SetPositionAndRotation(vec, where);
            obj.SetActive(true);
        }

        public override void Clear()
        {
        }
    }

    public class ShotGun1 : ModuleSpawnBullets
    {
        Quaternion q;
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 0.7f;
            mg.WaitShot = 0.5f;
            mg.from.localPosition = new Vector2(4.5f, 0.35f);
            Player.instance.koifGun = 0.5f;
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[1];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            for (int i = 0; i < 5; i++)
            {
                obj = mg.GetBullet();
                int j = Random.Range(-10, 10);
                q = Quaternion.Euler(0, 0, j);
                obj.transform.SetPositionAndRotation(vec, where * q);
                obj.SetActive(true);
            }
        }

        public override void Clear()
        {
        }
    }

    public class Aksu2 : ModuleSpawnBullets
    {
        Quaternion q;
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 1;
            mg.WaitShot = 0.15f;
            Player.instance.koifGun = 0.6f;
            mg.from.localPosition = new Vector2(3.3f, 0.6f);
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[2];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            obj = mg.GetBullet();
            int j = Random.Range(-5, 5);
            q = Quaternion.Euler(0, 0, j);
            obj.transform.SetPositionAndRotation(vec, where * q);
            obj.SetActive(true);
        }

        public override void Clear()
        {
        }
    }

    public class Cz3 : ModuleSpawnBullets
    {
        Quaternion q;
        WaitForSeconds wait = new(0.1f);
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 2.5f;
            mg.WaitShot = 0.5f;
            Player.instance.koifGun = 0.5f;
            mg.from.localPosition = new Vector2(1.6f, 0.7f);
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[3];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            mg.Courotine(qq());
        }

        public override void Clear()
        {
        }

        IEnumerator qq()
        {

            for (int i = 0; i < 4; i++)
            {
                mg.shotSound.Play();
                obj = mg.GetBullet();
                int j = Random.Range(-7, 7);
                q = Quaternion.Euler(0, 0, j);
                obj.transform.SetPositionAndRotation(mg.from.position, mg.whereBull * q);
                obj.SetActive(true);
                yield return wait;
            }
        }
    }

    public class DuableShot4 : ModuleSpawnBullets
    {
        Quaternion q;
        WaitForSeconds wait = new(0.1f);

        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 0.5f;
            mg.WaitShot = 1.5f;
            Player.instance.koifGun = 0.6f;
            mg.from.localPosition = new Vector2(4, 0.4f);
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[4];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            mg.Courotine(qq());
        }

        IEnumerator qq()
        {

            for (int i = 0; i < 2; i++)
            {
                mg.shotSound.Play();
                for (int j = 0; j < 5; j++)
                {
                    obj = mg.GetBullet();
                    int w = Random.Range(-10, 10);
                    q = Quaternion.Euler(0, 0, w);
                    obj.transform.SetPositionAndRotation(mg.from.position, mg.whereBull * q);
                    obj.SetActive(true);
                }
                yield return wait;
            }
        }

        public override void Clear()
        {
        }
    }

    public class Pp5 : ModuleSpawnBullets
    {
        Quaternion q;
        WaitForSeconds wait = new(0.1f);
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 2;
            mg.WaitShot = 1f;
            Player.instance.koifGun = 1;
            mg.from.localPosition = new Vector2(3, 0.8f);
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[5];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            mg.Courotine(qq());
        }

        public override void Clear()
        {
        }

        IEnumerator qq()
        {

            for (int i = 0; i < 4; i++)
            {
                mg.shotSound.Play();
                obj = mg.GetBullet();
                int j = Random.Range(-3, 3);
                q = Quaternion.Euler(0, 0, j);
                obj.transform.SetPositionAndRotation(mg.from.position, mg.whereBull * q);
                obj.SetActive(true);
                yield return wait;
            }
        }
    }

    public class Rifle6 : ModuleSpawnBullets
    {
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 1.2f;
            mg.WaitShot = 0.4f;
            Player.instance.koifGun = 1.5f;
            mg.from.localPosition = new Vector2(6, 0.65f);
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[6];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            obj = mg.GetBullet();
            obj.transform.SetPositionAndRotation(vec, where);
            obj.SetActive(true);
        }

        public override void Clear()
        {
        }
    }

    public class RPK7 : ModuleSpawnBullets
    {
        Quaternion q;

        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 1f;
            mg.WaitShot = 0.15f;
            Player.instance.koifGun = 0.8f;
            mg.from.localPosition = new Vector2(4.6f, 0.8f);
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[7];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            obj = mg.GetBullet();
            int j = Random.Range(-8, 8);
            q = Quaternion.Euler(0, 0, j);
            obj.transform.SetPositionAndRotation(vec, where * q);
            obj.SetActive(true);
        }

        public override void Clear()
        {
        }
    }

    public class Val8 : ModuleSpawnBullets
    {
        Quaternion q;

        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 1.2f;
            mg.WaitShot = 0.15f;
            Player.instance.koifGun = 0.5f;
            mg.from.localPosition = new Vector2(4.7f, 0.5f);
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[8];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            obj = mg.GetBullet();
            int j = Random.Range(-2, 2);
            q = Quaternion.Euler(0, 0, j);
            obj.transform.SetPositionAndRotation(vec, where * q);
            obj.SetActive(true);
        }

        public override void Clear()
        {
        }
    }

    public class DualPistol9 : ModuleSpawnBullets
    {
        float a = 0.25f;
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 1.2f;
            mg.WaitShot = 0.2f;
            mg.from.localPosition = new Vector2(3.15f, 0.75f);
            Player.instance.koifGun = 1;
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[9];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            mg.from.localPosition = new Vector2(3.15f, 0.75f + a);
            a *= -1;
            obj = mg.GetBullet();
            obj.transform.SetPositionAndRotation(vec, where);
            obj.SetActive(true);
        }

        public override void Clear()
        {
        }
    }

    public class Blaster10 : ModuleSpawnBullets
    {
        Vector3 g = new(0, 0.8f);
        Vector3 w = new Vector2(4.7f, 1.6f);
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 0.6f;
            mg.WaitShot = 0.4f;
            Player.instance.koifGun = 0.6f;
            mg.from.localPosition = w;
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[10];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            for (int i = 0; i < 3; i++)
            {
                obj = mg.GetBullet();
                obj.transform.SetPositionAndRotation(mg.from.position, where);
                obj.SetActive(true);
                mg.from.localPosition -= g;
            }
            mg.from.localPosition = w;
        }

        public override void Clear()
        {
        }
    }

    public class BMG11 : ModuleSpawnBullets
    {
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 2;
            mg.WaitShot = 1.3f;
            Player.instance.koifGun = 7;
            mg.from.localPosition = new Vector2(6.3f, 0.9f);
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[11];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            obj = mg.GetBullet();
            obj.transform.SetPositionAndRotation(vec, where);
            obj.SetActive(true);
        }

        public override void Clear()
        {
        }
    }

    public class Famas12 : ModuleSpawnBullets
    {
        WaitForSeconds wait = new(0.1f);

        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 1f;
            mg.WaitShot = 1f;
            Player.instance.koifGun = 0.2f;
            mg.from.localPosition = new Vector2(5, 0.8f);
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[12];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            mg.Courotine(qq());
        }

        public override void Clear()
        {
        }

        IEnumerator qq()
        {

            for (int i = 0; i < 4; i++)
            {
                mg.shotSound.Play();
                obj = mg.GetBullet();
                obj.transform.SetPositionAndRotation(mg.from.position, mg.whereBull);
                obj.SetActive(true);
                yield return wait;
            }
        }
    }

    public class FastShot13 : ModuleSpawnBullets
    {
        Quaternion q;
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 0.8f;
            mg.WaitShot = 0.2f;
            mg.from.localPosition = new Vector2(5, 0.35f);
            Player.instance.koifGun = 0.2f;
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[13];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            int j = -10;
            q = Quaternion.Euler(0, 0, j);
            for (int i = 0; i < 3; i++)
            {
                obj = mg.GetBullet();
                obj.transform.SetPositionAndRotation(vec, where * q);
                j += 10;
                q = Quaternion.Euler(0, 0, j);
                obj.SetActive(true);
            }
        }

        public override void Clear()
        {
        }
    }

    public class Uzi14 : ModuleSpawnBullets
    {
        Quaternion q;
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 1.5f;
            mg.WaitShot = 0.1f;
            Player.instance.koifGun = 0.5f;
            mg.from.localPosition = new Vector2(1.8f, 1.4f);
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[14];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            obj = mg.GetBullet();
            int j = Random.Range(-5, 5);
            q = Quaternion.Euler(0, 0, j);
            obj.transform.SetPositionAndRotation(vec, where * q);
            obj.SetActive(true);
        }

        public override void Clear()
        {
        }
    }

    public class MiniGun15 : ModuleSpawnBullets
    {
        Quaternion q;
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 1;
            mg.WaitShot = 0.04f;
            Player.instance.koifGun = 0.5f;
            mg.from.localPosition = new Vector2(5, 0.4f);
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[15];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            obj = mg.GetBullet();
            int j = Random.Range(-5, 5);
            q = Quaternion.Euler(0, 0, j);
            obj.transform.SetPositionAndRotation(vec, where * q);
            obj.SetActive(true);
        }

        public override void Clear()
        {
        }
    }

    public class BlusterTwo16 : ModuleSpawnBullets
    {
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 1;
            mg.WaitShot = 0.03f;
            Player.instance.koifGun = 0.1f;
            mg.from.localPosition = new Vector2(4.5f, 0.45f);
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[16];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            obj = mg.GetBullet();
            obj.transform.SetPositionAndRotation(vec, where);
            obj.SetActive(true);
        }

        public override void Clear()
        {
        }
    }

    public class HzFire17 : ModuleSpawnBullets
    {
        Vector3 g = new(0, 0.6f);
        Vector3 w = new(3.6f, -0.2f);
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 0.6f;
            mg.WaitShot = 0.1f;
            Player.instance.koifGun = 0.6f;
            mg.from.localPosition = w;
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[17];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            for (int i = 0; i < 2; i++)
            {
                obj = mg.GetBullet();
                obj.transform.SetPositionAndRotation(mg.from.position, where);
                obj.SetActive(true);
                mg.from.localPosition -= g;
            }
            mg.from.localPosition = w;
        }

        public override void Clear()
        {
        }
    }

    public class MoreUzi18 : ModuleSpawnBullets
    {
        Quaternion q;
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 1.5f;
            mg.WaitShot = 0.05f;
            Player.instance.koifGun = 0.3f;
            mg.from.localPosition = new Vector2(1.8f, 0.4f);
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[18];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            obj = mg.GetBullet();
            int j = Random.Range(-10, 10);
            q = Quaternion.Euler(0, 0, j);
            obj.transform.SetPositionAndRotation(vec, where * q);
            obj.SetActive(true);
        }

        public override void Clear()
        {
        }
    }

    public class Pistol19 : ModuleSpawnBullets
    {
        Quaternion q;
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 1;
            mg.WaitShot = 0.3f;
            Player.instance.koifGun = 1;
            mg.from.localPosition = new Vector2(1.5f, 0.45f);
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[19];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            obj = mg.GetBullet();
            int j = Random.Range(-10, 10);
            q = Quaternion.Euler(0, 0, j);
            obj.transform.SetPositionAndRotation(vec, where * q);
            obj.SetActive(true);
        }

        public override void Clear()
        {
        }
    }

    public class RailGun20 : ModuleSpawnBullets
    {
        WaitForSeconds wait = new(0.03f);
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 2;
            mg.WaitShot = 0.5f;
            Player.instance.koifGun = 0.5f;
            mg.from.localPosition = new Vector2(5.8f, 0.45f);
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[20];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            mg.Courotine(qq());
        }

        public override void Clear()
        {
        }

        IEnumerator qq()
        {

            for (int i = 0; i < 5; i++)
            {
                mg.shotSound.Play();
                obj = mg.GetBullet();
                obj.transform.SetPositionAndRotation(mg.from.position, mg.whereBull);
                obj.SetActive(true);
                yield return wait;
            }
        }
    }

    public class ShotOne21 : ModuleSpawnBullets
    {
        Quaternion q;
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 0.7f;
            mg.WaitShot = 0.4f;
            mg.from.localPosition = new Vector2(4, 0.6f);
            Player.instance.koifGun = 0.5f;
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[21];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            for (int i = 0; i < 4; i++)
            {
                obj = mg.GetBullet();
                int j = Random.Range(-5, 5);
                q = Quaternion.Euler(0, 0, j);
                obj.transform.SetPositionAndRotation(vec, where * q);
                obj.SetActive(true);
            }
        }

        public override void Clear()
        {
        }
    }

    public class TheeGun22 : ModuleSpawnBullets
    {
        float a = 0.6f;
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 1.2f;
            mg.WaitShot = 0.08f;
            mg.from.localPosition = new Vector2(1.4f, 0.4f);
            Player.instance.koifGun = 1;
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[22];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            mg.from.localPosition = new Vector2(1.4f, 0.4f + a);
            a *= -1;
            obj = mg.GetBullet();
            obj.transform.SetPositionAndRotation(vec, where);
            obj.SetActive(true);
        }

        public override void Clear()
        {
        }
    }

    public class ThreePistol23 : ModuleSpawnBullets
    {
        Quaternion q;
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 0.7f;
            mg.WaitShot = 0.6f;
            mg.from.localPosition = new Vector2(2, 0.55f);
            Player.instance.koifGun = 0.7f;
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[23];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            int j = -10;
            for (int i = 0; i < 3; i++)
            {
                obj = mg.GetBullet();
                q = Quaternion.Euler(0, 0, j);
                obj.transform.SetPositionAndRotation(vec, where * q);
                obj.SetActive(true);
                j += 10;
            }
        }

        public override void Clear()
        {
        }
    }

    public class TwoGun24 : ModuleSpawnBullets
    {
        Quaternion q;
        public override void Use(MoveGun gun)

        {
            mg = gun;
            mg.shotSound.pitch = 0.7f;
            mg.WaitShot = 0.1f;
            mg.from.localPosition = new Vector2(3, 1.75f);
            Player.instance.koifGun = 0.3f;
            mg.spriteRenderer.sprite = mg.GunMng.poolSprites[24];
            mg.FireBegin.transform.localPosition = mg.from.localPosition;
        }

        public override void Spawn(Quaternion where, Vector2 vec)

        {
            float j = -14;
            for (int i = 0; i < 2; i++)
            {
                j *= mg.Pl.transform.localScale.x;
                q = Quaternion.Euler(0, 0, j);
                where *= q;
                obj = mg.GetBullet();
                obj.transform.SetPositionAndRotation(mg.from.position, where);
                obj.SetActive(true);
                j = 20;
                mg.from.localPosition = new Vector2(3, -1);
            }
            mg.from.localPosition = new Vector2(3, 1.75f);
        }

        public override void Clear()
        {
            mg.from.localRotation = Quaternion.identity;
        }
    }
    #endregion

    #region SmallModules

    public abstract class SmallModules
    {
        public abstract string nameq { get; }
        public virtual void TakeBaff(Player pl)
        {
            pl.partHeal.SetActive(true);
            pl.audTakeItem.Play();
        }
    }

    public class MoreDamage : SmallModules
    {
        string damage = "+1% Damage";
        public override string nameq { get { return damage; } }

        public override void TakeBaff(Player pl)
        {
            base.TakeBaff(pl);
            pl.Damage *= 1.01f;
            pl.OnChangeDamage();
        }
    }

    public class MoreSpeed : SmallModules
    {
        string speed = "+1% Speed";
        public override string nameq { get { return speed; } }

        public override void TakeBaff(Player pl)
        {
            base.TakeBaff(pl);
            if (pl.speed < 100) pl.speed *= 1.01f;
        }
    }

    public class MoreJumps : SmallModules
    {
        string jumps = "+1 Jump";
        public override string nameq { get { return jumps; } }

        public override void TakeBaff(Player pl)
        {
            base.TakeBaff(pl);
            pl.maxCountJump += 1;
            pl.countJump = pl.maxCountJump;
            pl.OnChangeJumps();
        }
    }

    public class MoreHp : SmallModules
    {
        string Hp = "+10% Hp";
        public override string nameq { get { return Hp; } }

        public override void TakeBaff(Player pl)
        {
            base.TakeBaff(pl);
            pl.ChangeHp(pl.maxHp / 10);
        }
    }

    public class MoreMaxHp : SmallModules
    {
        string Hp = "+10 MaxHp";
        public override string nameq { get { return Hp; } }

        public override void TakeBaff(Player pl)
        {
            base.TakeBaff(pl);
            pl.maxHp += 10;
            pl.healthBar.SetMaxHp(pl.maxHp);
        }
    }

    #endregion

    public abstract class Enemys : MonoBehaviour
    {
        #region Player Components
        public Player player;
        public Transform PlayerTf;
        #endregion
        #region Components
        public Animator anim;
        public HealthBar healthbar;
        public GameObject particleDeath;
        public Rigidbody2D rb;
        public Transform tf;
        public Transform Check;
        public GameObject buff;
        public ManagerForEn Manager;
        public AudioSource audAttac;
        public AudioSource audTakeDamage;
        public AudioSource audRun;
        public AudioSource audOnSpawn;
        #endregion
        #region ParamsMob
        public float hp;
        public float damage;
        public float speed1;
        public float speed;
        public float koifHpMob;
        public float koifDamageMob;
        public bool WasDead = false;
        #endregion
        public float distanceToPlayer;
        public float distanceToPlayerX;
        public float RangeAttac = 2.1f;
        public bool enterInRangeAttac = false;
        public bool Stop = false;
        public Vector3 sideR = new(1, 1, 1);
        public Vector3 sideL = new(-1, 1, 1);
        public RaycastHit2D right;
        [SerializeField] float Waite = 1;
        protected WaitForSeconds wait;
        public string nameEnemyAttac;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            tf = GetComponent<Transform>();
            rb = GetComponent<Rigidbody2D>();
            speed1 = speed;
            player = Player.instance;
            PlayerTf = player.tf;
        }

        public virtual void OnEnable()
        {
            Manager.CountEnemy++;
            audOnSpawn.Play();
            SetParams();
        }

        public virtual void OnDisable()
        {
            Manager.CountEnemy--;
        }

        private void OnBecameInvisible()
        {
            Invoke(nameof(ActiveFalse), 15);
        }

        private void OnBecameVisible()
        {
            CancelInvoke(nameof(ActiveFalse));
        }

        public virtual void FixedUpdate()
        {
            MainMove();
        }

        void ActiveFalse()
        {
            gameObject.SetActive(false);
        }

        void SetParams()
        {
            WasDead = false;
            enterInRangeAttac = false;
            Stop = false;
            hp = player.Damage * 3 * koifHpMob * Random.Range(0.8f, 1.2f);
            healthbar.SetMaxHp(hp);
            healthbar.SetHp(hp);
            damage = player.maxHp * koifDamageMob * Random.Range(0.8f, 1.2f);
            speed = speed1 * Random.Range(0.8f, 1.2f);
            distanceToPlayer = Vector2.Distance(tf.position, PlayerTf.position);
            distanceToPlayerX = tf.position.x - PlayerTf.position.x;
            wait = new(Waite);
        }

        public virtual void DestroyEnemy()
        {
            if (!WasDead)
            {
                Instantiate(particleDeath, transform.position, Quaternion.identity);
                Manager.GetSoul().transform.SetPositionAndRotation(transform.position, Quaternion.identity);
                Instantiate(buff, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
                WasDead = true;
                player.audEnDead.Play();
            }
        }

        public void RunPlay()
        {
            audRun.Play();
        }

        public virtual void MainMove()
        {
            distanceToPlayer = Vector2.Distance(tf.position, PlayerTf.position);
            distanceToPlayerX = tf.position.x - PlayerTf.position.x;
            right = Physics2D.Linecast(tf.position, Check.position, LayerMask.GetMask("floor"));

            if (distanceToPlayerX <= -RangeAttac)
            {
                Move(sideR, Vector2.right);
            }
            else if (distanceToPlayerX >= RangeAttac)
            {
                Move(sideL, Vector2.left);
            }
            else if (distanceToPlayer < RangeAttac && enterInRangeAttac == false)
            {
                enterInRangeAttac = true;
                anim.SetBool("EnemyRun", false);
                audRun.Stop();
                StartCoroutine(AttacBegun());
            }
        }

        public virtual void Move(Vector3 side, Vector2 vec)
        {
            tf.localScale = side;
            if (right && !Stop)
            {
                tf.Translate(speed * Time.deltaTime * vec);
                anim.SetBool("EnemyRun", true);
            }
            else if (Stop)
            {
                tf.localScale = new Vector3(-side.x, 1, 1);
                tf.Translate(speed * Time.deltaTime * -vec);
                audRun.Stop();
            }
            else if (!right && !Stop)
            {
                StartCoroutine(StopAction());
            }
        }

        public IEnumerator StopAction()
        {
            Stop = true;
            yield return wait;
            Stop = false;
        }

        public void AttacHit()
        {
            if (distanceToPlayer < RangeAttac + 0.3f)
            {
                player.TakeDamage(-damage);
            }
        }

        public void GetDamage(float damage)
        {
            if (!WasDead)
            {
                hp -= damage;
                audTakeDamage.pitch = 1 + Random.Range(-0.2f, 0.2f);
                audTakeDamage.Play();
                if (hp < 0)
                {
                    DestroyEnemy();
                }
                healthbar.SetHp(hp);
            }
        }

        public virtual IEnumerator AttacBegun()
        {
            while (distanceToPlayer < RangeAttac + 0.3f)
            {
                anim.Play(nameEnemyAttac);
                audAttac.Play();
                yield return wait;
            }
            enterInRangeAttac = false;
        }
    }

    public abstract class Bullets : MonoBehaviour
    {
        public float koifBullet;
        public GameObject part;
        public float bulletspeed;
        protected Transform tf;

        private void Awake()
        {
            Stop();
        }
        public virtual void Stop()
        {
            gameObject.SetActive(false);
        }
        public virtual void OnEnable()
        {
            Invoke(nameof(Stop), 3);
        }
        public virtual void OnDisable()
        {
            CancelInvoke();
        }
        public virtual void Start()
        {
            tf = transform;
        }

        private void OnBecameInvisible()
        {
            Stop();
        }

        public virtual void OnTriggerEnter2D(Collider2D collision)
        {
            Intarget(collision);
        }

        public void FixedUpdate()
        {
            Move();
        }

        public virtual void Move()
        {
            tf.Translate(bulletspeed * Time.deltaTime * Vector2.right);
        }

        public virtual void Intarget(Collider2D collision)
        {
            Instantiate(part, transform.position, transform.rotation);
            if (collision.GetComponent<Enemys>()) collision.GetComponent<Enemys>().GetDamage(Player.instance.CurrentDamage);
            Stop();
        }
    }
}