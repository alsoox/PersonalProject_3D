using System.Collections;
using UnityEngine;

public class Plane : MonoBehaviour
{
    // Player 타켓 지정
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

        // 움직이는 Plane 일시 이동 로직 동작
        MovePlane();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Plane 에 Player Collision 시 Player 해당 Plane 자식 오브젝트로 들어가 같이 움직이기
        if (((1<<collision.gameObject.layer) & target) != 0)
        {
            collision.transform.SetParent(transform, true);

            if (!isForce) return;
            //JumpPlane 일 시 플레이어 높이 점프
            CharacterManager.Instance.Player.playerController.Jump(jumpForce);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //Plane 에 빠져나오면 Player 자식에서 빠져나오기
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
