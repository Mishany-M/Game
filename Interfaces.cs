using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    #region Modules
    public abstract class ModuleSpawnBullets
    {
        public MoveGun mg;
        public GameObject obj;
        public abstract int choose { get; set; }
        public virtual Color coloritem { get; }
        public abstract float Timershot { get; }

        public abstract void Use(MoveGun gun);
        public abstract void Spawn(Quaternion where, Vector2 vec);
        public virtual void Clear()
        {
            Debug.Log("Clear");
        }
    }
    public class Modul1 : ModuleSpawnBullets
    {
        Color color = new Color(255, 0, 0);
        public int choose1 = 0;
        public override int choose { get => choose1; set => choose1 = value; }
        public override Color coloritem => color;
        private readonly float timershot = 0.2f;
        public override float Timershot { get { return timershot; } }

        public override void Use(MoveGun gun)
        {
            mg = gun;
            mg.from.localPosition = new Vector2(2, 0.043f);
        }

        public override void Spawn(Quaternion where, Vector2 vec)
        {
            if (mg.timer <= 0)
            {
                mg.timer = timershot * mg.timershot;
                mg.shotSound.Play();
                obj = mg.GetBullet();
                obj.transform.SetPositionAndRotation(vec, where);
                obj.SetActive(true);
            }
        }
    }
    public class Modul2 : ModuleSpawnBullets
    {
        Color color = new Color(0, 255, 0);
        public int choose1 = 1;
        public override int choose { get => choose1; set => choose1 = value; }
        public override Color coloritem => color;
        private readonly float timershot = 0.7f;
        public override float Timershot { get { return timershot; } }

        public override void Use(MoveGun gun)
        {
            mg = gun;
            mg.from.localPosition = new Vector2(2, 0.043f);
        }

        public override void Spawn(Quaternion where, Vector2 vec)
        {
            if (mg.timer <= 0)
            {
                Quaternion q;
                mg.timer = timershot * mg.timershot;
                mg.shotSound.Play();
                for (int i = 0; i < 5; i++)
                {
                    obj = mg.GetBullet();
                    int j = Random.Range(-10, 10);
                    q = Quaternion.Euler(0, 0, j);
                    obj.transform.SetPositionAndRotation(vec, where * q);
                    obj.SetActive(true);
                }
            }
        }
    }
    public class Modul3 : ModuleSpawnBullets
    {
        Color color = new Color(0, 0, 255);
        public int choose1 = 2;
        public override int choose { get => choose1; set => choose1 = value; }
        public override Color coloritem => color;
        private readonly float timershot = 0.2f;
        public override float Timershot { get { return timershot; } }

        public override void Use(MoveGun gun)
        {
            mg = gun;
            mg.from.localPosition = new Vector2(1, 0.08f);
        }

        public override void Spawn(Quaternion where, Vector2 vec)
        {
            Quaternion q;
            if (mg.timer <= 0)
            {
                mg.shotSound.Play();
                mg.timer = timershot * mg.timershot;
                obj = mg.GetBullet();
                int j = Random.Range(-12, 12);
                q = Quaternion.Euler(0, 0, j);
                obj.transform.SetPositionAndRotation(vec, where * q);
                obj.SetActive(true);
            }
        }
    }
    public class Modul4 : ModuleSpawnBullets
    {
        Color color = new Color(0, 255, 255);
        public int choose1 = 3;
        public override int choose { get => choose1; set => choose1 = value; }
        public override Color coloritem => color;
        public GameObject cloud;
        private readonly float timershot = 0.1f;
        public override float Timershot { get { return timershot; } }

        public override void Use(MoveGun gun)
        {
            Player.DamageKof *= 0.9f;
            mg = gun;
            mg.from.localPosition = new Vector2(10, 0.043f);
            cloud = mg.Inst(mg.forModules[0]);
        }

        public override void Spawn(Quaternion where, Vector2 vec)
        {
            Vector2 v;
            Quaternion q;
            Vector2 vec1 = new(vec.x, mg.transform.position.y + 5);
            cloud.transform.position = vec1;

            if (mg.timer <= 0)
            {
                mg.shotSound.Play();
                mg.timer = timershot * mg.timershot;
                obj = mg.GetBullet();
                v = new Vector2(vec.x + Random.Range(-1.3f, 1.3f), mg.transform.position.y + 5);
                q = Quaternion.Euler(0, 0, -90);
                obj.transform.SetPositionAndRotation(v, q);
                obj.SetActive(true);
            }
        }

        public override void Clear()
        {
            Player.DamageKof /= 0.9f;
            mg.Destroy1(cloud);
        }
    }
    public class Modul5 : ModuleSpawnBullets
    {
        Color color = new Color(255, 255, 0);
        public int choose1 = 4;
        public override int choose { get => choose1; set => choose1 = value; }
        public override Color coloritem => color;
        private readonly float timershot = 1f;
        public override float Timershot { get { return timershot; } }

        public override void Use(MoveGun gun)
        {
            mg = gun;
            mg.from.localPosition = new Vector2(0, 0.043f);
        }

        public override void Spawn(Quaternion where, Vector2 vec)
        {
            Quaternion q;
            if (mg.timer <= 0)
            {
                mg.shotSound.Play();
                mg.timer = timershot * mg.timershot;
                for (int i = 0; i < 10; i++)
                {
                    obj = mg.GetBullet();
                    q = Quaternion.Euler(0, 0, i * 20);
                    obj.transform.SetPositionAndRotation(vec, q);
                    obj.SetActive(true);
                }
            }
        }
    }
    public class Modul6 : ModuleSpawnBullets
    {
        Color color = new(144, 0, 141);
        public int choose1 = 5;
        public override int choose { get => choose1; set => choose1 = value; }
        public override Color coloritem => color;
        private readonly float timershot = 0.05f;
        public override float Timershot { get { return timershot; } }

        public override void Use(MoveGun gun)
        {
            Player.DamageKof *= 0.3f;
            mg = gun;
            mg.from.localPosition = new Vector2(2.25f, 0.1f);
        }

        public override void Spawn(Quaternion where, Vector2 vec)
        {
            Quaternion q;
            if (mg.timer <= 0)
            {
                mg.shotSound.Play();
                mg.timer = timershot * mg.timershot;
                obj = mg.GetBullet();
                int j = Random.Range(-10, 10);
                q = Quaternion.Euler(0, 0, j);
                obj.transform.SetPositionAndRotation(vec, where * q);
                obj.SetActive(true);

            }
        }

        public override void Clear()
        {
            base.Clear();
            Player.DamageKof /= 0.3f;
        }
    }
    public class Modul7 : ModuleSpawnBullets
    {
        Color color = new Color(255, 0, 141);
        public int choose1 = 6;
        public override int choose { get => choose1; set => choose1 = value; }
        public override Color coloritem => color;
        private readonly float timershot = 0.5f;
        public override float Timershot { get { return timershot; } }

        public override void Use(MoveGun gun)
        {
            Player.DamageKof *= 0.5f;
            mg = gun;
            mg.from.localPosition = new Vector2(2.7f, 0.26f);
        }

        public override void Spawn(Quaternion where, Vector2 vec)
        {
            if (mg.timer <= 0)
            {
                mg.shotSound.Play();
                mg.timer = timershot * mg.timershot;
                obj = mg.GetBullet();
                obj.transform.SetPositionAndRotation(vec, where);
                obj.SetActive(true);
                mg.Begun(obj);
            }
        }

        public override void Clear()
        {
            base.Clear();
            Player.DamageKof /= 0.5f;
        }
    }
    #endregion

    #region SmallModules
    public abstract class SmallModules
    {
        public abstract string Namebuff { get; }
        public abstract void Upgrate(Player pl);
    }
    public class SmallModule1 : SmallModules
    {
        public string namebuff = "Damage + 0.1";
        public override string Namebuff { get { return namebuff; } }
        public override void Upgrate(Player pl)
        {
            Player.DamageKof += 0.1f;
        }
    }
    public class SmallModule2 : SmallModules
    {
        public string namebuff = "MaxHp + 10";
        public override string Namebuff { get { return namebuff; } }
        public override void Upgrate(Player pl)
        {
            pl.MaxHealth += 10;
            pl.healthbar.SetMaxHp(pl.MaxHealth);
        }
    }
    public class SmallModule3 : SmallModules
    {
        public string namebuff = "Speed + 0.1";
        public override string Namebuff { get { return namebuff; } }
        public override void Upgrate(Player pl)
        {
            pl.Speed += 0.1f;
        }
    }
    public class SmallModule4 : SmallModules
    {
        public string namebuff = "RegenHp + 10%";
        public override string Namebuff { get { return namebuff; } }
        public override void Upgrate(Player pl)
        {
            pl.SpeedRegen *= 0.9f;
        }
    }
    public class SmallModule5 : SmallModules
    {
        public string namebuff = "Jumps + 1";
        public override string Namebuff { get { return namebuff; } }
        public override void Upgrate(Player pl)
        {
            pl.CountJump++;
        }
    }
    #endregion

    public interface ITypeAttac
    {
        public void AttacHit();
    }

    public abstract class Enemys : MonoBehaviour, ITypeAttac
    {
        #region Player Components
        public Player player;
        public Rigidbody2D PlayerRb;
        public Transform PlayerTf;
        #endregion
        #region Components
        public Animator anim;
        public HealthBar healthbar;
        public GameObject particleDeath;
        public Rigidbody2D rb;
        public Transform tf;
        public Transform Check;
        public GameObject[] buff;
        public Manager HpManager;
        #endregion 
        public int damage;
        public float hpmax;
        public float hp;
        public int speed;
        public int speedmin;
        public int speedmax;
        public float KoifMob;
        public float distanceToPlayer;
        public float distanceToPlayerX;
        public float RangeAttac = 2;
        public bool enterInRangeAttac = false;
        private bool Stop = false;
        public bool WasDead = false;
        public Vector2 sideR = new(1, 1);
        public Vector2 sideL = new(-1, 1);
        RaycastHit2D right;
        WaitForSeconds wait = new(1);

        public void DestroyEnemy()
        {
            if (!WasDead)
            {
                WasDead = true;
                player.Coins += (int)hpmax / 10;
                player.textCoin.text = "COINS:" + player.Coins;
                Instantiate(particleDeath, transform.position, Quaternion.identity);
                Instantiate(buff[Random.Range(0, buff.Length)], transform.position, Quaternion.identity);
            }
        }
        private void Awake()
        {
            anim = GetComponent<Animator>();
            tf = GetComponent<Transform>();
            rb = GetComponent<Rigidbody2D>();
            player = FindObjectOfType<Player>();
            PlayerRb = player.GetComponent<Rigidbody2D>();
            PlayerTf = player.GetComponent<Transform>();
        }
        void Start()
        {
            speed = Random.Range(speedmin, speedmax);
            damage = (int)(Random.Range(HpManager.MinDamage, HpManager.MaxDamage) * KoifMob);
            hpmax = Random.Range(HpManager.MinHp, HpManager.MaxHp) * KoifMob;
            hp = hpmax;
            healthbar.SetMaxHealth(hpmax);
            distanceToPlayer = Vector2.Distance(tf.position, PlayerTf.position);
            distanceToPlayerX = tf.position.x - PlayerTf.position.x;
        }

        public virtual void FixedUpdate()
        {
            distanceToPlayer = Vector2.Distance(tf.position, PlayerTf.position);
            distanceToPlayerX = tf.position.x - PlayerTf.position.x;
            right = Physics2D.Linecast(tf.position, Check.position, LayerMask.GetMask("floor"));
            if (distanceToPlayerX <= -1.9f)
            {
                Move(sideR, Vector2.right);
            }
            else if (distanceToPlayerX >= 1.9f)
            {
                Move(sideL, Vector2.left);
            }
            else if (distanceToPlayerX < 1.9f && distanceToPlayerX > -1.9f)
            {
                anim.SetBool("EnemyRun", false);
                if (enterInRangeAttac == false && distanceToPlayer < RangeAttac) StartCoroutine(AttacBegun());
            }

            //RaycastHit2D right = Physics2D.Linecast(tf.position, checkRight.position, LayerMask.GetMask("floor"));
        }

        public virtual void Move(Vector2 side, Vector2 vec)
        {
            tf.localScale = side;
            if (right && !Stop)
            {
                tf.Translate(speed * Time.deltaTime * vec);
                anim.SetBool("EnemyRun", true);
            }
            else if (!right && !Stop)
            {
                StartCoroutine(StopAction());
            }
            else if (Stop)
            {
                tf.localScale = new Vector2(-side.x, 1);
                tf.Translate(speed * Time.deltaTime * -vec);
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
            player.Health -= damage;
            if (player.Health < 0 && !player.Dead)
            {
                player.OnDeadMove();
            }
            player.healthbar.SetHealth(player.Health);
            if (!player.particlDeath.activeInHierarchy)
                PlayerRb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            player.particlDeath.SetActive(true);
        }

        public virtual IEnumerator AttacBegun()
        {
            while (distanceToPlayer < RangeAttac)
            {
                enterInRangeAttac = true;
                player.state.ChooseAttac(this);
                yield return wait;
            }
            enterInRangeAttac = false;
        }
    }

    public abstract class Bullets : MonoBehaviour
    {
        public Color colorBullet;
        public float bulletdamage;
        public GameObject part;
        public float bulletspeed;
        protected Vector3 vec;
        Transform tf;

        private void Awake()
        {
            Application.targetFrameRate = 200;
            Stop();
        }
        private void Stop()
        {
            gameObject.SetActive(false);
        }
        private void OnEnable()
        {
            Invoke(nameof(Stop), 3);
        }
        private void OnDisable()
        {
            CancelInvoke();
        }
        private void Start()
        {
            tf = transform;
        }

        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }

        public virtual void OnTriggerEnter2D(Collider2D collision)
        {
            Intarget(collision);
        }

        public virtual void FixedUpdate()
        {
            Move();
        }

        public virtual void Move()
        {
            tf.Translate(Vector2.right * bulletspeed * Time.deltaTime);
        }

        public virtual void Intarget(Collider2D collision)
        {
            Instantiate(part, transform.position, transform.rotation);
            gameObject.SetActive(false);
            if (collision.GetComponent<Enemys>()) Damage(collision.GetComponent<Enemys>());
        }

        public virtual void Damage(Enemys enemy)
        {
            enemy.hp -= bulletdamage * Player.DamageKof;
            Debug.Log(bulletdamage * Player.DamageKof);
            if (enemy.hp < 0)
            {
                enemy.DestroyEnemy();
                Destroy(enemy.gameObject);
            }
            enemy.healthbar.SetHealth(enemy.hp);
        }
    }

    public class Save
    {
        public int CurrentScene;
        public List<ModuleSpawnBullets> pool = new() { new Modul1(), new Modul2(), new Modul3(), new Modul4(), new Modul5(), new Modul6(), new Modul7() };
        public Sprite sprite;
        public int Coins;
        public int Choose;
    }
}
