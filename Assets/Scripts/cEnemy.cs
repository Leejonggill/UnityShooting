using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cEnemy : MonoBehaviour
{
    static int frame = 0;
    public GameObject[] Bullet = new GameObject[2];
    public GameObject effect;
    bool IsShooting = false;
    bool IsEffect = false;
    bool IsRandom = false;

    float BulletTime;
    float waitingTime;

    void Start()
    {
        if (!IsRandom)
        {
            waitingTime = Random.Range(0.4f, 1.5f);
            IsRandom = true;
        }

        if (frame >= 10)
        {
            waitingTime = 1.5f;
        }
        BulletTime = 0.0f;
        Destroy(gameObject, 8.0f);
    }

    void Update()
    {
        BulletTime += Time.deltaTime;
        Shooting();
    }

    void Shooting()
    {

        if(!IsEffect&& BulletTime > (waitingTime-0.2f))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            IsEffect = true;
        }
        if (!IsShooting&& BulletTime > waitingTime)
        {
            frame++;
            float h = -0.3f;
            float Euler = 20;
            int random = Random.Range(0, 2);
            IsShooting = true;
            if (random == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    Instantiate(Bullet[0], transform.position + new Vector3(h, -0.1f), Quaternion.Euler(0, 0, Euler));
                    h += 0.15f;
                    Euler -= 10;
                }
            }
            if (random == 1)
            {
                h = -0.2f;
                Euler = -20;
                for (int i = 0; i < 5; i++)
                {
                    Instantiate(Bullet[0], transform.position + new Vector3(h, -0.1f), Quaternion.Euler(0, 0, Euler));
                    h += 0.1f;
                    Euler += 10;
                }
            }
        }
    }
}
