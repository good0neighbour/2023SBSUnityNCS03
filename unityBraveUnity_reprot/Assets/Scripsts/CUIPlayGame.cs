using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIPlayGame : MonoBehaviour
{
    //������ �Ӽ�
    //0: ���, 1: ������ �������, 100: ����� ��, 200: ������ ��
    int[,] mWorldAttrib = new int[5, 2]
    {
        { 100, 0 },
        { 0, 1 },
        { 1, 0 },
        { 0, 0 },
        { 200, 0 }
    };


    //public ���� �����ϸ�, ����Ƽ �����Ϳ��� �̰��� �ؼ��Ͽ� ������ �� �����Ų��.
    public CBrave mpBrave = null;

    public CEnemy[] mEnemys = new CEnemy[2];

    public GameObject mBtnBattle = null;

    // Start is called before the first frame update
    void Start()
    {
        //������ ������ �Ѹ�
        Random.InitState((int)Time.realtimeSinceStartup);

        //�ʱ�ȭ
        OnClickBtnDoReset();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            OnClickBtnDoMoveForward();
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            OnClickBtnDoMoveBackward();
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            OnClickBtnDoMoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            OnClickBtnDoMoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            OnClickBtnDoBattle();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            OnClickBtnDoReset();
        }
    }


    public void OnClickBtnDoReset()
    {
        mpBrave.transform.position = new Vector3(0.0f, 0.0f, -0.2f);
        mpBrave.gameObject.SetActive(true);
        for (int ti = 0; ti < mEnemys.Length; ++ti)
        {
            mEnemys[ti].gameObject.SetActive(true);
        }

        //����ġ �����ֱ�
        DoSeeWorld();
    }

    public void OnClickBtnDoMoveForward()
    {
        Debug.Log("CUIPlayGame.OnClickBtnDoMoveForward");

        mpBrave.DoMoveForward();
        DoSeeWorld();
    }

    public void OnClickBtnDoMoveBackward()
    {
        Debug.Log("CUIPlayGame.OnClickBtnDoMoveBackward");

        mpBrave.DoMoveBackward();
        DoSeeWorld();
    }

    public void OnClickBtnDoMoveLeft()
    {
        Debug.Log("CUIPlayGame.OnClickBtnDoMoveLeft");

        mpBrave.DoMoveLeft();
        DoSeeWorld();
    }

    public void OnClickBtnDoMoveRight()
    {
        Debug.Log("CUIPlayGame.OnClickBtnDoMoveRight");

        mpBrave.DoMoveRight();
        DoSeeWorld();
    }

    private void DoSeeWorld()
    {
        int tAttribe = FindWorldAttribe();

        switch (tAttribe)
        {
            case 0:
                {
                    Debug.Log("�ƹ��� ����");
                    mBtnBattle.gameObject.SetActive(false);
                }
                break;
            case 1:
                {
                    Debug.Log("������ �������");
                    mBtnBattle.gameObject.SetActive(true);
                }
                break;
            case 100:
                {
                    Debug.Log("����� ��");
                    mBtnBattle.gameObject.SetActive(false);
                }
                break;
            case 200:
                {
                    Debug.Log("������ ��");
                    mBtnBattle.gameObject.SetActive(true);
                }
                break;
        }
    }

    private int FindWorldAttribe()
    {
        //����� ��ġ�� �ε����� ��´�
        int tIndexX = (int)(mpBrave.transform.position.z + 0.3f); //�Ǽ�����?
        int tIndexY = (int)(mpBrave.transform.position.x);
        //������ �Ӽ� ������ ��´�
        int tAttribe = mWorldAttrib[tIndexX, tIndexY];
        return tAttribe;
    }
    public void OnClickBtnDoBattle()
    {
        Debug.Log("CUIPlayGame.OnClickBtnDoBattle");


        int tAttribe = FindWorldAttribe();

        if(1 == tAttribe)
        {
            Debug.Log("�������� ��Ÿ�����ϴ�.");

            DoBattle(mpBrave, FindWhichEnemy((int)mpBrave.transform.position.x, (int)(mpBrave.transform.position.z + 0.3f)));
        }
        else if (200 == tAttribe)
        {
            Debug.Log("������ ��Ÿ�����ϴ�.");

            DoBossBattle(mpBrave, FindWhichEnemy((int)mpBrave.transform.position.x, (int)(mpBrave.transform.position.z + 0.3f)));
        }
        else
        {
            Debug.Log("������ ��������� �ƴմϴ�.");
        }
    }

    private CEnemy FindWhichEnemy(int tX, int tZ)
    {
        for (int ti = 0; ti < mEnemys.Length; ++ti)
        {
            if ((int)mEnemys[ti].transform.position.x == tX && (int)mEnemys[ti].transform.position.z == tZ)
            {
                //��� ��ġ�� �ִ� ���� ��ȯ
                return mEnemys[ti];
            }
        }

        //�� ã�� ���
        Debug.Log("�� ����");
        return null;
    }

    private void DoBattle(CBrave tBrave, CEnemy tEnemy)
    {
        int tDice = Random.Range(1, 7);
        Debug.Log($"------tDice: {tDice.ToString()}");

        switch(tDice)
        {
            case 1:
            case 2:
            case 3:
                {
                    Debug.Log("��簡 ����.");
                    tBrave.gameObject.SetActive(false); //���ӿ�����Ʈ ��Ȱ��
                }
                break;
            case 4:
            case 5:
            case 6:
                {
                    Debug.Log("��簡 �̰��.");
                    tEnemy.gameObject.SetActive(false); //���ӿ�����Ʈ ��Ȱ��
                }
                break;
        }
    }

    private void DoBossBattle(CBrave tBrave, CEnemy tBoss)
    {
        //0: ��, 1: ��, 2: ��
        int tRSPBrave = Random.Range(0, 3);
        int tRSPBoss = Random.Range(0, 3);

        switch (tRSPBrave)
        {
            //��
            case 0:
                {
                    Debug.Log("���� ���� �´�.");
                    switch (tRSPBoss)
                    {
                        //��
                        case 0:
                            Debug.Log("������ ���� �´�.");
                            Debug.Log("����.");
                            return;
                        //��
                        case 1:
                            Debug.Log("������ � �´�.");
                            Debug.Log("�̰��.");
                            tBoss.gameObject.SetActive(false);
                            return;
                        //��
                        case 2:
                            Debug.Log("������ ���� �´�.");
                            Debug.Log("����.");
                            tBrave.gameObject.SetActive(false);
                            return;
                    }
                }
                return;
            //��
            case 1:
                {
                    Debug.Log("���� � �´�.");
                    switch (tRSPBoss)
                    {
                        //��
                        case 0:
                            Debug.Log("������ ���� �´�.");
                            Debug.Log("����.");
                            tBrave.gameObject.SetActive(false);
                            return;
                        //��
                        case 1:
                            Debug.Log("������ � �´�.");
                            Debug.Log("����.");
                            return;
                        //��
                        case 2:
                            Debug.Log("������ ���� �´�.");
                            Debug.Log("�̰��.");
                            tBoss.gameObject.SetActive(false);
                            return;
                    }
                }
                return;
            //��
            case 2:
                {
                    Debug.Log("���� ���� �´�.");
                    switch (tRSPBoss)
                    {
                        //��
                        case 0:
                            Debug.Log("������ ���� �´�.");
                            Debug.Log("�̰��.");
                            tBoss.gameObject.SetActive(false);
                            return;
                        //��
                        case 1:
                            Debug.Log("������ � �´�.");
                            Debug.Log("����.");
                            tBrave.gameObject.SetActive(false);
                            return;
                        //��
                        case 2:
                            Debug.Log("������ ���� �´�.");
                            Debug.Log("����.");
                            return;
                    }
                }
                return;
        }
    }
}
