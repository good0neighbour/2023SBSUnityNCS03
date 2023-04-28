/*
    Singleton Pattern을 적용한 클래스
    두 번째 버전

    static constructor 정적생성자와
    property를 이용

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuMgrStaticConstructor
{
    //데이터를 전역적으로 관리한다고 가정
    public int mTestScore = 999;

    //mpInst에 static을 적용( 힙에 High Frequency Heap영역에 저장된 것이다 )
    //선언함과 동시에 할당
    //런타임 상수화
    //              정적 생성자가 작동
    private static readonly CRyuMgrStaticConstructor mpInst = new CRyuMgrStaticConstructor();

    //이미 객체는 생성되어 있다.
    //여기서는 프로퍼티 문법을 통해 참조를 얻기만 한다.
    public static CRyuMgrStaticConstructor GetInst
    {
        get
        {
            return mpInst;
        }
    }

    //생성자는 public이 아니다
    private CRyuMgrStaticConstructor()
    {
        Debug.Log("CRyuMgrStaticConstructor.CRyuMgrStaticConstructor");
    }
}
