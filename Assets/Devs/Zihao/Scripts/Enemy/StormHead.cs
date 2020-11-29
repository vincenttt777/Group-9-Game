using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class StormHead : MonoBehaviour, Damageable
{
    public static GameObject loot1, loot2, loot3, loot4;
    public float attackRange = 13f;
    public int maxHealth = 10;
    public int currentHealth;
    public int Damage = 1;
    public Transform attackPoint;
    public Transform attackPoint02;
    public GameObject bullet;
    private bool Isdead = false;
    public Transform DropPoint;

    public Animator animator;
    Transform target;
    public GameObject[] Loots =
    {
        loot1,loot2,loot3,loot4
    };

    public int randomNumber;
    void Start()
    {
        target = Game.GetPlayerTransform();
        currentHealth = maxHealth;
        randomNumber = Random.Range(0, 101);

    }


    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= attackRange && Isdead == false)
        {
            GetComponent<Animator>().enabled = true;
            animator.Play("StormHead_Attack");
        }
        else
        
            GetComponent<Animator>().enabled = false;
        
    }

    public void OnDamaged(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        transform.DOShakePosition(0.5f, Vector3.one * 0.1f, 20);
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
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void Die()
    {
        animator.Play("StormHeadDeath");
        Isdead = true;
        Drop();
        GetComponent<Collider>().enabled = false;
        this.enabled = false;
    }

    void Drop()
    {
        if (randomNumber <= 10)
        { Instantiate(Loots[0], DropPoint.position, Quaternion.identity); }
        else if (randomNumber >= 10 && randomNumber <= 50)
            Instantiate(Loots[1], DropPoint.position, Quaternion.identity);
        else if (randomNumber > 50 && randomNumber <= 60)
            Instantiate(Loots[2], DropPoint.position, Quaternion.identity);
        else if (randomNumber > 60 && randomNumber <= 70)
            Instantiate(Loots[3], DropPoint.position, Quaternion.identity);

    }
//---------------------AnimationEvent----------------------------------------
    void ShootType01()
    {
        Instantiate(bullet, attackPoint.transform.position, Quaternion.identity);
    }
    void ShootType02()
    {
        Instantiate(bullet, attackPoint02.transform.position, Quaternion.identity);
    }
}
