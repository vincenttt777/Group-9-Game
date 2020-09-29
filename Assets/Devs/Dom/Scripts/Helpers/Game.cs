using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    public static bool UseObject (GameObject gameObject)
    {
        var useable = false;
        
        foreach (var useableObj in gameObject.GetComponents<Useable>())
        {
            useableObj.OnUse();
            useable = true;
        }

        return useable;
    }
    
    public static bool DamageObject (GameObject gameObject, int damage)
    {
        var damaged = false;
        
        foreach (var damageableObj in gameObject.GetComponents<Damageable>())
        {
            damageableObj.OnDamaged(damage);
            damaged = true;
        }

        return damaged;
    }

    public static GameManager GetGameManager ()
    {
        return GameManager.Instance;
    }

    public static Camera GetMainCamera ()
    {
        return GameManager.Instance?.GameCamera?.Camera;
    }

    public static Transform GetPlayerTransform()
    {
        return GameManager.Instance.Player.gameObject.transform;
    }
    
}
