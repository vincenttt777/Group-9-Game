using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
   public void DropItem(){
        GameObject.Destroy(gameObject);
   }

   public void potionClick(){
       Debug.Log("test");
       Game.GetPlayerTransform().GetComponent<Player>().Health += 1; 
   }
   
}
