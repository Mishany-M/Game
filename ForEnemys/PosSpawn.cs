using UnityEngine;

public class PosSpawn : MonoBehaviour
{
    public bool plIn;
    public bool shouldAdctive;
    [SerializeField] PosSpawn left;
    [SerializeField] PosSpawn right;
    EnemySpawner spawner;

    private void Start()
    {
        spawner = FindObjectOfType<EnemySpawner>();
    }

    void Enter(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (left != null)
            {
                if (!left.plIn)
                {
                    spawner.posSpawn.Add(left.transform.position);
                }
                left.shouldAdctive = true;
            }
            if (right != null)
            {
                right.shouldAdctive = true;
                if (!right.plIn)
                {
                    spawner.posSpawn.Add(right.transform.position);
                }
            }
            plIn = true;
            spawner.posSpawn.Remove(transform.position);
        }
    }

    void Exit(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (left != null)
            {
                left.shouldAdctive = false;
                spawner.posSpawn.Remove(left.transform.position);
            }
            if (right != null)
            {
                right.shouldAdctive = false;
                spawner.posSpawn.Remove(right.transform.position);
            }
            plIn = false;
            if (shouldAdctive)
            {
                spawner.posSpawn.Add(transform.position);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enter(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Exit(collision);
    }
}
