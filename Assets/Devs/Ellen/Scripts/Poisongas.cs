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
    public Collider poison;
    private bool isInside = false;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        poison = other;
        isInside = true;
        Damage();
    }

    private void OnTriggerExit(Collider other)
    {
        isInside = false;
        timer = 0f;
    }

    private float timer = 0f;
    private float waitTime = 1.5f;

    private void Update()
    {
        if(isInside == false)
        {
            return;
        }
        if(timer > waitTime)
        {
            timer = 0f;
            Damage();
        }
        timer += Time.deltaTime;
    }

    public void Damage()
    {
        Game.DamageObject(poison.transform.gameObject, Damages);
        damage.OnDamaged(Damages);
    }
}
