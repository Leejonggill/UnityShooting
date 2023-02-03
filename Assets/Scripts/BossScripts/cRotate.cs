using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cRotate : MonoBehaviour
{
    float time = 0;
    void Update()
    {
        time += Time.deltaTime;
        if (time < 5)
        {
            transform.Rotate(new Vector3(0, 0, 30) * 3.0f * Time.deltaTime);
            transform.Translate(new Vector3(0, 1, 0) * 3.0f * Time.deltaTime);
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
                Destroy(gameObject, 12.0f);
            }
        }
        if(time>=5)
        {
            transform.position += new Vector3(0, -1, 0) * 3.0f * Time.deltaTime;
        }
    }
}
