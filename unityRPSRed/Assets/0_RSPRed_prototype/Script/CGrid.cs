using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum SCROLL
{
    DISABLE_SCROLL = 0, //스크롤 불능
    ENABLE_SCROLL,      //스크롤 가능
}

public class CGrid : MonoBehaviour
{
    [SerializeField]    //<-- 유니티 에디터 상에 노출
    GameObject[] mGameObjects = null;   //준비된 각 섹션( 저글링의 대상 )

    [SerializeField]
    float mScalarSpeed = 0.0f;  //스크롤 속도

    [SerializeField]
    float mEdge = 0.0f; //하한선

    List<Vector3> mOriginPositionis = new List<Vector3>();  //각 섹션들의 원래 위치를 기억


    SCROLL mIsScroll = SCROLL.DISABLE_SCROLL;


    // Start is called before the first frame update
    void Start()
    {
        //섹션의 초기 값을 기억하게 한다.
        mOriginPositionis.Clear();

        foreach (var t in mGameObjects)
        {
            //Vector3는 struct므로 값복사
            mOriginPositionis.Add(t.transform.position);
        }

        mIsScroll = SCROLL.ENABLE_SCROLL;
    }

    // Update is called once per frame
    void Update()
    {
        if (SCROLL.ENABLE_SCROLL == mIsScroll)
        {
            for (int ti = 0;  ti < mGameObjects.Length; ++ti)
        {
            var t = mGameObjects[ti];

            //Time.deltaTime 프레임 시간 <-- 게임 루프의 한 프레임에 걸리는 시간
            //Vector3구조체
            t.transform.Translate((-1f) * Vector3.forward * mScalarSpeed * Time.deltaTime, Space.Self);

            if (t.transform.position.z <= mEdge)
            {
                //스크롤 오차 보정
                float tDiffY = t.transform.position.z - mEdge;

                //섹션의 개수를 변경해도 소스코드 수정이 없도록
                // mOriginPositionis.Count - 1로 표현
                t.transform.position = mOriginPositionis[mOriginPositionis.Count - 1] + new Vector3(0.0f, 0.0f, tDiffY);
            }

        }
        }
    }


    public void DoStopScroll()
    {
        //해당 구현은 방법이 여러가지겠다.
        //이를테면, mScarlarSpeed를 0으로 설정해도 된다.
        //하지만, Update함수 정의부에 코드를 연산안하는 경우가 제일 빠르겠다.
        //그래서 판단 제어구조를 이용한다.
        //그래서 열거형 변수를 사용한다.

        mIsScroll = SCROLL.DISABLE_SCROLL;
    }
}
