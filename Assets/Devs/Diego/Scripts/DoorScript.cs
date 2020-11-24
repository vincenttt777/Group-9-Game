using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour, Useable
{
    Animator anim;
    public bool isLocked = false;
    void Start ()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        // Door destroys itself
        anim.SetTrigger("door");   
    }

    public void OnUse()
    {
        if (isLocked)
        {
            if (Game.GetGameManager().KeyCount > 0)
            {
                Game.GetGameManager().KeyCount = Game.GetGameManager().KeyCount - 1;
                isLocked = false;
                OpenDoor();
            }
            return;
        }
        
        OpenDoor();
    }

    public void OnSelect()
    {
    }

    public void OnDeselect()
    {
    }
}
