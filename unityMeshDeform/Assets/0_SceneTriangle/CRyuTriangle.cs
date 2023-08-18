using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuTriangle : MonoBehaviour
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
        mVertices = new Vector3[3];

        //유니티는 왼속 좌표계를 사용한다. CW를 전면으로 한다.
        mVertices[0] = new Vector3(-1f, 0f, 0f);
        mVertices[1] = new Vector3(0f, 1f, 0f);
        mVertices[2] = new Vector3(0f, 0f, 0f);

        //메쉬의 정점 정보 설정
        mMesh.vertices = mVertices;

        //인덱스 설정
        mIndex = new int[3];
        mIndex[0] = 0;
        mIndex[1] = 1;
        mIndex[2] = 2;

        //인덱스를 이용하여 삼각형을 구축하도록 설정한다.
        mMesh.triangles = mIndex;


        //정점마다의 법선정보(normal vector)를 준비하자.
        Vector3[] tNormals = new Vector3[mVertices.Length];//정점 개수만큼 준비
        for (int ti = 0; ti < mVertices.Length; ++ti)
        {
            tNormals[ti].x = 0f;
            tNormals[ti].y = 0f;
            tNormals[ti].z = -1f;
        }
        //메쉬에 법선정보를 설정
        mMesh.normals = tNormals;




        Material tMtl = gameObject.GetComponent<MeshRenderer>().material;
        //위에서 만든 머티리얼을 메쉬 렌더러의 머티리얼에 설정한다.
        tMtl = tMaterials[0];
        tMtl.color = Color.white;//색상설정

        //메쉬 필터에 메쉬 설정
        mMeshFilter.mesh = mMesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
