using UnityEngine;

public class Platforms : MonoBehaviour
{
    public Vector2 qq;
    public Vector2 qq1;
    public short EnableX;
    public short EnableY;
    public int radiousX = 10;
    public int radiousY = 10;
    public int speed = 2;

    void Awake()
    {
        qq1 = new Vector2(transform.position.x, transform.position.y);
        qq = new Vector2(transform.position.x, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.parent = transform;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.parent = null;
    }

    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + speed * EnableX * Time.deltaTime, transform.position.y + speed * EnableY * Time.deltaTime);
        if (transform.position.y > qq1.y + radiousY && EnableY > 0) EnableY *= -1;
        else if (transform.position.y < qq1.y - radiousY && EnableY < 0) EnableY *= -1;
        if (transform.position.x > qq.x + radiousX && EnableX > 0) EnableX *= -1;
        else if (transform.position.x < qq.x - radiousX && EnableX < 0) EnableX *= -1;
    }
}
