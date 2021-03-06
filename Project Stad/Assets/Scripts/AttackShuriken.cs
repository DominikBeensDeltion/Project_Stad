﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackShuriken : MonoBehaviour
{

    public GameManager gm;
    public UIManager uim;
    public int totalAmmo;
    public int currentAmmo;
    public int clipSize;
    public float reloadTime;
    public bool isReloading;
    public float attackTime = 0.25f;
    public float attackTimeStamp;
    public bool canFire;
    private GameObject player;
    public GameObject shurikenGO;

    void Start()
    {
        gm = GameObject.FindWithTag("GM").GetComponent<GameManager>();
        player = GameObject.FindWithTag("Player");
        uim = GameObject.FindWithTag("UIM").GetComponent<UIManager>();
    }

    void Update()
    {
        if (gm.isAbleToAttack)
        {
            if (currentAmmo > 0 || totalAmmo > 0)
            {
                if (currentAmmo <= 0 && !isReloading)
                {
                    canFire = false;
                    StartCoroutine(Reload());
                }

                if (Time.time >= attackTimeStamp && Input.GetButton("Fire1") && canFire)
                {
                    Shuriken();
                    attackTimeStamp = Time.time + attackTime;

                    currentAmmo--;
                }
            }

            if (totalAmmo == 0 && currentAmmo == 0 && Input.GetButton("Fire1"))
            {
                if (!uim.noticePanelActive)
                {
                    StartCoroutine(uim.NoticePopUp("Out of ammo!", 2));
                }
            }
        }
    }

    public void Shuriken()
    {
        Instantiate(shurikenGO, player.transform.position, Quaternion.identity);
        Physics2D.IgnoreLayerCollision(8, 9);
    }

    public IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);

        if (totalAmmo >= clipSize)
        {
            currentAmmo += clipSize;
            totalAmmo -= clipSize;
        }
        else if (totalAmmo < clipSize)
        {
            currentAmmo += totalAmmo;
            totalAmmo -= totalAmmo;
        }
        else
        {
            yield return null;
        }

        canFire = true;
        isReloading = false;
    }
}
