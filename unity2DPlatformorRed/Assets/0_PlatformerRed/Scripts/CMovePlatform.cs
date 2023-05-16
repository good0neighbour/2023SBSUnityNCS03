using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMovePlatform : MonoBehaviour
{
    [SerializeField]
    GameObject[] mGO = null;    //위치를 참고할 게임오브젝트 N개

    //위치정보를 담아둘 가변배열
    List<Vector2> mPositions = new List<Vector2>();

    [SerializeField]    //<--유니티 에디터 상에서 편집가능하게 설계
    float mTime = 0.0f; //순찰에 걸리는 시간

    //가중치
    float mWeight = 0.0f;
    float mDir = -1.0f;

    float mScalarSpeed = 0.0f;  //속력

    // Start is called before the first frame update
    void Start()
    {
        foreach (var t in mGO)
        {
            mPositions.Add(t.transform.position);
        }

        //      속도 = 거리 / 시간

        //거리 구하기
        float tD = (mPositions[1] - mPositions[0]).magnitude;
        //(목적지점 - 시작지점) = 임의의 크기의 임의의 방향의 벡터
        //해당 벡터의 크기를 구했다.
        //(목적지점이 시작지점보다 크다고 가정)

        Debug.Log($"tD: {tD.ToString()}");

        //'속도(그 중에서 속력)'를 구한다
        if (mTime != 0.0f)
        {
            mScalarSpeed = tD / mTime;
        }
        //처음에는 왼쪽방향으로 이동한다고 가정
        mDir = -1.0f * mScalarSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //경계에 닿으면 방향 바꾸기( 선형보간을 사용했음을 고려 )
        if (1.0f <= mWeight)
        {
            mDir = -1.0f * mScalarSpeed;    //오른쪽 경계라면 왼쪽 방향으로
        }
        else if (0.0f >= mWeight)
        {
            mDir = 1.0f * mScalarSpeed;     //왼쪽 경계라면 오늘쪽 방향으로
        }


        //가중치 갱신
        mWeight = mWeight + mDir * Time.deltaTime;  //시간기반

        Vector2 tPos = Vector2.Lerp(mPositions[0], mPositions[1], mWeight);
        //위치를 직접 지정
        this.transform.position = tPos;
    }
}
