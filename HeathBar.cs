using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Slider sliderSoul;
    public Text text;
    public Text texthp;

    public void SetMaxHp(float MaxHp)
    {
        slider.maxValue = MaxHp;
        texthp.text = slider.value + "/" + slider.maxValue;
    }

    public void SetHp(float health)
    {
        slider.value = health;
        texthp.text = slider.value + "/" + slider.maxValue;
    }

    public void SetMaxSoul(int MaxHp)
    {
        sliderSoul.maxValue = MaxHp;
        text.text = sliderSoul.value + "/" + sliderSoul.maxValue;
    }

    public void SetSoul(int health)
    {
        sliderSoul.value = health;
        text.text = sliderSoul.value + "/" + sliderSoul.maxValue;
    }
}
