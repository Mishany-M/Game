using UnityEngine;
using UnityEngine.UI;

public class Capsule : MonoBehaviour
{
    public int Price;
    public Button button;
    public GameObject part;
    public Manager PriceManager;
    public Sprite spriteOpen;
    public bool active = true;
    Player pl;
    private void Start()
    {
        pl = FindObjectOfType<Player>();
        Price = PriceManager.ChestPrice / 2 + Random.Range(-PriceManager.ChestPrice / 2 + 5, PriceManager.ChestPrice / 2);
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
        part.SetActive(true);
        pl.Coins += Price;
        pl.textCoin.text = "COINS:" + pl.Coins;
        GetComponent<SpriteRenderer>().sprite = spriteOpen;
        button.gameObject.SetActive(false);
        active = false;
    }
}
