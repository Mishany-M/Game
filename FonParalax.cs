using UnityEngine;

public class FonParalax : MonoBehaviour
{
    public Transform TargetPos;
    public Transform Layer1;
    public Transform Layer2;
    public Transform Layer3;
    public float paralax1;
    public float paralax2;
    public float paralax3;
    public Vector3 previosPos;

    private void Start()
    {
        TargetPos = Player.instance.transform;
        previosPos = TargetPos.position;
    }

    private void FixedUpdate()
    {
        Vector3 vec = TargetPos.position - previosPos;
        Layer1.position += vec * paralax1;
        Layer2.position += vec * paralax2;
        Layer3.position += vec * paralax3;
        previosPos = TargetPos.position;
    }
}
