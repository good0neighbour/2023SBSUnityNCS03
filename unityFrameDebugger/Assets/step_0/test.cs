/*


    성능 측정의 기준 개념 중 일부

        FPS 초당 프레임: 1초에 몇 프레임이 있는가
            <-- '최종 결과물의 상태'만 알 수 있다.
        'Frame Time': 한 프레임에 걸리는 시간
            <-- 한 프레임에 시간이 어떻게 걸리는지 측정 가능한 개념이다.
            <-- 그러므로, 한 프레임에 어느 부분이 시간이 많이 걸리는지( 병목bottleneck 현상 )

                ---> 병목 현상: 임의의 프로세스(공정)에서 일부 구간에서 성능이 떨어지는 현상

                판단할 수 있는 기반 개념이다.

            <-- 그러므로 '성능측정'과 이를 기반으로 한 '최적화'에 중요한 개념이다.



    렌더링 성능 측정과 최적화

        FrameDebugger: 렌더링 성능 측정을 위해 유니티에서 준비해둔 도구다.

        왼쪽 창: Draw Call List
                <--드로우 콜을 카테고리별로 분류하여 보여준다.

        오른쪽 창: 임의의 드로우콜에 상세정보창



        DrawCall: 그래픽스에서 사용하는 일반적인 용어
                '렌더 상태 변경'과
                '렌더링 명령'
                을 호출하는 것을 말한다

            CPU---->GPU 명령을 호출하는 것이다.
            <--- CPU의 성능이 중요하다.




        유니티에서 DrawCall개념을 다시 분류하고 재정립해둔 개념
        i) Batch: '렌더 상태 변경'과
                '렌더링 명령'
                을 호출하는 것을 말한다( 넓은 의미의 드로우 콜 )

        ii) SetPass: '렌더 상태 변경' 여부

            <--- 머티리얼의 변경( 셰이더의 변경, 셰이더의 파라미터의 변경 )

            <-- 메쉬 변경은 포함하지 않는다



        ---> 유니티에서 그래픽스 최적화의 주요한 방법은 ( 물론 케바케이지만 )
            Draw Call회수를 줄이는 것이다
            그리고
            유니티에서는 이를 Batch와 SetPass라는 개념으로 다루고 있다.
            그러므로,
            Batch와 SetPass에 대해 회수를 줄이는 것이
            DrawCall을 줄이는 것이다.
            <-- 유니티에서 그래픽스 최적화를 하를 주요한 방법중 하나




        배칭Batching <--CPU가 수행하는 것이다.
            <-- 드로우콜을 줄이기 위해 매쉬를 모아 배치를 줄이는 방법이다.
                <--머티리얼은 일단 같아야 효과가 있다.

            Static Batching: 제작 중에 배칭 작업을 수행하는 옵션이다.
                            <--- 배칭을 적용할 메쉬를 선택하고 Batching Static옵션을 적용하면 된다.
                            <-- 머티리얼이 같지 않으면 실패한다.
                            <-- 실행중에는 CPU가 배칭연산을 하지 않는다

            Dynamic Batching: 실행중에 CPU가 배칭 작업을 수행하는 옵션이다.
                            <--별도의 작업이 필요없다.( 플레이어 설정에서 dynamic Batching플래그를 켜주면 된다 )



        --유니티 스래픽스 최적화 전략---
        DrawCall
            SetPass <-- 되도록 머티리얼 수를 줄이고 머티리얼 변경을 줄이는 방향으로 최적화 전략을 세운다
                        ( 텍스쳐는 셰이더 입장에서 볼 때 용량이 매우 큰, 응용프로그램에서 가져오는 전역적인 자원 '단위'다. 그러므로 머티리얼에서 텍스쳐가 주요한 성능의 병목지점이 될 가능성이 크다 )
            Batch<-- 배칭을 하는 전략을 세운다
    
*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int ti = 0; ti < 10; ++ti)
        {
            Debug.Log("test");
        }
    }
}
