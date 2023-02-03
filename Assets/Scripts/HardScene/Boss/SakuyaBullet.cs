using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SakuyaBullet : MonoBehaviour
{
    float time = 0;
    public float axis = 0;

    private void Start()
    {
        Destroy(gameObject, 8.0f);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time < 1.0f)
        {
            transform.Translate(new Vector2(0, -1.0f) * 2f * Time.deltaTime);
        }
 
        else if (time > 4.0f)
        {
            transform.Translate(new Vector2(0, -1.0f) * 6 * Time.deltaTime);
        }
    }
}
