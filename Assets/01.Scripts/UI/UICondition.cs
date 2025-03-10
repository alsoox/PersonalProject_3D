using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UICondition : MonoBehaviour
{
    public float curValue;
    public float maxValue;
    public Image uiBar;

    // Start is called before the first frame update
    void Start()
    {
        curValue = maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        uiBar.fillAmount = GetPercentage();
    }

    float GetPercentage()
    {
        return curValue / maxValue;
    }
}
