using System.Collections;
using System.Collections.Generic;
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

        health.curValue = playerCondition.curHealth;
        stamina.curValue = playerCondition.curStamina;    
    }
}
