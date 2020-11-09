
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour, Damageable
{
    public static GameObject loot1,loot2,loot3;
    public float attackRange = 2f;
    public int maxHealth = 20;
    public int currentHealth ;
    public float lookRadius = 1f;
    public int Damage = 1;
    Vector3 StopAt = new Vector3(0.5f,0,0);

    public Animator animator;
    Transform target;
    NavMeshAgent agent;
    
    public GameObject[] Loots = 
    {
        loot1,loot2,loot3
    };

    public int randomNumber;
    void Start()
    {
        target = Game.GetPlayerTransform();
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;

        randomNumber = Random.Range(0, 101);

    }


    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            animator.SetBool("PlayerInRange", true);
            agent.SetDestination(target.position + StopAt);
        }
        else
        {
            animator.SetBool("PlayerInRange", false);
        }

        if (distance <= attackRange)
        {
            animator.SetBool("Attack",true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }

    public void OnDamaged(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<Player>().OnDamaged(Damage);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void Die()
    {
        Debug.Log("Enemy is Dead");
        animator.SetBool("IsDead", true);
        Drop();
        GetComponent<Collider>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        this.enabled = false;
    }

    void Drop()
    {
        if(randomNumber  <= 25)
        { Instantiate(Loots[0], transform.position, Quaternion.identity); }
        else if(randomNumber >= 25 && randomNumber <= 50)
            Instantiate(Loots[1], transform.position, Quaternion.identity);
        else if(randomNumber > 50)
            Instantiate(Loots[2], transform.position, Quaternion.identity);
    }
}
