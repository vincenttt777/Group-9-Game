using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTester : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Game.DamageObject(other.gameObject, 1);
    }
}
