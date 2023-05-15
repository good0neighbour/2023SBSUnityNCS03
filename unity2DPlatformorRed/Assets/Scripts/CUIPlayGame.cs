using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

using System;   //Action사용을 위해

public class CUIPlayGame : MonoBehaviour
{
    //static: High Frequency Heap 메모리에 위치시킨다.<--전역적인 성격을 가진다
    //Action: 범용 대리자delegate, 프로시저 형태( 리턴값이 없는 형태 ) <-- vs Function 함수형태( 리턴값이 있는 형태 )

    //전역적인 성격의 delegate <-- 간접 호출 도구, 객체
    public static Action mAction = null;


    [SerializeField]
    TMPro.TMP_Text mTxtStatus = null;

    // Start is called before the first frame update
    void Start()
    {
        //람다 룰 Action 델리게이트에 배정
        mAction = () =>
        {
            //원하는 함수 호출
            BuildUI();
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //UI구성요소 갱신을 위한 함수
    public void BuildUI()
    {
        Debug.Log("<color='red'>CUIPlayGame.BuildUI</Color>");

        mTxtStatus.text = "GOOD";
    }
    public void OnClickBtnTest()
    {
        Debug.Log("<color='blue'>CUIPlayGame.OnClickBtnTest</Color>");
    }
}
