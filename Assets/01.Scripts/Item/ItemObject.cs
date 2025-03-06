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
}
