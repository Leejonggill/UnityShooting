using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject SpwanManager2;
    GameObject obj;

    public static int paffon = 0;

    int frame = 0;

    float posX = -3.5f;
    float posX2 = 2.5f;
    float posY = -270;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        StartCoroutine(Enemy1Spawn());
        yield return new WaitForSeconds(10.0f);
        Debug.Log(1);
    }

    IEnumerator Enemy1Spawn()
    {
        if (frame < 5)
        {
            int ran = Random.Range(0, 2);
            int ranY = Random.Range(150, 200);
            if (ran == 0)
            {
                frame++;
                float ranX = Random.Range(-3.0f, 0.0f);
                obj = Instantiate(enemy, transform.position + new Vector3(ranX, 0, 0), Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -ranY));
                obj = Instantiate(enemy, transform.position + new Vector3(ranX + 2, 0, 0), Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -ranY));
                yield return new WaitForSeconds(1.5f);
                StartCoroutine(Enemy1Spawn());
            }
            else if (ran == 1)
            {
                frame++;
                float ran1 = Random.Range(-3, -1);
                obj = Instantiate(enemy, transform.position + new Vector3(-3, 0, 0), Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -ranY));
                obj = Instantiate(enemy, transform.position + new Vector3(-0.5f, 0, 0), Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -ranY));
                obj = Instantiate(enemy, transform.position + new Vector3(2, 0, 0), Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -ranY));

                yield return new WaitForSeconds(2);
                StartCoroutine(Enemy1Spawn());
            }
        }
        else if(frame>=5)
        {
            if (frame == 5)
                yield return new WaitForSeconds(4.0f);
            paffon = 1;
            StartCoroutine(Spawn2());
        }

    }

    public IEnumerator Spawn2()
    {
        frame++;
        obj = Instantiate(enemy, transform.position + new Vector3(posX, 0, 0), Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, posY));

        obj = Instantiate(enemy, transform.position + new Vector3(posX2, 0, 0), Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, posY));

        posX += 0.5f;
        posX2 -= 0.5f;
        posY += 20;
        if (posX2 < 0.6f)
        {
            posX = -3.5f;
            posX2 = 2.5f;
            posY = -270;
            frame = 21;
            yield return new WaitForSeconds(5.0f);
            SpwanManager2.SetActive(true);
            gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Spawn2());


    }
}
