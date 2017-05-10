﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{

    public GameManager gm;
    public GameObject player;

    public bool attributeButton;
    public bool petButton;
    public bool weaponButton;

    public int buttonIndex;

    public Sprite healthSprite;
    public Sprite attackDamageSprite;
    public Sprite attackRangeSprite;
    public Sprite moveSpeedSprite;
    public Sprite jumpHeightSprite;
    public Sprite defenceSprite;

    private void Start()
    {
        gm = GameObject.FindWithTag("GM").GetComponent<GameManager>();
        player = GameObject.FindWithTag("Player");

        List<Transform> children = new List<Transform>();
        foreach (Transform child in gameObject.transform)
        {
            children.Add(child);
        }

        switch (buttonIndex)
        {
            case 1:
                gameObject.GetComponentInChildren<Text>().text = "Max Health Upgrade";
                children[1].GetComponent<Image>().sprite = healthSprite;
                //assign cost
                break;
            case 2:
                gameObject.GetComponentInChildren<Text>().text = "Attack Damage Upgrade";
                children[1].GetComponent<Image>().sprite = attackDamageSprite;
                break;
            case 3:
                gameObject.GetComponentInChildren<Text>().text = "Attack Range Upgrade";
                children[1].GetComponent<Image>().sprite = attackRangeSprite;
                break;
            case 4:
                gameObject.GetComponentInChildren<Text>().text = "Movement Speed Upgrade";
                children[1].GetComponent<Image>().sprite = moveSpeedSprite;
                break;
            case 5:
                gameObject.GetComponentInChildren<Text>().text = "Jump Height Upgrade";
                children[1].GetComponent<Image>().sprite = jumpHeightSprite;
                break;
            case 6:
                gameObject.GetComponentInChildren<Text>().text = "Defence Upgrade";
                children[1].GetComponent<Image>().sprite = defenceSprite;
                break;
        }
    }

    public void BuyUpgrade()
    {
        if (attributeButton)
        {
            switch (buttonIndex)
            {
                case 1:
                    player.GetComponent<Entity>().stats.maxHealth += 25;
                    //decrease currency
                    break;
                case 2:
                    player.GetComponent<Entity>().stats.attackDamage += 10;
                    break;
                case 3:
                    player.GetComponent<Entity>().stats.attackRange += 2.5f;
                    break;
                case 4:
                    player.GetComponent<Entity>().stats.moveSpeed += 0.5f;
                    break;
                case 5:
                    player.GetComponent<Entity>().stats.jumpForce += 0.5f;
                    break;
                case 6:
                    player.GetComponent<Entity>().stats.defence += 2;
                    break;
            }

        }
        else if (petButton)
        {
            switch (buttonIndex)
            {
                case 1:
                    break;
            }

        }
        else if (weaponButton)
        {
            switch (buttonIndex)
            {
                case 1:
                    break;
            }

        }
    }
}
