using UnityEngine;

public class Medical : MonoBehaviour
{
    Player pl;
    public float heal = 0.1f;
    private void Start()
    {
        pl = FindObjectOfType<Player>();
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (pl.Health < pl.MaxHealth)
            {
                pl.Health += pl.MaxHealth * heal;
                pl.healthbar.SetHealth(pl.Health);
            }
            Destroy(gameObject);
        }
    }
}
