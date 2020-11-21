using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
public class Skeleton : MonoBehaviour, Damageable
{
    public static GameObject loot0,loot1,loot2,loot3;

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

    public GameObject[] Loots =
    {
        loot0,loot1,loot2,loot3
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
            Attack();
        }
    }

    public void OnDamaged(int damage)
    {
        currentHealth -= damage;
        transform.DOShakePosition(0.5f, Vector3.one * 0.1f, 20);
        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Attack()
    {
        GetComponent<Animator>().SetTrigger("Attack");
    }
    void TurnOnAttack()
    {
        attackPoint.GetComponent<BoxCollider>().enabled = true;
    }
    void TurnOffAttack()
    { 
        attackPoint.GetComponent<BoxCollider>().enabled = false;
    }

    void StopMoving()
    {
        agent.speed = 0;
    }
    void StartMoving()
    {
        agent.speed = 2;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void Die()
    {

        animator.Play("Skeleton_Die");
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
        else if(randomNumber > 60 && randomNumber<= 70)
            Instantiate(Loots[3], transform.position, Quaternion.identity);

    }
}