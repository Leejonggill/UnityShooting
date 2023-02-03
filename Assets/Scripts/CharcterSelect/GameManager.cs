using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int SceneNum;
    public int Select = 1;
    public int SelectMod = 0;
    private static GameManager instance = null; // 스태틱 변수는 단 하나만 존재. 여러개존재x

    public static GameManager Instance // 변경을 못하도록 getter만해줌.
                                       // public static  GameManager Instance 써주는이유
                                       // 어느 스크립트에서든 접근이가능하고 쓸수있고
                                       // public static int를 안쓰고 public int score로만 써도되게해줌.
                                       // public static  GameManager Instance 의 게터를통해서 함수 , 변수를 불러옴
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance; // instance의 정보를 Instance에다 저장 , 리턴
        }
    }

    //public int score = 0;
    //public GameObject gold;

    private void Awake()
    {
        // 이게없으면 처음부터 다시실행될때 게임오브젝트가계속 생성됨 같은게.
        // 씬이 다시시작될때 원래 다 초기화되는데 이거는 초기화가안되고
        // 그대로이어가는데 그러면 오브젝트가2갠데 처음(원래있던) 오브젝트를 지우고
        // 새로만들어진  DontDestroyOnLoad(gameObject); 를 씀.

        if (instance == null) // 인스턴스가 처음실행된거면. 스태틱은 정적이기때문에 변수가 생성되고난후엔
                              // 게임을종료할때까지 안사라짐 , 게임종료를해야 사라짐.
        {
            instance = this; // 위에있는   private static GameManager instance를
                             // this. 이 스크립트의 변수 함수, 모든정보들을 저장.
                             // 그리고 public static GameManager Instance의 Getter를써서 리턴시켜줌.

            //DontDestroyOnLoad(this.gameObject); == DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(gameObject);
            // DontDestroyOnLoad : 씬 전환시 파괴되지 않도록 해줌.
        }
        else // 이미 인스턴스가 존재 한다면(값이 있다면)
        {
            Destroy(gameObject);
            // 중복되었을 경우 제거
        }
    }

    public int GetSceneNum()
    {
        return SceneNum;
    }

    public void SetSceneNum(int value)
    {
        SceneNum = value;
    }

    public int GetSelect()
    {
        return Select;
    }

    public void SetScore(int value)
    {
        Select += value;
        Select = Mathf.Clamp(Select, 1, 3);
    }

    //public void GetScore()
    //{
    //    return
    //}
    //public static int Select = 1;
    //private static GameManager instance = null;

    //public static GameManager Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            return null;
    //        }
    //        return instance;
    //    }
    //}

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}


}
