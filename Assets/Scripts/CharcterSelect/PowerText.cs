using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerText : MonoBehaviour
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
            powerText.text = "파워 : ★★";
        }
        if (GameManager.Instance.GetSelect() == 2)
        {
            powerText.color = new Color(255, 255, 0);
            powerText.text = "파워 : ★★★";
        }
        if (GameManager.Instance.GetSelect() == 3)
        {
            powerText.color = new Color(0,255 , 0);
            powerText.text = "파워 : ★★";
        }
    }
}
