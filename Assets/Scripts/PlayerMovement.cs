using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerStats Stats;
    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        // Position
        Vector3 translate = new Vector3(Input.GetAxis("Horizontal") * Stats.Speed, 0, Input.GetAxis("Vertical") * Stats.Speed);
        transform.Translate(translate * Stats.Speed * Time.deltaTime);

        animator.SetBool("isWalking", translate.x > 0 || translate.z > 0);

        // Rotation
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100, 1 << LayerMask.NameToLayer("Ground")))
        {
            Vector3 hitPoint = new Vector3(hit.point.x, 0, hit.point.z);
            if (Vector3.Distance(hitPoint, transform.position) > 0.1)
            {
                transform.Find("Model").LookAt(hitPoint);
                transform.Find("Model").Find("Head").LookAt(hitPoint);
            }
        }
    }
}