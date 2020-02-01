using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCmovement : MonoBehaviour
{
    NavMeshAgent navMeshAgent;

    GameObject goPlayer;
    Transform destination;

    
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

        SetDestination();

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
