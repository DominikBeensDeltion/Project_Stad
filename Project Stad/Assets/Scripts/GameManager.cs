﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public UIManager uim;
    public WaveManager wm;
    public Animator statsPanelAnim;

    public bool isAbleToAttack = true;

    public static int money = 1000;

    private void Start()
    {
        uim = GameObject.FindWithTag("UIM").GetComponent<UIManager>();
        wm = GameObject.FindWithTag("GM").GetComponent<WaveManager>();
        statsPanelAnim = uim.statsPanel.GetComponent<Animator>();

        uim.StartCoroutine(uim.FadeIn());
        wm.StartCountDown();
    }

    private void Update()
    {
        Debug.Log(money);
        if (Input.GetButton("c"))
        {
            statsPanelAnim.SetBool("StatsPanelActive", true);
        }

        if (Input.GetButtonUp("c"))
        {
            statsPanelAnim.SetBool("StatsPanelActive", false);
        }
    }
}
