using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cBossRotateImage : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 15f)*5 *Time.deltaTime);
    }
}
