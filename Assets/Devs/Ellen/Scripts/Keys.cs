using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public int KeyPrice = 1;
    public bool inTrigger;
    public bool noenoughcoin;
    public bool isPressed = false;
    private void Update()
    {
        isPressed = Input.GetKey(KeyCode.E);
    }
    void OnTriggerEnter(Collider other)
    {
        if (Game.GetGameManager().CoinCount < KeyPrice)
        {
            noenoughcoin = true;
        }
        inTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        noenoughcoin = false;
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(isPressed);
        if (isPressed == true)
        {
            if (Game.GetGameManager().CoinCount >= KeyPrice)
            {
                Game.GetGameManager().CoinCount -= KeyPrice;
                Destroy(gameObject);
            }
        }
    }

    void OnGUI()
    {
        if (inTrigger && noenoughcoin == false)
        {
            GUI.Button(new Rect(10, 80, 200, 20), new GUIContent("Press E to purchase the item"));
        }
        if (noenoughcoin)
        {
            GUI.Button(new Rect(10, 80, 200, 20), new GUIContent("You don't have enough coins"));
        }
    }
}
