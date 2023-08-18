using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CRyuCube_24 : MonoBehaviour
{
    Vector3[] mVertices = null;     //정점의 정보
    int[] mIndex = null;            //인덱스의 정보

    Mesh mMesh = null;              //메쉬 객체
    MeshFilter mMeshFilter = null;  //메쉬 필터 객체



    // Start is called before the first frame update
    void Start()
    {
        //실행중에 컴포넌트를 조립한다.
        gameObject.AddComponent<MeshRenderer>();
        mMeshFilter = gameObject.AddComponent<MeshFilter>();

        //텍스처와 머티리얼 객체를 준비한다.
        Texture2D tTexture = new Texture2D(32, 32);
        Material[] tMaterials = new Material[1];
        tMaterials[0] = new Material(Shader.Find("Standard"));
        tMaterials[0].mainTexture = tTexture;



        mMesh = new Mesh();
        //삼각형은 정점 3개로 이루어진 도형이다.
        mVertices = new Vector3[24];

        //유니티는 왼속 좌표계를 사용한다. CW를 전면으로 한다.
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

        //메쉬의 정점 정보 설정
        mMesh.vertices = mVertices;

        //인덱스 설정
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

        //인덱스를 이용하여 삼각형을 구축하도록 설정한다.
        mMesh.triangles = mIndex;


        //정점마다의 법선정보(normal vector)를 준비하자.
        Vector3[] tNormals = new Vector3[mVertices.Length];//정점 개수만큼 준비
        for (int ti = 0; ti < mVertices.Length; ti += 3)
        {
            //법선벡터를 구해, 한 평면에 속한 정점 세 개의, 정점마다의 법선벡터로 설정함
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
        //메쉬에 법선정보를 설정
        mMesh.normals = tNormals;



        tMaterials[0].color = Color.red;//Color.white;//색상설정
        tMaterials[0].name = "ryu";
        //위에서 만든 머티리얼을 메쉬 렌더러의 머티리얼에 설정한다.
        gameObject.GetComponent<MeshRenderer>().material = tMaterials[0];

        //메쉬 필터에 메쉬 설정
        mMeshFilter.mesh = mMesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
