using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cEnmeySpawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject Boss;
    GameObject obj;

    int frame = 0;

    float posX = -3.5f;
    float posX2 = 2.5f;
    float posY = -270;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    float BulletTime;
    private void Update()
    {
        BulletTime += Time.deltaTime;
    }
    IEnumerator Spawn()
    {
        if (frame < 10)
        {
            int ran = Random.Range(0, 2);
            if (ran == 0)
            {
                frame++;
                float ranX = Random.Range(-3.0f, 3.0f);
                obj = Instantiate(enemy, transform.position + new Vector3(ranX, 0, 0), Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -200));
                yield return new WaitForSeconds(2);
                StartCoroutine(Spawn());
            }
            else if(ran==1)
            {
                frame++;
                int ran1 = Random.Range(-3, 0);
                obj = Instantiate(enemy, transform.position + new Vector3(ran1, 0, 0), Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -200));
                obj = Instantiate(enemy, transform.position + new Vector3(ran1+2, 0, 0), Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -200));

                yield return new WaitForSeconds(2);
                StartCoroutine(Spawn());
            }
        }
        else if(frame>=10&&frame<20)
        {
            obj = Instantiate(enemy, transform.position + new Vector3(posX, 0, 0), Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, posY));

            obj = Instantiate(enemy, transform.position + new Vector3(posX2, 0, 0), Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, posY));

            posX += 0.5f;
            posX2 -= 0.5f;
            posY += 20;
            if(posX2<0.6f)
            {
                posX = -3.5f;
                posX2 = 2.5f;
                posY = -270;
                frame = 21;
                yield return new WaitForSeconds(7f);
                StartCoroutine(Spawn());
            }
            yield return new WaitForSeconds(0.2f);
            StartCoroutine(Spawn());
        }
        else if(frame>=20&&frame<41)
        {
            if(frame==40)
            {
                frame++;
                int x = -4;
                for(int i=0;i<7;i++)
                {
                    x++;
                    obj = Instantiate(enemy2, transform.position + new Vector3(x, 0, 0), Quaternion.identity);
                    obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -200));
                }
                yield return new WaitForSeconds(7f);
                StartCoroutine(Spawn());
            }
            frame++;
            if(frame==40)
            {
                yield return new WaitForSeconds(2.0f);
                StartCoroutine(Spawn());
            }
            float ranX = Random.Range(-3.0f, 3.0f);
            obj = Instantiate(enemy2, transform.position + new Vector3(ranX, 0, 0), Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -200));
            yield return new WaitForSeconds(1.5f);
            StartCoroutine(Spawn());
        }
        else if(frame>=41&&frame<65)
        {
            frame++;
            obj = Instantiate(enemy3, transform.position + new Vector3(-3.5f, -2, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(Spawn());
        }
        else if (frame <=65)
        {
            yield return new WaitForSeconds(5f);
            Boss.gameObject.SetActive(true);
            Destroy(gameObject, 3.0f);
        }
    }
}
