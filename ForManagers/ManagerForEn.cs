using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyHpManager", menuName = "Managers/EnemyHpManager")]
public class ManagerForEn : ScriptableObject
{
    public Transform plTf;
    public Player pl;
    public int ChestPrice;
    public int CountEnemy = 0;
    public float TimeSpawn = 10;
    public float MinTimeSpawn = 4;
    public float koifMob = 1;
    public float Volume = -20;
    public MoveGun mg;
    [SerializeField] GameObject Soul;
    public List<GameObject> souls = new();
    readonly bool isfill = true;

    public GameObject GetSoul()
    {
        if (souls[0] == null) souls.Clear();
        for (int i = 0; i < souls.Count; i++)
        {
            if (!souls[i].activeInHierarchy)
            {
                souls[i].SetActive(true);
                return souls[i];
            }
        }
        if (isfill)
        {
            GameObject obj = Instantiate(Soul);
            souls.Add(obj);
            obj.SetActive(true);
            return obj;
        }
        return null;
    }

    public void UpKoif()
    {
        koifMob += 0.003f;
        if (TimeSpawn > MinTimeSpawn)
            TimeSpawn -= 0.1f;
    }

    public void Defoult()
    {
        TimeSpawn = 10;
        koifMob = 1;
        ChestPrice = 11;
    }
}
