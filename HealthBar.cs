using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(float MaxHealth)
    {
        slider.maxValue = MaxHealth;
        slider.value = MaxHealth;
    }

    public void SetMaxHp(float MaxHp)
    {
        slider.maxValue = MaxHp;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
