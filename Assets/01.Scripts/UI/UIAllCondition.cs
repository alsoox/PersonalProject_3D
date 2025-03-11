using System.Collections;
using UnityEngine;

public class UIAllCondition : MonoBehaviour
{
    PlayerCondition playerCondition;

    public UICondition health;
    public UICondition stamina;

    // Start is called before the first frame update
    void Start()
    {
        playerCondition = FindObjectOfType<PlayerCondition>();

        health.maxValue = playerCondition.maxHealth;
        stamina.maxValue = playerCondition.maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCondition == null) return;
        //플레이어 Condition 확인 후 UI업데이트
        health.curValue = playerCondition.curHealth;
        stamina.curValue = playerCondition.curStamina;
        health.maxValue = playerCondition.maxHealth;
        stamina.maxValue = playerCondition.maxStamina;
    }
}
