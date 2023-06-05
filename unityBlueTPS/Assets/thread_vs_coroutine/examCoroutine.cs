using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    coroutine
    co + routine 협응 + 절차

    스레드(병렬진행)는 아니지만
    스레드의 동작을 모사하는 문법이다.( 실제로 병렬진행은 아니다. 그렇게 보이기만 한다. )

    작성방법도 유사하게 만들어져 있다.
*/
public class examCoroutine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ryuBeginCoroutine", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }

    void ryuBeginCoroutine()
    {
        StartCoroutine(OnExamDoit());
    }

    //step_0
    /*
    IEnumerator OnExamDoit()    //<-- StartCoroutine에 의해 함수 호출
    {
        Debug.Log("OnExamDoit");

        yield return null;
        //이 함수의 정의가 끝나지 않았지만 일단 실행 흐름을 양보하여 리턴
        //주 실행의 흐름을 한 프레임 지난 후에 다시 이 지점으로 돌아오는 것이 핵심
        //( <--yield return 후에 null을 준 것은 한 프레임마다라는 의미다 )

        Debug.Log("//---OnExamDoit");
    }//여기까지 오면 해당 코루틴 함수의 호출은 종료
    */

    //step_1
    IEnumerator OnExamDoit()    //<-- StartCoroutine에 의해 함수 호출
    {
        //반복제어구조와 결합
        for (; ; )
        {
            Debug.Log("OnExamDoit");

            yield return null;
            //이 함수의 정의가 끝나지 않았지만 일단 실행 흐름을 양보하여 리턴
            //주 실행의 흐름을 한 프레임 지난 후에 다시 이 지점으로 돌아오는 것이 핵심
            //( <--yield return 후에 null을 준 것은 한 프레임마다라는 의미다 )

            Debug.Log("//---OnExamDoit");
        }

    }//여기까지 오면 해당 코루틴 함수의 호출은 종료
}
