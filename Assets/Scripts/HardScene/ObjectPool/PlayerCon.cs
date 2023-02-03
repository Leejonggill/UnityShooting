using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    public GameObject arrow;
    public GameObject arrow2;
    public int Count = 0;

    Animator anim; // 애니메이터 
    List<GameObject> arrowPool = new List<GameObject>();
    GameObject arrowParent;

    //int shootingPower = 0;
    float BulletTime;
    float waitingTime;
    bool isBulletChane = false;

    void Start()
    {
        BulletTime = 0.0f;
        waitingTime = 0.1f;
        anim = GetComponent<Animator>();
        arrowParent = new GameObject("Arrows");

    }


    void Update()
    {
        BulletTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.Z) && BulletTime > waitingTime)
        {
            BulletTime = 0;
            GetArrow();
        }
    }

    void GetArrow()
    {
        Debug.Log(Count);
        Debug.Log(cPlayerController.shootingPower);

        if (cPlayerController.shootingPower == 0)
        {
            for (int i = 0; i < arrowPool.Count; i++)
            {
                if (!arrowPool[i].activeSelf)
                {
                    arrowPool[i].SetActive(true);
                    arrowPool[i].transform.position = transform.position;

                    return;
                }
            }
            GameObject obj =
                Instantiate(arrow, transform.position, Quaternion.identity);
            obj.transform.parent = arrowParent.transform;
            arrowPool.Add(obj);
        }
        else if (cPlayerController.shootingPower == 1)
        {
            for (int i = 1; i < arrowPool.Count; i+=2)
            {
                if (!arrowPool[i-1].activeSelf&& !arrowPool[i].activeSelf)
                {
                    arrowPool[i-1].SetActive(true);
                    arrowPool[i-1].transform.position = transform.position + new Vector3(-0.15f, 0.5f, 0);
                    arrowPool[i].SetActive(true);
                    arrowPool[i].transform.position = transform.position + new Vector3(0.15f, 0.5f, 0);
                    return;
                }
            }
            GameObject obj =
                Instantiate(arrow, transform.position + new Vector3(-0.15f, 0.5f, 0), Quaternion.identity);
            obj.transform.parent = arrowParent.transform;
            arrowPool.Add(obj);
            obj =
            Instantiate(arrow, transform.position + new Vector3(0.15f, 0.5f, 0), Quaternion.identity);
            obj.transform.parent = arrowParent.transform;
            arrowPool.Add(obj);
        }
        else if (cPlayerController.shootingPower == 2)
        {
            while(arrowPool.Count%3!=0)
            {
                arrowPool.RemoveAt(0);
            }
            for (int i = 1; i < arrowPool.Count; i+=3)
            {
                if (!arrowPool[i-1].activeSelf&&!arrowPool[i].activeSelf&&!arrowPool[i+1].activeSelf)
                {
                    arrowPool[i-1].SetActive(true);
                    arrowPool[i-1].transform.position = transform.position;
                    arrowPool[i].SetActive(true);
                    arrowPool[i].transform.rotation = Quaternion.Euler(0, 0, 10);
                    arrowPool[i].transform.position = transform.position;
                    arrowPool[i + 1].SetActive(true);
                    arrowPool[i+1].transform.rotation = Quaternion.Euler(0, 0, -10);
                    arrowPool[i + 1].transform.position = transform.position;
                    return; // 함수종료
                }
            }
            // 아니라면 밑에 실행.
            // 
            GameObject obj =
                Instantiate(arrow, transform.position, Quaternion.identity);
            obj.transform.parent = arrowParent.transform;
            arrowPool.Add(obj);
            obj =
           Instantiate(arrow, transform.position, Quaternion.Euler(0, 0, 10));
            obj.transform.parent = arrowParent.transform;
            arrowPool.Add(obj);
            obj =
            Instantiate(arrow, transform.position, Quaternion.Euler(0, 0, -10));
            obj.transform.parent = arrowParent.transform;
            arrowPool.Add(obj);
        }
        else if (cPlayerController.shootingPower == 3)
        {
            if(!isBulletChane)
            {
                for(int i=0; i<arrowPool.Count;i++)
                {
                    arrowPool[i] = Instantiate(arrow2, transform.position, Quaternion.identity);
                }
                isBulletChane = true;
            }
            for (int i = 0; i < arrowPool.Count; i++)
            {
                if (!arrowPool[i].activeSelf)
                {
                    arrowPool[i].SetActive(true);
                    arrowPool[i].transform.position = transform.position;
                    arrowPool[i].transform.rotation = Quaternion.identity;


                    return; // 함수종료
                }
            }
            GameObject obj =
                Instantiate(arrow2, transform.position, Quaternion.identity);
            obj.transform.parent = arrowParent.transform;
            arrowPool.Add(obj);
        }
        else if (cPlayerController.shootingPower == 4)
        {
            for (int i = 1; i < arrowPool.Count; i += 2)
            {
                if (!arrowPool[i-1].activeSelf&&!arrowPool[i].activeSelf)
                {
                    arrowPool[i-1].SetActive(true);
                    arrowPool[i-1].transform.position = transform.position + new Vector3(-0.15f, 0.5f, 0);
                    arrowPool[i].SetActive(true);
                    arrowPool[i].transform.position = transform.position + new Vector3(0.15f, 0.5f, 0);
                    return;
                }
            }
            GameObject obj =
                Instantiate(arrow2, transform.position + new Vector3(-0.15f, 0.5f, 0), Quaternion.identity);
            obj.transform.parent = arrowParent.transform;
            arrowPool.Add(obj);
            obj =
            Instantiate(arrow2, transform.position + new Vector3(0.15f, 0.5f, 0), Quaternion.identity);
            obj.transform.parent = arrowParent.transform;
            arrowPool.Add(obj);
        }
        else if (cPlayerController.shootingPower == 5)
        {
            while (arrowPool.Count % 3 != 0)
            {
                arrowPool.RemoveAt(0);
            }
            for (int i = 1; i < arrowPool.Count; i += 3)
            {
                if (!arrowPool[i - 1].activeSelf && !arrowPool[i].activeSelf && !arrowPool[i + 1].activeSelf)
                {
                    arrowPool[i-1].SetActive(true);
                    arrowPool[i-1].transform.position = transform.position;
                    arrowPool[i].SetActive(true);
                    arrowPool[i].transform.position = transform.position;
                    arrowPool[i].transform.rotation = Quaternion.Euler(0, 0, 10);
                    arrowPool[i + 1].SetActive(true);
                    arrowPool[i + 1].transform.position = transform.position;
                    arrowPool[i+1].transform.rotation = Quaternion.Euler(0, 0, -10);
                    return;
                }
            }
            GameObject obj =
                Instantiate(arrow2, transform.position, Quaternion.identity);
            obj.transform.parent = arrowParent.transform;
            arrowPool.Add(obj);
            obj =
           Instantiate(arrow2, transform.position, Quaternion.Euler(0, 0, 10));
            obj.transform.parent = arrowParent.transform;
            arrowPool.Add(obj);
            obj =
            Instantiate(arrow2, transform.position, Quaternion.Euler(0, 0, -10));
            obj.transform.parent = arrowParent.transform;
            arrowPool.Add(obj);
        }
    }

}
