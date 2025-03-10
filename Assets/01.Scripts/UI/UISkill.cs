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
        //�뽬 ��ų ��Ÿ�� ���� Ȯ�� �� UI ����
        float percnetage = (Time.time - equipSkill.lastDashTime) / equipSkill.dashCoolTime;
        dashCoolImage.fillAmount = percnetage;
    }

}
