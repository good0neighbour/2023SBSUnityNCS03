using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuDeformMesh : MonoBehaviour
{
    MeshFilter mMeshFilter = null;

    //원래 메쉬(정점의 집합)를 변형하여 새로운 메쉬(정점의 집합)을 만들고
    //이를 메쉬 필터에 설정하여
    //'메쉬 변형(정점의 위치 이동)'을 표현할 것이다
    Vector3[] mOriginVerts = null;  //게임오브젝트의 메쉬를 얻어온 장점의 정보
    Vector3[] mNewVerts = null;     //변형을 가해 새롭게 만들어진 메쉬의 정점의 정보

    Matrix4x4 mMatrix = Matrix4x4.identity; //이동변환을 적용하기 위한 변환행렬


    //힘을 발산하는 게임 오브젝트
    [SerializeField]
    GameObject mpForceObj = null;


    private void OnGUI()
    {
        //임의의 정점의 이동변환을 '간단하게 테스트'해본다.
        if (GUI.Button(new Rect(0f, 0f, 100f, 100f), "Test Translate\nAnyVertices"))
        {
            mMeshFilter = this.GetComponent<MeshFilter>();

            mOriginVerts = mMeshFilter.mesh.vertices;//메쉬필터로부터 정점의 정보를 얻는다

            //기존 정점의 개수만큼 새로운 정점의 개수를 확보한다.
            mNewVerts = new Vector3[mOriginVerts.Length];

            //임의의 조건을 만족하는 정점만 변형해본다.

            Matrix4x4 tM = Matrix4x4.identity;
            //(1,0,0)offset으로 이동변환 행렬
            tM.SetTRS(Vector3.right, Quaternion.identity, Vector3.one);

            for (int ti = 0; ti < mOriginVerts.Length; ++ti)
            {
                if (mOriginVerts[ti].z >= 0.5f)
                {
                    //이동변환
                    mMatrix = tM;
                }
                else
                {
                    //단위행렬
                    mMatrix = Matrix4x4.identity;
                }
                //행벡터 기준 행렬의 곱셈
                mNewVerts[ti] = mMatrix.MultiplyPoint3x4(mOriginVerts[ti]);
            }
            //새롭게 값이 구축된 새로운 정점 데이터를 메쉬에 설정
            mMeshFilter.mesh.vertices = mNewVerts;
        }

        //force를 적용하여 변형
        if (GUI.Button(new Rect(200f, 0f, 100f, 100f), "Apply Force"))
        {
            mMeshFilter = this.GetComponent<MeshFilter>();

            mOriginVerts = mMeshFilter.mesh.vertices;
            mNewVerts = new Vector3[mOriginVerts.Length];

            Matrix4x4 tM = Matrix4x4.identity;

            for (int ti = 0; ti < mOriginVerts.Length; ++ti)
            {
                //---- 임의의 정점에 적용할 힘을 구함 ----
                //임의의 크기의 방향의 벡터 = 목적지점 - 시작지점
                Vector3 tA = mpForceObj.transform.position;     //시작지점: force 오브젝트의 중심점 위치 정보
                Vector3 tB = mOriginVerts[ti];                  //목적지점: 메쉬의 임의의 정점

                //force object 중심점위치와 메쉬의 임의의 정점 사이의 거리
                float tDistance = Vector3.Distance(tB, tA);
                Vector3 tVectorTrans = tB - tA; //임의의 정점에 미치는 force발산(중심점--->임의의 정점) 벡터

                float tRadius = mpForceObj.gameObject.GetComponent<SphereCollider>().radius;
                float tPower = tRadius * 2f * mpForceObj.gameObject.transform.lossyScale.x;
                float tScalar = (1f / tVectorTrans.magnitude) * tPower;//힘을 받는 것을 반비례시킴, 즉 감쇄
                //<--멀리 떨어져 있을 수록 힘을 덜 받음

                //-- 임의의 정점에 힘을 적용 --
                tM.SetTRS(tVectorTrans.normalized * tScalar, Quaternion.identity, Vector3.one);
                mMatrix = tM;
                mNewVerts[ti] = mMatrix.MultiplyPoint3x4(mOriginVerts[ti]);
            }

            //새롭게 값이 구축된 새로운 정점 데이터를 메쉬에 설정
            mMeshFilter.mesh.vertices = mNewVerts;
        }

        //force를 적용하여 변형
        if (GUI.Button(new Rect(300f, 0f, 100f, 100f), "Apply Force Back"))
        {
            mMeshFilter = this.GetComponent<MeshFilter>();

            mOriginVerts = mMeshFilter.mesh.vertices;
            mNewVerts = new Vector3[mOriginVerts.Length];

            Matrix4x4 tM = Matrix4x4.identity;

            for (int ti = 0; ti < mOriginVerts.Length; ++ti)
            {
                //---- 임의의 정점에 적용할 힘을 구함 ----
                //임의의 크기의 방향의 벡터 = 목적지점 - 시작지점
                Vector3 tA = mpForceObj.transform.position;     //시작지점: force 오브젝트의 중심점 위치 정보
                Vector3 tB = mOriginVerts[ti];                  //목적지점: 메쉬의 임의의 정점

                //force object 중심점위치와 메쉬의 임의의 정점 사이의 거리
                float tDistance = Vector3.Distance(tB, tA);
                Vector3 tVectorTrans = tA - tB; //임의의 정점에 미치는 force수렴(중심점--->임의의 정점) 벡터

                float tRadius = mpForceObj.gameObject.GetComponent<SphereCollider>().radius;
                float tPower = tRadius * 2f * mpForceObj.gameObject.transform.lossyScale.x;
                float tScalar = (1f / tVectorTrans.magnitude) * tPower;//힘을 받는 것을 반비례시킴, 즉 감쇄
                //<--멀리 떨어져 있을 수록 힘을 덜 받음

                //-- 임의의 정점에 힘을 적용 --
                tM.SetTRS(tVectorTrans.normalized * tScalar, Quaternion.identity, Vector3.one);
                mMatrix = tM;
                mNewVerts[ti] = mMatrix.MultiplyPoint3x4(mOriginVerts[ti]);
            }

            //새롭게 값이 구축된 새로운 정점 데이터를 메쉬에 설정
            mMeshFilter.mesh.vertices = mNewVerts;
        }
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
