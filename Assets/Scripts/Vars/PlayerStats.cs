using UnityEngine;

[CreateAssetMenu(fileName = "Vars", menuName = "ScriptableObjects/PlayerStats", order = 1)]
public class PlayerStats : ScriptableObject
{
    public int Gold;

    // Stats
    public float Speed;
    public int Damage;
    public int DamageCost;
    public int HP;
    public int HPCost;
    public int Armor;
    public int ArmorCost;
}