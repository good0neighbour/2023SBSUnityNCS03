using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuDeformMesh : MonoBehaviour
{
    MeshFilter mMeshFilter = null;

    //원래 메쉬(정점의 집합)를 변형하여 새로운 메쉬(정점의 집합)을 만들고
    //이를 메쉬 필터에 설정하여
    //메쉬 변형을 표현할 것이다
    Vector3[] mOriginVerts = null;
    Vector3[] mNewVerts = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
