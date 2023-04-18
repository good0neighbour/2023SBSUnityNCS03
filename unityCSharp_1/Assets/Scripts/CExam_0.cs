/*
    struct vs class

    C#에서는 struct와 class가 완전히 다르다
    다음과 같이 서로 다르다

    i) struct는 값타입, class는 참조타입
    ii) struct는 멤버변수 선언 시 초기화 표현이 불가하다
    iii) struct는 매개변수 없는 기본 생성자를 명시적으로 가질 수 없다
    iv) struct는 상속을 지원하지 않는다

*/


using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public struct SUnitInfo
{
    //멤버변수 선언 시 초기화 표현이 불가하다
    public int mX;// = 0;
    public int mY;// = 0;

    //기본생성자를 명시적으로 만들 수 없다
    //public SUnitInfo()
    //{

    //}
    //매개변수 있는 생성자를 명시적으로 정의
    //<--이것은 가능
    public SUnitInfo(int tX, int tY)
    {
        mX = tX;
        mY = tY;
    }
}

//struct는 상속을 지원하지 않는다
//public struct SActorInfo: SUnitInfo
//{

//}


public struct SUnit
{
    public string mName;
}

public class CExam_0 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //step_0
        //기본 내장 타입이므로 값타입
        //그리고 지역객체들이므로 스택 메모리에 있다
        int tA = 0;         //해당 표현은 생성자를 호출하지 않고, 메모리를 초기화하는 코드다.
        int tB = new int(); //해당 표현은 생성자를 호출하는 표현이다.
        tB = 3;

        //구조체로 만든 타입이므로 '값타입'
        //그리고 지역객체들이므로 스택 메모리에 있다
        SUnitInfo tInfo_0 = new SUnitInfo();    //<-- 생성자를 호출, 메모리의 값은 0으로 모두 초기화
        SUnitInfo tInfo_1 = new SUnitInfo(3, 2);    //<-- 생성자를 호출, 3, 2로 초기화

        //구조체 객체는 생성식
        //new연산자를 사용하지 않고도 만들 수(인스턴스화) 있다
        // <-- 생성자를 호출하지 않고, 메모리를 할당한다
        SUnitInfo tInfo_2;
        //필드(멤버변수)가 초기화되어 있지 않으므로, 이 객체를 사용하려면 초기화를 한 후에 사용해야 한다
        tInfo_2.mX = 10;
        tInfo_2.mY = 20;

        Debug.Log($"tInfo_0: {tInfo_0.mX.ToString()}, {tInfo_0.mY.ToString()}");
        Debug.Log($"tInfo_1: {tInfo_1.mX.ToString()}, {tInfo_1.mY.ToString()}");
        Debug.Log($"tInfo_2: {tInfo_2.mX.ToString()}, {tInfo_2.mY.ToString()}");

        //step_1
        //List<T> 가변배열
        //SUnit은 구조체이므로 값타입으로 동작
        var tUnits = new List<SUnit>();

        SUnit t = new SUnit { mName = "First Man" };
        tUnits.Add(t);

        SUnit s = tUnits[0];
        s.mName = "New man";

        //여기서 tUnits[0].mName은 무엇이냐?
        Debug.Log($"tUnits[0].mName: {tUnits[0].mName}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
