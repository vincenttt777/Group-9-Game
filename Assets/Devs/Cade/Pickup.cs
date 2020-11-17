using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;
public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    
    private void Start(){
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        transform.DOMoveY(transform.position.y + 0.2f, 1f).SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }

    void OnTriggerEnter(Collider tag){
        if (tag.CompareTag("Player")){
            for (int i = 0; i < inventory.slots.Length; i++){
                if (inventory.isFull[i]==false){
                    inventory.isFull[i]=true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
