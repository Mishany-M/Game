using UnityEngine;

[CreateAssetMenu(fileName = "EnemyHpManager", menuName = "Managers/EnemyHpManager")]
public class Manager : ScriptableObject
{
    public Transform pl;
    public float MaxHp;
    public float MinHp;
    public int MaxDamage;
    public int MinDamage;
    public int ChestPrice;
    public float Volume = -20;

    public void Defoult()
    {
        MaxDamage = 20;
        MaxHp = 100;
        MinDamage = 5;
        MinHp = 25;
        ChestPrice = 11;
    }
}
