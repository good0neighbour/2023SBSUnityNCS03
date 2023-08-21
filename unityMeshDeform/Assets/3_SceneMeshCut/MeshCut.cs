using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//MeshRenderer������ �۵� Ȯ��
//Mesh�� �߶󳻴� ����� ���� Ŭ����
public class MeshCut
{
    //�޽� ������ ���� ��� ���� Ŭ����
    static Plane mPlane;    //<-- ����� ������ P dot N = d

    //'�޽� ���� ������ ����� �� �޽��� ��ȯ ����
    static Mesh mVictimMesh;    //�޽� ����
    static Transform mVictimTransform; //��ȯ ����

    //����� �ùٸ� �ʿ� �ִ��� ���� ���� <-- ������ �ﰢ���� �� ���� ���� �Ǵ��ϹǷ� �� ����.
    bool[] mIsCorrectSides = new bool[3];

    //---------- �߰� ������ ���� ������ ������ ----------
    //�ǵ��ϴ� �������(mesh cutting)�� ����� ���� �ʿ��� ���μ��� �����͸� �����Ѵٶ�� �ǹ̴�

    //-----------left-------------
    //���� ����޽��� �ε��� ���� ���
    List<int>[] left_Gather_subIndices = new List<int>[] { new List<int>(), new List<int>() };

    //���� �޽��� �����ϴ� �߰��������� ����
    //  ������ ��ġ���,
    //  uv���,
    //  normal ���
    //
    //���ϱ����� ���� �� ��
    List<Vector3>[] left_Gather_added_Points = new List<Vector3>[] { new List<Vector3>(), new List<Vector3>() };
    List<Vector2>[] left_Gather_added_uvs = new List<Vector2>[] { new List<Vector2>(), new List<Vector2>() };
    List<Vector3>[] left_Gather_added_normals = new List<Vector3>[] { new List<Vector3>(), new List<Vector3>() };

    //-----------right-------------
    //������ ����޽��� �ε��� ���� ���
    List<int>[] right_Gather_subIndices = new List<int>[] { new List<int>(), new List<int>() };

    //������ �޽��� �����ϴ� �߰��������� ����
    //  ������ ��ġ���,
    //  uv���,
    //  normal ���
    //
    //���ϱ����� ���� �� ��
    List<Vector3>[] right_Gather_added_Points = new List<Vector3>[] { new List<Vector3>(), new List<Vector3>() };
    List<Vector2>[] right_Gather_added_uvs = new List<Vector2>[] { new List<Vector2>(), new List<Vector2>() };
    List<Vector3>[] right_Gather_added_normals = new List<Vector3>[] { new List<Vector3>(), new List<Vector3>() };


    //------- ��(�ﰢ��) ���� ������ ���� �ʿ��� ������ ---------
    //��ġ, uv, normal
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
