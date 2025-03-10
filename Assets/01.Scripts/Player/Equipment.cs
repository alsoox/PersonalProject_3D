using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public Transform equipItem; //��� ���� �� �� �θ� ������Ʈ ����
    public List<Equip> curEquip;

    public void Equip(ItemData data)
    {
        // ���� ���� ��� Ȯ�� �� ������ ������Ʈ Ȱ��ȭ ������ ����
        for (int i = 0; i < curEquip.Count; i++)
        {
            if (curEquip[i].equipType == data.equipType)
            {
                curEquip[i].gameObject.SetActive(true);
                curEquip[i].isEquip = true;
                return;
            }
        }
        Equip newEquip = Instantiate(data.equipPrefap, equipItem).GetComponent<Equip>();
        newEquip.isEquip = true;
        curEquip.Add(newEquip);
    }    

    public void UnEquip(ItemData data)
    {
        for (int i = 0; i < curEquip.Count; i++)
        {
            if (curEquip[i].equipType == data.equipType)
            {
                curEquip[i].isEquip = false;
                curEquip[i].gameObject.SetActive(false);                
                return;
            }            
        }
    }
}
