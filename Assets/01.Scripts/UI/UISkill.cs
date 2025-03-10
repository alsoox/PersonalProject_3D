using System.Collections;
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
        //대쉬 스킬 쿨타임 정보 확인 후 UI 적용
        float percnetage = (Time.time - equipSkill.lastDashTime) / equipSkill.dashCoolTime;
        dashCoolImage.fillAmount = percnetage;
    }

}
