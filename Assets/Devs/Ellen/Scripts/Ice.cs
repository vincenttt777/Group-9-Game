using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    public PlayerController speed;
    public int spikeDamages = 1;
    public PlayerDamaged damage;
    public bool inTrigger;

    private void OnTriggerEnter(Collider other)
    {
        speed.moveSpeed = 3f;
        if (other.transform == Game.GetPlayerTransform())
        {
            Game.DamageObject(other.transform.gameObject, spikeDamages);
        }
        if (inTrigger)
        {
            damage.OnDamaged(spikeDamages);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        speed.moveSpeed = 5f;
    }
}
