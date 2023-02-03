using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTan2 : MonoBehaviour
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

    private void Update()
    {
        if (transform.position.x > 2.4f)
        {
            Destroy(gameObject);
        }

        transform.Translate(new Vector3(1, 0, 0) * 5 * Time.deltaTime);
    }

    IEnumerator Shooting()
    {
        float ran = Random.Range(0.2f, 1.1f);
        float Euler = 0;
        if (isSpawn == false)
        {
            isSpawn = true;
            yield return new WaitForSeconds(ran);
        }


        for (int i = 0; i < 8; i++)
        {
            Instantiate(Bullet, transform.position + new Vector3(0, 0), Quaternion.Euler(0, 0, Euler));
            Euler += 45;
        }
        Instantiate(effect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.0f);
    }
}
