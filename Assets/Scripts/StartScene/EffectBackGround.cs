using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBackGround : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.down * 2*Time.deltaTime);

        if(transform.position.y<-11.0f)
        {
            transform.position = new Vector3(transform.position.x, 15, -1);
        }
    }
}
