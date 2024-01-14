using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChestGun : MonoBehaviour
{
    public int Price;
    public Button button;
    public Text text;
    public ManagerForEn PriceManager;
    public Sprite spriteOpen;
    public GameObject Gun;
    public GameObject Bullet;
    public SpriteRenderer sprite;
    [SerializeField] AudioSource aud;
    public bool Whichitem;
    public bool active = true;

    private void Start()
    {
        text.text += Price.ToString();
        if(Whichitem) sprite.color = Color.white;
        else sprite.color = Color.green;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && active)
        {
            button.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            button.gameObject.SetActive(false);
        }
    }
    public void Take()
    {
        if (PriceManager.pl.soul >= Price)
        {
            aud.Play();
            PriceManager.pl.OnChangeSoul(-Price);
            GetComponent<SpriteRenderer>().sprite = spriteOpen;
            if (Whichitem)
                Instantiate(Gun, transform.position, Quaternion.identity);
            else
                Instantiate(Bullet, transform.position, Quaternion.identity);
            button.gameObject.SetActive(false);
            text.gameObject.SetActive(false);
            active = false;
        }
        else
        {
            StartCoroutine(NoMoney());
        }
    }
    public IEnumerator NoMoney()
    {
        text.text = "No Souls";
        yield return new WaitForSeconds(1);
        text.text = "Souls:" + Price.ToString();
    }
}