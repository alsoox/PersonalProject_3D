using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxCheckDistance, interatLayer))
        {
            curIteractGameObject = hit.collider.gameObject;
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
        promtText.gameObject.SetActive(true);
        promtText.text = curItemObject.GetInteractPrompt();
    }

    public void OnIterack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && curIteractGameObject != null)
        {
            curItemObject.OnInteract();        
        }
    }

}
