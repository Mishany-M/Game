using Interface;
using UnityEngine;

public class Enemy9 : Enemys
{
    Vector2 direction;
    Vector3 side;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) player.TakeDamage(-damage);
    }

    public override void MainMove()
    {
        distanceToPlayer = Vector2.Distance(tf.position, PlayerTf.position);
        distanceToPlayerX = tf.position.x - PlayerTf.position.x;
        right = Physics2D.Linecast(tf.position, Check.position, LayerMask.GetMask("floor"));

        if (distanceToPlayerX >= RangeAttac)
        {
            direction = Vector2.left;
            side = sideL;
        }
        else if (distanceToPlayerX <= -RangeAttac)
        {
            direction = Vector2.right;
            side = sideR;
        }
        Move(side, direction);
    }

    public override void Move(Vector3 side, Vector2 vec)
    {
        tf.localScale = side;
        if (right && !Stop)
        {
            tf.Translate(speed * Time.deltaTime * vec);
        }
        else if (Stop)
        {
            tf.localScale = new Vector3(-side.x, 1, 1);
            tf.Translate(speed * Time.deltaTime * -vec);
        }
        else if (!right && !Stop)
        {
            StartCoroutine(StopAction());
        }
    }
}
