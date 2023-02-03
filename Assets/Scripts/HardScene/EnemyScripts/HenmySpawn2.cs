using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenmySpawn2 : MonoBehaviour
{
    public GameObject enemy;
    public GameObject SpwanManager2;
    GameObject obj;


    int frame = 0;

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
        frame++;
        if (frame < 10)
        {
            float ranX = Random.Range(-3.0f, 0);
            obj = Instantiate(enemy, transform.position + new Vector3(ranX, 0, 0), Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -200));
            obj = Instantiate(enemy, transform.position + new Vector3(-ranX, 0, 0), Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -200));
            yield return new WaitForSeconds(1.5f);
            StartCoroutine(Spawn());
        }

        if(frame==10)
        {
            yield return new WaitForSeconds(3.0f);
        }

        if(frame==10)
        {
            int x = -4;
            for (int i = 0; i < 7; i++)
            {
                x++;
                obj = Instantiate(enemy, transform.position + new Vector3(x, 0, 0), Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -200));
            }
            frame++;
            yield return new WaitForSeconds(4.0f);
            SpwanManager2.SetActive(true);
            gameObject.SetActive(false);
        }

    }

}
