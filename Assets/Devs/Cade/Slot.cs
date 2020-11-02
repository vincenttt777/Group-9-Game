using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
   public void DropItem(){
       foreach (Transform child in transform ){
           GameObject.Destroy(child.gameObject);
       }
   }
/*
   public void potionClick(){
       Game.GetPlayerTransform().GetComponent<Player>().Health += 1; 
   }
   */
}
