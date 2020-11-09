using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public int spikeDamages = 1;
    public PlayerDamaged damage;
    public bool inTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == Game.GetPlayerTransform())
        {
            Game.DamageObject(other.transform.gameObject, spikeDamages);
        }
        if (inTrigger)
        {
            damage.OnDamaged(spikeDamages);
        }
    }
}
