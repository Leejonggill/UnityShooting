using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ch1 : MonoBehaviour
{
    Color color;
    public Image a;
    float h1 = 1;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(h1);
        if (GameManager.Instance.GetSelect() == 1 && h1 < 255)
        {
            color = a.color;
            color.a = h1 / 255f;
            a.color = color;
            h1 += 5f;
        }
        else if (GameManager.Instance.GetSelect() != 1 && h1 > 0)
        {
            color = a.color;
            color.a = h1 / 255f;
            a.color = color;
            h1 -= 5f;
        }
    }
}
