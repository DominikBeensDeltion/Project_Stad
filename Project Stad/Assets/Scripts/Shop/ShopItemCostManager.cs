using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemCostManager : MonoBehaviour
{

    [Header("Attribute Cost")]
    public int maxHealthCost;
    public int attackDamageCost;
    public int attackRangeCost;
    public int moveSpeedCost;
    public int jumpHeightCost;
    public int defenceCost;

    [Header("Attribute Cost Increase")]
    public int maxHealthCostIncrease;
    public int attackDamageCostIncrease;
    public int attackRangeCostIncrease;
    public int moveSpeedCostIncrease;
    public int jumpHeightCostIncrease;
    public int defenceCostIncrease;
}
