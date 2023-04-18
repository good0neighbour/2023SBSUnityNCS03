/*
    delegate
    대리자

        C#체서 제공하는 '간접호출 조구'다.

        임의의 메소드(함수)를 호출하는 방법을 담은 '객체'다.

        delegate객체에 메소드(함수)를 배정하는 연산은 실행시점에 일어난다.
        <-- 호출할 대상은 실행시점에 결정하게 된다.
            --> 콜하는 측과 콜받는 측의 결합을 약하게 만든다

    만드는 방법: delegate예약에를 적용하면 된다.

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUnit
{
    
    public void Doit(int tX)
    {
        Debug.Log($"CUnit.Doit {tX.ToString()}");
    }
}



public class CExam_1 : MonoBehaviour
{
    //델리게이트 선언 ( 간접호출도구, C++로 치면 함수포인터 )
    delegate void RyuFunc(int t);   //객체

    delegate void RyuMultiFunc();

    // Start is called before the first frame update
    void Start()
    {
        RyuFunc tRyu_0 = null;
        tRyu_0 = DoThat;
        tRyu_0(7);  //간접호출

        CUnit tUnit = new CUnit();

        RyuFunc tRyu_1 = null;
        tRyu_1 = tUnit.Doit;    //객체의 메소드(함수)를 대상으로 하는 경우에는 해당 객체(인스턴스)도 표기해줘야 한다
        tRyu_1(3);  //간접호출


        //multicast delegate
        //C#에서 제공하는 델리게이트는 여러 메소드를 동시에 위임할 수 있다.
        RyuMultiFunc tCall = null;
        tCall += InputControl;
        tCall += UpdateControl;
        tCall += RenderControl;

        tCall();

        tCall -= UpdateControl;

        tCall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void DoThat(int tX)
    {
        Debug.Log($"CExam_1.DoThat {tX.ToString()}");
    }


    void InputControl()
    {
        Debug.Log("InputConstrol");
    }
    void UpdateControl()
    {
        Debug.Log("UpdateConstrol");
    }
    void RenderControl()
    {
        Debug.Log("RenderConstrol");
    }
}
