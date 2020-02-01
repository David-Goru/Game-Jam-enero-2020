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
        Stats.Damage = damage;
        Stats.DamageCost = damageCost;
        Stats.Armor = armor;
        Stats.ArmorCost = armorCost;
        Stats.HP = hp;
        Stats.HPCost = hpCost;
    }

    public void Add(string type)
    {
        switch (type)
        {
            case "Damage":
                if (Stats.Gold >= Mathf.Pow(2, Stats.Damage))
                {
                    Stats.Gold -= (int)Mathf.Pow(2, Stats.Damage);
                    Stats.Damage++;
                    UpgradeUI.transform.Find("Upgrade damage").Find("Cost").GetComponent<Text>().text = string.Format("{0}g", (int)Mathf.Pow(2, Stats.Damage));
                    UpgradeUI.transform.Find("Upgrade damage").Find("Points").GetComponent<Text>().text = string.Format("({0})", Stats.Damage);
                }
                break;
            case "HP":
                if (Stats.Gold >= Mathf.Pow(2, Stats.HP))
                {
                    Stats.Gold -= (int)Mathf.Pow(2, Stats.HP);
                    Stats.HP++;
                    UpgradeUI.transform.Find("Upgrade HP").Find("Cost").GetComponent<Text>().text = string.Format("{0}g", (int)Mathf.Pow(2, Stats.HP));
                    UpgradeUI.transform.Find("Upgrade HP").Find("Points").GetComponent<Text>().text = string.Format("({0})", Stats.HP);
                }
                break;
            case "Armor":
                if (Stats.Gold >= Mathf.Pow(2, Stats.Armor))
                {
                    Stats.Gold -= (int)Mathf.Pow(2, Stats.Armor);
                    Stats.Armor++;
                    UpgradeUI.transform.Find("Upgrade armor").Find("Cost").GetComponent<Text>().text = string.Format("{0}g", (int)Mathf.Pow(2, Stats.Armor));
                    UpgradeUI.transform.Find("Upgrade armor").Find("Points").GetComponent<Text>().text = string.Format("({0})", Stats.Armor);
                }
                break;
        }

        UpgradeUI.transform.parent.Find("Gold").GetComponent<Text>().text = string.Format("{0}g", Stats.Gold);
    }
}