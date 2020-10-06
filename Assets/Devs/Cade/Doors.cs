using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
    }    

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            DoorControl("Open");
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Player"){
            DoorControl("Close");
        }
    }

    void DoorControl(string direction){
        animator.SetTrigger(direction);

    }
}
