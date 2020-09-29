using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    public GameObject destroyPrefab;

    private void Update()
    {
        transform.position += transform.forward * (Time.deltaTime * speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit " + other.gameObject.name);
        
        if (destroyPrefab != null)
        {
            Instantiate(destroyPrefab, transform.position + transform.forward * 0.6f, Quaternion.identity);
        }

        if (other.gameObject.GetComponent<Useable>() != null)
        {
            other.gameObject.GetComponent<Useable>().OnUse();
        }
        
        Destroy(gameObject);
        // Send damageable?
    }
}
