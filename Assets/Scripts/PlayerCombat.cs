using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
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
        if (attackTimer > 0) attackTimer -= Time.deltaTime;
        else if (Input.GetMouseButtonDown(0)) Attack();
    }

    public void RecibirDaño(int daño)
    {
        if (daño > Stats.HP)
        {
            Stats.HP = 0;

            // End
            Debug.Log("You died :(");
        }
        else Stats.HP -= daño;
    }

    void Attack()
    {
        // Run animation

        Collider[] enemies = Physics.OverlapSphere(checkEnemies.transform.position, checkEnemies.radius, 1 << LayerMask.NameToLayer("Enemy"));

        foreach (Collider enemy in enemies)
        {
            //(enemy.gameObject.GetComponent("EnemyController") as EnemyController).DoDamage(Stats.Damage);
            Instantiate(BloodParticles, enemy.transform.Find("Blood spawn").position, enemy.transform.rotation);
            enemy.gameObject.GetComponent<Rigidbody>().AddForce(enemy.transform.Find("Back point").position * 3, ForceMode.Impulse);
        }
        attackTimer = 0.5f;
    }
}