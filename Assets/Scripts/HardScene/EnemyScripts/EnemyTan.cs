using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTan : MonoBehaviour
{
    public GameObject[] Bullet = new GameObject[2];
    public GameObject effect;

    int frame = 0;
    bool isSpawn = false;

    void Start()
    {
        Destroy(gameObject, 8.0f);
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        if (isSpawn == false)
        {
            isSpawn = true;
            yield return new WaitForSeconds(1.0f);
            Instantiate(effect, transform.position, Quaternion.identity);
        }

        frame++;
        float h = -0.3f;
        float Euler = 20;
        //for (int i = 0; i < 5; i++)
        //{
        //    Instantiate(Bullet[0], transform.position + new Vector3(h, -0.1f), Quaternion.Euler(0, 0, Euler));
        //    h += 0.15f;
        //    Euler -= 10;
        //}
        h = -0.2f;
        Euler = -20;

        if (HEnemySpawn.paffon == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(Bullet[0], transform.position + new Vector3(h, -0.1f), Quaternion.Euler(0, 0, Euler));
                h += 0.1f;
                Euler += 10;
            }
        }
        if (HEnemySpawn.paffon == 1)
        {
            h = -0.3f;
            Euler = -40;
            for (int i = 0; i < 5; i++)
            {
                Instantiate(Bullet[1], transform.position + new Vector3(h, -0.1f), Quaternion.Euler(0, 0, Euler));
                h += 0.15f;
                Euler += 20;
            }
        }

        yield return new WaitForSeconds(0.2f);
        if (frame < 5)
        {
            StartCoroutine(Shooting());
        }
    }
}
