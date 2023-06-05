using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSpawnerEnemy : MonoBehaviour
{
    //프리팹 링크
    [SerializeField]
    GameObject PFEnemy = null;

    //코루틴 함수를 이용한 '별도의 실행흐름 개념' 만들기:
    //                  IEnumerator리턴타입 + 반복제어구조 + yield return
    IEnumerator OnSpawnEnemy()
    {
        for(; ; )
        {
            yield return new WaitForSeconds(5f);    //yield return 끝나지 않았지만 리턴할께
            //<-- new WaitForSeconds(5f)5초 시간 후에 이 지점으로 다시 코루틴 실행의 흐름이 돌아온다.

            /*
                병렬 진행을 모사하기 위한 문법이다.
                실행의 흐름이 병렬적으로 이루어지는 스레드의 동작을 흉내낸 것이며
                실제 병렬진행이 이루어지는 것은 아니다.
            */

            Debug.Log("OnSpawnEnemy");

            Vector3 tPosition = this.transform.position;
            //tPosition.y = 1.0f;
            Instantiate<GameObject>(PFEnemy, tPosition, Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("OnSpawnEnemy");   //문자열을 이용하여 코루틴 함수를 시작
        StartCoroutine(OnSpawnEnemy());     //코루틴의 간접호출?을 사용하여 코루틴 함수를 시작
        //<-- 두 번째 방식을 권한다
        //  왜냐하면, 첫 번째 문자열로 이용하는 방식은 수동 제어가 불가능하다.



        //일정 시간 간격으로 적 생성
        //InvokeRepeating("OnSpawnEnemy", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void OnSpawnEnemy()
    //{
    //    Debug.Log("OnSpawnEnemy");

    //    Vector3 tPosition = this.transform.position;
    //    tPosition.y = 1.0f;


    //    Instantiate<GameObject>(PFEnemy, tPosition, Quaternion.identity);
    //}
}
