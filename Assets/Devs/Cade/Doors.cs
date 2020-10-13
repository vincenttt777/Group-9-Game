using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    Animator animator;

    void Start(){
        animator = GetComponent<Animator>(); //grab the animation
    }    

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){ //if player moves into collider zone
            DoorControl("Open"); // pass open to door control 
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Player"){ //same collider as enter
            DoorControl("Close"); // pass close to the door control
        }
    }

    void DoorControl(string direction){
        animator.SetTrigger(direction); // if open is passed to this it will open the door
                                        // if close is passed it will trigger the close animation

    }
}
