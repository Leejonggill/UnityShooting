using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cBoss : MonoBehaviour
{
    public Image bossHp;
    public GameObject effect;
    public GameObject[] bullet;
    public GameObject[] bulletManager;
    public Text overText;
    Animator anim;


    public int currentHp { get; set; } = 500;
    int maxHp = 500;
    int time = 0;
    float MoveTime = 0;

    bool fristLogic = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(BulletFuc());
    }

    IEnumerator BulletFuc()
    {

        if (fristLogic)
        {
            if (time < 4)
            {
                time++;
                Pattun1();
                Pattun2();
                yield return new WaitForSeconds(1.0f);
                StartCoroutine(BulletFuc());
            }
            else if (time >= 4 && time < 7)
            {
                time++;
                yield return new WaitForSeconds(1.0f);
                StartCoroutine(BulletFuc());
            }
            else if (time < 12 && time >= 7)
            {
                time++;
                Pattun3();
                yield return new WaitForSeconds(1.0f);
                StartCoroutine(BulletFuc());
            }
            else if (time < 17 && time >= 12)
            {
                time++;
                Pattun4();
                yield return new WaitForSeconds(1.0f);
                StartCoroutine(BulletFuc());
            }
            else if (time < 24 && time >= 17)
            {
                time++;
                Pattun4();
                yield return new WaitForSeconds(0.3f);
                StartCoroutine(BulletFuc());
            }
            else if (time < 30 && time >= 24)
            {
                time++;
                Pattun5();
                Pattun6();
                yield return new WaitForSeconds(1.0f);
                StartCoroutine(BulletFuc());
            }
            else if (time >=30)
            {
                time = 0;
                fristLogic = false;
                yield return new WaitForSeconds(2.0f);
                StartCoroutine(BulletFuc());
            }
        }


        if (!fristLogic)
        {
            if (time == 6)
            {
                time = 0;
            }
            int random = Random.Range(0, 4);
            float seconds = Random.Range(0.3f, 2.0f);
            if (random == 0 && time <= 5)
            {
                time++;
                Pattun1();
                yield return new WaitForSeconds(seconds);
                StartCoroutine(BulletFuc());
            }
            if (random == 1 && time <= 5)
            {
                time++;
                Pattun3();
                yield return new WaitForSeconds(seconds);
                StartCoroutine(BulletFuc());
            }
            if (random == 2 && time <= 5)
            {
                time++;
                Pattun5();
                yield return new WaitForSeconds(seconds);
                StartCoroutine(BulletFuc());
            }
            if (random == 3 && time <= 5)
            {
                time++;
                Pattun1();
                Pattun5();
                yield return new WaitForSeconds(seconds);
                StartCoroutine(BulletFuc());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            currentHp--;
            Hp();
        }
        if (currentHp <= 0)
        {
            Time.timeScale = 0;
            overText.text = "게임 클리어";
        }
    }

    void Hp()
    {
        bossHp.fillAmount = (float)currentHp / maxHp;
        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Pattun1()
    {
        float Euler = 0;
        for (int i = 0; i < 18; i++)
        {
            Instantiate(bullet[1], transform.position /*+ new Vector3(-0.4f, 0)*/, Quaternion.Euler(0, 0, Euler));
            Euler += 20;
        }
    }

    void Pattun2()
    {
        if (bulletManager[0].activeSelf == false && time <= 7)
        {
            for (int i = 0; i < 2; i++)
            {
                bulletManager[i].SetActive(true);
            }
        }
    }

    void Pattun3()
    {
        if (bulletManager[2].activeSelf == false)
        {
            bulletManager[2].SetActive(true);
        }
    }

    void Pattun4()
    {
        float Euler = 70;
        for (int i = 0; i < 15; i++)
        {
            Instantiate(bullet[0], transform.position + new Vector3(0, -0.1f), Quaternion.Euler(0, 0, Euler));
            Euler -= 10;
        }
    }

    void Pattun5()
    {
        float Euler = 70;
        for (int i = 0; i < 15; i++)
        {
            Instantiate(bullet[1], transform.position, Quaternion.Euler(0, 0, Euler));
            Euler -= 10;
        }
    }

    void Pattun6()
    {
        float Euler = 40;
        float h = -4f;
        float v = 3.0f;
        for (int i = 0; i < 15; i++)
        {

            Instantiate(bullet[1], new Vector3(h, v, 0), Quaternion.Euler(0, 0, Euler));
            Euler -= 7;
            h += 0.6f;
            if (i < 8)
            {
                v -= 0.05f;
            }
            else
                v += 0.05f;
        }
    }

}
