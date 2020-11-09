using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal.Internal;

public class WallSpike : MonoBehaviour
{
    public int spikeDamages = 1;
    public PlayerDamaged damage;
    public bool inTrigger;

    public Shaker Shaker;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == Game.GetPlayerTransform())
        {
            Game.DamageObject(other.transform.gameObject, spikeDamages);
            StartCoroutine(Shaker.Shake(.15f, 0.4f));
            transform.DOMoveZ(-6.2f, 1.2f);
            StartCoroutine(Shaker.Shake(.15f, 0.1f));
            Invoke("Move", 0.7f);
        }
        if (inTrigger)
        {
            damage.OnDamaged(spikeDamages);
        }
    }

    private void Move()
    {
        transform.DOMoveZ(-5f, 1.2f);
    }
}
