using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCmovement : MonoBehaviour
{
    public Animator animator;
    NavMeshAgent navMeshAgent;

    GameObject goPlayer;
    Transform destination;

    float variableX;
    float variableZ;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            Debug.Log("el nav mesh no va: " + gameObject.name);
        }

        goPlayer = GameObject.FindWithTag("Player");
        Debug.Log("player: " + goPlayer.tag);


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


}
