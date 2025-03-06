using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float runSpeed;
    private Vector2 curMovementInput;
    public float jumpPower;
    public LayerMask groundLayerMask;

    [Header("Look")]
    public Transform playerLook;
    private float curLookUp;
    private float curLookRight;
    public Vector2 mouseDelta;
    public float mouseSensitivity;
    public float maxLookAngleY;
    public float minLookAngleY;


    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        Look();
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;

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

    private void Jump()
    {

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
            Debug.Log("Jump");
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
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
}
