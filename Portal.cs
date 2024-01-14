using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    public Button button;
    public AudioSource audReadyPortal;
    public GameObject partReady;
    public UnityEngine.UI.Text text;
    [SerializeField] AudioSource aud;
    public bool active = false;
    public bool Done = false;
    public bool Started = false;
    public Player player;
    public Saves saves;
    public ParticleSystem ps;
    public List<Transform> pos = new();
    public ParticleSystem.MainModule mainModule;
    public GameObject Chest;
    public int CountSouls = 0;
    public int NextLvl;
    public int needSouls;

    private void Awake()
    {
        int w = Random.Range(0, pos.Count);
        int h = Random.Range(1, pos.Count - 1);

        transform.position = pos[w].position;
        pos.Remove(pos[w]);

        for(int i = 0; i < h; ++i)
        {
            int q = Random.Range(0, pos.Count);
            if(i % 2  == 0)
            Instantiate(Chest, pos[q].position - new Vector3(0, 3.3f), Quaternion.identity).GetComponent<ChestGun>().Whichitem = true;
            else Instantiate(Chest, pos[q].position - new Vector3(0, 3.3f), Quaternion.identity).GetComponent<ChestGun>().Whichitem = false;
            pos.Remove(pos[q]);
        }
    }

    private void Start()
    {
        saves = Saves.instance;
        NextLvl = saves.SavedLvl;
        if (NextLvl < SceneManager.sceneCountInBuildSettings - 1) NextLvl++;
        else NextLvl = 1;
        text.text += CountSouls.ToString();
        player = Player.instance;
        mainModule = ps.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            button.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            button.gameObject.SetActive(false);
    }

    public void OnDown()
    {
        active = true;
        if (!Started) StartCoroutine(GetSouls());
    }

    public void OnUp()
    {
        active = false;
    }

    IEnumerator GetSouls()
    {
        Started = true;
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (active && CountSouls != needSouls && player.soul > 0)
        {
            player.soul--;
            CountSouls++;
            text.text = "souls: " + CountSouls.ToString();
            player.healthBar.SetSoul(player.soul);
            mainModule.maxParticles++;
            aud.pitch = 1;
            aud.pitch += Random.Range(-0.2f, 0.2f);
            aud.Play();
            yield return wait;
        }
        if (CountSouls == needSouls)
        {
            Done = true;
            text.text = "Done";
            player.Dead = true;
            audReadyPortal.Play();
            partReady.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            saves.LoadLevel(NextLvl);
            saves.Save();
        }
        Started = false;
    }
}
