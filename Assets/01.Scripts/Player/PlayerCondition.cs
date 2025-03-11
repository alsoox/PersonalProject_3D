using System.Collections;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    [Header("PlayerCondition")]
    public float curHealth;
    public float maxHealth;
    public float maxStamina;
    public float passiveStamina;
    [HideInInspector] public float curStamina;
    public float reserveApple;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        curStamina = maxStamina;
        reserveApple = 0f;
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
        //스테미나 소모 시 기본 스태미나 증가
        if (curStamina >= maxHealth) return;
        curStamina += passiveStamina * Time.deltaTime;        
    }
 
    public void AddApple(int amount)
    {
        reserveApple += amount;
    }

    public void AddHealth(float value)
    {
       curHealth = Mathf.Clamp(curHealth += value, 0, maxHealth);
    }

    public void AddStamina(float value)
    {
        curStamina = Mathf.Clamp(curStamina += value, 0, maxHealth);
    }
}
