using Interface;
using UnityEngine;

public class Enemy8 : Enemys
{
    float rot;
    public GameObject partOnPush;
    Vector2 vec;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) player.TakeDamage(-damage);
    }

    public override void MainMove()
    {
        vec = player.tf.position - transform.position;
        rot = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, rot), Time.deltaTime * 2);
    }

    public void Push()
    {
        partOnPush.SetActive(true);
        rb.AddForce(vec.normalized * speed, ForceMode2D.Impulse);
    }
}
