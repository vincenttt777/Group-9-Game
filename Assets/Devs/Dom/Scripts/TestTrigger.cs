using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestTrigger : MonoBehaviour
{
    public int spikeDamage = 1;

    public GameObject poisonParticles;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == Game.GetPlayerTransform())
        {
            Game.DamageObject(other.transform.gameObject, spikeDamage);
            Instantiate(poisonParticles, transform.position, Quaternion.identity);
        }
    }

}
