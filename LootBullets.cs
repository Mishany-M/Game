using Interface;
using UnityEngine;
using UnityEngine.UI;

public class LootBullets : MonoBehaviour
{
    [SerializeField] ManagerGuns guns;
    SpriteRenderer spriteLoot;
    MoveGun mg;
    [SerializeField] Button button;
    [SerializeField] AudioSource aud;
    [SerializeField] GameObject part;
    public GameObject bullet;
    int choose;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) button.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) button.gameObject.SetActive(false);
    }
    private void Start()
    {
        mg = MoveGun.instance;
        spriteLoot = GetComponent<SpriteRenderer>();
        choose = Random.Range(0, guns.poolBullets.Count);
        bullet = guns.poolBullets[choose];
        spriteLoot.color = bullet.GetComponent<SpriteRenderer>().color;
    }

    public void TakeLoot()
    {
        part.SetActive(false);
        part.SetActive(true);
        aud.Play();
        spriteLoot.color = mg.bulletUse.GetComponent<SpriteRenderer>().color;
        (mg.bulletUse, bullet) = (bullet, mg.bulletUse);
        foreach(GameObject a in mg.pooledbullets)
        {
            Destroy(a);
        }
        mg.pooledbullets.Clear();
        Player.instance.koifBullet = mg.bulletUse.GetComponent<Bullets>().koifBullet;
        Player.instance.OnChangeDamage();
        mg.CurrentBullet = choose;
        mg.SetColor();
    }
}
