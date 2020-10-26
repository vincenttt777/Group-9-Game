using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HeartContainer : MonoBehaviour
{
    private bool pickedUp = false;
    public GameObject spawnOnPickup;

    private void OnEnable()
    {
        transform.DOLocalMove(transform.position + Vector3.up * 0.25f, 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (pickedUp) return;
        
        if (other.transform == Game.GetPlayerTransform())
        {
            OnPickup();
        }
    }

    void OnPickup()
    {
        int currentMax = Game.GetPlayerTransform().GetComponent<Player>().MaxHealth;
        currentMax++;
        Game.GetPlayerTransform().GetComponent<Player>().SetMaxHealth(currentMax);
        Game.GetPlayerTransform().GetComponent<Player>().Health = currentMax;
        Game.GetPlayerTransform().GetComponent<Player>().SetMaxHealth(currentMax);
        if(spawnOnPickup) Instantiate(spawnOnPickup, transform.position, Quaternion.identity);
        transform.DOKill();
        Destroy(gameObject);
    }
}
