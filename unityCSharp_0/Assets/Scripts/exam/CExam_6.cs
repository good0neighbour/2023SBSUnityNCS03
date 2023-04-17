using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    boxing, unboxing


        boxing, unboxing은 C#에서 type system의 연산을 통합하기 위해 만들어진 개념이다.
*/

public class CExam_6 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //object
        //C#에서 모든 참조타입의 궁극적인 부모클래스(기반클래스)다.

        //step_0
        int tA = 777;   //값타임의 변수 tA
        object tObjectA = tA;   //boxing    값타입 --> 참조타입
        // 힙메모리에 객체를 만들고 값을 복사하는 연산이 일어나므로
        //성능상 좋지 않다
        Debug.Log("boxing " + tObjectA);

        //unboxing  참조타입 --> 값타입
        int tB = (int)tObjectA; //unboxing은 명시적으로 적어줘야만 한다. 성능상 좋지 않다.
        Debug.Log("unboxing " + tB);




        //step_1
        object tD = 999;    //boxing //999는 상수고 int타입(값타입), tD는 object타입 (참조타입)
        long tLong_0 = (int)tD;  //unboxing, 값타입끼리의 형변환은 암묵적

        object tE = 777;
        //long tLong_1 = (long)tE;    //unboxing이 없으므로 실행 중 에러

        object tF = 333;
        long tLong_2 = (long)(int)tF;   //unboxing, 값타입끼리의 형변환은 명시적


        //step_2
        int tFirst = 1;
        int tSecond = 2;
        //다음의 문자열 생성에서도 boxing이 일어난다. int -> object, 값-->참조타입
        Debug.Log($"A few Numbers: {tFirst}, {tSecond}");
        //다음의 문자열 생성에서는 boxing이 일어나지 않는다.
        //그러므로 해당 표현이 성능상 잇점이다.
        Debug.Log($"A few Numbers: {tFirst.ToString()}, {tSecond.ToString()}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
