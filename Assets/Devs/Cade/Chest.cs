using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, Useable
{
    Animator animator;

    public GameObject contents;

    public bool open = false;

    public void Start(){
        animator = GetComponent<Animator>();
    }

    public void OnUse(){
        open = !open;
        if(open){
            ChestControl("Open");
        }
        Instantiate(contents,transform.position+Vector3.back, Quaternion.identity);
        
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
