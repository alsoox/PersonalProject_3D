using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EquipSkill : MonoBehaviour
{
    [Header("Dash")]
    public float dashSpeed;
    public float dashDuration;
    public float dashCoolTime;
    private Coroutine dashCorutine;

    [Header("DoubleJump")]
    public bool isDoubleJump = false;

    public void OnDashSkill(InputAction.CallbackContext context)
    {
        List<Equip> equip = CharacterManager.Instance.Player.equip.curEquip;

        if (equip == null) return;

        bool hasSword = false;
        for (int i = 0; i < equip.Count; i++)
        {
            if (equip[i].equipType == EquipType.Sword && equip[i].isEquip)
            {
                hasSword = true;
                break;
            }
        }
        if (!hasSword) return;

        if (context.phase == InputActionPhase.Started)
        {
            Debug.Log("대쉬했다");
            if (dashCorutine != null) StopCoroutine(dashCorutine);

            dashCorutine = StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        float prevSpeed = CharacterManager.Instance.Player.playerController.walkSpeed;
        CharacterManager.Instance.Player.playerController.walkSpeed = dashSpeed;
        float time = 0;

        while (time < dashDuration)
        {
            time += Time.deltaTime;
            yield return null;
        }

        CharacterManager.Instance.Player.playerController.walkSpeed = prevSpeed;
    }

    public bool HasDoubleJump()
    {
        List<Equip> equip = CharacterManager.Instance.Player.equip.curEquip;
        if (equip == null) return false;

        bool hasShield = false;
        for (int i = 0; i < equip.Count; i++)
        {
            if (equip[i].equipType == EquipType.Shield && equip[i].isEquip)
            {
                hasShield = true;
                break;
            }
        }
        if (!hasShield) return false;
        return true;
    }
}
