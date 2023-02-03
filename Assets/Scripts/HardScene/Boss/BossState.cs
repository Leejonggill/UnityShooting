using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossState : MonoBehaviour
{
    public Image bossHp;
    public Text overText;
    public GameObject Patton1;
    public GameObject Patton2;

    public int currentHp { get; set; } = 350;
    int maxHp = 350;
    int life = 2;

    bool IsPatton = false;

    private void Start()
    {
        bossHp.gameObject.SetActive(true);
        overText.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            Hp();
        }
        if (life <= 0)
        {
            Time.timeScale = 0;
            overText.text = "게임 클리어";
        }
    }

    void Hp()
    {
        if (currentHp <= 0 && life > 0)
        {
            life--;
            currentHp = 350;
            if(life==0)
            {
                currentHp = 0;
            }
        }

        if (life==1&& IsPatton==false)
        {
            IsPatton = true;
            SetPatton();
        }

        bossHp.fillAmount = (float)currentHp / maxHp;

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    void SetPatton()
    {
        Patton1.SetActive(false);
        Patton2.SetActive(true);
    }
}
