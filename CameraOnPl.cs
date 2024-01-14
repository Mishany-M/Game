using UnityEngine;

public class CameraOnPl : MonoBehaviour
{
    [SerializeField] Transform pl;
    [SerializeField] float speedcamera;
    private void FixedUpdate()
    {
        float v = Vector2.Distance(transform.position, pl.position) * speedcamera;
        transform.position = Vector3.Lerp(transform.position, pl.position, Time.deltaTime * v);
    }
}
