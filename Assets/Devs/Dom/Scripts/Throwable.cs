using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Throwable : Weapon
{
    public GameObject projectilePrefab;
    public float coolDownTime = 0.5f;
    private bool _throwableReady = true;
    public int currentAmmo = -1;
    
    public override void OnWeaponDown()
    {
        Attack();
    }

    void Attack()
    {
        if (!_throwableReady || currentAmmo == 0) return;
        
        _throwableReady = false;
        GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(projectilePrefab, transform.position + Game.GetPlayerTransform().forward * 0.1f, FindObjectOfType<PlayerController>().transform.rotation);
        if (currentAmmo > 0) currentAmmo--;
        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSecondsRealtime(coolDownTime);
        GetComponent<SpriteRenderer>().enabled = true;
        _throwableReady = true;
    }
}
