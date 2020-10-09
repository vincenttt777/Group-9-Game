using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TurnLight : MonoBehaviour
{
    public GameObject light;
    private bool on = false;

    void OnTriggerStay(Collider plyr)
    {
        if (plyr.tag == "Player" && Input.GetKeyDown(KeyCode.E) && !on)
        {
            light.SetActive(true);
            on = true;
        }
        else if (plyr.tag == "Player" && Input.GetKeyDown(KeyCode.E) && on)
        {
            light.SetActive(false);
            on = false;
        }
    }
    void OnGUI()
    {
        if (on)
        {
            GUI.Box(new Rect(0, 0, 200, 20), "Press E to close the light");
        }
        else
        {
            GUI.Box(new Rect(0, 0, 200, 20), "Press E to open the light");
        }
    }
}
