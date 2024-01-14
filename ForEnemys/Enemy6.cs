using Interface;
using System.Collections;
using UnityEngine;

public class Enemy6 : Enemys
{

    Vector3 vec = new Vector3(0,0);

    void Start()
    {
        StartCoroutine(Moving());
        vec = (player.transform.position - transform.position).normalized * 15;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) player.TakeDamage(-damage);
    }

    void Move()
    {
        rb.velocity = Vector3.Lerp(rb.velocity, vec, Time.deltaTime * 2);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, rb.velocity.x * -1.5f), Time.deltaTime * 3);
    }

    public override void FixedUpdate()
    {
        Move();
    }

    public IEnumerator Moving()
    {
        while (true)
        {
            vec = (player.transform.position - transform.position).normalized * speed;
            yield return new WaitForSeconds(2);
        }
    }
}
