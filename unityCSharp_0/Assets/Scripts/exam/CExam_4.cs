/*
    매개변수


        함수가 매개변수를 넘기는 방식

            값으로 전달(복사) pass by value
            ref예약어 pass by reference

            out예약어: pass by reference + 해당 함수의 정의를 나가기 전엘 반드시 해당 변수는 값이 배정되어야 한다


            param예약거: N개의 매개변수를 받는다
            선택적 매개변수( 매개변수 기본값 문법이다 )
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CExam_4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int tA = 3;
        int tB = 2;

        //before
        Debug.Log($"DoSwap before {tA.ToString()}, {tB.ToString()}");

        //DoSwap(tA, tB);
        DoSwapRef(ref tA, ref tB);

        //after
        Debug.Log($"DoSwap after {tA.ToString()}, {tB.ToString()}");



        Doit(ref tA, out tB);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DoSwap(int tA, int tB)
    {
        int tTemp = 0;
        tTemp = tA;
        tA = tB;
        tB = tTemp;
    }

    void DoSwapRef(ref int tA, ref int tB)
    {
        int tTemp = 0;
        tTemp = tA;
        tA = tB;
        tB = tTemp;
    }

    void Doit(ref int tA, out int tB)
    {
        //out예약어가 적용된 변수는 해당 함수의 정의를 나가기 전에 반드시 값이 배정되어야 한다.
        tB = 0;
    }
}
