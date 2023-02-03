using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cPower : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 30) * 6 * Time.deltaTime);
    }
}
