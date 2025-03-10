using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISkill : MonoBehaviour
{
    public Image dashCoolImage;
    private EquipSkill equipSkill;

    private void Start()
    {
        equipSkill = FindObjectOfType<EquipSkill>();
    }

    private void Update()
    {
        DashCoolDown();
    }

    public void DashCoolDown()
    {
        float percnetage = (Time.time - equipSkill.lastDashTime) / equipSkill.dashCoolTime;
        dashCoolImage.fillAmount = percnetage;
    }

}
