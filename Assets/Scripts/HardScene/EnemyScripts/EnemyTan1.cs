using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTan1 : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject effect;

    bool isSpawn = false;
    int frame = 0;

    void Start()
    {
        Destroy(gameObject, 4.0f);
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        float Euler = 0;
        if (isSpawn == false)
        {
            isSpawn = true;
            yield return new WaitForSeconds(1.0f);
        }
        
        for (int i = 0; i < 8; i++)
        {
            Instantiate(Bullet, transform.position + new Vector3(0, 0), Quaternion.Euler(0, 0, Euler));
            Euler += 45;
        }
        Instantiate(effect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        //2
        Euler = 15;
        for (int i = 0; i < 8; i++)
        {
            Instantiate(Bullet, transform.position + new Vector3(0, 0), Quaternion.Euler(0, 0, Euler));
            Euler += 45;
        }
        Instantiate(effect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        //3
        Euler = 30;
        for (int i = 0; i < 8; i++)
        {
            Instantiate(Bullet, transform.position + new Vector3(0, 0), Quaternion.Euler(0, 0, Euler));
            Euler += 45;
        }
        Instantiate(effect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        //4
        Euler = 40;
        for (int i = 0; i < 8; i++)
        {
            Instantiate(Bullet, transform.position + new Vector3(0, 0), Quaternion.Euler(0, 0, Euler));
            Euler += 45;
        }
        Instantiate(effect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        Euler = 55;
        for (int i = 0; i < 8; i++)
        {
            Instantiate(Bullet, transform.position + new Vector3(0, 0), Quaternion.Euler(0, 0, Euler));
            Euler += 45;
        }
        Instantiate(effect, transform.position, Quaternion.identity);

    }
}
