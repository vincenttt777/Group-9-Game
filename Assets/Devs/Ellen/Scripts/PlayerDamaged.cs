using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour, Damageable
{
    public int health = 3;

    public void OnDamaged(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
        else
        {
            //Hurt();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

}
