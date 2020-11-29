using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class witch : MonoBehaviour
{
    public bool inTrigger;

    void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    void OnGUI()
    {
        if (inTrigger)
        {
            GUI.Button(new Rect(0, 80, 170, 50), new GUIContent("All the items are random. " + "\n" +
                "Do you want to buy some" + "\n" + "items in my shop?"));
        }
    }
}
