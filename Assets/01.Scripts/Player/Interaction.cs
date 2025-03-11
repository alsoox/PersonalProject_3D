using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{

    public float maxCheckDistance;
    public LayerMask interatLayer;
    Camera _camera;

    public GameObject curIteractGameObject;
    private ItemObject curItemObject;
    public TextMeshProUGUI promtText;

    private void Start()
    {
        _camera = Camera.main;
        InvokeRepeating("CheckInteracktable", 0, 0.1f);
    }


    private void CheckInteracktable()
    {
        //메인 카메라 기준 중앙 부분 레이 충돌체 확인 후 상호작용
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxCheckDistance, interatLayer))
        {
            curIteractGameObject = hit.collider.gameObject;
            //상호작용 아이템 정보 저장
            curItemObject = hit.collider.GetComponent<ItemObject>();
            ShowPromtText();
        }
        else
        {
            curIteractGameObject = null;
            curItemObject = null;
            promtText.gameObject.SetActive(false);
        }

    }

    private void ShowPromtText()
    {
        //아이템 설명 UI 활성화
        promtText.gameObject.SetActive(true);
        promtText.text = curItemObject.GetInteractPrompt();
    }

    public void OnIterack(InputAction.CallbackContext context)
    {
        //상호작용 물체 있을 경우 장비 획득
        if (context.phase == InputActionPhase.Started && curIteractGameObject != null)
        {
            curItemObject.OnInteract();        
        }
    }

}
