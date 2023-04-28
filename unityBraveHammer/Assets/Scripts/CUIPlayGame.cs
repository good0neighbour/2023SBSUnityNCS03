using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UGUI�� ����ϱ� ����
using UnityEngine.UI;
//TextMeshPro�� ����ϱ� ����
using TMPro;

//TimeSpam�� ����ϱ� ����
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
    //����UI���� �Լ�
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
            //���� ���� ǥ��
            mpDxEnd.SetActive(true);

            CancelInvoke();    //Invokeȣ���� �׸� ����Ѵ�.
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
