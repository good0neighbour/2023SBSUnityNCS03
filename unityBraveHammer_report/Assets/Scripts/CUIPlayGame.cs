using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UGUI를 사용하기 위해
using UnityEngine.UI;
//TextMeshPro를 사용하기 위해
using TMPro;

//TimeSpam을 사용하기 위해
using System;
using UnityEngine.SceneManagement;

public class CUIPlayGame : MonoBehaviour
{
    private static CUIPlayGame mpInstance;

    public TMPro.TMP_Text mpTxtScore = null;

    public TMPro.TMP_Text mpTxtLimitTime = null;

    public TMPro.TMP_Text mpTxtSpawnTime = null;

    int mLimitTimeTick = 0;

    public GameObject mpDxEnd = null;

    public static CUIPlayGame Instance
    {
        get
        {
            return mpInstance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mpInstance = this;

        mLimitTimeTick = 90;


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
        mLimitTimeTick--;

        if (mLimitTimeTick < 1 && !mpDxEnd.activeSelf)
        {
            //게임 종료 표시
            mpDxEnd.SetActive(true);
        }
        else if (mLimitTimeTick < -2)
        {
            //Invoke호출을 그만 취소한다.
            CancelInvoke();

            //주 화면으로 이동
            SceneManager.LoadScene("Scenetitle");
        }

        UpdateLimitTime();
    }
    public void UpdateLimitTime()
    {
        TimeSpan t = TimeSpan.FromSeconds(mLimitTimeTick);
        string s = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);

        mpTxtLimitTime.text = s;
    }

    public void SpawnTimeUpdate(float tSpawnTime)
    {
        mpTxtSpawnTime.text = string.Format($"슬라임 소환 간격: {tSpawnTime}초");
    }
}
