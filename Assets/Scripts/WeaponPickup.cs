using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weapon;

    private WeaponUse weaponScript;

    void Start()
    {
        weaponScript = GameObject.Find("Player").GetComponent<WeaponUse>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (weapon == GameObject.Find("GunPickup"))
        {
            weaponScript.hasGun = true;
            weapon.SetActive(false);
        }

        if (weapon == GameObject.Find("DaggerPickup"))
        {
            weaponScript.hasDagger = true;
            weapon.SetActive(false);
        }
    }
}
