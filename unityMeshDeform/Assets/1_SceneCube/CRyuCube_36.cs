using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CRyuCube_36 : MonoBehaviour
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
        mVertices = new Vector3[36];

        //����Ƽ�� �޼� ��ǥ�踦 ����Ѵ�. CW�� �������� �Ѵ�.
        //front
        mVertices[0] = new Vector3(0, 0, 0);
        mVertices[1] = new Vector3(0, 1, 0);
        mVertices[2] = new Vector3(1, 1, 0);

        mVertices[3] = new Vector3(0, 0, 0);
        mVertices[4] = new Vector3(1, 1, 0);
        mVertices[5] = new Vector3(1, 0, 0);

        //right
        mVertices[6] = new Vector3(1, 0, 0);
        mVertices[7] = new Vector3(1, 1, 0);
        mVertices[8] = new Vector3(1, 1, 1);

        mVertices[9] = new Vector3(1, 0, 0);
        mVertices[10] = new Vector3(1, 1, 1);
        mVertices[11] = new Vector3(1, 0, 1);

        //left
        mVertices[12] = new Vector3(0, 0, 0);
        mVertices[13] = new Vector3(0, 1, 1);
        mVertices[14] = new Vector3(0, 1, 0);

        mVertices[15] = new Vector3(0, 0, 0);
        mVertices[16] = new Vector3(0, 0, 1);
        mVertices[17] = new Vector3(0, 1, 1);


        //back
        mVertices[18] = new Vector3(0, 0, 1);
        mVertices[19] = new Vector3(1, 1, 1);
        mVertices[20] = new Vector3(0, 1, 1);

        mVertices[21] = new Vector3(0, 0, 1);
        mVertices[22] = new Vector3(1, 0, 1);
        mVertices[23] = new Vector3(1, 1, 1);


        //bottom
        mVertices[24] = new Vector3(0, 0, 0);
        mVertices[25] = new Vector3(1, 0, 0);
        mVertices[26] = new Vector3(0, 0, 1);

        mVertices[27] = new Vector3(0, 0, 1);
        mVertices[28] = new Vector3(1, 0, 0);
        mVertices[29] = new Vector3(1, 0, 1);

        //top
        mVertices[30] = new Vector3(0, 1, 0);
        mVertices[31] = new Vector3(0, 1, 1);
        mVertices[32] = new Vector3(1, 1, 1);

        mVertices[33] = new Vector3(0, 1, 0);
        mVertices[34] = new Vector3(1, 1, 1);
        mVertices[35] = new Vector3(1, 1, 0);

        //�޽��� ���� ���� ����
        mMesh.vertices = mVertices;

        //�ε��� ����
        mIndex = new int[36];
        mIndex[0] = 0;
        mIndex[1] = 1;
        mIndex[2] = 2;

        mIndex[3] = 3;
        mIndex[4] = 4;
        mIndex[5] = 5;

        mIndex[6] = 6;
        mIndex[7] = 7;
        mIndex[8] = 8;

        mIndex[9] = 9;
        mIndex[10] = 10;
        mIndex[11] = 11;

        mIndex[12] = 12;
        mIndex[13] = 13;
        mIndex[14] = 14;

        mIndex[15] = 15;
        mIndex[16] = 16;
        mIndex[17] = 17;

        mIndex[18] = 18;
        mIndex[19] = 19;
        mIndex[20] = 20;

        mIndex[21] = 21;
        mIndex[22] = 22;
        mIndex[23] = 23;

        mIndex[24] = 24;
        mIndex[25] = 25;
        mIndex[26] = 26;

        mIndex[27] = 27;
        mIndex[28] = 28;
        mIndex[29] = 29;

        mIndex[30] = 30;
        mIndex[31] = 31;
        mIndex[32] = 32;

        mIndex[33] = 33;
        mIndex[34] = 34;
        mIndex[35] = 35;

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
