using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createNPC : MonoBehaviour
{
    public GameObject[] enemyList;
    public GameObject prefab;
    public bool time;

    int random;
    Transform randomPosition;

    GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        time = true;

        enemyList = GameObject.FindGameObjectsWithTag("Spawn");  //returns GameObject[]

    }

    // Update is called once per frame
    void Update()
    {

        if (time)
        {
            StartCoroutine(Enemy());
        }

    }

    void CreateEnemy()
    {

    }

    IEnumerator Enemy()
    {
        time = false;
        yield return new WaitForSeconds(1);

        random = Random.Range(0, 4);
        randomPosition = enemyList[random].transform;

        enemy = Instantiate(prefab, randomPosition );
        
        time = true;
    }
}
