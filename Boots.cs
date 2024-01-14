using UnityEngine;

public class Boots : MonoBehaviour
{
    [SerializeField] Player pl;

    float damage = 0;

    void OnSeet()
    {
        pl.onFloor = true;
        pl.countJump = pl.maxCountJump;
        pl.anim.SetBool("Jump", false);
        if (pl.speedFall < -80)
        {
            damage = pl.speedFall * pl.speedFall * pl.speedFall * pl.maxHp / 10000000;
            pl.TakeDamage(damage);
            pl.speedFall = 0;
            pl.partSeet.SetActive(true);
        }
        pl.OnChangeJumps();
    }

    void OnJump()
    {
        pl.onFloor = false;
        pl.anim.SetBool("Jump", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("floor")) OnSeet();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("floor")) OnJump();
    }
}
