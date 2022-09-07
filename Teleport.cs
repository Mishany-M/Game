using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    public Slider slider;
    public Button button;
    public Text text;
    public bool down = false;
    public int nextScene;
    public Player pl;
    public LoadScene loadScene;
    public Sprite[] spr;
    public ChooseModule chooseModule;

    private void Start()
    {
        pl = FindObjectOfType<Player>();
        loadScene = FindObjectOfType<LoadScene>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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
    public void Use()
    {
        down = true;
        StartCoroutine(Repit());
    }

    public void NotUse()
    {
        down = false;
        StopCoroutine(Repit());
    }

    IEnumerator Repit()
    {
        while (down)
        {
            if (pl.Coins > 0 && slider.value < 1)
            {
                pl.Coins -= 1;
                slider.value += 0.01f;
                pl.UpdateCoins();
                yield return null;
            }
            else if (pl.Coins <= 0)
            {
                text.text = "NoMoney";
                yield return new WaitForSeconds(1);
                text.text = "Fill";
            }
            else
            {
                text.text = "ToTheMoon";
                chooseModule.Choose();
                yield return new WaitForSeconds(5);
                pl.SaveGame(nextScene);
                loadScene.LoadGameScene();
            }
        }
    }
}
