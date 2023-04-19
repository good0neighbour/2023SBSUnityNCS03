/*
    람다 lambda

        delegate의 인스턴스가 쓰이는 곳에
            delegate인스턴스 대신 사용가능하다.( 간접호출 도구다 )
        이름이 없는 함수다.

        ()=>{}

        매개변수리스트=>정의부 or 표현식

        i) 컴파일 결과물은 쌩제어구조다.( 즉, 함수호출 비용이 없으므로 빠르다 )
        ii) 변경의 국지화가 달성된다.


    익명형식 anonymouse type

        이름이 없는 타입이다.

        변경의 국지화가 달성된다


*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Func, Action 등을 사용하기 위해
using System;

public class CExam_4 : MonoBehaviour
{

    delegate int RyuFunc(int tX);
    // Start is called before the first frame update
    void Start()
    {
        //람다
        RyuFunc tRyu_0 = (tVal)=> { return tVal * tVal; };
        int tResult = tRyu_0(7);

        Debug.Log($"tResult: {tResult.ToString()}");


        //C# 언어에는 미리 준비된 델리게이트가 있다.

        //Func 델리게이트
        //Func는 제네릭으로 되어 있어 모든 타입에 대해 동작한다
        //그러므로, 델리게이트를 만들어도 되고, 미리 준비된 Func를 사용해도 된다
        //  Func는 함수function의 개념이다. 즉, 입력값과 출력값으로 정의된다
        Func<int, int> tRyu_1 = (tVal) => { return tVal + tVal; };
        tResult = tRyu_1(7);
        Debug.Log($"tResult: {tResult.ToString()}");

        //Action 델리게이트
        //  Action은 프로시저procedure의 개념이다. 즉, 입력값만 있다.
        Action<int> tRyu_2 = (tVal) => { Debug.Log(tVal.ToString()); };
        tRyu_2(1024);


        //캡춰, 외부변수 갈무리
        //outer variable, captured variable, closure
        int tFactor = 5;    //람다에서 보면 외부변수

        Func<int, int> tRyu_3 = (tVal) => { return tVal * tFactor; }; //캡춰
        tResult = tRyu_3(3);
        Debug.Log($"tResult: {tResult.ToString()}");


        //익명형식
        //익명형식의 객체를 참조할 때는 반드시 var을 사용한다
        //왜냐하면 타입이름이 없기 때문이다.
        var tRyu = new { mName = "ryu", mAge = 21 };

        Debug.Log(tRyu.ToString());

        Debug.Log(tRyu.mName.ToString());
        Debug.Log(tRyu.mAge.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
