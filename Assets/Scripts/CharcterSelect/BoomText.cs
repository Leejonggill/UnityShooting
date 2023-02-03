using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoomText : MonoBehaviour
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
            powerText.text = "ÆøÅº : ¡Ú¡Ú¡Ú";
        }
        if (GameManager.Instance.GetSelect() == 2)
        {
            powerText.text = "ÆøÅº : ¡Ú¡Ú";
        }
        if (GameManager.Instance.GetSelect() == 3)
        {
            powerText.text = "ÆøÅº : ¡Ú¡Ú¡Ú¡Ú";
        }
    }
}
