using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEnemyBullet2 : MonoBehaviour
{
    Transform taget;
    float time = 0;
    public float axis = 0;

    private void Start()
    {
        Destroy(gameObject, 6.0f);
        taget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time<1.0f)
        {
            transform.Translate(new Vector2(0, -1.0f) * 1.5f * Time.deltaTime);
        }
        else if(time>=1.0f&&time<1.7f)
        {
            Rookat();
        }
        else if(time>1.7f)
        {
            transform.Translate(Vector3.down * 10 * Time.deltaTime);
        }
    }

    void Rookat()
    {
        Vector3 myPos = transform.position;
        Vector3 targetPos = taget.position;
        targetPos.z = myPos.z;

        Vector3 vectorToTarget = targetPos - myPos;
        Vector3 quter = Quaternion.Euler(0, 0, 180) * vectorToTarget;

        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: quter);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 700 * Time.deltaTime);
    }


}
