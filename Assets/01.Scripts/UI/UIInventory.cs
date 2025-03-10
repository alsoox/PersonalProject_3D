using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


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
        //초기 UI Slot 가져오기
        slots = GetComponentsInChildren<UISlot>().ToList();
        useButton.onClick.AddListener(OnClickUseButton);
        gameObject.SetActive(false);
    }

    public void ShowInventory()
    {
        //인벤토리 Hierarchy 활성화 여부에 따라 진행
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

        //Player - Interaction 된 아이템 정보 확인 후 Slot에 등록
        //인벤토리에 아이템 있으면 ++ 없으면 신규아이템 등록
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
        //UI 최신화 시켜주기
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
        //활성화 된 아이템 슬롯 가져오기
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
        //비활성화 된 아이템 슬롯 가져오기 / 아이템 타입별로 슬롯이 다르기에 타입 확인
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
