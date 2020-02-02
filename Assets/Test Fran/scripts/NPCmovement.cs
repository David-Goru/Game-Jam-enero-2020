using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCmovement : MonoBehaviour
{
    //PlayerStats stats;
    PlayerCombat playerCombat;
    PlayerHandler playerHandler;
    createNPC createNPC;

    public Animator animator;
    NavMeshAgent navMeshAgent;

    GameObject goPlayer;
    Transform destination;

    float variableX;
    float variableZ;

    bool damage;
    int hp;


    // Start is called before the first frame update
    void Start()
    {

       
        damage = false;
        playerCombat = GameObject.Find("Player").GetComponent<PlayerCombat>();
        playerHandler = GameObject.Find("Player").GetComponent<PlayerHandler>();
        createNPC = GameObject.Find("Floor").GetComponent<createNPC>();

        hp = 1 + playerHandler.Stats.Round * 2;

        navMeshAgent = this.GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            Debug.Log("el nav mesh no va: " + gameObject.name);
        }

        goPlayer = GameObject.FindWithTag("Player");
        //Debug.Log("player: " + goPlayer.tag);


    }

    // Update is called once per frame
    void Update()
    {
        destination = goPlayer.transform;

        CheckDistance();
        SetDestination();
    }

    void CheckDistance()
    {
        //Debug.Log("distancia X: " + (goPlayer.transform.position.x - transform.position.x));
        //Debug.Log("distancia Z: " + (goPlayer.transform.position.z - transform.position.z));

        variableX = goPlayer.transform.position.x - transform.position.x;
        variableX = Mathf.Abs(variableX);

        variableZ = goPlayer.transform.position.z - transform.position.z;
        variableZ = Mathf.Abs(variableZ);

        if (variableX <= 2.5f && variableZ <= 2.5f)
        {
            animator.SetBool("bool_attack", true);
            StartCoroutine(TimeBetweenDamage());
        }
        else
        {
            animator.SetBool("bool_attack", false);
        }
    }

    void SetDestination()
    {
        if (destination != null)
        {
            Vector3 targetVector = destination.transform.position;
            navMeshAgent.SetDestination(targetVector);
        }

    }

    public void GetDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            playerHandler.MoreGold();
            createNPC.DestroyEnemy(1);
            Destroy(this.gameObject);
        }
    }

    IEnumerator TimeBetweenDamage()
    {

        if (damage == false)
        {
            playerCombat.GetDamage(1 + 3 * playerHandler.Stats.Round);
            damage = true;
        }

        yield return new WaitForSeconds(4);

        damage = false;
    }
}