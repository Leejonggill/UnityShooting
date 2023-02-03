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
            powerText.text = "이동속도 : ★★★";
        }
        if (GameManager.Instance.GetSelect() == 2)
        {
            powerText.text = "이동속도 : ★★";
        }
        if (GameManager.Instance.GetSelect() == 3)
        {
            powerText.text = "이동속도 : ★★★";
        }
    }
}