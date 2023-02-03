using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cBossBullet : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector2(0, -1.0f) * 3 * Time.deltaTime);
        if (transform.position.y < -5.2f)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > 3f)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -5f)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 5.0f);
        }
    }
}
