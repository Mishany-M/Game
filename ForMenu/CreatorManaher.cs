using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class CreatorManaher : MonoBehaviour
{
    public GameObject manager;
    public Saves saves;
    public GameObject panal;
    public GameObject panalAccept;
    public GameObject ContinueLvl;
    public Slider sliderSound;
    public Slider sliderMusic;
    public AudioMixerGroup Audio;
    public AudioSource audButton;
    public AudioSource audMusic;
    public ManagerAud audManager;

    private void Awake()
    {
        saves = FindObjectOfType<Saves>();
        if (!saves)
        {
            manager = Instantiate(manager);
            saves = manager.GetComponent<Saves>();
        }
        saves.Continue = ContinueLvl;
        saves.cm = this;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            ContinueLvl.SetActive(true);
        }
        ChangeValue();
        ChangeMusic();
        ChangeSound();
    }

    public void PlayAud()
    {
        audButton.Play();
    }

    public void ChangeSound()
    {
        Audio.audioMixer.SetFloat("sound", sliderSound.value);
        saves.ValueSound = sliderSound.value;
    }

    public void ChangeMusic()
    {
        Audio.audioMixer.SetFloat("music", sliderMusic.value);
        saves.ValueMusic = sliderMusic.value;
    }

    public void ChangeValue()
    {
        sliderSound.value = saves.ValueSound;
        sliderMusic.value = saves.ValueMusic;
    }

    public void LoadLevel(int level)
    {
        PlayAud();
        saves.LoadLevel(level);
    }

    public void Yes()
    {
        PlayAud();
        saves.ResetData();
        panalAccept.SetActive(false);
    }

    public void No()
    {
        PlayAud();
        panalAccept.SetActive(false);
    }

    public void ActivePanal()
    {
        PlayAud();
        if (panalAccept.activeSelf)
        {
            panalAccept.SetActive(false);
        }
        else
        {
            panalAccept.SetActive(true);
        }
    }

    public void Continue()
    {
        PlayAud();
        saves.LoadLevel(saves.SavedLvl);
    }

    public void OpenPanal()
    {
        PlayAud();
        if (panal.activeSelf)
        {
            panal.SetActive(false);
        }
        else
        {
            panal.SetActive(true);
        }
    }
}
