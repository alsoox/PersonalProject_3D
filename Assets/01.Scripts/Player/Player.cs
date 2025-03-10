using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerCondition playerCondition;
    public Equipment equip;
    public EquipSkill skill;

    public ItemData itemData;
    public Action addItem;

    void Awake()
    {
        CharacterManager.Instance.Player = this;
        playerController = GetComponent<PlayerController>();
        playerCondition = GetComponent<PlayerCondition>();
        equip = GetComponent<Equipment>();
        skill = GetComponent<EquipSkill>();
    }

}
