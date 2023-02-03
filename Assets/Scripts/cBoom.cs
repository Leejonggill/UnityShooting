using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cBoom : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 4.5f);
    }

    void Update()
    {
        transform.Translate(new Vector3(0, 1f) * 6 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("EnemyBullet"))
        {
            Destroy(collision.transform.gameObject);
        }
    }
}
