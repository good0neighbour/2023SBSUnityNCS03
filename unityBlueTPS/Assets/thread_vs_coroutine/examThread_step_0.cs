using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스레드: 실행흐름의 최소단위
//프로세스: N개의 스레드 집합
//스레드의 사용의 가장 큰 목적은
//  병렬 진행( 동시에 여러 실행흐름을 진행 )을 통해 '단위시간당 연산량'을 높이려 하는 것이다.
/*
    coroutine vs thread

    에 대한 배경지식을 목적으로 작성해본다


    MainThread 1개
        subThread 1개

    의 예시 작성

*/

using System.Threading; //C#에서 제공하는 스레드 관련 클래스와 함수를 사용하기 위해

public class examThread_step_0 : MonoBehaviour
{
    bool mThreadLoop = false;

    //스레드 클래스( 실행흐름의 최소단위를 클래스로 만들어 준비해둔 것)
    Thread mThread = null;

    //이벤트 함수의 실행순서가 주스레드Main Thread다.
    // Start is called before the first frame update
    void Start()
    {
        //5초 후에 별도의 스레드 실행
        Invoke("ryuBeginThread", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }

    //스레드를 시작하는 함수
    void ryuBeginThread()
    {
        mThreadLoop = true;
        //Dispatch함수를 스레드 함수로 삼아, 스레드 생성
        mThread = new Thread(new ThreadStart(Dispatch));
        mThread.Name = "ryu";
        //스레드 시작 (별도의 실행흐름 시작 )
        mThread.Start();
    }

    //스레드 함수( 별도의 실행흐름을 담당하는 함수 )
    void Dispatch()
    {
        Debug.Log("Dispatch ThreadFunction Start");

        //반복제어구조
        while (mThreadLoop)
        {
            Debug.Log($"Thread is running. {mThread.ManagedThreadId.ToString()}, name: {mThread.Name}");

            Thread.Sleep(5);//스레드 잠기 대기 (5/1000초)
        }

        Debug.Log("Dispatch ThreadFunction End");
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0f, 0f, 100f, 100f), "Abort Thread"))
        {
            //.NET Framework에서의 스레드 강제 종료, ( 종료를 반드시 보장하지는 않는다 )
            // test 용도로 사용하였으며, 실제로는 권장하지 않는 종료방법이다.
            //( join을 이용하여 모든 스레드가 종료되었음을 체크하자. )

            //스레드 강제 중지
            mThread.Abort();
        }
    }

}
