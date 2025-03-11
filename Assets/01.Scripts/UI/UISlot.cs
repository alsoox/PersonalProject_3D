using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public ItemData itemData;
    public ItemType type;

    public Button button;
    public Image icon;
    public TextMeshProUGUI itemCurText;
    public int quantity;
    public bool isEquip;

    private UIInventory inventory;

    private void Awake()
    {
        button.onClick.AddListener(OnClickButton);
    }

    private void Start()
    {
        //�κ��丮�� ȹ�� ������ ���� �����ϹǷ� �κ��丮 �ʿ�
        inventory = FindObjectOfType<UIInventory>();
        isEquip = false;        
    }

    public void Set()
    {
        icon.sprite = itemData.icon;
        switch(type)
        {
            case ItemType.Consumable: 
                //��� ������ ���� Ȯ�� �� UI ǥ��
                itemCurText.text = quantity.ToString();                
                break;
            case ItemType.Equipable:
                //���� ������ ���� ������ ���� ǥ��
                if (isEquip)
                {
                    itemCurText.text = "[E]";
                }
                else
                {
                    itemCurText.text = "";
                }
                break;
        }
    }

    public void Clear()
    {   
        //������ ���� �ʱ�ȭ
        itemData = null;
        icon.sprite = null;        
    }

    private void OnClickButton()
    {
        inventory.SelectItem(this);
    }
    
    public void UseConsume()
    {
        //��� ������ Ÿ�� ���ο� ���� ��� �� �÷��̾� ���� ����
        if (quantity > 0)
        {
            if (itemData.type == ConditionType.Health)
            {
                CharacterManager.Instance.Player.playerCondition.AddHealth(itemData.value);
            }
            else
            {
                CharacterManager.Instance.Player.playerCondition.AddStamina(itemData.value);
            }
            quantity--;
        }
    }

    public void Equip()
    {
        isEquip = !isEquip;

        //���� ������ Ÿ�Կ� ���� Equipment ������ ������ ����
        if(isEquip)
        {
            if (itemData.equipType == EquipType.Shield)
            {
                CharacterManager.Instance.Player.equip.Equip(itemData);
            }
            else if(itemData.equipType == EquipType.Sword)
            {
                CharacterManager.Instance.Player.equip.Equip(itemData);
            }
        }
        else
        {
            if (itemData.equipType == EquipType.Shield)
            {
                CharacterManager.Instance.Player.equip.UnEquip(itemData);
            }
            else if (itemData.equipType == EquipType.Sword)
            {
                CharacterManager.Instance.Player.equip.UnEquip(itemData);
            }

        }

    }
}
