using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int Damage = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
                other.GetComponent<Player>().OnDamaged(Damage);
        }
    }
}
