using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int slotIndex;
   public void DropItem(){
        FindObjectOfType<Inventory>().isFull[slotIndex] = false;
        GameObject.Destroy(gameObject); 
   }

   public void potionClick(){
       Game.GetPlayerTransform().GetComponent<Player>().Health += 1; 

   }

   public void speedClick(){
       Game.Player.SetPlayerSpeedFactor(2,10);
   }

   public void invulClick(){
       Game.Player.SetPlayerInvulnerability(10);
   }
   
}
