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
            powerText.text = "������ ���̹�";
        }
        if (GameManager.Instance.GetSelect() == 2)
        {
            powerText.color = new Color(255, 255, 0);
            powerText.text = "Ű����� ������";
        }
        if (GameManager.Instance.GetSelect() == 3)
        {
            powerText.color = new Color(0, 255, 0);
            powerText.text = "��ġ�� �糪��";
        }
    }
}
