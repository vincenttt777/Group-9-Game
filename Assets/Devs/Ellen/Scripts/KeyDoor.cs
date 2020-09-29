using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public bool inTrigger;

    void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    public void Update()
    {
        if (Key.have_key == true)
        {
            if (inTrigger)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
    private void OnGUI()
    {
        if (inTrigger)
        {
            if (Key.have_key == true)
            {
                GUI.Box(new Rect(0, 60, 200, 25), "Press E to open the door");
            }
            else
            {
                GUI.Box(new Rect(0, 60, 200, 25), "You need to find a key");
            }
        }
    }
}
