using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    public int KeyPrice = 1;
    public bool inTrigger;
    public bool noenoughcoin;
    public bool isPressed = false;
    public Sprite[] Sprite_Pic;
    private int rand;
    public GameObject spawnOnPickup;

    private void Start()
    {
        rand = Random.Range(0, Sprite_Pic.Length);
        GetComponent<SpriteRenderer>().sprite = Sprite_Pic[rand];
    }

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
        if (isPressed == true)
        {
            if (Game.GetGameManager().CoinCount >= KeyPrice)
            {
                Game.GetGameManager().CoinCount -= KeyPrice;
                if(Sprite_Pic[rand].name == "Key")
                {
                    Game.GetGameManager().KeyCount += 1;
                    Destroy(gameObject);
                }
                if(Sprite_Pic[rand].name == "hearts_2")
                {
                    OnPickup();
                    Destroy(gameObject);
                }
            }
        }
    }
    void OnPickup()
    {
        int currentMax = Game.GetPlayerTransform().GetComponent<Player>().MaxHealth;
        currentMax++;

        Game.GetPlayerTransform().GetComponent<Player>().SetMaxHealth(currentMax);

        Game.GetPlayerTransform().GetComponent<Player>().Health = currentMax;
        Game.GetPlayerTransform().GetComponent<Player>().SetMaxHealth(currentMax);

        if (spawnOnPickup) Instantiate(spawnOnPickup, transform.position, Quaternion.identity);
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
