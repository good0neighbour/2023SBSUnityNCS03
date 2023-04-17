using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Generic

    C#에서 일반화 프로그래밍( General Programming )
        의 도구로서 제공되는 문법이다.

    타입을 매개변수처럼 다룬다.
    <-- 서로 다른 타입들에 대해서 재사용 가능한 코드를 만든다.


    C++의 template은 컴파일 시점에 추론으로 인해 타입이 결정되지만,
    C#의 generic은 실행 시점에 추론으로 인해 타입이 결정된다.
    <--즉, C++은 컴파일 시점에 구체적인 해당 타입들에 대한 함수들이 만들어지고
        C#은 컴파일 시점에는 제네릭 코드 그 자체로 컴파일된다.



    C/C++언어로 작성한 프로그램의 실행 동작기전

        native code
        execute

    C#언어로 작성한 프로그램의 실행 동작기전

        Compilation

        IL

        CLR
            JIT
            native code
            execute
*/

public class CExam_7 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int tA = 3;
        int tB = 2;
        DoSwap(ref tA, ref tB);
        Debug.Log($"after: tA: {tA.ToString()}, tB: {tB.ToString()}");

        float tAA = 3.14f;
        float tBB = 1.2f;
        DoSwap(ref tAA, ref tBB);
        Debug.Log($"after: tA: {tAA.ToString()}, tB: {tBB.ToString()}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Generic Function
    //다음과 같이 타입을 일반화시키면, 상황에 따라 구체적인 타입의 함수들이 만들어진다.
    void DoSwap<T>(ref T tA, ref T tB)
    {
        T tTemp;
        tTemp = tA;
        tA = tB;
        tB = tTemp;
    }
    //void DoSwap(ref int tA, ref int tB)
    //{
    //    int tTemp = 0;
    //    tTemp = tA;
    //    tA = tB;
    //    tB = tTemp;
    //}
    //void DoSwap(ref float tA, ref float tB)
    //{
    //    float tTemp = 0;
    //    tTemp = tA;
    //    tA = tB;
    //    tB = tTemp;
    //}
}
