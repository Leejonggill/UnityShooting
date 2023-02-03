using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenemySpawn3 : MonoBehaviour
{
    public GameObject enemy;
    public GameObject SpawnManager;
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
            obj = Instantiate(enemy, transform.position + new Vector3(-3.5f, -2, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(Spawn());
        }

        if (frame == 10)
        {
            yield return new WaitForSeconds(5.0f);
            gameObject.SetActive(false);
            SpawnManager.SetActive(true);
        }
    }
}
