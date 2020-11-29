using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DestructableDoor : MonoBehaviour, Damageable
{
    public void OnDamaged(int damage)
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddExplosionForce(25f, Game.GetPlayerTransform().position, 555f);
    }
}
