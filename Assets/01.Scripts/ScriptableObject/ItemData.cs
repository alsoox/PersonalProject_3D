using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    Apple
}

public enum EquipType
{
    Shield,
    Sword
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public string description;
    public ItemType itemType;
    public Sprite icon;

    [Header("Stacking")]
    public bool canStack;
    public int maxStacking;

    [Header("ConditionUpValue")]
    public float value;
    public ConditionType type;

    [Header("EquipPrefap")]
    public GameObject equipPrefap;
    public EquipType equipType;
}
