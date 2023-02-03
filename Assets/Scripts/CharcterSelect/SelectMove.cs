using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectMove : MonoBehaviour
{
    public Image image;
    public GameObject effect;
    bool isSelect = false;

    private void Start()
    {
        GameManager.Instance.Select = 1;
    }
    void Update()
    {
        if (!isSelect)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                GameManager.Instance.SetScore(-1);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                GameManager.Instance.SetScore(+1);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameManager.Instance.SetSceneNum(1);
                StartCoroutine(StartScene());
            }
        }
    }

    IEnumerator StartScene()
    {
        effect.gameObject.SetActive(true);
        isSelect = true;
        yield return new WaitForSeconds(0.5f);
        image.gameObject.SetActive(true);
    }
}
