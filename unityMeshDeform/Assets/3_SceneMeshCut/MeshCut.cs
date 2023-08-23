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

    static List<Vector3> left_Final_vertices = new List<Vector3>();
    static List<Vector3> left_Final_normals = new List<Vector3>();
    static List<Vector2> left_Final_uvs = new List<Vector2>();


    //--������ �޽��� ���� ������--
    //�ε���, ������ ��ġ, ��������, uv����
    static new List<int>[] mRtFinalSubIndices = new List<int>[] { new List<int>(), new List<int>() };

    static List<Vector3> right_Final_vertices = new List<Vector3>();
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
        left_Final_vertices.Clear();
        left_Final_normals.Clear();
        left_Final_uvs.Clear();


        mRtFinalSubIndices[0].Clear();
        mRtFinalSubIndices[1].Clear();
        right_Final_vertices.Clear();
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

        //i)���� �����ͷκ��� ���� �κ��� �����
        //  ���� �޽� ���������͸� �����
        //  ������ �޽� ���������͸� �����
        //ii)���Ӱ� ���� �κ��� �����
        //  ���� �޽� ���������͸� �����
        //  ������ �޽� ���������͸� �����
        //iii)���ܸ��� ä���
        SetFinalArrays_withOriginals();//<-----���� �����ͷκ��� ���� �κ��� �����
        AddNewTriangles_toFinalArrays();//<-----���Ӱ� ���� �κ��� �����
        MakeCaps();

        //left Mesh�� �ٷ�� ���� ó���� ���ش�
        Mesh tLtHalfMesh = new Mesh();
        tLtHalfMesh.name = "split mesh left";

        tLtHalfMesh.vertices = left_Final_vertices.ToArray();//List ---> Array
        tLtHalfMesh.subMeshCount = 2;//<--sub mesh count�� 2ro

        //topology ������: ������ ������ � �������� �ؼ��� ���̳Ŀ� ���� �ɼ�
        tLtHalfMesh.SetIndices(mLtFinalSubIndices[0].ToArray(), MeshTopology.Triangles, 0);
        tLtHalfMesh.SetIndices(mLtFinalSubIndices[1].ToArray(), MeshTopology.Triangles, 1);

        tLtHalfMesh.normals = left_Final_normals.ToArray();
        tLtHalfMesh.uv = left_Final_uvs.ToArray();


        //����Ƽ���� right Mesh�� �ٷ�� ���� ó���� ���ش�
        Mesh tRtHalfMesh = new Mesh();
        tRtHalfMesh.name = "split mesh right";

        tRtHalfMesh.vertices = right_Final_vertices.ToArray();//List ---> Array
        tRtHalfMesh.subMeshCount = 2;//<--sub mesh count�� 2ro

        //topology ������: ������ ������ � �������� �ؼ��� ���̳Ŀ� ���� �ɼ�
        tRtHalfMesh.SetIndices(mRtFinalSubIndices[0].ToArray(), MeshTopology.Triangles, 0);
        tRtHalfMesh.SetIndices(mRtFinalSubIndices[1].ToArray(), MeshTopology.Triangles, 1);

        tRtHalfMesh.normals = right_Final_normals.ToArray();
        tRtHalfMesh.uv = right_Final_uvs.ToArray();




        //����Ƽ���� ���� ���ӿ�����Ʈ, ������ ���ӿ�����Ʈ�� �ٷ�� ���� ó���� �Ѵ�

        //���� ���ӿ�����Ʈ�� �����.
        //����GameObject�� �̿��Ͽ� �����.
        GameObject leftSideObject = null;
        tVictim.name = "leftSideObject";
        tVictim.GetComponent<MeshFilter>().mesh = tLtHalfMesh;//<-- �޽� �����͸� ���ӿ�����Ʈ�� ����
        
        leftSideObject = tVictim;//<--���� ���ӿ�����Ʈ�� ���� ���ӿ�����Ʈ�� ������ �����.

        //������ ���ӿ�����Ʈ�� �����
        //<--���Ӱ� �����.
        GameObject rightSideObject = null;
        rightSideObject = new GameObject("rightSideObject", typeof(MeshFilter), typeof(MeshRenderer));
        rightSideObject.transform.position = mVictimTransform.position; //���� ���ӿ�����Ʈ�� ��ȯ���� ����
        rightSideObject.transform.rotation = mVictimTransform.rotation;
        rightSideObject.GetComponent<MeshFilter>().mesh = tRtHalfMesh;//<-- �޽� �����͸� ���ӿ�����Ʈ�� ����

        //��Ƽ������ �����Ѵ�.
        Material[] mats = new Material[] { tVictim.GetComponent<MeshRenderer>().material, tCapMaterial };
        //<--���� ��, ���ܸ��� ���� ��Ƽ����

        leftSideObject.GetComponent<MeshRenderer>().materials = mats;
        rightSideObject.GetComponent<MeshRenderer>().materials = mats;
        
        return new GameObject[] {leftSideObject, rightSideObject};
    }

    //������ ��(�ﰢ��) ���� �Լ�
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
            //�ﰢ���� ������ ������ �ùٸ� �鿡 �ִٸ�, �� ���� �ִٸ�
            if (mIsCorrectSides[side])
            {
                if (mLtPoint_0 == Vector3.zero)
                {
                    //leftPoint1�� (0, 0, 0)�̶�� ������ ���� ��ġ ������ ����
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
            else
            {
                if (mLtPoint_0 == Vector3.zero)
                {
                    //leftPoint1�� (0, 0, 0)�̶�� ������ ���� ��ġ ������ ����
                    mRtPoint_0 = mVictimMesh.vertices[p];
                    mRtPoint_1 = mLtPoint_0;
                    mRtUV_0 = mVictimMesh.uv[p];
                    mRtUV_1 = mLtUV_0;
                    mRtNormal_0 = mVictimMesh.normals[p];
                    mRtNormal_1 = mLtNormal_0;
                }
                else
                {
                    mRtPoint_1 = mVictimMesh.vertices[p];
                    mRtUV_1 = mVictimMesh.uv[p];
                    mRtNormal_1 = mVictimMesh.normals[p];
                }
            }
        }//for


        //�ݺ�������� ���������Ƿ�, ���� �� �� ���� �ε����� ���� ó���Ǿ�
        //mLt0, mLt1, mRt0, mRt1�� �غ�Ǿ� �ִ�.

        //���� �̷��� �غ�� �����͸� ������, ������ ������ ������.
        float tDistance = 0.0f;
        float tNormalizedDistance = 0.0f;

        mPlane.Raycast(new Ray(mLtPoint_0, (mRtPoint_0 - mLtPoint_0).normalized), out tDistance);
        //<--���� �������� �浹����, �̸� ���ؼ� �浹���������� �Ÿ��� ���Ѵ�
        tNormalizedDistance = tDistance / (mRtPoint_0 - mLtPoint_0).magnitude;
        // �浹���������� �Ÿ�/ mRt0�� mLt0������ �Ÿ� = �浹������ ������

        Vector3 newVertex1 = Vector3.Lerp(mLtPoint_0, mRtPoint_0, tNormalizedDistance);
        //�������� �Լ��� ����ġ �κп� �������� �־� �� ����(��ġ)�� ������ ��ġ<--������ ���Ѵ�.
        Vector2 newUv1 = Vector2.Lerp(mLtUV_0, mRtUV_0, tNormalizedDistance);
        Vector3 newNormal1 = Vector3.Lerp(mLtNormal_0, mRtNormal_0, tNormalizedDistance);
        mCreatedVertexPoints.Add(newVertex1);//���ܸ��� ���� ����




        mPlane.Raycast(new Ray(mLtPoint_1, (mRtPoint_1 - mLtPoint_1).normalized), out tDistance);
        //<--���� �������� �浹����, �̸� ���ؼ� �浹���������� �Ÿ��� ���Ѵ�
        tNormalizedDistance = tDistance / (mRtPoint_1 - mLtPoint_1).magnitude;
        // �浹���������� �Ÿ�/ mRt0�� mLt0������ �Ÿ� = �浹������ ������

        Vector3 newVertex2 = Vector3.Lerp(mLtPoint_1, mRtPoint_1, tNormalizedDistance);
        //�������� �Լ��� ����ġ �κп� �������� �־� �� ����(��ġ)�� ������ ��ġ<--������ ���Ѵ�.
        Vector2 newUv2 = Vector2.Lerp(mLtUV_1, mRtUV_1, tNormalizedDistance);
        Vector3 newNormal2 = Vector3.Lerp(mLtNormal_1, mRtNormal_1, tNormalizedDistance);
        mCreatedVertexPoints.Add(newVertex2);//���ܸ��� ���� ����


        //���� ù ��° �ﰢ��
        Add_Left_triangle(tSubMesh, newNormal1, new Vector3[] { mLtPoint_0, newVertex1, newVertex2 },
            new Vector2[] { mLtUV_0, newUv1, newUv2 },
            new Vector3[] { mLtNormal_0, newNormal1, newNormal2 });
        //���� �� ��° �ﰢ��
        Add_Left_triangle(tSubMesh, newNormal2, new Vector3[] { mLtPoint_0, mLtPoint_1, newVertex2 },
            new Vector2[] { mLtUV_0, mLtUV_1, newUv2 },
            new Vector3[] { mLtNormal_0, mLtNormal_1, newNormal2 });

        //������ ù ��° �ﰢ��
        Add_Right_triangle(tSubMesh, newNormal1, new Vector3[] { mRtPoint_0, newVertex1, newVertex2 },
            new Vector2[] { mRtUV_0, newUv1, newUv2 },
            new Vector3[] { mRtNormal_0, newNormal1, newNormal2 });
        //������ �� ��° �ﰢ��
        Add_Right_triangle(tSubMesh, newNormal2, new Vector3[] { mRtPoint_0, mRtPoint_1, newVertex2 },
            new Vector2[] { mRtUV_0, mLtUV_1, newUv2 },
            new Vector3[] { mRtNormal_0, mLtNormal_1, newNormal2 });




    }



    //���� �޽��� ���� �ε��� ���� ����
    static void Add_Left_triangle(int tSubMesh, Vector3 faceNormal, Vector3[] points, Vector2[] uvs, Vector3[] normals)
    {

        int p_0 = 0;
        int p_1 = 1;
        int p_2 = 2;
        //���� ���� ���ϱ� 
        Vector3 calculated_normal = Vector3.Cross((points[1] - points[0]).normalized, (points[2] - points[0]).normalized);

        //���� ���� ���� ���� 
        if (Vector3.Dot(calculated_normal, faceNormal) < 0)
        {

            p_0 = 2;
            p_1 = 1;
            p_2 = 0;
        }
        //������ �����ͷ� �ϴ� �����ص� 
        left_Gather_added_Points[tSubMesh].Add(points[p_0]);
        left_Gather_added_Points[tSubMesh].Add(points[p_1]);
        left_Gather_added_Points[tSubMesh].Add(points[p_2]);

        left_Gather_added_uvs[tSubMesh].Add(uvs[p_0]);
        left_Gather_added_uvs[tSubMesh].Add(uvs[p_1]);
        left_Gather_added_uvs[tSubMesh].Add(uvs[p_2]);

        left_Gather_added_normals[tSubMesh].Add(normals[p_0]);
        left_Gather_added_normals[tSubMesh].Add(normals[p_1]);
        left_Gather_added_normals[tSubMesh].Add(normals[p_2]);

    }

    static void Add_Right_triangle(int tSubMesh, Vector3 faceNormal, Vector3[] points, Vector2[] uvs, Vector3[] normals)
    {


        int p_0 = 0;
        int p_1 = 1;
        int p_2 = 2;
        //���� ���� ���ϱ� 
        Vector3 calculated_normal = Vector3.Cross((points[1] - points[0]).normalized, (points[2] - points[0]).normalized);
        //���� ���� ���� ���� 
        if (Vector3.Dot(calculated_normal, faceNormal) < 0)
        {

            p_0 = 2;
            p_1 = 1;
            p_2 = 0;
        }


        right_Gather_added_Points[tSubMesh].Add(points[p_0]);
        right_Gather_added_Points[tSubMesh].Add(points[p_1]);
        right_Gather_added_Points[tSubMesh].Add(points[p_2]);

        right_Gather_added_uvs[tSubMesh].Add(uvs[p_0]);
        right_Gather_added_uvs[tSubMesh].Add(uvs[p_1]);
        right_Gather_added_uvs[tSubMesh].Add(uvs[p_2]);

        right_Gather_added_normals[tSubMesh].Add(normals[p_0]);
        right_Gather_added_normals[tSubMesh].Add(normals[p_1]);
        right_Gather_added_normals[tSubMesh].Add(normals[p_2]);

    }



    //���ݱ��� ������ �����͵��� �������� �׸��� ������ �ִ� �޽������� ����  ���� , ������ �޽� ������ ����ȭ�Ѵ� 
    static void SetFinalArrays_withOriginals()
    {
        int tIndexP = 0;
        //�� ���� ����޽� �� ����: 0�� ����޽� , 1�� ����޽� 
        for (int tSubMesh = 0; tSubMesh < 2; tSubMesh++)
        {
            //���� ������ 0�� ����޽� 1�� ����޽� 
            for (int i = 0; i < left_Gather_subIndices[tSubMesh].Count; i++)
            {

                tIndexP = left_Gather_subIndices[tSubMesh][i];//�ε����� ��´� 

                //�ش� �ε����� ������ ��ġ����, �������� , UV���� �� �߰��Ѵ� 
                left_Final_vertices.Add(mVictimMesh.vertices[tIndexP]);
                mLtFinalSubIndices[tSubMesh].Add(left_Final_vertices.Count - 1);

                left_Final_normals.Add(mVictimMesh.normals[tIndexP]);
                left_Final_uvs.Add(mVictimMesh.uv[tIndexP]);

            }

            //������ ������ 0�� ����޽� 1�� ����޽� 
            for (int i = 0; i < right_Gather_subIndices[tSubMesh].Count; i++)
            {

                tIndexP = right_Gather_subIndices[tSubMesh][i];//�ε����� ��´� 

                //�ش� �ε����� ������ ��ġ����, �������� , UV���� �� �߰��Ѵ� 
                right_Final_vertices.Add(mVictimMesh.vertices[tIndexP]);
                mRtFinalSubIndices[tSubMesh].Add(right_Final_vertices.Count - 1);

                right_Final_normals.Add(mVictimMesh.normals[tIndexP]);
                right_Final_uvs.Add(mVictimMesh.uv[tIndexP]);

            }

        }

    }
    //���ݱ��� ������ �����͵��� �������� ���Ӱ� �����Ǵ� �ﰢ���鿡 ����  �������� ���� , ������ �޽� ������ ����ȭ�Ѵ� 
    static void AddNewTriangles_toFinalArrays()
    {

        for (int tSubMesh = 0; tSubMesh < 2; tSubMesh++)
        {

            int count = left_Final_vertices.Count;//<-----------------SetFinalArrays_withOriginals �� ������� �� �����Ϳ� ���� ���� ���� 
                                                  // add the new ones
                                                  // ���Ӱ� �߰��� ������ �� ���� ������ �Ѵ� 
            for (int i = 0; i < left_Gather_added_Points[tSubMesh].Count; i++)
            {

                left_Final_vertices.Add(left_Gather_added_Points[tSubMesh][i]);
                mLtFinalSubIndices[tSubMesh].Add(i + count);

                left_Final_uvs.Add(left_Gather_added_uvs[tSubMesh][i]);
                left_Final_normals.Add(left_Gather_added_normals[tSubMesh][i]);

            }

            count = right_Final_vertices.Count;//<-----------------SetFinalArrays_withOriginals �� ������� �� �����Ϳ� ���� ���� ���� 

            for (int i = 0; i < right_Gather_added_Points[tSubMesh].Count; i++)
            {

                right_Final_vertices.Add(right_Gather_added_Points[tSubMesh][i]);
                mRtFinalSubIndices[tSubMesh].Add(i + count);

                right_Final_uvs.Add(right_Gather_added_uvs[tSubMesh][i]);
                right_Final_normals.Add(right_Gather_added_normals[tSubMesh][i]);

            }
        }

    }
    //���ܸ��� ä���.
    static void MakeCaps()
    {

    }


}
