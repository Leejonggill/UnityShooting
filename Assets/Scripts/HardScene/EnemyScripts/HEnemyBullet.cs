using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEnemyBullet : MonoBehaviour
{
    Transform taget;
    Transform boss;
    bool isMove = false;

    public float axis = 0;

    private void Start()
    {
        Destroy(gameObject, 6.0f);
        taget = GameObject.FindGameObjectWithTag("Player").transform;
        boss = GameObject.FindGameObjectWithTag("Boss").transform;
    }

    private void Update_LookRotation()
    {
        Vector3 myPos = transform.position;
        Vector3 targetPos = taget.position;
        targetPos.z = myPos.z;

        Vector3 vectorToTarget = targetPos - myPos;
        Vector3 quter = Quaternion.Euler(0, 0, axis) * vectorToTarget;

        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: quter);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 500 * Time.deltaTime);
    }

    void Update()
    {
        if (isMove == false)
        {
            Update_LookRotation();
            StartCoroutine(See());
        }
        if (isMove == true)
        {
            transform.Translate(Vector3.up * 7 * Time.deltaTime);
        }
    }

    IEnumerator See()
    {
        yield return new WaitForSeconds(1.5f);
        isMove = true;
    }
}
