using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{

    private GameManager gm;
    private GameObject player;
    private ShopItemCostManager shopICM;

    public int buttonIndex;
    private Transform[] children;

    [Header("Attribute Button")]
    public bool attributeButton;

    public Sprite maxHealthSprite;
    public Sprite attackDamageSprite;
    public Sprite attackRangeSprite;
    public Sprite moveSpeedSprite;
    public Sprite jumpHeightSprite;
    public Sprite defenceSprite;

    [Header("Pet Button")]
    public bool petButton;

    [Header("Weapon Button")]
    public bool weaponButton;

    private void Start()
    {
        gm = GameObject.FindWithTag("GM").GetComponent<GameManager>();
        player = GameObject.FindWithTag("Player");
        shopICM = GameObject.FindWithTag("GM").GetComponent<ShopItemCostManager>();

        children = GetComponentsInChildren<Transform>();

        switch (buttonIndex)
        {
            case 1:
                gameObject.GetComponentInChildren<Text>().text = "Max Health Upgrade";
                children[2].GetComponent<Image>().sprite = maxHealthSprite;
                children[3].GetComponent<Text>().text = shopICM.maxHealthCost.ToString();
                break;
            case 2:
                gameObject.GetComponentInChildren<Text>().text = "Attack Damage Upgrade";
                children[2].GetComponent<Image>().sprite = attackDamageSprite;
                children[3].GetComponent<Text>().text = shopICM.attackDamageCost.ToString();
                break;
            case 3:
                gameObject.GetComponentInChildren<Text>().text = "Attack Range Upgrade";
                children[2].GetComponent<Image>().sprite = attackRangeSprite;
                children[3].GetComponent<Text>().text = shopICM.attackRangeCost.ToString();
                break;
            case 4:
                gameObject.GetComponentInChildren<Text>().text = "Movement Speed Upgrade";
                children[2].GetComponent<Image>().sprite = moveSpeedSprite;
                children[3].GetComponent<Text>().text = shopICM.moveSpeedCost.ToString();
                break;
            case 5:
                gameObject.GetComponentInChildren<Text>().text = "Jump Height Upgrade";
                children[2].GetComponent<Image>().sprite = jumpHeightSprite;
                children[3].GetComponent<Text>().text = shopICM.jumpHeightCost.ToString();
                break;
            case 6:
                gameObject.GetComponentInChildren<Text>().text = "Defence Upgrade";
                children[2].GetComponent<Image>().sprite = defenceSprite;
                children[3].GetComponent<Text>().text = shopICM.defenceCost.ToString();
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
                    shopICM.maxHealthCost += shopICM.maxHealthCostIncrease;
                    children[3].GetComponent<Text>().text = shopICM.maxHealthCost.ToString();
                    break;
                case 2:
                    player.GetComponent<Entity>().stats.attackDamage += 10;
                    shopICM.attackDamageCost += shopICM.attackDamageCostIncrease;
                    children[3].GetComponent<Text>().text = shopICM.attackDamageCost.ToString();
                    break;
                case 3:
                    player.GetComponent<Entity>().stats.attackRange += 2.5f;
                    shopICM.attackRangeCost += shopICM.attackRangeCostIncrease;
                    children[3].GetComponent<Text>().text = shopICM.attackRangeCost.ToString();
                    break;
                case 4:
                    player.GetComponent<Entity>().stats.moveSpeed += 0.5f;
                    shopICM.moveSpeedCost += shopICM.moveSpeedCostIncrease;
                    children[3].GetComponent<Text>().text = shopICM.moveSpeedCost.ToString();
                    break;
                case 5:
                    player.GetComponent<Entity>().stats.jumpForce += 0.5f;
                    shopICM.jumpHeightCost += shopICM.jumpHeightCostIncrease;
                    children[3].GetComponent<Text>().text = shopICM.jumpHeightCost.ToString();
                    break;
                case 6:
                    player.GetComponent<Entity>().stats.defence += 2;
                    shopICM.defenceCost += shopICM.defenceCostIncrease;
                    children[3].GetComponent<Text>().text = shopICM.defenceCost.ToString();
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
