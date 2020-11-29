
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
public class EnemyAI : MonoBehaviour, Damageable
{
    public static GameObject loot1,loot2,loot3,loot4;
    public float attackRange = 1f;
    public int maxHealth = 10;
    public int currentHealth ;
    public float lookRadius = 1f;
    public int Damage = 1;
    public float stoppingDistance = 1f;

    public Animator animator;
    Transform target;
    NavMeshAgent agent;
    public GameObject[] Loots = 
    {
        loot1,loot2,loot3,loot4
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
        agent.updateRotation = false;
        agent.stoppingDistance = 1f;
        agent.SetDestination(target.position);
        if (transform.position.x < target.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (distance < lookRadius)//Chase Player
        {
            GetComponent<NavMeshAgent>().isStopped = false;
            GetComponent<Animator>().SetBool("PlayerInRange", true);
        }
        else
        {

            GetComponent<NavMeshAgent>().isStopped = true;
            GetComponent<Animator>().SetBool("PlayerInRange", false);
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
        transform.DOShakePosition(0.5f, Vector3.one * 0.1f, 20);
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
        animator.SetBool("IsDead", true);
        Drop();
        GetComponent<Collider>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        this.enabled = false;
    }

    void Drop()
    {
        if (randomNumber <= 10)
        { Instantiate(Loots[0], transform.position, Quaternion.identity); }
        else if (randomNumber > 10 && randomNumber <= 50)
            Instantiate(Loots[1], transform.position, Quaternion.identity);
        else if (randomNumber > 50 && randomNumber <= 60)
            Instantiate(Loots[1], transform.position, Quaternion.identity);

    }
}
