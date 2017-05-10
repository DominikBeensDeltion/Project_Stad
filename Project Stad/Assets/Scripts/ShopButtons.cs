using System.Collections;
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


    private void Start()
    {
        gm = GameObject.FindWithTag("GM").GetComponent<GameManager>();
        player = GameObject.FindWithTag("Player");

        switch (buttonIndex)
        {
            case 1:
                gameObject.GetComponentInChildren<Text>().text = "Max Health Upgrade"; // + cost, same for the rest
                break;
            case 2:
                gameObject.GetComponentInChildren<Text>().text = "Attack Damage Upgrade";
                break;
            case 3:
                gameObject.GetComponentInChildren<Text>().text = "Attack Range Upgrade";
                break;
            case 4:
                gameObject.GetComponentInChildren<Text>().text = "Movement Speed Upgrade";
                break;
            case 5:
                gameObject.GetComponentInChildren<Text>().text = "Jump Height Upgrade";
                break;
            case 6:
                gameObject.GetComponentInChildren<Text>().text = "Defence Upgrade";
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
                    //decrease currency, increase cost, same for the rest
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
