using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    [Header("PlayerCondition")]
    [HideInInspector]public float curHealth;
    public float maxHealth;
    public float maxStamina;
    public float passiveStamina;
    [HideInInspector] public float curStamina;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        curStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        PassiveStamina();
    }

    public bool UseStamina(float amount)
    {
        if (curStamina - amount < 0)
        {
            return false;
        }

        curStamina -= amount;
        return true;
    }

    private void PassiveStamina()
    {
        if (curStamina >= maxHealth) return;
        curStamina += passiveStamina * Time.deltaTime;        
    }
 
}
