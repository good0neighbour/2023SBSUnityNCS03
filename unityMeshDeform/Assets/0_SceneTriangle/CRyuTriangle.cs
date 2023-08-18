using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuTriangle : MonoBehaviour
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
        mVertices = new Vector3[3];

        //����Ƽ�� �޼� ��ǥ�踦 ����Ѵ�. CW�� �������� �Ѵ�.
        mVertices[0] = new Vector3(-1f, 0f, 0f);
        mVertices[1] = new Vector3(0f, 1f, 0f);
        mVertices[2] = new Vector3(0f, 0f, 0f);

        //�޽��� ���� ���� ����
        mMesh.vertices = mVertices;

        //�ε��� ����
        mIndex = new int[3];
        mIndex[0] = 0;
        mIndex[1] = 1;
        mIndex[2] = 2;

        //�ε����� �̿��Ͽ� �ﰢ���� �����ϵ��� �����Ѵ�.
        mMesh.triangles = mIndex;


        //���������� ��������(normal vector)�� �غ�����.
        Vector3[] tNormals = new Vector3[mVertices.Length];//���� ������ŭ �غ�
        for (int ti = 0; ti < mVertices.Length; ++ti)
        {
            tNormals[ti].x = 0f;
            tNormals[ti].y = 0f;
            tNormals[ti].z = -1f;
        }
        //�޽��� ���������� ����
        mMesh.normals = tNormals;




        Material tMtl = gameObject.GetComponent<MeshRenderer>().material;
        //������ ���� ��Ƽ������ �޽� �������� ��Ƽ���� �����Ѵ�.
        tMtl = tMaterials[0];
        tMtl.color = Color.white;//������

        //�޽� ���Ϳ� �޽� ����
        mMeshFilter.mesh = mMesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
