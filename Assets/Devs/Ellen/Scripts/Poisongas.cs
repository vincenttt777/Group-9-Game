using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Animations;

public class Poisongas : MonoBehaviour
{
    public int Damages = 1;
    public PlayerDamaged damage;
    public bool inTrigger;
    bool canTakeDamage = true;

    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if (other.transform == Game.GetPlayerTransform())
        {
            if(canTakeDamage)
            {
                StartCoroutine(WaitForSeconds());
                Game.DamageObject(other.transform.gameObject, Damages);
                damage.OnDamaged(Damages);
            }
        }
    }

    IEnumerator WaitForSeconds()
    {
        canTakeDamage = false;
        yield return new WaitForSecondsRealtime(3);
        canTakeDamage = true;
    }
}
