using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cItem : MonoBehaviour
{
    Rigidbody2D rgd;
    int posY;
    private void Awake()
    {
        rgd = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        posY = Random.Range(200, 350);
        rgd.AddForce(new Vector3(0, posY, 0));
        Destroy(gameObject, 6.0f);
    }

}
