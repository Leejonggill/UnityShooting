using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatton2 : MonoBehaviour
{
    Animator ani;
    public GameObject Bullet;
    public GameObject Bullet2;
    public GameObject Bullet3;
    public GameObject Bullet4;
    public GameObject Effect;
    public GameObject StopImage;
    Transform boss;
    Transform Player;


    bool first = false;
    int frame = 0;
    bool isSpawn = false;
    bool isMove = false;
    bool isMove2 = false;
    bool isMove3 = false;
    float Euler = 0;
    float posY = -4;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        ani = GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>();
        boss = GameObject.FindGameObjectWithTag("Boss").transform;
        StartCoroutine(PattonFun());
    }

    private void Update()
    {
        if (isMove == true)
        {
            if (isMove == true && boss.transform.position.x < 1.5f)
            {
                ani.SetInteger("Speed", 3);
                boss.transform.Translate(Vector3.right * 1.0f * Time.unscaledDeltaTime);
            }
            else
            {
                isMove = false;
                ani.SetInteger("Speed", 0);
            }
        }

        if (isMove2 == true)
        {
            if (isMove2 == true && boss.transform.position.x > -3.3f)
            {
                ani.SetInteger("Speed", -3);
                boss.transform.Translate(Vector3.right * -3 * Time.unscaledDeltaTime);
            }
            else
            {
                isMove2 = false;
                ani.SetInteger("Speed", 0);
            }
        }

        if (isMove3 == true)
        {
            isMove3 = false;
            boss.transform.position = new Vector3(-0.6f, 2.5f, 0);
            Instantiate(Effect, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
    public void ImageSetTrue()
    {
        StopImage.SetActive(true);
    }

    public void ImageSetFalse()
    {
        StopImage.SetActive(false);
    }

    public void EffetCreate()
    {
        Instantiate(Effect, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
    }

    IEnumerator PattonFun()
    {
        if (first == false)
        {
            Instantiate(Effect, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
            boss.transform.position = new Vector3(1.3f, 3.3f, -1);
            first = true;
        }
        yield return new WaitForSecondsRealtime(3.0f);
        yield return new WaitForSeconds(1.0f);
        ani.SetInteger("Speed", -3);
        ImageSetTrue();
        EffetCreate();
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0.0f;
        isMove2 = true;
        StopImage.SetActive(true);
        StartCoroutine(Patton1());
        yield return new WaitForSecondsRealtime(4.0f);
        EffetCreate();
        yield return new WaitForSecondsRealtime(0.5f);
        ImageSetFalse();
        frame = 0;
        Time.timeScale = 1.0f;

        // 2 
        yield return new WaitForSecondsRealtime(4.0f);
        ani.SetInteger("Speed", 3);
        isMove = true;
        yield return new WaitForSecondsRealtime(0.5f);
        EffetCreate();
        ImageSetTrue();
        Time.timeScale = 0.0f;
        StartCoroutine(Patton2());
        yield return new WaitForSecondsRealtime(3.0f);
        EffetCreate();
        ImageSetFalse();
        frame = 0;
        posY = -4;
        Time.timeScale = 1.0f;

        //3
        yield return new WaitForSecondsRealtime(4.0f);
        ani.SetInteger("Speed", -3);
        isMove2 = true;
        yield return new WaitForSeconds(0.5f);
        EffetCreate();
        ImageSetTrue();
        Time.timeScale = 0.0f;
        StartCoroutine(Patton3());
        yield return new WaitForSecondsRealtime(3.0f);
        EffetCreate();
        ImageSetFalse();
        frame = 0;
        posY = -4;
        Time.timeScale = 1.0f;

        //4
        yield return new WaitForSecondsRealtime(3.0f);
        isMove = true;
        ani.SetInteger("Speed", 3);
        yield return new WaitForSeconds(0.5f);
        EffetCreate();
        ImageSetTrue();
        StartCoroutine(Patton4());

        yield return new WaitForSecondsRealtime(7.0f);
        isMove2 = true;
        Time.timeScale = 1.0f;
        EffetCreate();
        ImageSetFalse();
        frame = 0;
        posY = -4;
        StartCoroutine(Patton5());

        //6
        yield return new WaitForSecondsRealtime(8.0f);
        frame = 0;
        ani.SetInteger("Speed", -3);
        ImageSetTrue();
        EffetCreate();
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0.0f;
        isMove = true;
        StopImage.SetActive(true);
        StartCoroutine(Patton6());

        yield return new WaitForSecondsRealtime(4.0f);
        EffetCreate();
        frame = 0;
        StartCoroutine(Patton3());
        yield return new WaitForSecondsRealtime(7.0f);
        ImageSetFalse();
        EffetCreate();
        frame = 0;
        Time.timeScale = 1.0f;
        yield return new WaitForSecondsRealtime(4.0f);
        StartCoroutine(PattonFun());
    }

    IEnumerator Patton1()
    {
        frame++;
        for (int i = 0; i < 16; i++)
        {
            Instantiate(Bullet, transform.position + new Vector3(0, 0), Quaternion.Euler(0, 0, Euler));
            Euler += 22.5f;
        }
        Instantiate(Effect, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
        yield return new WaitForSecondsRealtime(0.2f);
        if (frame < 7)
        {
            StartCoroutine(Patton1());
        }
    }

    IEnumerator Patton2()
    {
        frame++;

        Instantiate(Effect, Player.position + new Vector3(2, posY), Quaternion.identity);
        for (int i = 0; i < 8; i++)
        {
            Instantiate(Bullet2, Player.position + new Vector3(2, posY), Quaternion.Euler(0, 0, Euler));
            Euler += 45f;
        }
        for (int i = 0; i < 8; i++)
        {
            Instantiate(Bullet2, Player.position + new Vector3(-2, posY), Quaternion.Euler(0, 0, Euler));
            Euler += 45f;
        }
        Instantiate(Effect, Player.position + new Vector3(-2, posY), Quaternion.identity);
        posY += 2;
        yield return new WaitForSecondsRealtime(0.2f);
        if (frame < 5)
        {
            StartCoroutine(Patton2());
        }
    }

    IEnumerator Patton3()
    {
        frame++;
        for (int i = 0; i < 12; i++)
        {
            Instantiate(Bullet3, Player.position + new Vector3(2, posY), Quaternion.Euler(0, 0, Euler));
            Euler += 30f;
        }
        Instantiate(Effect, Player.position + new Vector3(2, posY), Quaternion.identity);
        for (int i = 0; i < 12; i++)
        {
            Instantiate(Bullet3, Player.position + new Vector3(-2, posY), Quaternion.Euler(0, 0, Euler));
            Euler += 30f;
        }
        Instantiate(Effect, Player.position + new Vector3(-2, posY), Quaternion.identity);
        posY += 2;
        yield return new WaitForSecondsRealtime(0.2f);
        if(frame<5)
        {
            StartCoroutine(Patton3());
        }
    }

    IEnumerator Patton4()
    {
        EffetCreate();
        frame++;
        for (int i = 0; i < 12; i++)
        {
            Instantiate(Bullet4, transform.position + new Vector3(0, 0, -1), Quaternion.Euler(0, 0, Euler));
            Euler += 30;
        }

        Time.timeScale = 1.0f;
        ImageSetFalse();
        Euler += 15f;
        yield return new WaitForSecondsRealtime(0.2f);
        EffetCreate();
        for (int i = 0; i < 12; i++)
        {
            Instantiate(Bullet4, transform.position + new Vector3(0, 0, -1), Quaternion.Euler(0, 0, Euler));
            Euler += 30;
        }
        Euler += 15f;
        Time.timeScale = 0.0f;
        ImageSetTrue();
        yield return new WaitForSecondsRealtime(0.2f);
        Time.timeScale = 1.0f;
        ImageSetFalse();
        if (frame < 10)
        {
            StartCoroutine(Patton4());
        }
    }

    IEnumerator Patton5()
    {
        frame++;
        for (int i = 0; i < 8; i++)
        {
            Instantiate(Bullet4, transform.position + new Vector3(0, 0, -1), Quaternion.Euler(0, 0, Euler));
            Euler += 45;
        }
        Euler += 7.5f;
        yield return new WaitForSeconds(0.1f);
        if (frame < 50)
        {
            StartCoroutine(Patton5());
        }
    }

    IEnumerator Patton6()
    {
        frame++;
        for (int i = 0; i < 16; i++)
        {
            Instantiate(Bullet, transform.position + new Vector3(0, 0), Quaternion.Euler(0, 0, Euler));
            Euler += 22.5f;
        }
        Instantiate(Effect, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
        yield return new WaitForSecondsRealtime(0.6f);
        if (frame < 7)
        {
            StartCoroutine(Patton6());
        }
    }
}
