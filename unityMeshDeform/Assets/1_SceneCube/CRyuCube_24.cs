using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CRyuCube_24 : MonoBehaviour
{
    Vector3[] mVertices = null;     //������ ����
    int[] mIndex = null;            //�ε����� ����

    Mesh mMesh = null;              //�޽� ��ü
    MeshFilter mMeshFilter = null;  //�޽� ���� ��ü



    // Start is called before the first frame update
    void Start()
    {
        //�����߿� ������Ʈ�� �����Ѵ�.
        gameObject.AddComponent<MeshRenderer>();
        mMeshFilter = gameObject.AddComponent<MeshFilter>();

        //�ؽ�ó�� ��Ƽ���� ��ü�� �غ��Ѵ�.
        Texture2D tTexture = new Texture2D(32, 32);
        Material[] tMaterials = new Material[1];
        tMaterials[0] = new Material(Shader.Find("Standard"));
        tMaterials[0].mainTexture = tTexture;



        mMesh = new Mesh();
        //�ﰢ���� ���� 3���� �̷���� �����̴�.
        mVertices = new Vector3[24];

        //����Ƽ�� �޼� ��ǥ�踦 ����Ѵ�. CW�� �������� �Ѵ�.
        //front
        mVertices[0] = new Vector3(0, 0, 0);
        mVertices[1] = new Vector3(0, 1, 0);
        mVertices[2] = new Vector3(1, 1, 0);
        mVertices[3] = new Vector3(1, 0, 0);

        //right
        mVertices[4] = new Vector3(1, 0, 0);
        mVertices[5] = new Vector3(1, 1, 0);
        mVertices[6] = new Vector3(1, 1, 1);
        mVertices[7] = new Vector3(1, 0, 1);

        //left
        mVertices[8] = new Vector3(0, 0, 0);
        mVertices[9] = new Vector3(0, 1, 1);
        mVertices[10] = new Vector3(0, 1, 0);
        mVertices[11] = new Vector3(0, 0, 1);

        //back
        mVertices[12] = new Vector3(0, 0, 1);
        mVertices[13] = new Vector3(1, 1, 1);
        mVertices[14] = new Vector3(0, 1, 1);
        mVertices[15] = new Vector3(1, 0, 1);

        //bottom
        mVertices[16] = new Vector3(0, 0, 0);
        mVertices[17] = new Vector3(1, 0, 0);
        mVertices[18] = new Vector3(0, 0, 1);
        mVertices[19] = new Vector3(1, 0, 1);

        //top
        mVertices[20] = new Vector3(0, 1, 0);
        mVertices[21] = new Vector3(0, 1, 1);
        mVertices[22] = new Vector3(1, 1, 1);
        mVertices[23] = new Vector3(1, 1, 0);

        //�޽��� ���� ���� ����
        mMesh.vertices = mVertices;

        //�ε��� ����
        mIndex = new int[36];
        mIndex[0] = 0;
        mIndex[1] = 1;
        mIndex[2] = 2;

        mIndex[3] = 0;
        mIndex[4] = 2;
        mIndex[5] = 3;

        mIndex[6] = 4;
        mIndex[7] = 5;
        mIndex[8] = 6;

        mIndex[9] = 4;
        mIndex[10] = 6;
        mIndex[11] = 7;

        //left
        mIndex[12] = 8;
        mIndex[13] = 9;
        mIndex[14] = 10;

        mIndex[15] = 8;
        mIndex[16] = 11;
        mIndex[17] = 9;

        mIndex[18] = 12;
        mIndex[19] = 13;
        mIndex[20] = 14;

        mIndex[21] = 12;
        mIndex[22] = 15;
        mIndex[23] = 13;

        mIndex[24] = 16;
        mIndex[25] = 17;
        mIndex[26] = 18;

        mIndex[27] = 17;
        mIndex[28] = 19;
        mIndex[29] = 18;

        mIndex[30] = 20;
        mIndex[31] = 21;
        mIndex[32] = 22;

        mIndex[33] = 22;
        mIndex[34] = 23;
        mIndex[35] = 20;

        //�ε����� �̿��Ͽ� �ﰢ���� �����ϵ��� �����Ѵ�.
        mMesh.triangles = mIndex;


        //���������� ��������(normal vector)�� �غ�����.
        Vector3[] tNormals = new Vector3[mVertices.Length];//���� ������ŭ �غ�
        for (int ti = 0; ti < mVertices.Length; ti += 3)
        {
            //�������͸� ����, �� ��鿡 ���� ���� �� ����, ���������� �������ͷ� ������
            Vector3 tA = mVertices[ti + 1] - mVertices[ti];
            Vector3 tB = mVertices[ti + 2] - mVertices[ti + 1];
            Vector3 tCross = Vector3.Cross(tA, tB);

            tNormals[ti].x = tCross.x;
            tNormals[ti].y = tCross.y;
            tNormals[ti].z = tCross.z;

            tNormals[ti + 1].x = tCross.x;
            tNormals[ti + 1].y = tCross.y;
            tNormals[ti + 1].z = tCross.z;

            tNormals[ti + 2].x = tCross.x;
            tNormals[ti + 2].y = tCross.y;
            tNormals[ti + 2].z = tCross.z;
        }
        //�޽��� ���������� ����
        mMesh.normals = tNormals;



        tMaterials[0].color = Color.red;//Color.white;//������
        tMaterials[0].name = "ryu";
        //������ ���� ��Ƽ������ �޽� �������� ��Ƽ���� �����Ѵ�.
        gameObject.GetComponent<MeshRenderer>().material = tMaterials[0];

        //�޽� ���Ϳ� �޽� ����
        mMeshFilter.mesh = mMesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
