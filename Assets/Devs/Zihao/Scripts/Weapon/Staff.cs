using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : Weapon
{
    public GameObject projectile;
    public Transform ShootPoint;
    private float timeBtwShots;
    public float StartTimeBtwShots;

    public override void OnWeaponDown()
    {

        if (timeBtwShots <= 0)
        {
        }
        else
        {
            Instantiate(projectile, ShootPoint.position, transform.rotation);
            timeBtwShots -= Time.deltaTime;
        }    
    }

    public override void OnWeaponRelease()
    {

    }
}
