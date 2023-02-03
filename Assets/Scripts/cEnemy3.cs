using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cEnemy3 : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject effect;
    bool IsShooting = false;
    bool IsEffect = false;
    bool IsRandom = false;

    float BulletTime;
    float waitingTime;

    void Start()
    {
        BulletTime = 0.0f;
        waitingTime = 1.5f;
        Destroy(gameObject, 3.0f);
    }

    void Update()
    {
        if (transform.position.x > 2.4f)
        {
            Destroy(gameObject);
        }

        if (!IsRandom)
        {
            waitingTime = Random.Range(0.1f, 1.2f);
            IsRandom = true;
        }
        BulletTime += Time.deltaTime;

        transform.Translate(new Vector3(1, 0, 0) * 5 * Time.deltaTime);
        Shooting();
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
            float h = -0.15f;
            float Euler = 10;
            IsShooting = true;
            for (int i = 0; i < 3; i++)
            {
                Instantiate(Bullet, transform.position + new Vector3(h, -0.1f), Quaternion.Euler(0, 0, Euler));
                h += 0.15f;
                Euler -= 10;
            }
        }
    }
}
