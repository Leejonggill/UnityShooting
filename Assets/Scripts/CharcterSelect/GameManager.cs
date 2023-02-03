using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int SceneNum;
    public int Select = 1;
    public int SelectMod = 0;
    private static GameManager instance = null; // ����ƽ ������ �� �ϳ��� ����. ����������x

    public static GameManager Instance // ������ ���ϵ��� getter������.
                                       // public static  GameManager Instance ���ִ�����
                                       // ��� ��ũ��Ʈ������ �����̰����ϰ� �����ְ�
                                       // public static int�� �Ⱦ��� public int score�θ� �ᵵ�ǰ�����.
                                       // public static  GameManager Instance �� ���͸����ؼ� �Լ� , ������ �ҷ���
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance; // instance�� ������ Instance���� ���� , ����
        }
    }

    //public int score = 0;
    //public GameObject gold;

    private void Awake()
    {
        // �̰Ծ����� ó������ �ٽý���ɶ� ���ӿ�����Ʈ����� ������ ������.
        // ���� �ٽý��۵ɶ� ���� �� �ʱ�ȭ�Ǵµ� �̰Ŵ� �ʱ�ȭ���ȵǰ�
        // �״���̾�µ� �׷��� ������Ʈ��2���� ó��(�����ִ�) ������Ʈ�� �����
        // ���θ������  DontDestroyOnLoad(gameObject); �� ��.

        if (instance == null) // �ν��Ͻ��� ó������ȰŸ�. ����ƽ�� �����̱⶧���� ������ �����ǰ��Ŀ�
                              // �����������Ҷ����� �Ȼ���� , �������Ḧ�ؾ� �����.
        {
            instance = this; // �����ִ�   private static GameManager instance��
                             // this. �� ��ũ��Ʈ�� ���� �Լ�, ����������� ����.
                             // �׸��� public static GameManager Instance�� Getter���Ἥ ���Ͻ�����.

            //DontDestroyOnLoad(this.gameObject); == DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(gameObject);
            // DontDestroyOnLoad : �� ��ȯ�� �ı����� �ʵ��� ����.
        }
        else // �̹� �ν��Ͻ��� ���� �Ѵٸ�(���� �ִٸ�)
        {
            Destroy(gameObject);
            // �ߺ��Ǿ��� ��� ����
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
