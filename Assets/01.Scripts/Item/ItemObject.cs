using System.Collections;
using UnityEngine;


public class ItemObject : MonoBehaviour
{
    public ItemData itemData;
    
    public string GetInteractPrompt()
    {
        //Inventory ���� ������ ����
        string str = $"{itemData.itemName}\n{itemData.description}";

        return str;
    }

    public void OnInteract()
    {
        //��� ȹ�� - ���� ������(Etable) Type �� �����Ҽ� ����
        if (itemData.itemType != ItemType.Etable)
        {
            CharacterManager.Instance.Player.itemData = itemData;
            CharacterManager.Instance.Player.addItem?.Invoke();
            Destroy(gameObject);
        }
    }
}
