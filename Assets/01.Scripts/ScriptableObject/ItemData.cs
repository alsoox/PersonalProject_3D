using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Consumable,//소비용아이템
    Etable,//섭취용아이템
    Equipable//장착용아이템
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
