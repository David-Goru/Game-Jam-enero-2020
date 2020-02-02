using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public PlayerStats playerStats;
    public createNPC createNPC;
    public GameObject player;//------------------------------------no se usa
    int contEnemiesInGame;

    bool roundStart;

    GameObject[] enemiesInScene;

    int temp;

    // Start is called before the first frame update
    void Start()
    {
        contEnemiesInGame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        win();
        lose();
    }

    void win()
    {
        if (contEnemiesInGame >= 5)
        {

            contEnemiesInGame = 0;

            playerStats.Damage = 1 + playerStats.LevelDamage * 2;
            playerStats.Armor = 1 + playerStats.LevelArmor * 2;
            playerStats.HP = 5 + playerStats.LevelHP * 2;
            player.transform.position = new Vector3(0,0,64);
            roundStart = false;
        }
    }

    void lose()
    {
        if (playerStats.HP <= 0)
        {
            contEnemiesInGame = 0;
            roundStart = false;
            enemiesInScene = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemiesInScene)
            {
                Destroy(enemy);
            }

            player.transform.position = new Vector3(0, 0, 64);
            playerStats.Gold = 100;

            playerStats.Damage = 1;
            playerStats.Armor = 1;
            playerStats.HP = 5;

            playerStats.LevelDamage = 0;
            playerStats.LevelArmor = 0;
            playerStats.LevelHP = 0;

            GameObject.Find("UI").transform.Find("Upgrades").Find("Upgrade damage").Find("Points").GetComponent<Text>().text = string.Format("({0})", playerStats.LevelDamage);
            GameObject.Find("UI").transform.Find("Upgrades").Find("Upgrade armor").Find("Points").GetComponent<Text>().text = string.Format("({0})", playerStats.LevelArmor);
            GameObject.Find("UI").transform.Find("Upgrades").Find("Upgrade HP").Find("Points").GetComponent<Text>().text = string.Format("({0})", playerStats.LevelHP);

        }
    }

    public void rounds()
    {
        contEnemiesInGame += 1;
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //other.gameObject.transform.position = new Vector3(-11,0,34);
        }
    }*/

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && roundStart == false)
        {
            other.gameObject.transform.position = new Vector3(0, 0, 7);
            createNPC.contEnemies = 0; //------------------------------------------------------------------------------restar enemies y vuelta a empezar rondas
            roundStart = true;
        }
    }

}
