using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cHitBoom : MonoBehaviour
{
    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(new Vector3(0, 0, 45) * 3 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("EnemyBullet"))
        {
            Destroy(collision.transform.gameObject);
        }
    }
}
