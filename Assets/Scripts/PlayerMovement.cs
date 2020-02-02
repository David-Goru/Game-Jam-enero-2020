using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerStats Stats;
    Animator animator;

    void Start()
    {
        //animator = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Position
        transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * Stats.Speed *  Time.deltaTime, 0, transform.position.z + Input.GetAxis("Vertical") * Stats.Speed * Time.deltaTime);

        //animator.SetBool("isWalking", Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0);

        // Rotation
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100, 1 << LayerMask.NameToLayer("Ground")))
        {
            Vector3 hitPoint = new Vector3(hit.point.x, 0, hit.point.z);
            if (Vector3.Distance(hitPoint, transform.position) > 0.1)
            {
                transform.Find("Model").LookAt(new Vector3(hitPoint.x, transform.Find("Model").position.y, hitPoint.z));
            }
        }
    }
}