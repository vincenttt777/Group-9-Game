using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    public Vector3 swingStartRot;
    public Vector3 swingFinalRot;
    public float swingSpeed = 25f;
    private bool swing = false;

    public GameObject clangPrefab;
    
    public void Update()
    {
        if (swing)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(swingStartRot), Time.deltaTime * swingSpeed);
        }
        else
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(swingFinalRot), Time.deltaTime * swingSpeed);
        }
    }

    public override void OnWeaponDown()
    {
        swing = !swing;
        Attack();
    }

    void Attack()
    {
        Vector3 facingDirection = GameObject.FindObjectOfType<PlayerController>().facingDirection;

        bool collision = false;
        
        var selectedObjects = Physics.SphereCastAll(transform.position + facingDirection * 0.1f, 0.35f, facingDirection, 0.2f);
        foreach (var hit in selectedObjects)
        {
            if (hit.transform.gameObject.GetComponent<Interactable>() != null)
            {
                collision = true;
                hit.transform.gameObject.GetComponent<Interactable>().OnUse();
                break;
            }
        }

        if (collision)
        {
            Instantiate(clangPrefab, transform.position + facingDirection * 0.3f, Quaternion.identity);
        }
    }
}
