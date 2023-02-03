using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedText : MonoBehaviour
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
            powerText.text = "�̵��ӵ� : �ڡڡ�";
        }
        if (GameManager.Instance.GetSelect() == 2)
        {
            powerText.text = "�̵��ӵ� : �ڡ�";
        }
        if (GameManager.Instance.GetSelect() == 3)
        {
            powerText.text = "�̵��ӵ� : �ڡڡ�";
        }
    }
}