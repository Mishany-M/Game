using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public Manager HpManager;
    public GameObject partSpawn;
    public float frequencySpawn = 5;
    public bool spawn = true;

    private void Awake()
    {
        StartCoroutine(Spawn());
    }

    public void Switch()
    {
        if (spawn)
        {
            spawn = false;
            StopCoroutine(Spawn());
        }
        else
        {
            spawn = true;
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        WaitForSeconds wait = new(frequencySpawn);
        while (spawn)
        {
            yield return wait;

            if (Vector2.Distance(transform.position, HpManager.pl.position) < 40)
            {
                partSpawn.SetActive(true);
                Instantiate(enemy[Random.Range(0, enemy.Length)], transform.position, Quaternion.identity);
                HpManager.MaxHp += 1;
            }
        }
    }
}
