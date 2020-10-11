using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingLights : MonoBehaviour, Useable, Damageable
{
    public GameObject lightObject;

    private bool lightOn = false;
    
    public void OnUse()
    {
        lightOn = !lightOn;
    }

    private void Update()
    {
        
    }

    public void OnSelect()
    {
        
    }

    public void OnDeselect()
    {
        
    }

    public void OnDamaged(int damage)
    {
        Destroy(gameObject);
    }
}
