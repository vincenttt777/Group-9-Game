using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DestructableDoor : MonoBehaviour, Damageable
{
    public void OnDamaged(int damage)
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddExplosionForce(25f, Game.GetPlayerTransform().position, 555f);
    }
}
