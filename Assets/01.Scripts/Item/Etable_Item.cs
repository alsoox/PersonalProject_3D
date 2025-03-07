using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Etable_Item : ItemObject
{
    public LayerMask targetLayer;

    private void OnTriggerEnter(Collider other)
    {
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
