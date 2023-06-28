using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Gizmo 기즈모: 게임 제작시 사용하는( 시각적, 조작적인 도움을 주는 ) 부가적인 물체
    <-- 시각적 디버깅을 씬뷰에서 할 수 있게 해주는 부가적인 도구다.


    여기서는 이전에 살펴보았던 내용을 다시 한번 복기하자.
*/

public class testGizmo_0 : MonoBehaviour
{

    //MonoBehaviour에 준비된 다음과 같은 이벤트 함수가 있다.
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 1f, 0f, 1f);//노란색//<--[0, 1]로 정규화
        Gizmos.DrawWireCube(this.transform.position, this.transform.lossyScale * 1.2f);
        //localScale: 로컬좌표계 상에 스케일
        //lossyScale: 절대좌표계 상에 스케일

        //Gizmos.color = new Color32(255, 255, 0, 255); //8비트로 한 성분을 나타낸다. 즉 [0, 255]
        //Gizmos.DrawWireSphere(this.transform.position, 1.2f);
    }
    //MonoBehaviur에 준비된 다음과 같은 이벤트 함수가 있다.
    //선택 시 기즈모 렌더
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 1f);
        Gizmos.DrawWireCube(this.transform.position, this.transform.lossyScale * 1.1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
