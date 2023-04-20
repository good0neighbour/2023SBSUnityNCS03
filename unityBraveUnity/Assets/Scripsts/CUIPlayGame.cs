using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIPlayGame : MonoBehaviour
{
    //월드의 속성
    //0: 빈곳, 1: 슬라임 출몰지역, 100: 용사의 집, 200: 세상의 끝
    int[] mWorldAttrib = new int[5]
    {
        100,
        0,
        1,
        0,
        200
    };


    //public 예약어를 적용하면, 유니티 에디터에서 이것을 해석하여 에디터 상에 노출시킨다.
    public CBrave mpBrave = null;

    public CEnemy[] mEnemys = new CEnemy[2];

    // Start is called before the first frame update
    void Start()
    {
        //난수의 씨앗을 뿌림
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
                    Debug.Log("아무도 없음");
                }
                break;
            case 1:
                {
                    Debug.Log("슬라임 출몰지역");
                }
                break;
            case 100:
                {
                    Debug.Log("용사의 집");
                }
                break;
            case 200:
                {
                    Debug.Log("세상의 끝");
                }
                break;
        }
    }

    private int FindWorldAttribe()
    {
        //용사의 위치를 인덱스로 삼는다
        int tIndex = (int)(mpBrave.transform.position.z + 0.3f); //실수오차?
        //지형의 속성 정보를 얻는다
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
            Debug.Log("슬라임 출몰지역이 아닙니다.");
            return;
        }

        Debug.Log("슬라임이 나타났습니다.");

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
                    Debug.Log("용사가 졌다.");
                    tBrave.gameObject.SetActive(false); //게임오브젝트 비활성
                }
                break;
            case 4:
            case 5:
            case 6:
                {
                    Debug.Log("용사가 이겼다.");
                    tEnemy.gameObject.SetActive(false); //게임오브젝트 비활성
                }
                break;
        }
    }
}
