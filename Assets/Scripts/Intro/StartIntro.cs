using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartIntro : MonoBehaviour
{
    bool isStart = true;
    public Image image;
    bool isEnd = false;
    public Text startText;
    public Text EndText;

    private void Start()
    {
        GameManager.Instance.SetSceneNum(0);
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (isEnd == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && !isStart)
            {
                isStart = true;
                AlpahText();
                transform.position = new Vector3(1.51f, -1.6f, 2);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && isStart)
            {
                isStart = false;
                AlpahText();
                transform.position = new Vector3(1.51f, -2.3f, 2);
            }

            if (isStart && Input.GetKeyDown(KeyCode.Space))
            {
                isEnd = true;
                image.gameObject.SetActive(true);
            }
            else if (!isStart && Input.GetKeyDown(KeyCode.Space))
            {
                Application.Quit();
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
        if(isStart == true)
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
