using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cBossEvent : MonoBehaviour
{
    public Text  bossNameText;
    public Image bossHpscrollbar;
    public GameObject Boss;
    public GameObject effect;
    public GameObject effect2;

    int frame = 0;
    void Start()
    {
        StartCoroutine(Setboss());
    }

    IEnumerator Setboss()
    {
        if (frame == 0)
        {
            frame++;
            yield return new WaitForSeconds(1);
            StartCoroutine(Setboss());
        }
        else if (frame==1)
        {
            frame++;
            Instantiate(effect2, transform.position + new Vector3(-2f, 0, 0), Quaternion.identity);
            Instantiate(effect2, transform.position + new Vector3(2f, 0, 0), Quaternion.identity);
            Instantiate(effect2, transform.position + new Vector3(-2f, -2f, 0), Quaternion.identity);
            Instantiate(effect2, transform.position + new Vector3(2f, -2f, 0), Quaternion.identity);
            Instantiate(effect2, transform.position + new Vector3(-2f, -4f, 0), Quaternion.identity);
            Instantiate(effect2, transform.position + new Vector3(2f, -4f, 0), Quaternion.identity);
            yield return new WaitForSeconds(1);
            StartCoroutine(Setboss());
        }
        else if(frame==2)
        {
            Instantiate(effect2, transform.position , Quaternion.identity);
            Instantiate(effect, transform.position , Quaternion.identity);
            Boss.gameObject.SetActive(true);
            bossNameText.gameObject.SetActive(true);
            bossHpscrollbar.gameObject.SetActive(true);
        }
    }
}
