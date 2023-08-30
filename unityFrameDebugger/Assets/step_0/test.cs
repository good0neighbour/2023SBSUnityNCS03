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


        유니티에서 DrawCall개념을 다시 분류하고 재정립해둔 개념
        i) Batch: '렌더 상태 변경'과
                '렌더링 명령'
                을 호출하는 것을 말한다( 넓은 의미의 드로우 콜 )
        ii) SetPass: '렌더 상태 변경' 여부





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
