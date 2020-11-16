﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUse : MonoBehaviour
{

    public GameObject gun;
    public GameObject dagger;

    public bool hasGun;
    public bool hasDagger;

    public bool hasAttacked;

    public bool gunActive;
    public bool daggerActive;

    public float timer;
    public float cooldown = 1;

    public Animator _animator;

    void Start()
    {
        hasGun = false;
        hasDagger = false;

        gunActive = false;
        daggerActive = false;

        hasAttacked = false;

        gun.SetActive(false);
        dagger.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && hasGun)
        {
            gun.SetActive(true);
            dagger.SetActive(false);
            gunActive = true;
            daggerActive = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && hasDagger)
        {
            dagger.SetActive(true);
            gun.SetActive(false);
            gunActive = false;
            daggerActive = true;
        }
        if (Input.GetMouseButtonDown(0) && gunActive && !hasAttacked)
        {
            hasAttacked = true;
        }
        if (Input.GetMouseButtonDown(0) && daggerActive && !hasAttacked)
        {
            hasAttacked = true;
            _animator.SetBool("hasSwung", true);
        }
        if (hasAttacked)
        {
            timer += Time.deltaTime;
        }
        attackCooldown();
    }

    void attackCooldown()
    {
        if (timer >= cooldown)
        {
            timer = 0;
            hasAttacked = false;
            if (daggerActive)
                _animator.SetBool("hasSwung", false);
        }
    }
}