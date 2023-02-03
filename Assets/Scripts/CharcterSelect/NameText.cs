using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameText : MonoBehaviour
{
    Text powerText;

    void Start()
    {
        powerText = GetComponent<Text>();
    }

    void Update()
    {
        if (GameManager.Instance.GetSelect() == 1)
        {
            powerText.color = new Color(255, 0, 0);
            powerText.text = "하쿠레이 레이무";
        }
        if (GameManager.Instance.GetSelect() == 2)
        {
            powerText.color = new Color(255, 255, 0);
            powerText.text = "키리사메 마리사";
        }
        if (GameManager.Instance.GetSelect() == 3)
        {
            powerText.color = new Color(0, 255, 0);
            powerText.text = "코치야 사나에";
        }
    }
}
