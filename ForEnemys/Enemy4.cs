using System.Collections;
using UnityEngine;
using Interface;

public class Enemy4 : Enemys
{
    public float PowerJump;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) AttacHit();
    }
    public override IEnumerator AttacBegun()
    {
        if (distanceToPlayerX < 0) tf.localScale = sideR;
        else tf.localScale = sideL;
        anim.SetBool("EnemyAttac", true);
        rb.AddForce(PowerJump * tf.localScale, ForceMode2D.Impulse);
        yield return wait;
        anim.SetBool("EnemyAttac", false);
        yield return wait;
        enterInRangeAttac = false;
    }
}
