using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createNPC : MonoBehaviour
{

    public Restart restart;

    public GameObject[] enemyList;
    [HideInInspector] public int contEnemies;

    public GameObject prefab;
    public bool time;
    public int numEnemies;

    int random;
    Transform randomPosition;

    GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        contEnemies = 5;
        time = true;

        enemyList = GameObject.FindGameObjectsWithTag("Spawn");  //returns GameObject[]

    }

    // Update is called once per frame
    void Update()
    {

        if (time && contEnemies < numEnemies)
        {
            StartCoroutine(Enemy());
            contEnemies += 1;
        }

    }

    public void DestroyEnemy(int num)
    {
        restart.rounds();
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
