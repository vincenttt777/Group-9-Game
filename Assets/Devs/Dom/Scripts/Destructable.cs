using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour, Damageable
{
    public GameObject spawnOnDeath;

    public void OnDamaged(int damage)
    {
        Instantiate(spawnOnDeath, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
