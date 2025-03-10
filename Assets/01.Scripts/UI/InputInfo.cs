using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputInfo : MonoBehaviour
{
    public LayerMask target;
    public GameObject inputInfoUI;

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & target) != 0)
        {
            inputInfoUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(((1 << other.gameObject.layer) & target) != 0)
        {
            inputInfoUI.SetActive(false);
        }
    }
}
