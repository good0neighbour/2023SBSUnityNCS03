/*
    '싱글턴 패턴'을 적용해보자
    singleton pattern
    <-- 객체의 최대 생성개수를 1개로 제한하는 것이 목적인 패턴

    아주 정직한 첫 번째 버전


    i) mpInst를 static을 적용한다
    ii) 생성자는 public이 아니다
    iii)GetInst 함수 안에는 객체를 1개로 생성제한하는 판단 구문이 존재한다
    
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuMgr
{
    //mpInst에 static을 적용한다
    private static CRyuMgr mpInst = null;   //C#에서는 static참조변수의 선언 시 null로 초기화 표현이 가능하다
    //<-- C#에서 static이 적용된 변수는 힙(의 특별한 위치 High Frequency Heap)에 위치한다

    //생성자는 public이 아니다
    private CRyuMgr()
    {
        Debug.Log("CRyuMgr.CRyuMgr");
    }
    //1개만 인스턴스화한다
    public static CRyuMgr GetInst()
    {
        if(null == mpInst)
        {
            mpInst = new CRyuMgr();
        }

        return mpInst;
    }
}


/*
    C#에서 객체 생성 단계

    임의의 타입으로
    '첫 번째' 인스턴스'를 생성할 시
    수행되는 과정은 다음과 같다.

    정적변수 단계

        i) 정적 변수의 저장공간(메모리)를 0으로 초기화
        ii) 정적 변수에 대한 초기화 구문을 수행

        iii) 정적 생성자 수행
            만약에 상속관계라면
            가) 베이스 클래스의 정적 생성자 수행
            나) 자신의 정적 생성자 수행

    ============
    인스턴스 변수 단계

        i) 인스턴스 변수의 저장공간(메모리)를 0으로 초기화
        ii) 인스턴스 변수에 대한 초기화 구문을 수행

        iii) 인스턴스 생성자 수행
            만약에 상속관계라면
            가) 베이스 클래스의 인스턴스 생성자 수행
            나) 자신의 인스턴스 생성자 수행

*/