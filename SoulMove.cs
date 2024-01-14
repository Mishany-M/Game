using UnityEngine;

public class SoulMove : MonoBehaviour
{
    [SerializeField] ManagerForEn mng;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mng.pl.OnChangeSoul(1);
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, mng.plTf.position, Time.deltaTime * 30);
    }
}
