using Interface;
using UnityEngine;
using UnityEngine.UI;

public class SmallBuff : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] ManagerGuns mng;
    SmallModules sm;

    private void Start()
    {
        sm = mng.smallModules[Random.Range(0, 5)];
        text.text = sm.nameq;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sm.TakeBaff(Player.instance);
            Destroy(gameObject);
        }
    }
}
