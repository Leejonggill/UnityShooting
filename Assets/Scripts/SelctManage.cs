using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelctManage : MonoBehaviour
{
    public GameObject Re;
    public GameObject Ma;
    public GameObject Sa;

    public void Start()
    {
        if (GameManager.Instance.GetSelect() == 1)
        {
            Re.gameObject.SetActive(true);
        }
        else if (GameManager.Instance.GetSelect() == 2)
        {
            Ma.gameObject.SetActive(true);
        }
        else if (GameManager.Instance.GetSelect() == 3)
        {
            Sa.gameObject.SetActive(true);
        }


        if (GameManager.Instance.GetSelect() != 1)
        {
            Destroy(Re.gameObject);
            Destroy(gameObject);
        }
        else if (GameManager.Instance.GetSelect() != 2)
        {
            Destroy(Ma.gameObject);
            Destroy(gameObject);
        }
        else if (GameManager.Instance.GetSelect() != 3)
        {
            Destroy(Sa.gameObject);
            Destroy(gameObject);
        }
    }

    //private void Update()
    //{
    //    if (GameManager.Instance.GetSelect() != 1)
    //    {
    //        Destroy(Re.gameObject);
    //        Destroy(gameObject);
    //    }
    //}

}
