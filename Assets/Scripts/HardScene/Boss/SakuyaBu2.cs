using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SakuyaBu2 : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 6.0f);
    }

    void Update()
    {
            transform.Translate(new Vector2(0, -1.0f) * 6f * Time.deltaTime);
    }
}
