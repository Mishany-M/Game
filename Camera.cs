using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    Vector2 qq;
    Vector2 ww;
    Transform cachetransform;

    private void Awake()
    {
        cachetransform = transform;
        cachetransform.position = player.position;
    }
    private void Start()
    {
        transform.position = new Vector2(player.position.x, player.position.y + 5);
    }

    void FixedUpdate()
    {
        qq = new Vector2(player.position.x, player.position.y + 5);
        ww = Vector2.Lerp(cachetransform.position, qq, 12 * Time.deltaTime);
        cachetransform.position = ww;
    }
}
