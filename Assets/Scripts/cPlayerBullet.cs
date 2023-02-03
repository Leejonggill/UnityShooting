using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class cPlayerBullet : MonoBehaviour
{
    //private void Start()
    //{
    //    /*transform.Rotate(0, 0, 90); */// 로컬
    //    //transform.localRotation = Quaternion.Euler(0, 0, 90); // 월드
    //}

    public GameObject effect;

    void Update()
    {
        //transform.position += new Vector3(0, 1, 0)*5*Time.deltaTime; // 월드좌표로 고정 불렛2
        transform.Translate(new Vector2(1, 0f) * 7 * Time.deltaTime); // 불렛2 로컬. 이거쓰면은 위로안가고 좌우로이동함.
        if (transform.position.y>5.0f)
        {
            Destroy(gameObject);
        }
        if(transform.position.x>3)
        {
            Destroy(gameObject);
        }
        else if(transform.position.x < -5)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 5.0f);
        }
    }

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            Instantiate(effect, transform.position+new Vector3(0,0.5f,0), Quaternion.identity);
            collision.transform.GetComponent<cEnemyState>().hp -= cPlayerController.playerDamage;
            Destroy(gameObject);
        }

        if (collision.transform.CompareTag("Boss"))
        {
            Instantiate(effect, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            collision.transform.GetComponent<cBoss>().currentHp -= cPlayerController.playerDamage;
            Destroy(gameObject);
        }
    }
}
