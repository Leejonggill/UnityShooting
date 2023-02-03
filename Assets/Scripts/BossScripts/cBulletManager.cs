using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cBulletManager : MonoBehaviour
{
    public GameObject[] bullet;

    int frame = 0;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        if (frame < 10)
        {
            frame++;
            Pattun1();
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(Spawn());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Pattun1()
    {
        float Euler = 0;
        for (int i = 0; i < 18; i++)
        {
            Instantiate(bullet[0], transform.position + new Vector3(0, 0), Quaternion.Euler(0, 0, Euler));
            Euler += 20;
        }
    }
}
