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

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == Game.GetPlayerTransform())
        {
            Game.DamageObject(other.transform.gameObject, spikeDamages);
            transform.DOMoveZ(gameObject.transform.position.z-1f, 1.2f);
            Debug.Log(gameObject.transform.position.z);
            Invoke("Move", 0.9f);
        }
        if (inTrigger)
        {
            damage.OnDamaged(spikeDamages);
        }
    }

    private void Move()
    {
        transform.DOMoveZ(gameObject.transform.position.z+1f, 1.2f);
        Debug.Log(gameObject.transform.position.z);
    }
}
