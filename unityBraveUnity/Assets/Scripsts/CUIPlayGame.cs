using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIPlayGame : MonoBehaviour
{
    //������ �Ӽ�
    //0: ���, 1: ������ �������, 100: ����� ��, 200: ������ ��
    int[] mWorldAttrib = new int[5]
    {
        100,
        0,
        1,
        0,
        200
    };


    //public ���� �����ϸ�, ����Ƽ �����Ϳ��� �̰��� �ؼ��Ͽ� ������ �� �����Ų��.
    public CBrave mpBrave = null;

    public CEnemy[] mEnemys = new CEnemy[2];

    // Start is called before the first frame update
    void Start()
    {
        //������ ������ �Ѹ�
        Random.InitState((int)Time.realtimeSinceStartup);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClickBtnDoMoveForward()
    {
        Debug.Log("CUIPlayGame.OnClickBtnDoMoveForward");

        mpBrave.DoMoveForward();
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
                }
                break;
            case 1:
                {
                    Debug.Log("������ �������");
                }
                break;
            case 100:
                {
                    Debug.Log("����� ��");
                }
                break;
            case 200:
                {
                    Debug.Log("������ ��");
                }
                break;
        }
    }

    private int FindWorldAttribe()
    {
        //����� ��ġ�� �ε����� ��´�
        int tIndex = (int)(mpBrave.transform.position.z + 0.3f); //�Ǽ�����?
        //������ �Ӽ� ������ ��´�
        int tAttribe = mWorldAttrib[tIndex];
        return tAttribe;
    }

    public void OnClickBtnDoMoveBackward()
    {
        Debug.Log("CUIPlayGame.OnClickBtnDoMoveBackward");

        mpBrave.DoMoveBackward();
        DoSeeWorld();
    }
    public void OnClickBtnDoBattle()
    {
        Debug.Log("CUIPlayGame.OnClickBtnDoBattle");


        int tAttribe = FindWorldAttribe();

        if(1 != tAttribe)
        {
            Debug.Log("������ ��������� �ƴմϴ�.");
            return;
        }

        Debug.Log("�������� ��Ÿ�����ϴ�.");

        DoBattle(mpBrave, mEnemys[0]);
    }

    void DoBattle(CBrave tBrave, CEnemy tEnemy)
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
}
