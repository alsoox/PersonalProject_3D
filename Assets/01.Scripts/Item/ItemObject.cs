using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemObject : MonoBehaviour
{
    public ItemData itemData;

    public string GetInteractPrompt()
    {
        string str = $"{itemData.itemName}\n{itemData.description}";

        return str;
    }

    public void OnInteract()
    {
        //���� ������(Etable) Type �� �����Ҽ� ����
        if (itemData.itemType != ItemType.Etable)
        {
            CharacterManager.Instance.Player.itemData = itemData;
            CharacterManager.Instance.Player.addItem?.Invoke();
            Destroy(gameObject);
        }
    }
}
