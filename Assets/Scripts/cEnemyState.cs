using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cEnemyState : MonoBehaviour
{
    public int hp { get; set; } = 6;
    public GameObject Item;
    public GameObject Item2;
    public GameObject effect;

    private void Update()
    {
        Death();
    }

    void Death()
    {
        int random = Random.Range(1, 5);
        if (hp <= 0)
        {
            float randomX = Random.Range(-0.4f, 0.4f);
            Instantiate(Item, transform.position + new Vector3(randomX, 0), Quaternion.identity);
            Destroy(gameObject);
            for (int i = 0; i < random; i++)
            {
                randomX = Random.Range(-0.4f, 0.4f);
                Instantiate(Item2, transform.position + new Vector3(randomX, 0), Quaternion.identity);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Boom"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            hp = 0;
        }
    }
}
