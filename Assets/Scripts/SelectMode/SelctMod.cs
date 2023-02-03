using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelctMod : MonoBehaviour
{
    bool isStart = true;
    public Image image;
    bool isEnd = false;
    public Text startText;
    public Text EndText;

    private void Start()
    {
        GameManager.Instance.SetSceneNum(2);
    }

    void Update()
    {
        if (isEnd == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && !isStart)
            {
                isStart = true;
                GameManager.Instance.SelectMod = 0;
                AlpahText();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && isStart)
            {
                isStart = false;
                GameManager.Instance.SelectMod = 1;
                AlpahText();
            }

            if (isStart && Input.GetKeyDown(KeyCode.Space))
            {
                isEnd = true;
                image.gameObject.SetActive(true);
            }
            else if (!isStart && Input.GetKeyDown(KeyCode.Space))
            {
                isEnd = true;
                image.gameObject.SetActive(true);
            }
        }
    }

    public void AlpahText()
    {
        if (isStart == false)
        {
            Color color = startText.color;
            color.a = 0.5f;
            startText.color = color;

            color = EndText.color;
            color.a = 1.0f;
            EndText.color = color;
        }
        if (isStart == true)
        {
            Color color = startText.color;
            color.a = 1.0f;
            startText.color = color;

            color = EndText.color;
            color.a = 0.5f;
            EndText.color = color;
        }
    }
}
