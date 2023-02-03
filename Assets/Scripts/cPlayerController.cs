using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class cPlayerController : MonoBehaviour
{
    public Text[] stateText = new Text[2];//0:Power 1:score
    public Image[] hpImage;
    public Image[] boomImage;
    public GameObject[] bullet = new GameObject[3];
    public GameObject[] powerObject = new GameObject[2];
    public GameObject boomObject;
    public GameObject hitBoom;
    public Text overText;

    bool hitCool = false;
    bool isEsc = false;
    float BulletTime;
    float waitingTime;
    float speed = 4;
    int currentHp;
    int maxHp;
    int boom;
    int score = 0;
    int power = 0;
    float speedTep;
    float SlowSpeed;
    public static int shootingPower = 0;
    int powerUpResult = 0;
    static public int playerDamage = 1;


    Animator anim;

    void Start()
    {
        playerDamage = 1;
        shootingPower = 0;
        SetStartState();
        anim = GetComponent<Animator>();
        BulletTime = 0.0f;
        waitingTime = 0.1f;
        Time.timeScale = 1.0f;
        bullet[0].transform.Rotate(0, 0, 90);
        bullet[1].transform.Rotate(0, 0, 90);
    }

    void Update()
    {
        if (currentHp <= 0 && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !isEsc)
        {
            isEsc = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isEsc)
        {
            isEsc = false;
        }
        BulletTime += Time.deltaTime;
        ShowState();
        Move();
        powerUp();
    }


    void Move()
    {
        if (isEsc == false)
        {
            if (Input.GetButton("Fire3"))
            {
                speed = SlowSpeed;
            }
            else
            {
                speed = speedTep;
            }

            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                anim.SetBool("isMove", true);
                float h = Input.GetAxisRaw("Horizontal");
                float v = Input.GetAxisRaw("Vertical");
                anim.SetFloat("posX", h);
                transform.Translate(new Vector3(h, v, 0) * speed * Time.deltaTime);
            }
            else
            {
                anim.SetBool("isMove", false);
            }

            Shooting();
            MoveMax();
        }
    }

    void powerUp()
    {
        if (powerUpResult >= 10 && shootingPower < 5)
        {
            powerUpResult = 0;
            shootingPower++;
        }

        if (powerObject[0].activeSelf == false && shootingPower >= 2 && shootingPower < 5)
        {
            powerObject[0].SetActive(true);
            powerObject[1].SetActive(false);
        }
        else if (powerObject[1].activeSelf == false && shootingPower == 5)
        {
            if (GameManager.Instance.Select != 2)
            {
                playerDamage = 2;
            }
            else if (GameManager.Instance.Select == 2)
            {
                playerDamage = 3;
            }
            powerObject[1].SetActive(true);
        }
        else if (powerObject[0].activeSelf == false && shootingPower < 5)
        {
            if (GameManager.Instance.Select != 2)
            {
                playerDamage = 1;
            }
            else if (GameManager.Instance.Select == 2)
            {
                playerDamage = 2;
            }
            powerObject[0].SetActive(false);
            powerObject[1].SetActive(false);
        }
    }

    void Shooting()
    {
        //    if (Input.GetKey(KeyCode.Z) && BulletTime > waitingTime)
        //    {
        //        BulletTime = 0;
        //        switch (shootingPower)
        //        {
        //            case 1:
        //                Instantiate(bullet[0], transform.position + new Vector3(0f, 0.5f, 0), Quaternion.Euler(0, 0, 90));
        //                break;
        //            case 2:
        //                Instantiate(bullet[0], transform.position + new Vector3(-0.15f, 0.5f, 0), Quaternion.Euler(0, 0, 90));
        //                Instantiate(bullet[0], transform.position + new Vector3(0.15f, 0.5f, 0), Quaternion.Euler(0, 0, 90));
        //                break;
        //            case 3:
        //                Instantiate(bullet[0], transform.position + new Vector3(0f, 0.5f, 0), Quaternion.Euler(0, 0, 90));
        //                Instantiate(bullet[0], transform.position + new Vector3(0f, 0.5f, 0), Quaternion.Euler(0, 0, 100));
        //                Instantiate(bullet[0], transform.position + new Vector3(0f, 0.5f, 0), Quaternion.Euler(0, 0, 80));
        //                break;
        //            case 4:
        //                playerDamage = 2;
        //                Instantiate(bullet[1], transform.position + new Vector3(0f, 0.5f, 0), Quaternion.Euler(0, 0, 90));
        //                break;
        //            case 5:
        //                Instantiate(bullet[1], transform.position + new Vector3(0.15f, 0.5f, 0), Quaternion.Euler(0, 0, 90));
        //                Instantiate(bullet[1], transform.position + new Vector3(-0.15f, 0.5f, 0), Quaternion.Euler(0, 0, 90));
        //                break;
        //            case 6:
        //                Instantiate(bullet[1], transform.position + new Vector3(0f, 0.5f, 0), Quaternion.Euler(0, 0, 90));
        //                Instantiate(bullet[1], transform.position + new Vector3(0f, 0.5f, 0), Quaternion.Euler(0, 0, 100));
        //                Instantiate(bullet[1], transform.position + new Vector3(0f, 0.5f, 0), Quaternion.Euler(0, 0, 80));
        //                break;
        //        }
        //    }

        if (Input.GetKeyDown(KeyCode.V) && boom > 0)
        {
            boom--;
            Instantiate(boomObject, transform.position + new Vector3(0f, 0.5f, 0), Quaternion.identity);
        }
    }

    void ShowState()
    {

        stateText[0].text = "파워: " + power.ToString();
        stateText[1].text = "점수: " + score.ToString();

        if (maxHp < currentHp)
        {
            currentHp = maxHp;
        }


        for (int i = hpImage.Length; i > currentHp; i--)
        {
            hpImage[i - 1].gameObject.SetActive(false);
        }
        for (int i = 0; i < currentHp; i++)
        {
            hpImage[i].gameObject.SetActive(true);
        }

        for (int i = boomImage.Length; i > boom; i--)
        {
            boomImage[i - 1].gameObject.SetActive(false);
        }
        for (int i = 0; i < boom; i++)
        {
            boomImage[i].gameObject.SetActive(true);
        }
    }

    public void SetStartState()
    {
        if (GameManager.Instance.GetSelect() == 2)
        {
            speed = 2.5f;
            playerDamage = 2;
        }
        if (GameManager.Instance.GetSelect() == 3)
        {
            boomImage[3].gameObject.SetActive(true);
        }

        currentHp = hpImage.Length;
        maxHp = hpImage.Length;
        boom = boomImage.Length;
        speedTep = speed;
        SlowSpeed = speed - 0.5f;
    }

    void MoveMax()
    {
        if (transform.position.x > 2.3f)
        {
            transform.position = new Vector2(2.3f, transform.position.y);
        }
        else if (transform.position.x < -4.2f)
        {
            transform.position = new Vector2(-4.2f, transform.position.y);
        }

        if (transform.position.y > 4.0f)
        {
            transform.position = new Vector2(transform.position.x, 4.0f);
        }
        else if (transform.position.y < -4.6f)
        {
            transform.position = new Vector2(transform.position.x, -4.6f);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.CompareTag("EnemyBullet") && hitCool == false)
        {
            StartCoroutine(HitCoolTime());
            Instantiate(hitBoom, transform.position, Quaternion.identity);
            currentHp--;
            Destroy(collision.transform.gameObject);
        }
        if (collision.transform.CompareTag("Enemy") && hitCool == false)
        {
            StartCoroutine(HitCoolTime());
            currentHp--;
            Destroy(collision.transform.gameObject);
        }
        if (collision.transform.CompareTag("PowerItem"))
        {
            powerUpResult += 5;
            power += 5;
            Destroy(collision.transform.gameObject);
        }
        if (collision.transform.CompareTag("ScoreItem"))
        {
            score += 10;
            Destroy(collision.transform.gameObject);
        }
        if (currentHp <= 0)
        {
            Time.timeScale = 0;
            overText.text = "게임 오버";
        }
    }

    IEnumerator HitCoolTime()
    {
        hitCool = true;
        yield return new WaitForSecondsRealtime(1.0f);
        hitCool = false;
    }
}
