/*
    형변환

    C#에서는 형변환을 수행하는 방법이 크게 두 가지가 있다.

    i) 컴파일러의 타입 캐스트(형변환) 연산자 구분 <--우리가 알고 있는 그 형변환 연산자다.
    ii) as 연산자
        기본타입은 안됨( nullable(null값을 가질 수 있는 타입)한 타입에 가능하다 )
        <-- 임의의 객체의 참조를 리턴

        is 연산자: 형변환이 가능한지 검사하는 연산자다.
            <-- 참 아니면 거짓이 리턴


        as연산자를 사용할 수 있는 경우라면
        as연산자를 사용하는 것이 타입캐스트 연산자를 사용하는 경우보다 안전하다.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class CUnitRyu
{
}
class CActorRyu : CUnitRyu
{
}
class CBraveRyu : CActorRyu
{
}



public class CExam_5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //step_0
        int tA = 3;
        float tB = 3.14f;
        //기본타입, 컴파일러레서 지원하는 타입캐스트 적용
        tA = (int)tB;

        //기본타입에 as 적용은 안됨
        //tA = tB as int;



        //step_1
        CUnitRyu tUnit = new CUnitRyu();
        CActorRyu tActor = new CActorRyu();
        CBraveRyu tBrave = new CBraveRyu();

        //형변환 성공
        //련타임에 객체의 타입이 변환하려는 타입과 일치하는 경우에만 형변환이 성공한다.
        CUnitRyu u = tActor as CUnitRyu;
        if (null != u)
        {
            Debug.Log("OK, actor as unit");
        }
        //형변환 실패
        CBraveRyu v = tActor as CBraveRyu;
        if (null != v)
        {
            Debug.Log("OK, actor as brave");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
