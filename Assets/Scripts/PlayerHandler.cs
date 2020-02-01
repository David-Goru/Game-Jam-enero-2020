using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    public PlayerStats Stats;
    public GameObject UpgradeUI;

    void Start()
    {
        Stats.Gold = 100;
        Stats.Speed = 2f;
        Stats.Damage = 0;
        Stats.DamageCost = 0;
        Stats.Armor = 0;
        Stats.ArmorCost = 0;
        Stats.HP = 0;
        Stats.HPCost = 0;
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