using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spike : MonoBehaviour
{
    public int spikeDamages = 1;
    public PlayerDamaged damage;
    public bool inTrigger;

    public Shaker Shaker;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == Game.GetPlayerTransform())
        {
            Game.DamageObject(other.transform.gameObject, spikeDamages);
            StartCoroutine(Shaker.Shake(0.1f, 0.01f));
            transform.DOJump(transform.position,1.2f,1,1f);
        }
        if (inTrigger)
        {
            damage.OnDamaged(spikeDamages);
        }
    }
}
