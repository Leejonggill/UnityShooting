using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject EnemySpawnManager;
    // Start is called before the first frame update
    void Start()
    {
        HEnemySpawn.paffon = 0;
        StartCoroutine(SetAct());
    }

    IEnumerator SetAct()
    {
        yield return new WaitForSeconds(2.0f);
        EnemySpawnManager.gameObject.SetActive(true);
    }
}
