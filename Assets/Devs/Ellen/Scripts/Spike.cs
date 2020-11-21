using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spike : MonoBehaviour
{
    public int spikeDamages = 1;
    public PlayerDamaged damage;
    public bool inTrigger;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == Game.GetPlayerTransform())
        {
            Game.DamageObject(other.transform.gameObject, spikeDamages);
            transform.DOJump(transform.position,1.3f,1,1f);
        }
        if (inTrigger)
        {
            damage.OnDamaged(spikeDamages);
        }
    }
}
