using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, Useable
{
    Animator animator;

    public GameObject HealthPotion;

    public bool open = false;

    public void Start(){
        animator = GetComponent<Animator>();
    }

    public void OnUse(){
        open = !open;
        if(open){
            ChestControl("Open");
        }
        else
            ChestControl("Close");
        
        Instantiate(HealthPotion);
        
    }

    public void OnSelect()
    {
    }

    public void OnDeselect()
    {
    }

    void Update(){
        
    }

    void ChestControl(string pos){
        animator.SetTrigger(pos);
    }
}
