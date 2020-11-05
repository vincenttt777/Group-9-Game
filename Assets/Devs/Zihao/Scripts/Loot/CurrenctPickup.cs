using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrenctPickup : MonoBehaviour
{

    public enum PickupObject {COIN,KEY,WEAPON};
    public PickupObject currentObject;
    public int PickQuantity = 1;
    public GameObject thePlayer;


    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            if (currentObject == PickupObject.COIN)
            {
                 Game.GetGameManager().CoinCount += PickQuantity;
                Debug.Log(Game.GetGameManager().CoinCount);
                Destroy(gameObject);
            }
            else if (currentObject == PickupObject.KEY)
            {
                Game.GetGameManager().KeyCount += PickQuantity;
                Debug.Log(Game.GetGameManager().CoinCount);
                Destroy(gameObject);
            }
        }
    }
}
