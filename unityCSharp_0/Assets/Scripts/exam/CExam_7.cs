using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Generic

    C#에서 일반화 프로그래밍( General Programming )
        의 도구로서 제공되는 문법이다.

    타입을 매개변수(로 일반화하여)처럼 다룬다.
    <-- 서로 다른 타입들에 대해서 재사용 가능한 코드를 만든다.


    C++의 template은 컴파일 시점에 추론으로 인해 타입이 결정되지만,
    C#의 generic은 실행 시점에 추론으로 인해 타입이 결정된다.
    <--즉, C++은 컴파일 시점에 구체적인 해당 타입들에 대한 함수들이 만들어지고
        C#은 컴파일 시점에는 제네릭 코드 그 자체로 컴파일된다.



    C/C++언어로 작성한 프로그램의 실행 동작기전

        native code
        execute

    C#언어로 작성한 프로그램의 실행 동작기전

        Compilation( C#컴파일러에 의한 결과물, C#외의 언어들에도 같은 기전으로 동작 즉, 각각의 언어의 컴파일러들이 결과물을 만듦 )

        IL( Intermediate Language ) //<-- CLR을 위한 중간 언어

        CLR( Common Language Runtime )
            JIT( Just In Time )컴파일러     //<-- 실행시점에 필요하면 IL을 해석하여 필요하면 native code로 컴파일
            native code     //<--CPU에서 해석하여 동작
            execute
*/


public class CStack<T>
{
    int mCurIndex = 0;
    T[] mArray = new T[100];    //선언시 동적할당

    public void Push(T t)
    {
        mArray[mCurIndex++] = t;
    }
    public T Pop()
    {
        return mArray[--mCurIndex];
    }
}

public class CExam_7 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //step_0
        //제
        int tA = 3;
        int tB = 2;
        DoSwap(ref tA, ref tB);
        Debug.Log($"after: tA: {tA.ToString()}, tB: {tB.ToString()}");

        float tAA = 3.14f;
        float tBB = 1.2f;
        DoSwap(ref tAA, ref tBB);
        Debug.Log($"after: tA: {tAA.ToString()}, tB: {tBB.ToString()}");



        //generic은 아니지만 다음 문법도 한 번 보자.
        //var 타입 추론 예약어
        var tX = 3; //실행시점에 tX의 타입이 결정된다. 어차피 c#은 실행시점에 CLR에 의해 해석되므로 속도상 불이익은 없다
        Debug.Log($"tX: {tX.ToString()}");


        //step_1
        //제네릭 클래스
        CStack<int> tStack = new CStack<int>();
        tStack.Push(5);
        tStack.Push(10);

        int tXX = tStack.Pop();
        int tXXX = tStack.Pop();
        //10, 5
        Debug.Log($"tXX: {tXX.ToString()}, tXXX: {tXXX.ToString()}");

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
