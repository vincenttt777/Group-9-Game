using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Weapon
{
    public float swingSpeed = 25f;
    private bool swing = false;
    public float stabAmount = 1f;

    private Vector3 _localPosStart;

    public GameObject clangPrefab;

    void Start()
    {
        _localPosStart = transform.localPosition;
    }
    public void Update()
    {
        if (swing)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _localPosStart + Vector3.forward * stabAmount, Time.deltaTime * swingSpeed);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _localPosStart, Time.deltaTime * swingSpeed);
        }
    }

    public override void OnWeaponDown()
    {
        swing = !swing;
        Attack();
    }
    
    
    public override void OnWeaponRelease()
    {
        swing = !swing;
        Attack();
    }

    public int attackPower = 2;

    private GameManager _gameManager;

    void OnEnable()
    {
        _gameManager = Game.GetGameManager();
    }

    public float rayCastDistance = 2f;
    
    void Attack()
    {
        Vector3 facingDirection = _gameManager.Player.facingDirection;

        bool collision = false;
        
        var selectedObjects = Physics.RaycastAll(transform.position,  facingDirection, rayCastDistance);
        
        foreach (var hit in selectedObjects)
        {
            if (hit.transform != Game.GetPlayerTransform() && Game.DamageObject(hit.transform.gameObject, attackPower))
            {
                collision = true;
                break;
            }
        }

        if (collision)
        {
            Instantiate(clangPrefab, transform.position + facingDirection * 0.3f, Quaternion.identity);
        }
    }
}
