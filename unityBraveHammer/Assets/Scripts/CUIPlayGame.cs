using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UGUI를 사용하기 위해
using UnityEngine.UI;
//TextMeshPro를 사용하기 위해
using TMPro;

//TimeSpam을 사용하기 위해
using System;

public class CUIPlayGame : MonoBehaviour
{
    public TMPro.TMP_Text mpTxtScore = null;

    public TMPro.TMP_Text mpTxtLimitTime = null;


    int mLimitTimeTick = 0;


    public GameObject mpDxEnd = null;

    // Start is called before the first frame update
    void Start()
    {
        mLimitTimeTick = 60;


        UpdateLimitTime();


        InvokeRepeating("OnTimerTick", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //점수UI갱신 함수
    public void UpdateScore(int tScore)
    {
        string tString = $"SCORE {tScore.ToString()}";
        mpTxtScore.text = tString;
    }

    public void OnTimerTick()
    {
        if (mLimitTimeTick > 0)
        {
            mLimitTimeTick--;
        }
        else
        {
            //게임 종료 표시
            mpDxEnd.SetActive(true);

            CancelInvoke();    //Invoke호출을 그만 취소한다.
        }

        UpdateLimitTime();
    }
    public void UpdateLimitTime()
    {
        TimeSpan t = TimeSpan.FromSeconds(mLimitTimeTick);
        string s = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);

        mpTxtLimitTime.text = s;
    }
}
