using DG.Tweening;
using UnityEngine;

public class BossSkill01 : MonoBehaviour
{
    public int Damage = 1;
    public float speed;
    Vector3 movedirction;
    Rigidbody rb;
    Transform player;
    public GameObject destroyPrefab;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = Game.GetPlayerTransform();
        movedirction = (player.transform.position - transform.position).normalized*speed;
        rb.velocity = new Vector3(movedirction.x, movedirction.y,movedirction.z);

    }

    private void Update()
    {
        Destroy(this.gameObject, 5f);  
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<Player>().OnDamaged(Damage);

            if (destroyPrefab != null)
            {
                Instantiate(destroyPrefab, transform.position + transform.forward * 0.6f, Quaternion.identity);
            }

            Destroy(this.gameObject);
        }
        else if (other.tag == "Block")
        {
            if (destroyPrefab != null)
            {
                Instantiate(destroyPrefab, transform.position + transform.forward * 0.6f, Quaternion.identity);
            }

            Destroy(this.gameObject);
        }


        // Send damageable?
    }
}