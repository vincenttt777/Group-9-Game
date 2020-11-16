using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour, Damageable
{
    public static GameObject loot1, loot2, loot3;

    public int maxHealth = 50;
    public int currentHealth;


    public float attackRange = 1f;
    public float lookRadius = 15f;
    public float stoppingDistance = 3f;

    Vector3 right = new Vector3(0.126f, -0.093f, 0f);
    Vector3 left = new Vector3(-0.126f, -0.093f, 0f);

    public Animator animator;

    Transform target;
    public Transform attackPoint;
    NavMeshAgent agent;
    public LayerMask playerLayer;
    public GameObject[] Loots =
    {
        loot1,loot2,loot3
    };

    public int randomNumber;

    void Start()
    {
        target = Game.GetPlayerTransform();
        currentHealth = maxHealth;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.stoppingDistance = 2f;

        randomNumber = Random.Range(0, 101);
    }


    void Update()
    {
        agent.SetDestination(target.position);
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance < lookRadius)//Chase Player
        {
            GetComponent<Animator>().SetBool("PlayerInRange", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("PlayerInRange", false);
        }

        if (transform.position.x < target.position.x)//Face Player
        {
            GetComponent<SpriteRenderer>().flipX = false;
            attackPoint.transform.localPosition = right;
            
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
            attackPoint.transform.localPosition = left;
        }


        if (distance <= attackRange)//Attack if in range
        {
            Debug.Log("Attack");
            Attack();
        }
        else 
        {
            attackPoint.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void OnDamaged(int damage)
    {
        currentHealth -= damage;
        GetComponent<Animator>().SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }

    }

    IEnumerator AttackDelay()
    {
        Debug.Log("AttackDelay Start");
       yield return new WaitForSeconds(1.2f);
        attackPoint.GetComponent<BoxCollider>().enabled = true;
        Debug.Log("AttackDelay End");
    }

    void Attack()
    {
        GetComponent<Animator>().SetTrigger("Attack");
        StartCoroutine(AttackDelay());
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void Die()
    {
        Debug.Log("Enemy is Dead");
        animator.SetBool("Dead", true);
        Drop();
        GetComponent<Collider>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        this.enabled = false;
    }

    void Drop()
    {
        if (randomNumber <= 10)
        { Instantiate(Loots[0], transform.position, Quaternion.identity); }
        else if (randomNumber >= 10 && randomNumber <= 50)
            Instantiate(Loots[1], transform.position, Quaternion.identity);
        else if (randomNumber > 50 && randomNumber <= 60)
            Instantiate(Loots[2], transform.position, Quaternion.identity);

    }
}