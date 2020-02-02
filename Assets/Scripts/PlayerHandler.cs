using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    public PlayerStats Stats;
    public GameObject UpgradeUI;

    public int gold;
    public float speed;
    public int damage;
    public int damageCost;
    public int armor;
    public int armorCost;
    public int hp;
    public int hpCost;

    void Start()
    {
        Stats.Gold = gold;
        Stats.Speed = speed;
        Stats.Damage = 1;
        Stats.Armor = 1;
        Stats.HP = 5;

        Stats.LevelDamage = 0;
        Stats.LevelArmor = 0;
        Stats.LevelHP = 0;
    }

    public void Add(string type)
    {
        switch (type)
        {
            case "Damage":
                if (Stats.Gold >= Mathf.Pow(2, Stats.LevelDamage))
                {
                    Stats.Gold -= (int)Mathf.Pow(2, Stats.LevelDamage);
                    Stats.LevelDamage++;
                    UpgradeUI.transform.Find("Upgrade damage").Find("Cost").GetComponent<Text>().text = string.Format("{0}g", (int)Mathf.Pow(2, Stats.LevelDamage));
                    UpgradeUI.transform.Find("Upgrade damage").Find("Points").GetComponent<Text>().text = string.Format("({0})", Stats.LevelDamage);
                }
                break;
            case "HP":
                if (Stats.Gold >= Mathf.Pow(2, Stats.LevelHP))
                {
                    Stats.Gold -= (int)Mathf.Pow(2, Stats.LevelHP);
                    Stats.LevelHP++;
                    UpgradeUI.transform.Find("Upgrade HP").Find("Cost").GetComponent<Text>().text = string.Format("{0}g", (int)Mathf.Pow(2, Stats.LevelHP));
                    UpgradeUI.transform.Find("Upgrade HP").Find("Points").GetComponent<Text>().text = string.Format("({0})", Stats.LevelHP);
                }
                break;
            case "Armor":
                if (Stats.Gold >= Mathf.Pow(2, Stats.LevelArmor))
                {
                    Stats.Gold -= (int)Mathf.Pow(2, Stats.LevelArmor);
                    Stats.LevelArmor++;
                    UpgradeUI.transform.Find("Upgrade armor").Find("Cost").GetComponent<Text>().text = string.Format("{0}g", (int)Mathf.Pow(2, Stats.LevelArmor));
                    UpgradeUI.transform.Find("Upgrade armor").Find("Points").GetComponent<Text>().text = string.Format("({0})", Stats.LevelArmor);
                }
                break;
        }

        UpgradeUI.transform.parent.Find("Gold").GetComponent<Text>().text = string.Format("{0}g", Stats.Gold);
    }

    public void MoreGold()
    {
        Stats.Gold += 10;
    }

    /*
    public int AmountGold()
    {
        return Stats.Gold;
    }*/

}