/*
    상수

    const vs readonly


    컴파일 타임 상수
        const예약어로 만든다.

        <-- 컴파일 시점에 상수로 대체된다.

        예) 내장된 숫자형, enum, null, 문자열( ""로 만드는 것 )

    런타임 상수
        readonly예약어로 만든다.

        i)런타임에 생성자에서 초기화가 가능하다.
            ( 컴파일 타임 상수는 컴파일 시에 상수 값으로 대체되므로 그럴 수 없다. 선언할 때 토기화 표현만 가능 )
        ii) 어떤 타입과도 사용 가능하다
            ( 컴파일 타임 상수는 컴파일 시에 값이 결정되어야 하므로 미리 상수값이 정해질 수 있는 타임의 경우에만 가능하다 )
        iii) 인스턴스마다 다른 값을 가질 수도 있다.
            ( 생성자에서 경우에 따라 다르게 입력받아 초기화 가능, 그 이후에는 수정 불가 )

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CExam_6 : MonoBehaviour
{
    //컴파일 타임 상수 <--const예약어 사용
    public const int mConstInt = 777;
    //런 타임 상수 <--readonly예약어 사용
    public readonly int mReadonlyInt = 999;


    CExam_6(int tReadonlyInt)
    {
        //mConstInt = tReadonlyInt;   //<-- 컴파일 상수라 안됨.
        mReadonlyInt = tReadonlyInt;    //<-- 런타임 상수는 생성자에서 초기화 가능
    }

    // Start is called before the first frame update
    void Start()
    {
        //mConstInt = 7;    <--안됨
        Debug.Log($"const {mConstInt.ToString()}");

        //mReadonlyInt = 9; <--안됨
        Debug.Log($"readonly {mReadonlyInt.ToString()}");



        //컴파일 타임 상수는 임의의 메소드(함수)안에서 선언 가능
        const float tGravity = 9.8f;
        //런타임 상수는 임의의 메소드(함수)안에서 선언불가
        //readonly float tGRAVITY = 9.8f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
