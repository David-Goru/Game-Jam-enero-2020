using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Restart restart;
    public PlayerStats Stats;
    public GameObject BloodParticles;
    float attackTimer = 0;
    SphereCollider checkEnemies;

    void Start()
    {

        checkEnemies = transform.Find("Model").Find("Check enemies").GetComponent<SphereCollider>();
    }

    void Update()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
            
    }

    void Attack()
    {
        animator.SetTrigger("attack");
        // Run animation

        Collider[] enemies = Physics.OverlapSphere(checkEnemies.transform.position, checkEnemies.radius, 1 << LayerMask.NameToLayer("Enemy"));

        foreach (Collider enemy in enemies)
        {
            (enemy.gameObject.GetComponent("NPCmovement") as NPCmovement).GetDamage(Stats.Damage);
            //Instantiate(BloodParticles, enemy.transform.Find("Blood spawn").position, enemy.transform.rotation);/---------------------------------lo siento david xD
            //enemy.gameObject.GetComponent<Rigidbody>().AddForce(enemy.transform.Find("Back point").position * 10, ForceMode.Impulse);

        }
        attackTimer = 0.5f;
    }

    public void GetDamage(int damage)
    {
        Stats.HP -= damage - Stats.Armor / 4;  //------------------------------------------------------------------------------------------------------- esto lo ajustamos cuando cuando metamos las animaciones buenas de los modelados

    }
}