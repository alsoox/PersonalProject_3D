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
        //인벤토리에 획득 아이템 정보 저장하므로 인벤토리 필요
        inventory = FindObjectOfType<UIInventory>();
        isEquip = false;        
    }

    public void Set()
    {
        icon.sprite = itemData.icon;
        switch(type)
        {
            case ItemType.Consumable: 
                //사용 아이템 수량 확인 후 UI 표시
                itemCurText.text = quantity.ToString();                
                break;
            case ItemType.Equipable:
                //착용 아이템 착용 유무에 따른 표시
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
        //아이템 슬롯 초기화
        itemData = null;
        icon.sprite = null;        
    }

    private void OnClickButton()
    {
        inventory.SelectItem(this);
    }
    
    public void UseConsume()
    {
        //사용 아이템 타입 여부에 따른 사용 후 플레이어 상태 변경
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

        //착용 아이템 타입에 따라 Equipment 아이템 데이터 전달
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
