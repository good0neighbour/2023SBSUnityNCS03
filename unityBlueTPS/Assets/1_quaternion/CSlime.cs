using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSlime : MonoBehaviour
{
    //embedded enum
    //해당 클래스 내에 포함해서 정의함
    enum STATE
    {
        WITH_NONE = 0,  //회전이 없는 원래 상태

        WITH_ELUER,     //오일러 각을 이용한 회전 상태
        WITH_QUATERNION //사원수를 이용한 회전 상태
    }

    [SerializeField]
    STATE mState = STATE.WITH_NONE;

    //사원수를 이용한 회전의 처음 상태와 끝 상태
    Quaternion mStart = Quaternion.identity;   //단위원 사원수로 초기화( 회전이 없음 )
    Quaternion mEnd = Quaternion.identity;   //단위원 사원수로 초기화( 회전이 없음 )

    float mInterpolatePoint = 0f;   //보간의 매개변수 t, 처음 값은 0

    //유니티에 Transform의 회전은 기본적으로 사원수를 이용하도록 만들어져있다.
    //<-- 그러므로 오일러 각에 의한 회전은 쌩으로 만들어야 한다.
    //오일러 각에 의한 회전을 위함
    Matrix4x4 mMatRot = Matrix4x4.identity; //단위행렬로 초기화
    MeshFilter mMeshFilter = null;          //메쉬를 관리하는 컴포넌트( 메쉬: 삼각형의 집합, 정점의 집합 )
    Vector3[] mOriginVertices;              //원래 정점
    Vector3[] mNewVertices;                 //변환이 적용된 새로운 정점


    private void OnGUI()
    {
        //처음 상태로 만들기
        if (GUI.Button(new Rect(0f, 300f, 100f, 100f), "Origin"))
        {
            mStart = Quaternion.identity;
            mEnd = Quaternion.identity;

            //해당 게임 오브젝트의 회전상태는 처음상태다.
            this.transform.rotation = mStart;

            mInterpolatePoint = 0f;

            mState = STATE.WITH_NONE;
        }


        if (GUI.Button(new Rect(0f, 0f, 100f, 100f), "Quaternion"))
        {
            //z, x, y 순서로 사원수 곱셈
            mEnd = Quaternion.Euler(0f, 0f, 90f) * Quaternion.Euler(90f, 0f, 0f) * Quaternion.Euler(0f, 90f, 0f);

            mState = STATE.WITH_QUATERNION;
        }

        if (GUI.Button(new Rect(100f, 0f, 100f, 100f), "Transform.Rotate"))
        {
            //transform에서 제공하는 Rotate는 사원수 기반으로 만들어져 있다.
            //z, x, y
            this.transform.Rotate(0f, 0f, 90f);
            this.transform.Rotate(90f, 0f, 0f);
            this.transform.Rotate(0f, 90f, 0f);

            mState = STATE.WITH_NONE;
        }

        //이 경우는 오일러 각에 의한 회전의 결과가 나온다
        //z, x, y
        if (GUI.Button(new Rect(100f, 100f, 150f, 100f), "______Quaternion.Euler"))
        {
            //이 회전은 사원수에 의한 결과가 아니다.
            mEnd = Quaternion.Euler(90f, 90f, 90f);

            mState = STATE.WITH_ELUER;
        }

        //회전 행렬에 의한 회전
        if (GUI.Button(new Rect(0f, 100f, 100f, 100f), "EULER with MATRIX"))
        {
            //w = TRSv

            //z축 회전 행렬
            Matrix4x4 tM = Matrix4x4.identity;
            tM.SetTRS(Vector3.zero, Quaternion.Euler(0f, 0f, 90f), Vector3.one);

            mMatRot = tM * mMatRot; //행렬끼리의 곱셈

            //x축 회전 행렬
            tM = Matrix4x4.identity;
            tM.SetTRS(Vector3.zero, Quaternion.Euler(90f, 0f, 0f), Vector3.one);

            mMatRot = tM * mMatRot; //행렬끼리의 곱셈

            //y축 회전 행렬
            tM = Matrix4x4.identity;
            tM.SetTRS(Vector3.zero, Quaternion.Euler(0f, 90f, 0f), Vector3.one);

            mMatRot = tM * mMatRot; //행렬끼리의 곱셈

            //MeshFillter컴포넌트에 접근
            mMeshFilter = GetComponentInChildren<MeshFilter>();
            mOriginVertices = mMeshFilter.mesh.vertices;    //메쉬의 정점에 접근

            //변환을 가하기 위해 새로운 정점목록을 만들고 복사
            mNewVertices = new Vector3[mOriginVertices.Length];

            int ti = 0;
            while (ti < mOriginVertices.Length)
            {
                //정점의 위치 반환
                mNewVertices[ti] = mMatRot.MultiplyPoint3x4(mOriginVertices[ti]);

                ++ti;
            }

            //변환이 적용된 정점목록을 적용
            mMeshFilter.mesh.vertices = mNewVertices;


            mState = STATE.WITH_NONE;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        mStart = Quaternion.identity;
        mEnd = Quaternion.identity;

        //해당 게임 오브젝트의 회전상태는 처음상태다.
        this.transform.rotation = mStart;

        mInterpolatePoint = 0f;

        mState = STATE.WITH_NONE;

    }

    // Update is called once per frame
    void Update()
    {
        if (STATE.WITH_NONE != mState)
        {
            //Slerp: Sphere Linear interpolation 구면 선형 보간
            this.transform.rotation = Quaternion.Slerp(mStart, mEnd, mInterpolatePoint);
            /*
                Lerp Linear Interpolation
                선형보간
                직선의 방정식(일차함수)을 사용하여 임의의 두 점 사이의 한 점을 구한다.
                두 값을 알 때 그 사이의 근사치를 구하기 위한 방법이다.

                Slerp Sphere Linear Interpolation
                구면 선형 보간

                선형보간의 식으로 원의 둘레 중 일부인 호를 사용하여 표현하는 것이다
                원의 호의 개념이 들어가므로
                각도가 수식에 포함된다.

                원의 호는 곡선이므로
                기울기가 변한다
                그러므로 좀더 부드러운?(일반적인 선형보간보다는 좀더 다이나믹한) 변화를 표현가능하다


                구면선형보간은 다음 식을 사용하여 구현된다

                P = ( sin( (1 - t)Theta) * P0 + sin(t * Theta) * P1 ) / sinTheta

                    <-- 각도에 관한 수식
                    <-- [0, 1]로의 정규화를 위해 sin 적용

            */


            mInterpolatePoint += Time.deltaTime;
        }
    }
}
