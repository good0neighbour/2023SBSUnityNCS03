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
    bool[] mIsCorrectSides = new bool[3];

    //---------- 중간 과정을 위한 수집용 데이터 ----------
    //의도하는 최종결과(mesh cutting)을 만들기 위해 필요한 재료로서의 데이터를 수집한다라는 의미다

    //-----------left-------------
    //왼쪽 서브메쉬의 인덱스 정보 목록
    List<int>[] left_Gather_subIndices = new List<int>[] { new List<int>(), new List<int>() };

    //왼쪽 메쉬를 구성하는 중간과정에서 사용될
    //  정점의 위치목록,
    //  uv목록,
    //  normal 목록
    //
    //기하구조물 정보 두 개
    List<Vector3>[] left_Gather_added_Points = new List<Vector3>[] { new List<Vector3>(), new List<Vector3>() };
    List<Vector2>[] left_Gather_added_uvs = new List<Vector2>[] { new List<Vector2>(), new List<Vector2>() };
    List<Vector3>[] left_Gather_added_normals = new List<Vector3>[] { new List<Vector3>(), new List<Vector3>() };

    //-----------right-------------
    //오른쪽 서브메쉬의 인덱스 정보 목록
    List<int>[] right_Gather_subIndices = new List<int>[] { new List<int>(), new List<int>() };

    //오른쪽 메쉬를 구성하는 중간과정에서 사용될
    //  정점의 위치목록,
    //  uv목록,
    //  normal 목록
    //
    //기하구조물 정보 두 개
    List<Vector3>[] right_Gather_added_Points = new List<Vector3>[] { new List<Vector3>(), new List<Vector3>() };
    List<Vector2>[] right_Gather_added_uvs = new List<Vector2>[] { new List<Vector2>(), new List<Vector2>() };
    List<Vector3>[] right_Gather_added_normals = new List<Vector3>[] { new List<Vector3>(), new List<Vector3>() };


    //------- 면(삼각형) 절단 동작을 위해 필요한 데이터 ---------
    //위치, uv, normal
    static Vector3 mLtPoint_0 = Vector3.zero;
    static Vector3 mLtPoint_1 = Vector3.zero;
    static Vector3 mRtPoint_0 = Vector3.zero;
    static Vector3 mRtPoint_1 = Vector3.zero;

    static Vector2 mLttUV_0 = Vector2.zero;
    static Vector2 mLttUV_1 = Vector2.zero;
    static Vector2 mRttUV_0 = Vector2.zero;
    static Vector2 mRttUV_1 = Vector2.zero;

    static Vector3 mLtNormal_0 = Vector3.zero;
    static Vector3 mLtNormal_1 = Vector3.zero;
    static Vector3 mRtNormal_0 = Vector3.zero;
    static Vector3 mRtNormal_1 = Vector3.zero;

}
