using Interface;
using UnityEngine;
using UnityEngine.UI;

public class LootGun : MonoBehaviour
{
    [SerializeField] ManagerGuns guns;
    SpriteRenderer spriteLoot;
    Sprite sprite;
    MoveGun mg;
    ModuleSpawnBullets currentModule;
    ModuleSpawnBullets module;
    [SerializeField] Button button;
    [SerializeField] AudioSource aud;
    [SerializeField] GameObject part;
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
        choose = Random.Range(0, guns.poolModules.Count);
        spriteLoot.sprite = guns.poolSprites[choose];
        currentModule = guns.poolModules[choose];
    }

    public void TakeLoot()
    {
        part.SetActive(false);
        part.SetActive(true);
        aud.Play();
        mg.module.Clear();
        spriteLoot.sprite = mg.spriteRenderer.sprite;
        (mg.module, currentModule) = (currentModule, mg.module);
        mg.module.Use(mg);
        //(sprite, module) = (mg.spriteRenderer.sprite, mg.module);
        //(mg.spriteRenderer.sprite, mg.module) = (spriteLoot.sprite, currentModule);
        //(spriteLoot.sprite, currentModule) = (sprite, module);
        mg.CurrentGun = choose;
        Player.instance.OnChangeDamage();
    }
}
