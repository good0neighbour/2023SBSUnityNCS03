using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFollowCam : MonoBehaviour
{
    [SerializeField]
    GameObject mLookAtObj = null;


    [SerializeField]
    float mDistance = 1.5f; //후방거리
    [SerializeField]
    float mHeight = 1.5f;   //상방거리

    [SerializeField]
    float mDampTrace = 10.0f;    //


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //게임 루피에 따라,. 게임 오브젝트의 렌더링 데이터의 갱신을 하는 함수
    //시스템의 성능에 따라 호출 횟수가 변경된다.
    void Update()
    {
        
    }

    //FixedUpdate
    //물리 기반의 갱신 함수
    //일정 간격으로 호출되므로 호출횟수가 일정하다

    //모든 Update가 호출된 이후에 호출되는 갱신함수다.
    //카메라 워크는 여기서 만들 것이다.
    //왜냐하면 카메라에 렌더링 결과물을 담을 것이기 때문이다.
    private void LateUpdate()
    {
        //오프셋: 기준점에서 어느 만큼 떨어져 있는지에 대한 변위
        Vector3 tOffset = (-1.0f) * mLookAtObj.transform.forward * mDistance + Vector3.up * mHeight;
        Vector3 tPosition = mLookAtObj.transform.position + tOffset;
        //가중치
        float tWeight = mDampTrace * Time.deltaTime;

        //선형보간
        this.transform.position = Vector3.Lerp(
            this.transform.position,    //0
            tPosition,                  //1
            tWeight);                   //가중치


        //바라보는 지점 설정
        this.transform.LookAt(mLookAtObj.transform.position);
    }
}
