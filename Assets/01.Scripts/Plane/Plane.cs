using System.Collections;
using UnityEngine;

public class Plane : MonoBehaviour
{
    // Player Ÿ�� ����
    public LayerMask target;

    [Header("Foce")]
    public bool isForce =false;    
    public float jumpForce;

    [Header("Move")]
    public bool isMove = false;
    private Vector3 prevPos;
    public Vector3 movePos;
    public float moveSpeed;
    private float marginDistance = 0.01f;

    private void Start()
    {
        prevPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (!isMove) return;

        // �����̴� Plane �Ͻ� �̵� ���� ����
        MovePlane();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Plane �� Player Collision �� Player �ش� Plane �ڽ� ������Ʈ�� �� ���� �����̱�
        if (((1<<collision.gameObject.layer) & target) != 0)
        {
            collision.transform.SetParent(transform, true);

            if (!isForce) return;
            //JumpPlane �� �� �÷��̾� ���� ����
            CharacterManager.Instance.Player.playerController.Jump(jumpForce);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //Plane �� ���������� Player �ڽĿ��� ����������
        if (((1<<collision.gameObject.layer) & target) != 0)
        {
            collision.transform.SetParent(null);
        }
    }

    private void MovePlane()
    {
        
        transform.position += Time.fixedDeltaTime * moveSpeed * movePos.normalized;

        Vector3 desiredPos = prevPos + movePos;

        if (Mathf.Abs(Vector3.Distance(transform.position,desiredPos)) < marginDistance 
            || Mathf.Abs(Vector3.Distance(transform.position,prevPos)) < marginDistance)

        {
            moveSpeed *= -1;
        }
    }

}
