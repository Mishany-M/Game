using System.Collections;
using UnityEngine;

public class pltf : MonoBehaviour
{
    public bool Vector;
    public int Speed;
    public float TimeReverse;
    public Vector2 side = Vector2.right;
    public Vector2 side1 = Vector2.up;

    private void Start()
    {
        StartCoroutine(Each());
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("boots"))
        {
            Saves.instance.fullPlayer.transform.parent = transform;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("boots"))
        {
            Saves.instance.fullPlayer.transform.parent = null;
            DontDestroyOnLoad(Saves.instance.fullPlayer);
        }
    }

    private void FixedUpdate()
    {
        if (Vector)
        {
            transform.Translate(Speed * Time.deltaTime * side);
        }
        else
        {
            transform.Translate(Speed * Time.deltaTime * side1);
        }
    }

    IEnumerator Each()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeReverse);
            side *= -1;
            side1 *= -1;
            //if (Vector) Vector = false; else Vector = true;
        }
    }
}
