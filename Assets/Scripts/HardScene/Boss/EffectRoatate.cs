using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRoatate : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 180f * Time.unscaledTime);
    }
}
