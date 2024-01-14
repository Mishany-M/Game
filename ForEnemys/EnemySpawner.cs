using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    readonly bool isfill = true;
    WaitForSeconds wait;
    WaitForSeconds waitFES;
    [SerializeField] bool ActiveSpawn;
    [SerializeField] float TimeSpawn = 10;
    [SerializeField] ManagerForEn mngEn;
    [SerializeField] GameObject[] EnemyPool;
    [SerializeField] GameObject[] EnemyPoolFES;
    [SerializeField] GameObject PartSpawn;
    [SerializeField] GameObject PartSpawn1;
    [SerializeField] int[] chance;
    [SerializeField] int MaxCountSpawn;
    [SerializeField] int MaxCountSpawnFES;
    public List<Vector3> posSpawn = new();
    public List<Transform> posAbsoluteSpawn = new();
    [SerializeField] int[] chanceFES;
    Dictionary<GameObject, List<GameObject>> EnDictionary = new();
    Dictionary<GameObject, List<GameObject>> EnDictionaryFES = new();

    private void Start()
    {
        TimeSpawn = mngEn.TimeSpawn;

        foreach (GameObject a in EnemyPool)
        {
            EnDictionary.Add(a, new List<GameObject>());
        }

        foreach (GameObject a in EnemyPoolFES)
        {
            EnDictionaryFES.Add(a, new List<GameObject>());
        }
        StartCoroutine(WaitSpawn());
        StartCoroutine(WaitSpawnFES());
    }

    public GameObject GetEnemy(List<GameObject> pool, GameObject en)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }
        if (isfill)
        {
            GameObject obj = Instantiate(en);
            pool.Add(obj);
            return obj;
        }
        return null;
    }

    IEnumerator WaitSpawnFES()
    {
        waitFES = new WaitForSeconds(10);
        yield return waitFES;

        while (true)
        {
            if (ActiveSpawn)
            {
                if (posSpawn.Count == 0)
                    waitFES = new WaitForSeconds(TimeSpawn / 2);
                else waitFES = new WaitForSeconds(TimeSpawn);

                foreach (Transform a in posAbsoluteSpawn)
                {
                    for (int j = 0; j < Random.Range(1, MaxCountSpawnFES); j++)
                    {
                        int c = Random.Range(0, 101);
                        for (int i = 0; i < EnemyPoolFES.Length; i++)
                        {
                            if (c < chance[i])
                            {
                                GameObject v = GetEnemy(EnDictionaryFES[EnemyPoolFES[i]], EnemyPoolFES[i]);
                                v.transform.position = a.position + new Vector3(Random.Range(-5, 5), 0);
                                v.SetActive(true);
                                Instantiate(PartSpawn, v.transform.position, Quaternion.identity);
                                mngEn.UpKoif();
                                break;
                            }
                        }
                    }
                }
            }
            yield return waitFES;
        }
    }

    IEnumerator WaitSpawn()
    {
        wait = new WaitForSeconds(10);
        yield return wait;

        while (true)
        {
            if (ActiveSpawn)
            {
                if (mngEn.CountEnemy < 10)
                    wait = new WaitForSeconds(TimeSpawn / 2);
                else wait = new WaitForSeconds(TimeSpawn);

                foreach (Vector3 a in posSpawn)
                {
                    for (int j = 0; j < Random.Range(1, MaxCountSpawn); j++)
                    {
                        int c = Random.Range(0, 101);
                        for (int i = 0; i < EnemyPool.Length; i++)
                        {
                            if (c < chance[i])
                            {
                                GameObject v = GetEnemy(EnDictionary[EnemyPool[i]], EnemyPool[i]);
                                v.transform.position = a + new Vector3(Random.Range(-5, 5), 0);
                                v.SetActive(true);
                                Instantiate(PartSpawn1, v.transform.position, Quaternion.identity);
                                mngEn.UpKoif();
                                break;
                            }
                        }
                    }
                }
            }
            yield return wait;
        }
    }
}
