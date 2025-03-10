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
        //�ʱ� UI Slot ��������
        slots = GetComponentsInChildren<UISlot>().ToList();
        useButton.onClick.AddListener(OnClickUseButton);
        gameObject.SetActive(false);
    }

    public void ShowInventory()
    {
        //�κ��丮 Hierarchy Ȱ��ȭ ���ο� ���� ����
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

        //Player - Interaction �� ������ ���� Ȯ�� �� Slot�� ���
        //�κ��丮�� ������ ������ ++ ������ �űԾ����� ���
        if (inventory.Contains(item))
        {            
            UISlot slot = GetItemSlot(item);
            slot.quantity++;
        }
        else
        {
            UISlot emptySlot = GetEmptySlot(item.itemType);
            emptySlot.itemData = item;
            inventory.Add(item); // �������� 1�� ���
            emptySlot.quantity++;
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        //UI �ֽ�ȭ �����ֱ�
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
        //Ȱ��ȭ �� ������ ���� ��������
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
        //��Ȱ��ȭ �� ������ ���� �������� / ������ Ÿ�Ժ��� ������ �ٸ��⿡ Ÿ�� Ȯ��
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
