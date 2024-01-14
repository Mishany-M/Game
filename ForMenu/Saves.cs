using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class ForSave
{
    public float hp;
    public int soul;
    public int MaxSoul;
    public float maxHp;
    public float PowerForce;
    public float koifGun;
    public float koifBullet;
    public float Damage;
    public int idGun;
    public int idGun1;
    public int idBullet;
    public int idBullet1;
    public float speed;
    public int maxCountJump;
    public int countJump;
    public int CurrentLevel;
}

[Serializable]
public class SaveSound
{
    public float ValueMusic;
    public float ValueSound;
}

public class Saves : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    public GameObject fullPlayer;
    public GameObject Loading;
    public Animator animLoad;
    public ManagerGuns managerGuns;
    public CreatorManaher cm;
    public Player pl;
    public static Saves instance;
    public bool loadingScene = false;
    public AsyncOperation loading;
    public int CurrentLvl;
    public int SavedLvl;
    public GameObject Continue;
    public float ValueMusic;
    public float ValueSound;

    private void OnApplicationQuit()
    {
        SaveSound();
    }

    private void Awake()
    {
        instance = this;
        LoadSound();
        SceneManager.sceneLoaded += OnLoadLvl;
        Loading = Instantiate(Loading);
        animLoad = Loading.GetComponentInChildren<Animator>();
        fullPlayer = Instantiate(player);
        pl = FindObjectOfType<Player>();
        fullPlayer.SetActive(false);
        Loading.SetActive(false);
        DontDestroyOnLoad(fullPlayer);
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(Loading);
    }

    private void Start()
    {
        Load();
        if (cm != null)
        {
            cm.ChangeValue();
            cm.ChangeMusic();
            cm.ChangeSound();
        }
    }

    public void OnLoadLvl(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex != 0)
        {
            fullPlayer.SetActive(true);
            Transform a = GameObject.FindGameObjectWithTag("StartPos").transform;
            pl.ResetHp();
            if (a == null)
            {
                pl.gameObject.transform.position = new Vector3(0, 0, 0);
            }
            else
            {
                pl.gameObject.transform.position = a.position;
            }
        }
        else fullPlayer.SetActive(false);

        Loading.GetComponent<Canvas>().worldCamera = Camera.main;
    }

    public void LoadLvl()
    {
        loading = SceneManager.LoadSceneAsync(CurrentLvl);
    }

    public void LoadLevel(int level)
    {
        if (!loadingScene)
        {
            if (level != 0) SavedLvl = level;
            CurrentLvl = level;
            Loading.SetActive(true);
        }
    }

    public void SaveSound()
    {
        SaveSound data = new SaveSound
        {
            ValueMusic = ValueMusic,
            ValueSound = ValueSound
        };
        PlayerPrefs.SetString("SaveSound", JsonUtility.ToJson(data));
    }

    public void LoadSound()
    {
        if (PlayerPrefs.HasKey("SaveSound"))
        {
            SaveSound data = JsonUtility.FromJson<SaveSound>(PlayerPrefs.GetString("SaveSound"));
            ValueSound = data.ValueSound;
            ValueMusic = data.ValueMusic;
        }
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            try
            {

                //ForSave save = new();
                //DataContractSerializer xmlSerializer = new DataContractSerializer(save.GetType());
                //ForSave data = (ForSave)xmlSerializer.ReadObject(file);
                //XmlSerializer xml = new XmlSerializer(save.GetType());
                //StreamReader srm = new StreamReader(file);
                //ForSave data = (ForSave)xml.Deserialize(XmlReader.Create(file));
                ForSave data = JsonUtility.FromJson<ForSave>(PlayerPrefs.GetString("Save"));
                pl.Gun.module = managerGuns.poolModules[data.idGun];
                pl.Gun.GetComponent<SpriteRenderer>().sprite = managerGuns.poolSprites[data.idGun];
                pl.Gun.module.Use(pl.Gun);
                pl.Gun.module1 = managerGuns.poolModules[data.idGun1];
                pl.Gun.CurrentBullet = data.idBullet;
                pl.Gun.SecondBullet = data.idBullet1;
                pl.Gun.bulletUse = managerGuns.poolBullets[data.idBullet];
                pl.Gun.bulletUse1 = managerGuns.poolBullets[data.idBullet1];
                pl.speed = data.speed;
                pl.soul = data.soul;
                pl.countJump = data.countJump;
                pl.maxCountJump = data.maxCountJump;
                pl.koifGun = data.koifGun;
                pl.koifBullet = data.koifBullet;
                pl.Damage = data.Damage;
                pl.hp = data.hp;
                pl.maxHp = data.maxHp;
                pl.PowerForce = data.PowerForce;
                pl.MaxSoul = data.MaxSoul;
                SavedLvl = data.CurrentLevel;
                Continue.SetActive(true);
            }
            catch (Exception ex)
            {
                Debug.Log(ex + " FailLoad");
            }
        }
    }

    public void Save()
    {
        try
        {
            ForSave data = new()
            {
                MaxSoul = pl.MaxSoul,
                hp = pl.hp,
                maxHp = pl.maxHp,
                soul = pl.soul,
                PowerForce = pl.PowerForce,
                koifBullet = pl.koifBullet,
                koifGun = pl.koifGun,
                Damage = pl.Damage,
                speed = pl.speed,
                countJump = pl.countJump,
                maxCountJump = pl.maxCountJump,
                idGun = pl.Gun.CurrentGun,
                idGun1 = pl.Gun.SecondGun,
                idBullet = pl.Gun.CurrentBullet,
                idBullet1 = pl.Gun.SecondBullet,
                CurrentLevel = SavedLvl,
            };

            PlayerPrefs.SetString("Save", JsonUtility.ToJson(data));
            //FileStream file =
            //File.Create(Application.persistentDataPath + "/MySaveData.dat");
            //DataContractSerializer bf = new DataContractSerializer(data.GetType());
            //MemoryStream streamer = new MemoryStream();
            //bf.WriteObject(streamer, data);
            //streamer.Seek(0, SeekOrigin.Begin);
            //file.Write(streamer.GetBuffer(), 0, streamer.GetBuffer().Length);
            //file.Close();
        }
        catch (Exception ex)
        {
            Debug.LogError(ex + "FailedSave");
        }
    }

    public void ResetData()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            PlayerPrefs.DeleteKey("Save");
        }
        else
            Debug.LogError("No save data to delete.");
    }
}