using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;
    public float speed;
    public float spinSpeed = 0;

    public GameObject destroyPrefab;


    private void Update()
    {
        transform.position += transform.forward * (Time.deltaTime * speed);
        if(transform.childCount > 0) transform.GetChild(0).localEulerAngles += Vector3.up * (spinSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hit " + other.gameObject.name);
        
        if (destroyPrefab != null)
        {
            Instantiate(destroyPrefab, transform.position + transform.forward * 0.6f, Quaternion.identity);
        }

        Game.DamageObject(other.gameObject, damage);
        
        Destroy(gameObject);
        // Send damageable?
    }
}
