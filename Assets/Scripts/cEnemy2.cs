using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cEnemy2 : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject effect;
    bool IsShooting = false;
    bool IsEffect = false;

    float BulletTime;
    float waitingTime;

    void Start()
    {
        BulletTime = 0.0f;
        waitingTime = 1.0f;
        Destroy(gameObject, 4.0f);
    }

    void Update()
    {
        BulletTime += Time.deltaTime;
        Shooting();
        //Death();
    }

    void Shooting()
    {

        if (!IsEffect && BulletTime > (waitingTime - 0.2f))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            IsEffect = true;
        }
        if (!IsShooting && BulletTime > waitingTime)
        {
            float Euler = 0;
            IsShooting = true;
            for (int i = 0; i < 8; i++)
            {
                Instantiate(Bullet, transform.position + new Vector3(0, 0), Quaternion.Euler(0, 0, Euler));
                Euler += 45;
            }
        }
    }

    ////void Death()
    ////{
    ////    int random = Random.Range(1, 10);
    ////    if (hp <= 0)
    ////    {
    ////        float randomX = Random.Range(-0.4f, 0.4f);
    ////        Instantiate(Item, transform.position + new Vector3(randomX, 0), Quaternion.identity);
    ////        Destroy(gameObject);
    ////        for (int i = 0; i < random; i++)
    ////        {
    ////            randomX = Random.Range(-0.4f, 0.4f);
    ////            Instantiate(Item2, transform.position + new Vector3(randomX, 0), Quaternion.identity);
    ////        }
    ////    }
    ////}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.transform.CompareTag("Boom"))
    //    {
    //        hp = 0;
    //    }
    //}
}
