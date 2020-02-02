using UnityEngine;

[CreateAssetMenu(fileName = "Vars", menuName = "ScriptableObjects/PlayerStats", order = 1)]
public class PlayerStats : ScriptableObject
{
    public int Gold;

    // Stats
    public float Speed;
    public int Damage;
    public int HP;
    public int Armor;

    public int LevelDamage;
    public int LevelHP;
    public int LevelArmor;
}