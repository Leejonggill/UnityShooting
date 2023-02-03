using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscManage : MonoBehaviour
{
    public Text PasueText;
    public Text[] texts;
    bool isEsc = false;
    int Select = 0;

    private void Update()
    {
        Debug.Log(Select);
        if (Input.GetKeyDown(KeyCode.Escape) && !isEsc)
        {
            SetAcitveText();
            isEsc = true;
            Time.timeScale = 0.0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isEsc)
        {
            SetAcitveText();
            isEsc = false;
            Time.timeScale = 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Select++;
            AlpahText();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Select--;
            AlpahText();
        }

        if(Input.GetKeyDown(KeyCode.Z)&&isEsc)
        {
            LoadScene();
        }
    }

    void SetAcitveText()
    {
        if (PasueText.gameObject.activeSelf == false)
        {
            PasueText.gameObject.SetActive(true);
        }

        if (PasueText.gameObject.activeSelf == true&&isEsc==true)
        {
            PasueText.gameObject.SetActive(false);
        }

        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].gameObject.SetActive(true);
        }

        if(isEsc==true)
        {
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].gameObject.SetActive(false);
            }
        }
    }

    public void AlpahText()
    {
        Select = Mathf.Clamp(Select, 0, 2);
        for (int i = 0; i < texts.Length; i++)
        {
            if (i != Select) 
            {
                Color color = texts[i].color;
                color = texts[i].color;
                color.a = 0.5f;
                texts[i].color = color;
            }
            else if(i==Select)
            {
                Color color = texts[i].color;
                color = texts[i].color;
                color.a = 1.0f;
                texts[i].color = color;
            }
        }
    }

    public void LoadScene()
    {
        if (Select == 0)
        {
            SetAcitveText();
            isEsc = false;
            Time.timeScale = 1.0f;
        }
        if (Select==1)
        {
            SceneManager.LoadScene(0);
        }
        if(Select==2)
        {
            Application.Quit();
        }
    }
}
