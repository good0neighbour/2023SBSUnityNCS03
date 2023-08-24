using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



//MeshRenderer에서만 작동 확인
//Mesh를 잘라내는 기능을 가진 클래스 
public class MeshCut
{
    //메쉬 절단을 위한 평면 정보 클래스 
    static Plane mPlane;        //<-- 평면의 방정식 P dot N = d

    //'메쉬 절단 적용의 대상'이 될 메쉬와 변환 정보 
    static Mesh mVictimMesh;            //메쉬 정보 
    static Transform mVictimTransform;     //변환 정보

    //평면의 올바른 쪽에 있는지 여부 정보 <-- 임의의 삼각형의 세 점에 대해 판단하므로 세개이다.
    static bool[] mIsCorrectSides = new bool[3];

    //---------- 중간 과정을 위한 수집용 데이터 ----------
    //의도하는 최종결과(mesh cutting)을 만들기 위해 필요한 재료로서의 데이터들을 수집한다 라는 의미이다

    //-----------left-------------
    //왼쪽 서브메쉬의 인덱스정보 목록 
    static List<int>[] left_Gather_subIndices = new List<int>[] { new List<int>(), new List<int>() };

    //'왼쪽 메쉬 를 구성하는 중간과정'에서 사용될
    //      정점의 위치목록,
    //      uv목록,
    //      normal 목록
    //
    //기하구조물 정보 두 개
    static List<Vector3>[] left_Gather_added_Points = new List<Vector3>[] { new List<Vector3>(), new List<Vector3>() };
    static List<Vector2>[] left_Gater_added_uvs = new List<Vector2>[] { new List<Vector2>(), new List<Vector2>() };
    static List<Vector3>[] left_Gater_added_normals = new List<Vector3>[] { new List<Vector3>(), new List<Vector3>() };

    //-----------right-------------
    //오른쪽 서브메쉬의 인덱스정보 목록 
    static List<int>[] right_Gather_subIndices = new List<int>[] { new List<int>(), new List<int>() };

    //'오른쪽 메쉬 를 구성하는 중간과정'에서 사용될
    //      정점의 위치목록,
    //      uv목록,
    //      normal 목록
    //
    //기하구조물 정보 두 개
    static List<Vector3>[] right_Gather_added_Points = new List<Vector3>[] { new List<Vector3>(), new List<Vector3>() };
    static List<Vector2>[] right_Gater_added_uvs = new List<Vector2>[] { new List<Vector2>(), new List<Vector2>() };
    static List<Vector3>[] right_Gater_added_normals = new List<Vector3>[] { new List<Vector3>(), new List<Vector3>() };


    //------- 면(삼각형) 절단 동작을 위해 필요한 데이터들 ---------
    //위치, uv, normal
    static Vector3 mLtPoint_0 = Vector3.zero;
    static Vector3 mLtPoint_1 = Vector3.zero;
    static Vector3 mRtPoint_0 = Vector3.zero;
    static Vector3 mRtPoint_1 = Vector3.zero;

    static Vector2 mLtUV_0 = Vector2.zero;
    static Vector2 mLtUV_1 = Vector2.zero;
    static Vector2 mRtUV_0 = Vector2.zero;
    static Vector2 mRtUV_1 = Vector2.zero;

    static Vector3 mLtNormal_0 = Vector3.zero;
    static Vector3 mLtNormal_1 = Vector3.zero;
    static Vector3 mRtNormal_0 = Vector3.zero;
    static Vector3 mRtNormal_1 = Vector3.zero;



    //-----------최종적으로 만들어지는 데이터들--------------
    //left는 원래 것을 이용
    //right는 새로 만든 메쉬

    //--왼쪽 메쉬 를 위한 데이터들--
    //인덱스, 정점의 위치, 법선정보, uv정보
    static List<int>[] mLtFinalSubIndices = new List<int>[]{ new List<int>(), new List<int>() };

    static List<Vector3> left_Final_vertices = new List<Vector3>();
    static List<Vector3> left_Final_normals = new List<Vector3>();
    static List<Vector2> left_Final_uvs = new List<Vector2>();


    //--오른쪽 메쉬 를 위한 데이터들--
    //인덱스, 정점의 위치, 법선정보, uv정보
    static List<int>[] mRtFinalSubIndices = new List<int>[] { new List<int>(), new List<int>() };

    static List<Vector3> right_Final_vertices = new List<Vector3>();
    static List<Vector3> right_Final_normals = new List<Vector3>();
    static List<Vector2> right_Final_uvs = new List<Vector2>();



    //절단면을 위한 정점들
    static List<Vector3> mCreatedVertexPoints = new List<Vector3>();

    //수집용 데이터들을 리셋
    static void ResetGatheringValues()
    {
        left_Gather_subIndices[0].Clear();
        left_Gather_subIndices[1].Clear();
        left_Gather_added_Points[0].Clear();
        left_Gather_added_Points[1].Clear();
        left_Gater_added_uvs[0].Clear();
        left_Gater_added_uvs[1].Clear();
        left_Gater_added_normals[0].Clear();
        left_Gater_added_normals[1].Clear();

        right_Gather_subIndices[0].Clear();
        right_Gather_subIndices[1].Clear();
        right_Gather_added_Points[0].Clear();
        right_Gather_added_Points[1].Clear();
        right_Gater_added_uvs[0].Clear();
        right_Gater_added_uvs[1].Clear();
        right_Gater_added_normals[0].Clear();
        right_Gater_added_normals[1].Clear();

        mCreatedVertexPoints.Clear();
    }
    //면 절단을 위한 임시변수들을 리셋
    static void ResetFaceCuttingTemps()
    {
        mLtPoint_0 = Vector3.zero;
        mLtPoint_1 = Vector3.zero;
        mRtPoint_0 = Vector3.zero;
        mRtPoint_1 = Vector3.zero;

        mLtUV_0 = Vector2.zero;
        mLtUV_1 = Vector2.zero;
        mRtUV_0 = Vector2.zero;
        mRtUV_1 = Vector2.zero;

        mLtNormal_0 = Vector3.zero;
        mLtNormal_1 = Vector3.zero;
        mRtNormal_0 = Vector3.zero;
        mRtNormal_1 = Vector3.zero;
    }

    //최종 데이터 리셋
    static void ResetFinalArrays()
    {
        mLtFinalSubIndices[0].Clear();
        mLtFinalSubIndices[1].Clear();
        left_Final_vertices.Clear();
        left_Final_normals.Clear();
        left_Final_uvs.Clear();


        mRtFinalSubIndices[0].Clear();
        mRtFinalSubIndices[1].Clear();
        right_Final_vertices.Clear();
        right_Final_normals.Clear();
        right_Final_uvs.Clear();
    }

    //tVictim: 원본 게임오브젝트, 절단의 대상이 된다
    //tAnchorPoint: 평면위에 임의의 한점
    //tNormalDir: 평면의 법선벡터
    //          P dot N = d
    //tCapMaterial: 절단면에 적용될 머티리얼 
    public static GameObject[] Cut(GameObject tVictim, Vector3 tAnchorPoint, Vector3 tNormalDir, Material tCapMaterial)
    {
        mVictimTransform = tVictim.transform;

        //Transform:                Local ---> World
        //InverseTransform:     World ---> Local
        //      <-- 임의의 변환이 가해지지 않은 상태라면 정점의 위치는 로컬좌표계 기준으로 만들어져 있다.
        //          그러므로 로컬좌표계 기준의 위치값으로 평면의 방정식을 변환하여 정점과 수준을 맞춘 것이다.
        mPlane = new Plane(tVictim.transform.InverseTransformDirection(-tNormalDir), tVictim.transform.InverseTransformPoint(tAnchorPoint)) ;

        mVictimMesh = tVictim.GetComponent<MeshFilter>().mesh;
        mVictimMesh.subMeshCount = 2;//<--2개의 서브메쉬를 이용하기 위해 설정

        //수집용 데이터를 초기화
        ResetGatheringValues();

        //삼각형의 정점의 인덱스 임시 변수
        int p_0 = 0;
        int p_1 = 0;
        int p_2 = 0;

        int sub = 0;//서브메쉬인지 여부
        int[] indices = mVictimMesh.triangles;               //메인메쉬 인덱스 목록
        int[] secondIndices = mVictimMesh.GetIndices(1);     //서브메쉬 인덱스 목록

        //인덱스 갯수만큼 반복하면서 임의의 정점의 위치관계를 판단한다
        for(int ti = 0; ti<indices.Length; ti+=3)
        {
            //연속된 세 개의 정점 인덱스 단위로 정점 3개의 데이터를 얻는다 
            p_0 = indices[ti];
            p_1 = indices[ti + 1];
            p_2 = indices[ti + 2];

            //삼각형의 임의의 정점이 평면의 올바른 쪽에 있는지 여부 검사
            mIsCorrectSides[0] = mPlane.GetSide(mVictimMesh.vertices[p_0]);
            mIsCorrectSides[1] = mPlane.GetSide(mVictimMesh.vertices[p_1]);
            mIsCorrectSides[2] = mPlane.GetSide(mVictimMesh.vertices[p_2]);

            //Main Mesh인지 SubMesh인지 판단
            sub = 0;//<--Main과 Sub 를 모두 나타내는 변수이다. 0: main, 1: sub
            for (int k = 0; k < secondIndices.Length; k++)
            {
                //이렇다면, Sub이다. 
                if (secondIndices[k] == p_0)
                {
                    sub = 1;
                    break;
                }
            }

            //임의의 삼각형의 세 점이 모두 올바른 쪽에 있거나,
            //임의의 삼각형의 세 점이 모두 올바르지 않은 쪽에 있다면 
            //<-- Cut의 대상이 아니다.
            if (mIsCorrectSides[0] == mIsCorrectSides[1] && mIsCorrectSides[0] == mIsCorrectSides[2])
            {
                //모두 올바른 쪽에 있는 경우
                if (mIsCorrectSides[0])
                {
                    //left sub에 속하게 된다
                    left_Gather_subIndices[sub].Add(p_0);
                    left_Gather_subIndices[sub].Add(p_1);
                    left_Gather_subIndices[sub].Add(p_2);
                }
                else//모두 올바르지 않은 쪽에 있는 경우 
                {
                    //right sub에 속하게 된다
                    right_Gather_subIndices[sub].Add(p_0);
                    right_Gather_subIndices[sub].Add(p_1);
                    right_Gather_subIndices[sub].Add(p_2);
                }
            }
            else//그렇지 않다면 <--Cut의 대상이다.
            {
                //면 절단을 위한 임시변수들 초기화 
                ResetFaceCuttingTemps();

                //face cut
                Cut_this_Face(sub, p_0, p_1, p_2);
            }
        }


        //여기까지 오면, 절단을 위한 중간용 수집 데이터는 완성이 되었다.
        //이제 최종 결과물을 만든다

        //최종결과물을 위한 데이터 초기화 
        ResetFinalArrays();


        //i)원래 데이터로부터 만들어낼 부분들은 만든다
        //          왼쪽 메쉬 최종데이터를 만든다
        //          오른쪽 메쉬 최종데이터를 만든다
        //ii)새롭게 만들어낼 부분들을 만든다
        //          왼쪽 메쉬 최종데이터를 만든다
        //          오른쪽 메쉬 최종데이터를 만든다
        //iii)절단면을 채운다
        SetFinalArrays_withOriginals();//<-----원래 데이터로부터 만들어낼 부분들은 만든다
        AddNewTriangles_toFinalArrays();//<-----새롭게 만들어낼 부분들을 만든다
        MakeCaps();

        //유니티에서 left Mesh로 다루기 위한 처리를 해준다
        Mesh tLtHalfMesh = new Mesh();
        tLtHalfMesh.name = "split mesh left";

                tLtHalfMesh.vertices = left_Final_vertices.ToArray();//List ---> Array
                tLtHalfMesh.subMeshCount = 2;//<--sub mesh count는 2개 

                //topology 위상구조: 정점들의 집합을 어떤 도형으로 해석할 것이냐에 대한 옵션 
                tLtHalfMesh.SetIndices(mLtFinalSubIndices[0].ToArray(), MeshTopology.Triangles, 0);
                tLtHalfMesh.SetIndices(mLtFinalSubIndices[1].ToArray(), MeshTopology.Triangles, 1);

                tLtHalfMesh.normals = left_Final_normals.ToArray();
                tLtHalfMesh.uv = left_Final_uvs.ToArray() ;


        //유니티에서 right Mesh로 다루기 위한 처리를 해준다
        Mesh tRtHalfMesh = new Mesh();
        tRtHalfMesh.name = "split mesh right";

                tRtHalfMesh.vertices = right_Final_vertices.ToArray();//List ---> Array
                tRtHalfMesh.subMeshCount = 2;//<--sub mesh count는 2개 

                //topology 위상구조: 정점들의 집합을 어떤 도형으로 해석할 것이냐에 대한 옵션 
                tRtHalfMesh.SetIndices(mRtFinalSubIndices[0].ToArray(), MeshTopology.Triangles, 0);
                tRtHalfMesh.SetIndices(mRtFinalSubIndices[1].ToArray(), MeshTopology.Triangles, 1);

                tRtHalfMesh.normals = right_Final_normals.ToArray();
                tRtHalfMesh.uv = right_Final_uvs.ToArray();




        //유니티에서 왼쪽 게임오브젝트 ,오른쪽 게임오브젝트로 다루기 위한 처리를 한다

        //왼쪽 게임오브젝트를 만든다. 
        //<--원본GameObject를 이용하여 만든다.
        GameObject leftSideObject = null;
        tVictim.name = "leftSideObject";
        tVictim.GetComponent<MeshFilter>().mesh = tLtHalfMesh;//<-- 메쉬 데이터를 게임오브젝트에 설정
        
        leftSideObject = tVictim;//<--왼쪽 게임오브젝트는 원래 게임오브젝트를 가지고 만든다. 

        //오른쪽 게임오브젝트를 만든다
        //<--새롭게 만든다.
        GameObject rightSideObject = null;
        rightSideObject = new GameObject("rightSideObject", typeof(MeshFilter), typeof(MeshRenderer));
        rightSideObject.transform.position = mVictimTransform.position; //원래 게임오브젝트의 변환정보 설정
        rightSideObject.transform.rotation = mVictimTransform.rotation;
        rightSideObject.GetComponent<MeshFilter>().mesh = tRtHalfMesh;//<-- 메쉬 데이터를 게임오브젝트에 설정

        //머티리얼을 설정한다.
        Material[] mats = new Material[] { tVictim.GetComponent<MeshRenderer>().material, tCapMaterial };
        //<--원래 것, 절단면을 위한 머티리얼 

        leftSideObject.GetComponent<MeshRenderer>().materials = mats;
        rightSideObject.GetComponent<MeshRenderer>().materials = mats;

        return new GameObject[] { leftSideObject,rightSideObject};
    }

    //임의의 면(삼각형) 절단 함수 
    static void Cut_this_Face(int tSubMesh, int tIndex_0, int tIndex_1, int tIndex_2)
    {
        int p = tIndex_0;
        for (int side = 0; side < 3; side++)
        {
            switch (side)
            {
                case 0:
                    p = tIndex_0;
                    break;
                case 1:
                    p = tIndex_1;
                    break;
                case 2:
                    p = tIndex_2;
                    break;
            }
            //삼각형의 임의의 정점이 올바른 면에 있다면 , 즉 왼편에 있다면 
            if (mIsCorrectSides[side])
            {
                if (mLtPoint_0 == Vector3.zero)
                {
                    //leftPoint1이 (0,0,0) 이라면 임의의 정점 위치 정보로 설정 
                    mLtPoint_0 = mVictimMesh.vertices[p];
                    mLtPoint_1 = mLtPoint_0;
                    mLtUV_0 = mVictimMesh.uv[p];
                    mLtUV_1 = mLtUV_0;
                    mLtNormal_0 = mVictimMesh.normals[p];
                    mLtNormal_1 = mLtNormal_0;
                }
                else
                {                    
                    mLtPoint_1 = mVictimMesh.vertices[p];
                    mLtUV_1 = mVictimMesh.uv[p];
                    mLtNormal_1 = mVictimMesh.normals[p];
                }
            }
            else//임의의 정점이 올바르지 않은 편에 있다면, 즉 오른편에 있다면
            {
                if (mRtPoint_0 == Vector3.zero)
                {
                    //rightPoint0이 (0,0,0) 이라면 임의의 정점 위치 정보로 설정 
                    mRtPoint_0 = mVictimMesh.vertices[p];
                    mRtPoint_1 = mRtPoint_0;
                    mRtUV_0 = mVictimMesh.uv[p];
                    mRtUV_1 = mRtUV_0;
                    mRtNormal_0 = mVictimMesh.normals[p];
                    mRtNormal_1 = mRtNormal_0;
                }
                else
                {
                    mRtPoint_1 = mVictimMesh.vertices[p];
                    mRtUV_1 = mVictimMesh.uv[p];
                    mRtNormal_1 = mVictimMesh.normals[p];
                }
            }
        }//for


        //반복제어구조를 지나왔으므로 , 이제 이 세개의 인덱스에 대해 처리되어 
        //mLt0, mLt1, mRt0, mRt1이 준비되어 있다. 

        //이제 이렇게 준비된 데이터를 가지고, 평면과의 교점들을 구하자.
        float tDistance = 0.0f;
        float tNormalizedDistance = 0.0f;

        mPlane.Raycast(new Ray(mLtPoint_0, (mRtPoint_0 - mLtPoint_0).normalized), out tDistance);
        //<--평면과 반직선의 충돌검토, 이를 통해서 충돌지점까지의 거리를 구한다
        tNormalizedDistance = tDistance / (mRtPoint_0 - mLtPoint_0).magnitude;
        // 충돌지점까지의 거리/ mRt0과 mLt0사이의 거리 = 충돌지점의 비율값 

        Vector3 newVertex1 = Vector3.Lerp(mLtPoint_0, mRtPoint_0, tNormalizedDistance);
        //선형보간 함수의 가중치 부분에 비율값을 넣어 두 지점(위치)의 보간된 위치<--교점 을 구한다.
        Vector2 newUv1 = Vector2.Lerp(mLtUV_0, mRtUV_0, tNormalizedDistance);
        Vector3 newNormal1 = Vector3.Lerp(mLtNormal_0, mRtNormal_0, tNormalizedDistance);
        mCreatedVertexPoints.Add(newVertex1);//절단면을 위한 정점




        mPlane.Raycast(new Ray(mLtPoint_1, (mRtPoint_1 - mLtPoint_1).normalized), out tDistance);
        //<--평면과 반직선의 충돌검토, 이를 통해서 충돌지점까지의 거리를 구한다
        tNormalizedDistance = tDistance / (mRtPoint_1 - mLtPoint_1).magnitude;
        // 충돌지점까지의 거리/ mRt0과 mLt0사이의 거리 = 충돌지점의 비율값 

        Vector3 newVertex2 = Vector3.Lerp(mLtPoint_1, mRtPoint_1, tNormalizedDistance);
        //선형보간 함수의 가중치 부분에 비율값을 넣어 두 지점(위치)의 보간된 위치<--교점 을 구한다.
        Vector2 newUv2 = Vector2.Lerp(mLtUV_1, mRtUV_1, tNormalizedDistance);
        Vector3 newNormal2 = Vector3.Lerp(mLtNormal_1, mRtNormal_1, tNormalizedDistance);
        mCreatedVertexPoints.Add(newVertex2);//절단면을 위한 정점

        
        //왼쪽 첫번째 삼각형
        Add_Left_triangle(tSubMesh, newNormal1, new Vector3[] {mLtPoint_0, newVertex1, newVertex2 },
                                                new Vector2[] { mLtUV_0, newUv1, newUv2 },
                                                new Vector3[] { mLtNormal_0, newNormal1, newNormal2 });
        //왼쪽 두번째 삼각형
        Add_Left_triangle(tSubMesh, newNormal2, new Vector3[] { mLtPoint_0, mLtPoint_1, newVertex2 },
                                                new Vector2[] { mLtUV_0, mLtUV_1, newUv2 },
                                                new Vector3[] { mLtNormal_0, mLtNormal_1, newNormal2 });

        //오른쪽 첫번째 삼각형
        Add_Right_triangle(tSubMesh, newNormal1, new Vector3[] { mRtPoint_0, newVertex1, newVertex2 },
                                                new Vector2[] { mRtUV_0, newUv1, newUv2 },
                                                new Vector3[] { mRtNormal_0, newNormal1, newNormal2 });
        //오른쪽 두번째 삼각형
        Add_Right_triangle(tSubMesh, newNormal2, new Vector3[] { mRtPoint_0, mRtPoint_1, newVertex2 },
                                                new Vector2[] { mRtUV_0, mRtUV_1, newUv2 },
                                                new Vector3[] { mRtNormal_0, mRtNormal_1, newNormal2 });



    }



    //왼쪽 메쉬를 위한 인덱스 정보 수집
    static void Add_Left_triangle(int tSubMesh, Vector3 faceNormal, Vector3[] points, Vector2[] uvs, Vector3[] normals)
    {

        int p_0 = 0;
        int p_1 = 1;
        int p_2 = 2;
        //법선 벡터 구하기 
        Vector3 calculated_normal = Vector3.Cross((points[1] - points[0]).normalized, (points[2] - points[0]).normalized);

        //정점 나열 순서 조정 
        if (Vector3.Dot(calculated_normal, faceNormal) < 0)
        {

            p_0 = 2;
            p_1 = 1;
            p_2 = 0;
        }
        //수집용 데이터로 일단 저장해둠 
        left_Gather_added_Points[tSubMesh].Add(points[p_0]);
        left_Gather_added_Points[tSubMesh].Add(points[p_1]);
        left_Gather_added_Points[tSubMesh].Add(points[p_2]);

        left_Gater_added_uvs[tSubMesh].Add(uvs[p_0]);
        left_Gater_added_uvs[tSubMesh].Add(uvs[p_1]);
        left_Gater_added_uvs[tSubMesh].Add(uvs[p_2]);

        left_Gater_added_normals[tSubMesh].Add(normals[p_0]);
        left_Gater_added_normals[tSubMesh].Add(normals[p_1]);
        left_Gater_added_normals[tSubMesh].Add(normals[p_2]);

    }

    static void Add_Right_triangle(int tSubMesh, Vector3 faceNormal, Vector3[] points, Vector2[] uvs, Vector3[] normals)
    {


        int p_0 = 0;
        int p_1 = 1;
        int p_2 = 2;
        //법선 벡터 구하기 
        Vector3 calculated_normal = Vector3.Cross((points[1] - points[0]).normalized, (points[2] - points[0]).normalized);
        //정점 나열 순서 조정 
        if (Vector3.Dot(calculated_normal, faceNormal) < 0)
        {

            p_0 = 2;
            p_1 = 1;
            p_2 = 0;
        }


        right_Gather_added_Points[tSubMesh].Add(points[p_0]);
        right_Gather_added_Points[tSubMesh].Add(points[p_1]);
        right_Gather_added_Points[tSubMesh].Add(points[p_2]);

        right_Gater_added_uvs[tSubMesh].Add(uvs[p_0]);
        right_Gater_added_uvs[tSubMesh].Add(uvs[p_1]);
        right_Gater_added_uvs[tSubMesh].Add(uvs[p_2]);

        right_Gater_added_normals[tSubMesh].Add(normals[p_0]);
        right_Gater_added_normals[tSubMesh].Add(normals[p_1]);
        right_Gater_added_normals[tSubMesh].Add(normals[p_2]);

    }



    //지금까지 수집된 데이터들을 바탕으로 그리고 기존에 있던 메쉬정보에 대해  왼쪽 , 오른쪽 메쉬 정보를 조직화한다 
    static void SetFinalArrays_withOriginals()
    {
        int tIndexP = 0;
        //두 개의 서브메쉬 를 가정: 0번 서브메쉬 , 1번 서브메쉬 
        for (int tSubMesh = 0; tSubMesh < 2; tSubMesh++)
        {
            //왼쪽 수집된 0번 서브메쉬 1번 서브메쉬 
            for (int i = 0; i < left_Gather_subIndices[tSubMesh].Count; i++)
            {

                tIndexP = left_Gather_subIndices[tSubMesh][i];//인덱스를 얻는다 

                //해당 인덱스로 정점의 위치정보, 법선정보 , UV정보 를 추가한다 
                left_Final_vertices.Add(mVictimMesh.vertices[tIndexP]);
                mLtFinalSubIndices[tSubMesh].Add(left_Final_vertices.Count - 1);

                left_Final_normals.Add(mVictimMesh.normals[tIndexP]);
                left_Final_uvs.Add(mVictimMesh.uv[tIndexP]);

            }

            //오른쪽 수집된 0번 서브메쉬 1번 서브메쉬 
            for (int i = 0; i < right_Gather_subIndices[tSubMesh].Count; i++)
            {

                tIndexP = right_Gather_subIndices[tSubMesh][i];//인덱스를 얻는다 

                //해당 인덱스로 정점의 위치정보, 법선정보 , UV정보 를 추가한다 
                right_Final_vertices.Add(mVictimMesh.vertices[tIndexP]);
                mRtFinalSubIndices[tSubMesh].Add(right_Final_vertices.Count - 1);

                right_Final_normals.Add(mVictimMesh.normals[tIndexP]);
                right_Final_uvs.Add(mVictimMesh.uv[tIndexP]);

            }

        }

    }
    //지금까지 수집된 데이터들을 바탕으로 새롭게 구성되는 삼각형들에 대해  최종적인 왼쪽 , 오른쪽 메쉬 정보를 조직화한다 
    static void AddNewTriangles_toFinalArrays()
    {

        for (int tSubMesh = 0; tSubMesh < 2; tSubMesh++)
        {

            int count = left_Final_vertices.Count;//<-----------------SetFinalArrays_withOriginals 로 만들어진 그 데이터에 더해 가기 위해 
                                                  // add the new ones
                                                  // 새롭게 추가된 데이터 를 왼쪽 것으로 한다 
            for (int i = 0; i < left_Gather_added_Points[tSubMesh].Count; i++)
            {

                left_Final_vertices.Add(left_Gather_added_Points[tSubMesh][i]);
                mLtFinalSubIndices[tSubMesh].Add(i + count);

                left_Final_uvs.Add(left_Gater_added_uvs[tSubMesh][i]);
                left_Final_normals.Add(left_Gater_added_normals[tSubMesh][i]);

            }

            count = right_Final_vertices.Count;//<-----------------SetFinalArrays_withOriginals 로 만들어진 그 데이터에 더해 가기 위해 

            for (int i = 0; i < right_Gather_added_Points[tSubMesh].Count; i++)
            {

                right_Final_vertices.Add(right_Gather_added_Points[tSubMesh][i]);
                mRtFinalSubIndices[tSubMesh].Add(i + count);

                right_Final_uvs.Add(right_Gater_added_uvs[tSubMesh][i]);
                right_Final_normals.Add(right_Gater_added_normals[tSubMesh][i]);

            }
        }

    }
    
    
    //최종 폴리곤 조직화 과정에 필요한 기록을 위한 정점의 모음
    static List<Vector3> capVertTracker = new List<Vector3>();
    //최종 폴리곤( 정점의 모음 )
    static List<Vector3> capVertpolygon = new List<Vector3>();

    //절단면을 만들고 채운다.
    static void MakeCaps()
    {
        capVertTracker.Clear();//해당 자료구조를 일단 초기화

        for (int ti = 0; ti < mCreatedVertexPoints.Count; ++ti)
        {
            //포함되어 있지 않다면 추가한다.
            if (!capVertTracker.Contains(mCreatedVertexPoints[ti]))
            {
                //절단면을 채울 최종적으로 만드려는 데이터를 초기화하고
                capVertpolygon.Clear();

                capVertpolygon.Add(mCreatedVertexPoints[ti]);
                capVertpolygon.Add(mCreatedVertexPoints[ti + 1]);

                //기록도 해둔다. 그래야 ti + 1번째를 추가한 것이 또 추가되지 않는다
                capVertTracker.Add(mCreatedVertexPoints[ti]);
                capVertTracker.Add(mCreatedVertexPoints[ti + 1]);

                //이웃한 삼각형의 정점도 고려한다.
                bool isDone = false;
                while (!isDone)
                {
                    isDone = true;

                    for (int tj = 0; tj < mCreatedVertexPoints.Count; tj += 2)
                    {
                        //tj번째가 마지막것이라면
                        if (mCreatedVertexPoints[tj] == capVertpolygon[capVertpolygon.Count - 1] && !capVertTracker.Contains(mCreatedVertexPoints[tj + 1]))
                        {//tj + 1번째가 포함되어 있지 않은 것이므로 포함한다
                            isDone = false;
                            capVertpolygon.Add(mCreatedVertexPoints[tj + 1]);
                            capVertTracker.Add(mCreatedVertexPoints[tj + 1]);
                        }
                        //tj + 1번째가 마지막것이라면
                        else if (mCreatedVertexPoints[tj + 1] == capVertpolygon[capVertpolygon.Count - 1] && !capVertTracker.Contains(mCreatedVertexPoints[tj]))
                        {//tj번째가 포함되어 있지 않은 것이므로 포함한다
                            isDone = false;
                            capVertTracker.Add(mCreatedVertexPoints[tj]);
                            capVertpolygon.Add(mCreatedVertexPoints[tj]);
                        }
                    }
                }

                //한별의 capVertpolygon이 완성되었다면 이것으로 절단면 일부를 채운다
                FillCap(capVertpolygon);
            }
        }

    }

    //임의의 정점 목록으로 절단면을 최종적으로 채운다.
    static void FillCap(List<Vector3> vertices)
    {
        //위치정보는 매개변수로 넘어온다.
        //인덱스, uv, normal
        List<int> triangles = new List<int>();
        List<Vector2> uvs = new List<Vector2>();
        List<Vector3> normals = new List<Vector3>();

        //머티리얼에 필요한 uv값을 만들어내자.

        //중심점을 구하자.(각각의 성분은 각각의 성분을 모두 더하고 총개수로 나눠 구할 수 있다 )
        Vector3 center = Vector3.zero;
        foreach (Vector3 p in vertices)
        {
            center += p;
        }
        center = center / vertices.Count;

        Vector3 upward = Vector3.zero;//<--Up
        //90 degree turn
        upward.x = mPlane.normal.y;
        upward.y = -mPlane.normal.x;
        upward.z = mPlane.normal.z;
        Vector3 left = Vector3.Cross(mPlane.normal, upward);//<--Left

        Vector3 displacement = Vector3.zero;
        Vector3 relativePosition = Vector3.zero;

        for (int ti = 0; ti < vertices.Count; ++ti)
        {
            displacement = vertices[ti] - center;   //목적지점 - 시작지점

            relativePosition = Vector3.zero;
            //uv좌표를 계산한다.
            relativePosition.x = 0.5f + Vector3.Dot(displacement, left);//<--투영을 이용한다
            relativePosition.y = 0.5f + Vector3.Dot(displacement, upward);
            relativePosition.z = 0.5f + Vector3.Dot(displacement, mPlane.normal);
            //<--0.5는 중심점에서의 uv좌표 값이다.

            //uv정보 추가, normal 정보 추가 
            uvs.Add(new Vector2(relativePosition.x, relativePosition.y));
            normals.Add(mPlane.normal);
        }

        //center를 정점목록 에 추가 <-- 이 center도 해당 폴리곤을 구성하는 하나의 정점이다.
        vertices.Add(center);
        normals.Add(mPlane.normal);
        uvs.Add(new Vector2(0.5f, 0.5f));

        //--정점목록--을 순회하며 임의의 처리를 수행한다 
        Vector3 calculated_normal = Vector3.zero;
        int otherIndex = 0;
        for (int i = 0; i < vertices.Count; i++)
        {

            otherIndex = (i + 1) % (vertices.Count - 1);

            //--다음은 법선벡터를 계산하여 정점의 나열 순서를 규칙에 맞게 나열해주는 것이다 

            //법선을 계산함 
            calculated_normal = Vector3.Cross((vertices[otherIndex] - vertices[i]).normalized,
                                              (vertices[vertices.Count - 1] - vertices[i]).normalized);

            //바로 위에서 구한 법선 과 절단을위한평면의 법선 이 둘의 위치관계를 파악 
            if (Vector3.Dot(calculated_normal, mPlane.normal) < 0)//위치관계 둔각 , 즉 다른 방향 
            {

                triangles.Add(vertices.Count - 1);
                triangles.Add(otherIndex);
                triangles.Add(i);
                //면 인덱스 정보 추가 <--삼각형은 정점 세개로 이루어짐 
            }
            else//같은 방향 
            {

                triangles.Add(i);
                triangles.Add(otherIndex);
                triangles.Add(vertices.Count - 1);
                //면 인덱스 정보 추가 <--삼각형은 정점 세개로 이루어짐 
            }

        }


        //------절단되고 나면 하나가 두개가 된. 즉 , 각각의 물체에 대해 절단면이 있다 .
        //그러므로 , 절단면은 두 개가 되어야 하므로 왼쪽 , 오른쪽 두 개에 대한 처리를 한다 

        //--삼각형 목록--을 순회하며 임의의 처리를 수행한다 
        int index = 0;
        for (int i = 0; i < triangles.Count; i++)
        {

            index = triangles[i];

            right_Final_vertices.Add(vertices[index]);
            mRtFinalSubIndices[1].Add(right_Final_vertices.Count - 1);

            right_Final_normals.Add(normals[index]);
            right_Final_uvs.Add(uvs[index]);

        }

        for (int i = 0; i < normals.Count; i++)
        {
            normals[i] = -normals[i];
        }

        int temp1, temp2;
        for (int i = 0; i < triangles.Count; i += 3)
        {

            temp1 = triangles[i + 2];
            temp2 = triangles[i];

            triangles[i] = temp1;
            triangles[i + 2] = temp2;
        }

        //--삼각형 목록--을 순회하며 임의의 처리를 수행한다 
        for (int i = 0; i < triangles.Count; i++)
        {

            index = triangles[i];

            left_Final_vertices.Add(vertices[index]);
            mLtFinalSubIndices[1].Add(left_Final_vertices.Count - 1);

            left_Final_normals.Add(normals[index]);
            left_Final_uvs.Add(uvs[index]);

        }


    }


}
