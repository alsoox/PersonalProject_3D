using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Etable,
    Equipable
}

public enum ConditionType
{
    Health,
    Stamina,
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public string description;
    public ItemType itemType;

    [Header("Stacking")]
    public bool canStack;
    public int maxStacking;

    [Header("ConditionUpValue")]
    public float value;
    public ConditionType type;
}
