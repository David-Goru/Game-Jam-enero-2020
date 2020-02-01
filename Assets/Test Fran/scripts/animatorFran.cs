using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorFran : MonoBehaviour
{
    public Animator animator;
    float walk;

    public PlayerStats Stats;

    // Update is called once per frame
    void Update()
    {

        // Position
        Vector3 translate = new Vector3(Input.GetAxis("Horizontal") * Stats.Speed, 0, Input.GetAxis("Vertical") * Stats.Speed);
        transform.Translate(translate * Stats.Speed * Time.deltaTime);

        walk = Mathf.Abs(translate.x) + Mathf.Abs(translate.z);
        //Debug.Log("movimiento xD: "+translate);
        AnimatorPlayer();
    }
    void AnimatorPlayer()
    {
        if (walk > 0.0f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

}
