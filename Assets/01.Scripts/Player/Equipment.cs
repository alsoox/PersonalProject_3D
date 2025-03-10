using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public Transform equipItem; //장비 착용 시 들어갈 부모 오브젝트 저장
    public List<Equip> curEquip;

    public void Equip(ItemData data)
    {
        // 보유 중인 장비 확인 후 있으면 오브젝트 활성화 없으면 생성
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
