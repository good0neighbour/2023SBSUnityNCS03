using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CRyuCube_36 : MonoBehaviour
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
        mVertices = new Vector3[36];

        //유니티는 왼속 좌표계를 사용한다. CW를 전면으로 한다.
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

        //메쉬의 정점 정보 설정
        mMesh.vertices = mVertices;

        //인덱스 설정
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
