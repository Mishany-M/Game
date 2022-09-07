using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public int Price;
    public Button button;
    public GameObject part;
    public Text text;
    public Manager PriceManager;
    public Sprite spriteOpen;
    public List<GameObject> drop = new();
    public bool active = true;
    Player pl;
    private void Start()
    {
        Price = PriceManager.ChestPrice;
        text.text += Price.ToString();
        pl = FindObjectOfType<Player>();
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
        if (pl.Coins >= Price)
        {
            part.SetActive(true);
            pl.Coins -= Price;
            pl.textCoin.text = "COINS:" + pl.Coins;
            PriceManager.ChestPrice += 10;
            GetComponent<SpriteRenderer>().sprite = spriteOpen;
            Instantiate(drop[Random.Range(0, drop.Count)], transform.position, Quaternion.identity);
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
        text.text = "No Money";
        yield return new WaitForSeconds(1);
        text.text = "COINS:" + Price.ToString();
    }
}
