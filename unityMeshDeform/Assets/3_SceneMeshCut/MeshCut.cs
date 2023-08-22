using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//MeshRenderer에서만 작동 확인
//Mesh를 잘라내는 기능을 가진 클래스
public class MeshCut
{
    //메쉬 절단을 위한 평면 정보 클래스
    static Plane mPlane;    //<-- 평면의 방정식 P dot N = d

    //'메쉬 절단 적용의 대상이 될 메쉬와 변환 정보
    static Mesh mVictimMesh;    //메쉬 정보
    static Transform mVictimTransform; //변환 정보

    //평면의 올바른 쪽에 있는지 여부 정보 <-- 임의의 삼각형의 세 점에 대해 판단하므로 세 개다.
    static bool[] mIsCorrectSides = new bool[3];

    //---------- 중간 과정을 위한 수집용 데이터 ----------
    //의도하는 최종결과(mesh cutting)을 만들기 위해 필요한 재료로서의 데이터를 수집한다라는 의미다

    //-----------left-------------
    //왼쪽 서브메쉬의 인덱스 정보 목록
    static List<int>[] left_Gather_subIndices = new List<int>[] { new List<int>(), new List<int>() };

    //왼쪽 메쉬를 구성하는 중간과정에서 사용될
    //  정점의 위치목록,
    //  uv목록,
    //  normal 목록
    //
    //기하구조물 정보 두 개
    static List<Vector3>[] left_Gather_added_Points = new List<Vector3>[] { new List<Vector3>(), new List<Vector3>() };
    static List<Vector2>[] left_Gather_added_uvs = new List<Vector2>[] { new List<Vector2>(), new List<Vector2>() };
    static List<Vector3>[] left_Gather_added_normals = new List<Vector3>[] { new List<Vector3>(), new List<Vector3>() };

    //-----------right-------------
    //오른쪽 서브메쉬의 인덱스 정보 목록
    static List<int>[] right_Gather_subIndices = new List<int>[] { new List<int>(), new List<int>() };

    //오른쪽 메쉬를 구성하는 중간과정에서 사용될
    //  정점의 위치목록,
    //  uv목록,
    //  normal 목록
    //
    //기하구조물 정보 두 개
    static List<Vector3>[] right_Gather_added_Points = new List<Vector3>[] { new List<Vector3>(), new List<Vector3>() };
    static List<Vector2>[] right_Gather_added_uvs = new List<Vector2>[] { new List<Vector2>(), new List<Vector2>() };
    static List<Vector3>[] right_Gather_added_normals = new List<Vector3>[] { new List<Vector3>(), new List<Vector3>() };


    //------- 면(삼각형) 절단 동작을 위해 필요한 데이터 ---------
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



    //-----------최종적으로 만들어지는 데이터--------------
    //left는 원래 것을 이용
    //right는 새로 만든 메쉬

    //--왼쪽 메쉬를 위한 데이터--
    //인덱스, 정점의 위치, 법선정보, uv정보
    static new List<int>[] mLtFinalSubIndices = new List<int>[]{ new List<int>(), new List<int>()};

    static List<Vector3> left_Final_vertcies = new List<Vector3>();
    static List<Vector3> left_Final_normals = new List<Vector3>();
    static List<Vector2> left_Final_uvs = new List<Vector2>();


    //--오른쪽 메쉬를 위한 데이터--
    //인덱스, 정점의 위치, 법선정보, uv정보
    static new List<int>[] mRtFinalSubIndices = new List<int>[] { new List<int>(), new List<int>() };

    static List<Vector3> right_Final_vertcies = new List<Vector3>();
    static List<Vector3> right_Final_normals = new List<Vector3>();
    static List<Vector2> right_Final_uvs = new List<Vector2>();



    //절단면을 위한 정점
    static List<Vector3> mCreatedVertexPoints = new List<Vector3>();

    //수집용 데이터를 리셋
    static void ResetGatheringValues()
    {
        left_Gather_subIndices[0].Clear();
        left_Gather_subIndices[1].Clear();
        left_Gather_added_Points[0].Clear();
        left_Gather_added_Points[1].Clear();
        left_Gather_added_uvs[0].Clear();
        left_Gather_added_uvs[1].Clear();
        left_Gather_added_normals[0].Clear();
        left_Gather_added_normals[1].Clear();

        right_Gather_subIndices[0].Clear();
        right_Gather_subIndices[1].Clear();
        right_Gather_added_Points[0].Clear();
        right_Gather_added_Points[1].Clear();
        right_Gather_added_uvs[0].Clear();
        right_Gather_added_uvs[1].Clear();
        right_Gather_added_normals[0].Clear();
        right_Gather_added_normals[1].Clear();

        mCreatedVertexPoints.Clear();
    }
    //면 절단을 위한 임시변수를 리셋
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
        left_Final_vertcies.Clear();
        left_Final_normals.Clear();
        left_Final_uvs.Clear();


        mRtFinalSubIndices[0].Clear();
        mRtFinalSubIndices[1].Clear();
        right_Final_vertcies.Clear();
        right_Final_normals.Clear();
        right_Final_uvs.Clear();
    }

    //tVictim: 원본 게임오브젝트, 절단의 대상이 된다
    //tAnchorPoint: 평면위에 임의의 한점
    //tNormalDir: 평면의 법선벡터
    //      P dot N = d
    //tCapMaterial: 절단면에 적용될 머티리얼
    public static GameObject[] Cut(GameObject tVictim, Vector3 tAnchorPoint, Vector3 tNormalDir, Material tCapMaterial)
    {
        mVictimTransform = tVictim.transform;

        //Transform:        Local ---> Wolrd
        //InverseTranform:  World ---> Local
        //  <-- 임의의 변환이 가해지지 않은 상태라면 정점의 위치는 로컬좌표계 기준으로 만들어져있다.
        //  그러므로 로컬좌표계 기준의 위치값으로 평면의 방정식을 변환하여 정점과 수준을 맞춘 것이다.
        mPlane = new Plane(tVictim.transform.InverseTransformDirection(-tNormalDir), tVictim.transform.InverseTransformPoint(tAnchorPoint));

        mVictimMesh = tVictim.GetComponent<MeshFilter>().mesh;
        mVictimMesh.subMeshCount = 2;//<--2개의 서브메쉬를 이용하기 위해 설정

        //수집용 데이터를 초기화
        ResetGatheringValues();

        // 삼각형의 정점의 인덱스 임시 변수
        int p_0 = 0;
        int p_1 = 0;
        int p_2 = 0;

        int sub = 0;//서브메쉬인지 여부
        int[] indices = mVictimMesh.triangles;       //메인메쉬 인덱스 목록
        int[] secondIndices = mVictimMesh.GetIndices(1); //서브메쉬 인덱스 목록

        //인덱스 개수만큼 반복하면서 임의의 정점의 위치관계를 판단한다
        for (int ti = 0; ti < indices.Length; ti += 3)
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
            sub = 0;//<--Main과 Sub를 모두 나타내는 변수다. 0: main, 1: sub
            for (int k = 0; k < secondIndices.Length; ++k)
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
                //면 절단을 위한 임시변수 초기화
                ResetFaceCuttingTemps();

                //face cut
                Cut_this_Face(sub, p_0, p_1, p_2);
            }
        }


        //여기까지 오면, 절단을 위한 증간용 수집데이터는 완성이 되었다.
        //이제 최종 결과물을 만든다

        //최종결과물을 위한 데이터 초기화
        ResetFinalArrays();

        //왼쪽 메쉬 최종데이터를 만든다
        //오른쪽 메쉬 최종데이터를 만든다
        //절단면을 채운다
        SetFinalArrays_withOriginals();
        AddNewTriangles_toFinalArrays();
        MakeCaps();

        //left Mesh로 다루기 위한 처리를 해준다
        Mesh tLtHalfMesh = new Mesh();
        tLtHalfMesh.name = "split mesh left";

        tLtHalfMesh.vertices = left_Final_vertcies.ToArray();//List ---> Array
        tLtHalfMesh.subMeshCount = 2;//<--sub mesh count는 2ro

        //topology 위상구조: 정점의 집합을 어떤 도형으로 해석할 것이냐에 대한 옵션
        tLtHalfMesh.SetIndices(mLtFinalSubIndices[0].ToArray(), MeshTopology.Triangles, 0);
        tLtHalfMesh.SetIndices(mLtFinalSubIndices[1].ToArray(), MeshTopology.Triangles, 1);

        tLtHalfMesh.normals = left_Final_normals.ToArray();
        tLtHalfMesh.uv = left_Final_uvs.ToArray();


        //유니티에서 right Mesh로 다루기 위한 처리를 해준다
        Mesh tRtHalfMesh = new Mesh();
        tRtHalfMesh.name = "split mesh right";

        tRtHalfMesh.vertices = right_Final_vertcies.ToArray();//List ---> Array
        tRtHalfMesh.subMeshCount = 2;//<--sub mesh count는 2ro

        //topology 위상구조: 정점의 집합을 어떤 도형으로 해석할 것이냐에 대한 옵션
        tRtHalfMesh.SetIndices(mRtFinalSubIndices[0].ToArray(), MeshTopology.Triangles, 0);
        tRtHalfMesh.SetIndices(mRtFinalSubIndices[1].ToArray(), MeshTopology.Triangles, 1);

        tRtHalfMesh.normals = right_Final_normals.ToArray();
        tRtHalfMesh.uv = right_Final_uvs.ToArray();




        //유니티에서 왼쪽 게임오브젝트, 오른쪽 게임오브젝트로 다루기 위한 처리를 한다

        GameObject leftSideObject = null;
        GameObject rightSideObject = null;
        
        return new GameObject[] {leftSideObject, rightSideObject};
    }

    //임의의 면(삼각형) 절단 함수
    static void Cut_this_Face(int tSubMesh, int tIndex_0, int tIndex_1, int tIndex_2)
    {

    }
    //왼쪽 메쉬 최종 데이터는 원래의 데이터로부터 만들어낸다.
    static void SetFinalArrays_withOriginals()
    {

    }
    //오른쪽 메쉬 최종 데이터는 새로 만든다.
    static void AddNewTriangles_toFinalArrays()
    {

    }
    //절단면을 채운다.
    static void MakeCaps()
    {

    }


}
