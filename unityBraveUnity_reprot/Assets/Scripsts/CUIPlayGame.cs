using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIPlayGame : MonoBehaviour
{
    //월드의 속성
    //0: 빈곳, 1: 슬라임 출몰지역, 100: 용사의 집, 200: 세상의 끝
    int[,] mWorldAttrib = new int[5, 2]
    {
        { 100, 0 },
        { 0, 1 },
        { 1, 0 },
        { 0, 0 },
        { 200, 0 }
    };


    //public 예약어를 적용하면, 유니티 에디터에서 이것을 해석하여 에디터 상에 노출시킨다.
    public CBrave mpBrave = null;

    public CEnemy[] mEnemys = new CEnemy[2];

    public GameObject mBtnBattle = null;

    // Start is called before the first frame update
    void Start()
    {
        //난수의 씨앗을 뿌림
        Random.InitState((int)Time.realtimeSinceStartup);

        //초기화
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

        //현위치 보여주기
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
                    Debug.Log("아무도 없음");
                    mBtnBattle.gameObject.SetActive(false);
                }
                break;
            case 1:
                {
                    Debug.Log("슬라임 출몰지역");
                    mBtnBattle.gameObject.SetActive(true);
                }
                break;
            case 100:
                {
                    Debug.Log("용사의 집");
                    mBtnBattle.gameObject.SetActive(false);
                }
                break;
            case 200:
                {
                    Debug.Log("세상의 끝");
                    mBtnBattle.gameObject.SetActive(true);
                }
                break;
        }
    }

    private int FindWorldAttribe()
    {
        //용사의 위치를 인덱스로 삼는다
        int tIndexX = (int)(mpBrave.transform.position.z + 0.3f); //실수오차?
        int tIndexY = (int)(mpBrave.transform.position.x);
        //지형의 속성 정보를 얻는다
        int tAttribe = mWorldAttrib[tIndexX, tIndexY];
        return tAttribe;
    }
    public void OnClickBtnDoBattle()
    {
        Debug.Log("CUIPlayGame.OnClickBtnDoBattle");


        int tAttribe = FindWorldAttribe();

        if(1 == tAttribe)
        {
            Debug.Log("슬라임이 나타났습니다.");

            DoBattle(mpBrave, FindWhichEnemy((int)mpBrave.transform.position.x, (int)(mpBrave.transform.position.z + 0.3f)));
        }
        else if (200 == tAttribe)
        {
            Debug.Log("보스가 나타났습니다.");

            DoBossBattle(mpBrave, FindWhichEnemy((int)mpBrave.transform.position.x, (int)(mpBrave.transform.position.z + 0.3f)));
        }
        else
        {
            Debug.Log("슬라임 출몰지역이 아닙니다.");
        }
    }

    private CEnemy FindWhichEnemy(int tX, int tZ)
    {
        for (int ti = 0; ti < mEnemys.Length; ++ti)
        {
            if ((int)mEnemys[ti].transform.position.x == tX && (int)mEnemys[ti].transform.position.z == tZ)
            {
                //용사 위치에 있는 적을 반환
                return mEnemys[ti];
            }
        }

        //못 찾은 경우
        Debug.Log("적 없음");
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

    private void DoBossBattle(CBrave tBrave, CEnemy tBoss)
    {
        //0: 묵, 1: 찌, 2: 빠
        int tRSPBrave = Random.Range(0, 3);
        int tRSPBoss = Random.Range(0, 3);

        switch (tRSPBrave)
        {
            //묵
            case 0:
                {
                    Debug.Log("용사는 묵을 냈다.");
                    switch (tRSPBoss)
                    {
                        //묵
                        case 0:
                            Debug.Log("보스는 묵을 냈다.");
                            Debug.Log("비겼다.");
                            return;
                        //찌
                        case 1:
                            Debug.Log("보스는 찌를 냈다.");
                            Debug.Log("이겼다.");
                            tBoss.gameObject.SetActive(false);
                            return;
                        //빠
                        case 2:
                            Debug.Log("보스는 빠를 냈다.");
                            Debug.Log("졌다.");
                            tBrave.gameObject.SetActive(false);
                            return;
                    }
                }
                return;
            //찌
            case 1:
                {
                    Debug.Log("용사는 찌를 냈다.");
                    switch (tRSPBoss)
                    {
                        //묵
                        case 0:
                            Debug.Log("보스는 묵을 냈다.");
                            Debug.Log("졌다.");
                            tBrave.gameObject.SetActive(false);
                            return;
                        //찌
                        case 1:
                            Debug.Log("보스는 찌를 냈다.");
                            Debug.Log("비겼다.");
                            return;
                        //빠
                        case 2:
                            Debug.Log("보스는 빠를 냈다.");
                            Debug.Log("이겼다.");
                            tBoss.gameObject.SetActive(false);
                            return;
                    }
                }
                return;
            //빠
            case 2:
                {
                    Debug.Log("용사는 빠를 냈다.");
                    switch (tRSPBoss)
                    {
                        //묵
                        case 0:
                            Debug.Log("보스는 묵을 냈다.");
                            Debug.Log("이겼다.");
                            tBoss.gameObject.SetActive(false);
                            return;
                        //찌
                        case 1:
                            Debug.Log("보스는 찌를 냈다.");
                            Debug.Log("졌다.");
                            tBrave.gameObject.SetActive(false);
                            return;
                        //빠
                        case 2:
                            Debug.Log("보스는 빠를 냈다.");
                            Debug.Log("비겼다.");
                            return;
                    }
                }
                return;
        }
    }
}
