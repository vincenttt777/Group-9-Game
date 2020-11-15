using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;

public class WeaponPickup : MonoBehaviour, Useable
{
    public string weaponName = "Unknown Weapon";
    public int weaponID;
    public TextMeshPro textMesh;

    private void Start()
    {
        transform.DOMoveY(transform.position.y + 0.2f, 1f).SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }

    public void OnUse()
    {
        transform.DOComplete();
        Game.Player.EquipWeapon(weaponID);
        Destroy(gameObject);
    }

    public void OnSelect()
    {
        if (textMesh)
        {
            textMesh.text = weaponName;
            textMesh.gameObject.SetActive(true);
        }
    }

    public void OnDeselect()
    {
        if (textMesh)
        {
            textMesh.gameObject.SetActive(false);
        }
    }
}
