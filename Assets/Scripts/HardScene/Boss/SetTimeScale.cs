using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTimeScale : MonoBehaviour
{
    public GameObject BackGroundEffect;
    public GameObject Effect;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_Time());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator _Time()
    {
        Instantiate(Effect, transform.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(2.0f);
        Instantiate(Effect, transform.position, Quaternion.identity);
        BackGroundEffect.SetActive(false);
        Time.timeScale= 1.0f;
    }
}
