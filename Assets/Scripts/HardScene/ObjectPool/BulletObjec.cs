using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjec : MonoBehaviour
{
    public GameObject effect;

    private void OnEnable() // Ȱ��ȭ�� ȣ��Ǵ� �Լ�
    {
        StartCoroutine(DisableArrow());
    }

    IEnumerator DisableArrow()
    {
        yield return new WaitForSeconds(4.0f); // 5�� ���
        gameObject.SetActive(false); // ������Ʈ ��Ȱ��ȭ
    }

    void Update()
    {
        transform.Translate(Vector3.up * 7.0f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Instantiate(effect, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            collision.transform.GetComponent<cEnemyState>().hp -= cPlayerController.playerDamage;
            gameObject.SetActive(false);
        }

        if (collision.transform.CompareTag("Boss"))
        {
            Instantiate(effect, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            collision.transform.GetComponent<BossState>().currentHp -= cPlayerController.playerDamage;
            gameObject.SetActive(false);
        }
    }
}
