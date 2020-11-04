using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class FallingStone : MonoBehaviour
{
    public int spikeDamages = 1;
    public PlayerDamaged damage;
    public bool inTrigger;
    public PlayerController speed;

    // Start is called before the first frame update
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
