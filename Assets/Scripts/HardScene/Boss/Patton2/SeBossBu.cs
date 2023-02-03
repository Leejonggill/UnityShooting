using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeBossBu : MonoBehaviour
{
    Transform taget;
    float frame = 0;
    public float axis = 0;

    bool isStart = false;
    private void Start()
    {
        Destroy(gameObject, 6.0f);
        taget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        StartCoroutine(Move());
        Debug.Log(Time.unscaledTime);
        if (frame == 0)
        {
            transform.Translate(new Vector2(0, -1.0f) * 2f * Time.unscaledDeltaTime);
        }
        if (frame == 1)
        {
            Rookat();
        }
        if(frame==2)
        {
            transform.Translate(Vector3.down * 5*Time.deltaTime);
        }
    }


    IEnumerator Move()
    {
        if (isStart == false)
        {
            isStart = true;
            yield return new WaitForSecondsRealtime(1.0f);
            frame = 1;
            yield return new WaitForSecondsRealtime(2.0f);
            frame = 2;
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
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 500 * Time.unscaledDeltaTime);
    }

}
