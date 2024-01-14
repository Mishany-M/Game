using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    private Quaternion zero = Quaternion.Euler(0, 0, 0);
    [SerializeField] MoveGun Gun;
    protected override void Start()
    {
        base.Start();
        background.gameObject.SetActive(false);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        Gun.FireOn = true;
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        Gun.FireOn = false;
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
        Gun.tf.localRotation = zero;
    }
}