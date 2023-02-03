using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatton : MonoBehaviour
{
    Animator ani;
    public GameObject Bullet;
    public GameObject Bullet2;
    public GameObject Bullet3;
    public GameObject Bullet4;
    public GameObject Effect;
    Transform boss;
    

    int frame = 0;
    bool isSpawn = false;
    bool isMove = false;
    bool isMove2 = false;
    bool isMove3 = false;
    float Euler = 0;
    // Start is called before the first frame update
    void Start()
    {
        ani = GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>();
        boss = GameObject.FindGameObjectWithTag("Boss").transform;
        StartCoroutine(SpawnFun());
        //StartCoroutine(Patton1());
    }

    private void Update()
    {
        if(isMove==true)
        {
            if (isMove == true && boss.transform.position.x < 1.5f)
            {
                ani.SetInteger("Speed", 3);
                boss.transform.Translate(Vector3.right * 3 * Time.deltaTime);
            }
            else
            {
                isMove = false;
                ani.SetInteger("Speed", 0);
            }
        }

        if(isMove2==true)
        {
            if (isMove2 == true && boss.transform.position.x > -3f)
            {
                ani.SetInteger("Speed", -3);
                boss.transform.Translate(Vector3.right * -3 * Time.deltaTime);
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
            Instantiate(Effect, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
        }
    }

    IEnumerator SpawnFun()
    {
        // 1
        StartCoroutine(Patton1());
        yield return new WaitForSeconds(10.0f);
        isMove = true;
        frame = 0;
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(Patton1());

        // 2
        yield return new WaitForSeconds(7.0f);
        Instantiate(Effect, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
        frame = 0;
        isMove2 = true;
        StartCoroutine(Patton2());
        yield return new WaitForSeconds(12.0f);
        Instantiate(Effect, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
        frame = 0;
        isMove = true;
        StartCoroutine(Patton3());

        // 3 Áß¾Ó
        yield return new WaitForSeconds(10.0f);
        Instantiate(Effect, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
        yield return new WaitForSeconds(1.0f);
        isMove3 = true;
        yield return new WaitForSeconds(3.0f);
        Instantiate(Effect, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
        frame = 0;
        StartCoroutine(Patton4());

        //4
        yield return new WaitForSeconds(12.0f);
        Instantiate(Effect, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
        frame = 0;
        Euler = 0;
        StartCoroutine(Patton6());
        yield return new WaitForSeconds(10.0f);
        Euler = 0;
        frame = 0;
        StartCoroutine(SpawnFun());
    }

    IEnumerator Patton1()
    {
        Debug.Log(frame);
        frame++;
        if (isSpawn == false)
        {
            isSpawn = true;
            yield return new WaitForSeconds(4.0f);
        }

        for (int i = 0; i < 8; i++)
        {
            Instantiate(Bullet, transform.position + new Vector3(0, 0, -1), Quaternion.Euler(0, 0, Euler));
            Euler += 45;
        }
        Euler += 20;
        for (int i = 0; i < 8; i++)
        {
            Instantiate(Bullet, transform.position + new Vector3(0, 0, -1), Quaternion.Euler(0, 0, Euler));
            Euler += 45;
        }
        Euler += 20;
        yield return new WaitForSeconds(0.1f);
        if(frame<15)
        {
            StartCoroutine(Patton1());
            if (frame == 14)
            {
                yield return new WaitForSeconds(1.0f);
                Instantiate(Effect, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
                yield return new WaitForSeconds(1.0f);
                Instantiate(Effect, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
                yield return new WaitForSeconds(3.0f);
                Euler = 0;
                //frame = 0;
                //StartCoroutine(Patton1());
            }
        }
    }

    IEnumerator Patton2()
    {
        frame++;
        for (int i = 0; i < 4; i++)
        {
            Instantiate(Bullet2, transform.position + new Vector3(0, 0, -1), Quaternion.Euler(0, 0, Euler));
            Euler += 90;
        }
        Euler += 90;
        Euler += 5;
        if (frame > 50 && frame < 100)
        {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(Bullet2, transform.position + new Vector3(0, 0, -1), Quaternion.Euler(0, 0, Euler));
                Euler += 90;
            }
            Euler += 5;
        }
        yield return new WaitForSeconds(0.1f);
        if (frame < 100)
        {
            StartCoroutine(Patton2());
        }
    }

    IEnumerator Patton3()
    {
        frame++;
        for (int i = 0; i < 4; i++)
        {
            Instantiate(Bullet3, transform.position + new Vector3(0, 0, -1), Quaternion.Euler(0, 0, Euler));
            Euler -= 90;
        }
        Euler -= 90;
        Euler -= 5;
        if (frame > 50 && frame < 100)
        {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(Bullet3, transform.position + new Vector3(0, 0, -1), Quaternion.Euler(0, 0, Euler));
                Euler -= 90;
            }
            Euler -= 5;
        }
        yield return new WaitForSeconds(0.1f);
        if (frame < 100)
        {
            StartCoroutine(Patton3());
        }
    }

    IEnumerator Patton4()
    {
        frame++;
        if (frame < 50)
        {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(Bullet2, transform.position + new Vector3(0, 0, -1), Quaternion.Euler(0, 0, Euler));
                Euler += 90;
            }
            Euler += 90;
            Euler += 10;
        }
        else if(frame>50)
        {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(Bullet3, transform.position + new Vector3(0, 0, -1), Quaternion.Euler(0, 0, Euler));
                Euler -= 90;
            }
            Euler -= 90;
            Euler -= 10;
        }
        yield return new WaitForSeconds(0.1f);
        if(frame<100)
        {
            StartCoroutine(Patton4());
        }
    }

    IEnumerator Patton5()
    {
        frame++;
        if (frame < 50)
        {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(Bullet2, transform.position + new Vector3(0, 0, -1), Quaternion.Euler(0, 0, Euler));
                Euler += 90;
            }

            Euler += 45;

            for (int i = 0; i < 4; i++)
            {
                Instantiate(Bullet3, transform.position + new Vector3(0, 0, -1), Quaternion.Euler(0, 0, Euler));
            }
            Euler += 45;
            Euler += 10;
        }
        yield return new WaitForSeconds(0.1f);
        if (frame < 50)
        {
            StartCoroutine(Patton5());
        }
    }

    IEnumerator Patton6()
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
            StartCoroutine(Patton6());
        }
    }
}
