using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed;
    public float addSpeed;
    private Vector2 curMovementInput;
    public float jumpPower;
    public LayerMask groundLayerMask;
    public float runStamina;
    private bool isRun = false;

    [Header("Look")]
    public Transform playerLook;
    private float curLookUp;
    private float curLookRight;
    public Vector2 mouseDelta;
    public float mouseSensitivity;
    public float maxLookAngleY;
    public float minLookAngleY;
    private bool canLook;

    private Rigidbody rigid;
    private Coroutine runStaminaCoroutine;
    public UIInventory inventory;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        canLook = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        if (isRun && CharacterManager.Instance.Player.playerCondition.curStamina > 0)
        {
            Move(walkSpeed + addSpeed);
        }
        else
        {
            Move(walkSpeed);
        }
    }
    private void LateUpdate()
    {
        if (canLook)
        {
            Look();
        }
    }

    private void Move(float speed)
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= speed;

        dir.y = rigid.velocity.y;

        rigid.velocity = dir;
    }

    private void Look()
    {
        curLookUp += mouseDelta.y * mouseSensitivity;
        curLookRight += mouseDelta.x * mouseSensitivity;

        curLookUp = Mathf.Clamp(curLookUp, minLookAngleY, maxLookAngleY);

        playerLook.localRotation = Quaternion.Euler(-curLookUp, curLookRight, 0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }      
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            Jump(jumpPower);
            CharacterManager.Instance.Player.skill.isDoubleJump = false;
        }

        if (context.phase == InputActionPhase.Started && CharacterManager.Instance.Player.skill.HasDoubleJump()
            && !CharacterManager.Instance.Player.skill.isDoubleJump && !IsGrounded())
        {
            Jump(jumpPower);
            CharacterManager.Instance.Player.skill.isDoubleJump = true;
        }

    }

    public void Jump(float _jumppower)
    {
        rigid.AddForce(Vector3.up * _jumppower, ForceMode.Impulse);
    }
        

    public void OnRun(InputAction.CallbackContext context)
    {
        if (CharacterManager.Instance.Player.playerCondition.curStamina <= 0) return;
      
        if (context.phase == InputActionPhase.Performed)
        {
            isRun = true;
            
            runStaminaCoroutine = StartCoroutine(UseRuningStamina());
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            isRun = false;
            if (runStaminaCoroutine != null)
            {
                StopCoroutine(runStaminaCoroutine);
            }
        }
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            inventory.ShowInventory();
            ToggleCursor();
        }
    }

    private IEnumerator UseRuningStamina()
    {
        while(isRun)
        {
            if (!CharacterManager.Instance.Player.playerCondition.UseStamina(runStamina * Time.deltaTime))
            {
                //사용 가능 스태미나 없을시 종료
                if (!CharacterManager.Instance.Player.playerCondition.UseStamina(runStamina))
                {
                    isRun = false;
                    yield break;                    
                }
            }          
                yield return null;
        }
    }

    private bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.3f) + (transform.up * 0.01f),Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.3f) + (transform.up * 0.01f),Vector3.down),
            new Ray(transform.position + (transform.right* 0.3f) + (transform.up * 0.01f),Vector3.down),
            new Ray(transform.position + (-transform.right * 0.3f) + (transform.up * 0.01f),Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask)) return true;          
        }
        return false;
    }

    private void ToggleCursor()
    {
        bool toggle = Cursor.lockState == CursorLockMode.Locked;
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        canLook = !toggle;
    }
}
