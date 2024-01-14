using Interface;
using System.Collections;
using UnityEngine;

public class Enemy3 : Enemys
{
    public float PowerJump;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            anim.SetBool("EnemyAttac", false);
            if (distanceToPlayer < RangeAttac) AttacHit();
        }
    }

    public override IEnumerator AttacBegun()
    {
        while (distanceToPlayer < RangeAttac + 0.3f)
        {
            anim.SetBool("EnemyAttac", true);
            audAttac.Play();
            rb.AddForce(PowerJump * tf.localScale, ForceMode2D.Impulse);
            anim.Play("EnemyAttac3");
            yield return wait;
        }
        enterInRangeAttac = false;
    }
}
