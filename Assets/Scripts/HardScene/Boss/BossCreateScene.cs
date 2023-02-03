using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossCreateScene : MonoBehaviour
{
    public GameObject BossSpawn;
    public GameObject BackGround;
    public GameObject Effect;

    float time;
    bool isEffect = false;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Debug.Log(time);

        if(time>1&&!isEffect)
        {
            Effect.SetActive(true);
            isEffect = true;
        }

        if(time>1.5f)
        {
            Effect.SetActive(false);
            BackGround.SetActive(true);
            Time.timeScale = 0.0f;
            BossSpawn.SetActive(true);
            Destroy(gameObject);
        }
    }

}
