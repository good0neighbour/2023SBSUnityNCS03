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
    static bool[] mIsCorrectSides = new bool[3];

    //---------- �߰� ������ ���� ������ ������ ----------
    //�ǵ��ϴ� �������(mesh cutting)�� ����� ���� �ʿ��� ���μ��� �����͸� �����Ѵٶ�� �ǹ̴�

    //-----------left-------------
    //���� ����޽��� �ε��� ���� ���
    static List<int>[] left_Gather_subIndices = new List<int>[] { new List<int>(), new List<int>() };

    //���� �޽��� �����ϴ� �߰��������� ����
    //  ������ ��ġ���,
    //  uv���,
    //  normal ���
    //
    //���ϱ����� ���� �� ��
    static List<Vector3>[] left_Gather_added_Points = new List<Vector3>[] { new List<Vector3>(), new List<Vector3>() };
    static List<Vector2>[] left_Gather_added_uvs = new List<Vector2>[] { new List<Vector2>(), new List<Vector2>() };
    static List<Vector3>[] left_Gather_added_normals = new List<Vector3>[] { new List<Vector3>(), new List<Vector3>() };

    //-----------right-------------
    //������ ����޽��� �ε��� ���� ���
    static List<int>[] right_Gather_subIndices = new List<int>[] { new List<int>(), new List<int>() };

    //������ �޽��� �����ϴ� �߰��������� ����
    //  ������ ��ġ���,
    //  uv���,
    //  normal ���
    //
    //���ϱ����� ���� �� ��
    static List<Vector3>[] right_Gather_added_Points = new List<Vector3>[] { new List<Vector3>(), new List<Vector3>() };
    static List<Vector2>[] right_Gather_added_uvs = new List<Vector2>[] { new List<Vector2>(), new List<Vector2>() };
    static List<Vector3>[] right_Gather_added_normals = new List<Vector3>[] { new List<Vector3>(), new List<Vector3>() };


    //------- ��(�ﰢ��) ���� ������ ���� �ʿ��� ������ ---------
    //��ġ, uv, normal
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



    //-----------���������� ��������� ������--------------
    //left�� ���� ���� �̿�
    //right�� ���� ���� �޽�

    //--���� �޽��� ���� ������--
    //�ε���, ������ ��ġ, ��������, uv����
    static new List<int>[] mLtFinalSubIndices = new List<int>[]{ new List<int>(), new List<int>()};

    static List<Vector3> left_Final_vertcies = new List<Vector3>();
    static List<Vector3> left_Final_normals = new List<Vector3>();
    static List<Vector2> left_Final_uvs = new List<Vector2>();


    //--������ �޽��� ���� ������--
    //�ε���, ������ ��ġ, ��������, uv����
    static new List<int>[] mRtFinalSubIndices = new List<int>[] { new List<int>(), new List<int>() };

    static List<Vector3> right_Final_vertcies = new List<Vector3>();
    static List<Vector3> right_Final_normals = new List<Vector3>();
    static List<Vector2> right_Final_uvs = new List<Vector2>();



    //���ܸ��� ���� ����
    static List<Vector3> mCreatedVertexPoints = new List<Vector3>();

    //������ �����͸� ����
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
    //�� ������ ���� �ӽú����� ����
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

    //���� ������ ����
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

    //tVictim: ���� ���ӿ�����Ʈ, ������ ����� �ȴ�
    //tAnchorPoint: ������� ������ ����
    //tNormalDir: ����� ��������
    //      P dot N = d
    //tCapMaterial: ���ܸ鿡 ����� ��Ƽ����
    public static GameObject[] Cut(GameObject tVictim, Vector3 tAnchorPoint, Vector3 tNormalDir, Material tCapMaterial)
    {
        mVictimTransform = tVictim.transform;

        //Transform:        Local ---> Wolrd
        //InverseTranform:  World ---> Local
        //  <-- ������ ��ȯ�� �������� ���� ���¶�� ������ ��ġ�� ������ǥ�� �������� ��������ִ�.
        //  �׷��Ƿ� ������ǥ�� ������ ��ġ������ ����� �������� ��ȯ�Ͽ� ������ ������ ���� ���̴�.
        mPlane = new Plane(tVictim.transform.InverseTransformDirection(-tNormalDir), tVictim.transform.InverseTransformPoint(tAnchorPoint));

        mVictimMesh = tVictim.GetComponent<MeshFilter>().mesh;
        mVictimMesh.subMeshCount = 2;//<--2���� ����޽��� �̿��ϱ� ���� ����

        //������ �����͸� �ʱ�ȭ
        ResetGatheringValues();

        // �ﰢ���� ������ �ε��� �ӽ� ����
        int p_0 = 0;
        int p_1 = 0;
        int p_2 = 0;

        int sub = 0;//����޽����� ����
        int[] indices = mVictimMesh.triangles;       //���θ޽� �ε��� ���
        int[] secondIndices = mVictimMesh.GetIndices(1); //����޽� �ε��� ���

        //�ε��� ������ŭ �ݺ��ϸ鼭 ������ ������ ��ġ���踦 �Ǵ��Ѵ�
        for (int ti = 0; ti < indices.Length; ti += 3)
        {
            //���ӵ� �� ���� ���� �ε��� ������ ���� 3���� �����͸� ��´�
            p_0 = indices[ti];
            p_1 = indices[ti + 1];
            p_2 = indices[ti + 2];

            //�ﰢ���� ������ ������ ����� �ùٸ� �ʿ� �ִ��� ���� �˻�
            mIsCorrectSides[0] = mPlane.GetSide(mVictimMesh.vertices[p_0]);
            mIsCorrectSides[1] = mPlane.GetSide(mVictimMesh.vertices[p_1]);
            mIsCorrectSides[2] = mPlane.GetSide(mVictimMesh.vertices[p_2]);

            //Main Mesh���� SubMesh���� �Ǵ�
            sub = 0;//<--Main�� Sub�� ��� ��Ÿ���� ������. 0: main, 1: sub
            for (int k = 0; k < secondIndices.Length; ++k)
            {
                //�̷��ٸ�, Sub�̴�.
                if (secondIndices[k] == p_0)
                {
                    sub = 1;
                    break;
                }
            }

            //������ �ﰢ���� �� ���� ��� �ùٸ� �ʿ� �ְų�,
            //������ �ﰢ���� �� ���� ��� �ùٸ��� ���� �ʿ� �ִٸ�
            //<-- Cut�� ����� �ƴϴ�.
            if (mIsCorrectSides[0] == mIsCorrectSides[1] && mIsCorrectSides[0] == mIsCorrectSides[2])
            {
                //��� �ùٸ� �ʿ� �ִ� ���
                if (mIsCorrectSides[0])
                {
                    //left sub�� ���ϰ� �ȴ�
                    left_Gather_subIndices[sub].Add(p_0);
                    left_Gather_subIndices[sub].Add(p_1);
                    left_Gather_subIndices[sub].Add(p_2);
                }
                else//��� �ùٸ��� ���� �ʿ� �ִ� ���
                {
                    //right sub�� ���ϰ� �ȴ�
                    right_Gather_subIndices[sub].Add(p_0);
                    right_Gather_subIndices[sub].Add(p_1);
                    right_Gather_subIndices[sub].Add(p_2);
                }
            }
            else//�׷��� �ʴٸ� <--Cut�� ����̴�.
            {
                //�� ������ ���� �ӽú��� �ʱ�ȭ
                ResetFaceCuttingTemps();

                //face cut
                Cut_this_Face(sub, p_0, p_1, p_2);
            }
        }


        //������� ����, ������ ���� ������ ���������ʹ� �ϼ��� �Ǿ���.
        //���� ���� ������� �����

        //����������� ���� ������ �ʱ�ȭ
        ResetFinalArrays();

        //���� �޽� ���������͸� �����
        //������ �޽� ���������͸� �����
        //���ܸ��� ä���
        SetFinalArrays_withOriginals();
        AddNewTriangles_toFinalArrays();
        MakeCaps();

        //left Mesh�� �ٷ�� ���� ó���� ���ش�
        Mesh tLtHalfMesh = new Mesh();
        tLtHalfMesh.name = "split mesh left";

        tLtHalfMesh.vertices = left_Final_vertcies.ToArray();//List ---> Array
        tLtHalfMesh.subMeshCount = 2;//<--sub mesh count�� 2ro

        //topology ������: ������ ������ � �������� �ؼ��� ���̳Ŀ� ���� �ɼ�
        tLtHalfMesh.SetIndices(mLtFinalSubIndices[0].ToArray(), MeshTopology.Triangles, 0);
        tLtHalfMesh.SetIndices(mLtFinalSubIndices[1].ToArray(), MeshTopology.Triangles, 1);

        tLtHalfMesh.normals = left_Final_normals.ToArray();
        tLtHalfMesh.uv = left_Final_uvs.ToArray();


        //����Ƽ���� right Mesh�� �ٷ�� ���� ó���� ���ش�
        Mesh tRtHalfMesh = new Mesh();
        tRtHalfMesh.name = "split mesh right";

        tRtHalfMesh.vertices = right_Final_vertcies.ToArray();//List ---> Array
        tRtHalfMesh.subMeshCount = 2;//<--sub mesh count�� 2ro

        //topology ������: ������ ������ � �������� �ؼ��� ���̳Ŀ� ���� �ɼ�
        tRtHalfMesh.SetIndices(mRtFinalSubIndices[0].ToArray(), MeshTopology.Triangles, 0);
        tRtHalfMesh.SetIndices(mRtFinalSubIndices[1].ToArray(), MeshTopology.Triangles, 1);

        tRtHalfMesh.normals = right_Final_normals.ToArray();
        tRtHalfMesh.uv = right_Final_uvs.ToArray();




        //����Ƽ���� ���� ���ӿ�����Ʈ, ������ ���ӿ�����Ʈ�� �ٷ�� ���� ó���� �Ѵ�

        GameObject leftSideObject = null;
        GameObject rightSideObject = null;
        
        return new GameObject[] {leftSideObject, rightSideObject};
    }

    //������ ��(�ﰢ��) ���� �Լ�
    static void Cut_this_Face(int tSubMesh, int tIndex_0, int tIndex_1, int tIndex_2)
    {

    }
    //���� �޽� ���� �����ʹ� ������ �����ͷκ��� ������.
    static void SetFinalArrays_withOriginals()
    {

    }
    //������ �޽� ���� �����ʹ� ���� �����.
    static void AddNewTriangles_toFinalArrays()
    {

    }
    //���ܸ��� ä���.
    static void MakeCaps()
    {

    }


}
