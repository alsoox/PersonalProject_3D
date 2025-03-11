using System.Collections;
using UnityEngine;


public class ItemObject : MonoBehaviour
{
    public ItemData itemData;
    
    public string GetInteractPrompt()
    {
        //Inventory 에서 아이템 설명
        string str = $"{itemData.itemName}\n{itemData.description}";

        return str;
    }

    public void OnInteract()
    {
        //장비 획득 - 땅에 떨어진(Etable) Type 은 소지할수 없음
        if (itemData.itemType != ItemType.Etable)
        {
            CharacterManager.Instance.Player.itemData = itemData;
            CharacterManager.Instance.Player.addItem?.Invoke();
            Destroy(gameObject);
        }
    }
}
