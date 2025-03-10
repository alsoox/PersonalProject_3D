using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
using static UnityEngine.EventSystems.EventTrigger;

public class UIInventory : MonoBehaviour
{
    [Header("ItemSlot")]
    private List<ItemData> inventory = new List<ItemData>();
    private List<UISlot> slots;

    public TextMeshProUGUI itemNameDisplay;
    public TextMeshProUGUI itemDiscription;
    public Button useButton;
    public UISlot selcetSlot;
    [Header("Apple")]
    public TextMeshProUGUI appleText;

    // Start is called before the first frame update
    void Start()
    {
        CharacterManager.Instance.Player.playerController.inventory = this;
        CharacterManager.Instance.Player.addItem += AddItem;
        slots = GetComponentsInChildren<UISlot>().ToList();

        useButton.onClick.AddListener(OnClickUseButton);
        gameObject.SetActive(false);
    }

    public void ShowInventory()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
        UpdateUI();
    }

    private void AddItem()
    {
        ItemData item = CharacterManager.Instance.Player.itemData;

        if (inventory.Contains(item))
        {            
            UISlot slot = GetItemSlot(item);
            slot.quantity++;
        }
        else
        {
            UISlot emptySlot = GetEmptySlot(item.itemType);
            emptySlot.itemData = item;
            inventory.Add(item); // 새아이템 1개 등록
            emptySlot.quantity++;
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].itemData != null)
            {
                slots[i].Set();
            }
            else
            {
                slots[i].Clear();
            }
        }

        appleText.text = CharacterManager.Instance.Player.playerCondition.reserveApple.ToString();
    }

    private UISlot GetItemSlot(ItemData data)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].itemData == data && slots[i].type == data.itemType)
            {
                return slots[i];
            }
        }
        return null;
    }

    private UISlot GetEmptySlot(ItemType itemType)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].itemData == null && slots[i].type == itemType)
            {
                return slots[i];
            }
        }
        return null;
    }

    public void SelectItem(UISlot slot)
    {        
        selcetSlot = slot;

        if (selcetSlot.itemData == null) return;
        itemNameDisplay.text = selcetSlot.itemData.itemName;
        itemDiscription.text = selcetSlot.itemData.description;

        
    }

    public void OnClickUseButton()
    {
        switch (selcetSlot.type)
        {
            case ItemType.Equipable:
                selcetSlot.Equip();
                UpdateUI();
                break;
            case ItemType.Consumable:
                selcetSlot.UseConsume();
                UpdateUI();
                break;
        }
    }
}
