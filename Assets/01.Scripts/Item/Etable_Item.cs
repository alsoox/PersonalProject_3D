using System.Collections;
using UnityEngine;

public class Etable_Item : ItemObject
{
    public LayerMask targetLayer;


    private void OnTriggerEnter(Collider other)
    {
        //섭취용 아이템 Player 충돌 검사 후 체력 회복 및 코인 수 증가
        if (((1<< other.gameObject.layer) & targetLayer) != 0 )
        {
            switch(itemData.type)
            {
                case ConditionType.Health:
                    CharacterManager.Instance.Player.playerCondition.AddHealth(itemData.value);
                    break;
                case ConditionType.Apple:
                    CharacterManager.Instance.Player.playerCondition.AddApple((int)itemData.value);
                    break;
            }

            Destroy(gameObject);
        }
    }
}
