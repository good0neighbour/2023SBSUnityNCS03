using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//유니티 상에서 다루는 모든 Object는 SerializedObject를 기반으로 한다.
//( 직렬화 기능을 가지는 오브젝트 )

public class CTestSerializedObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //하얀색 기본 텍스쳐로 SerializedObject를 생성
        var tSO = new SerializedObject(Texture2D.whiteTexture);

        var tPop = tSO.GetIterator();
        while(tPop.NextVisible(true))
        {
            Debug.Log(tPop.propertyPath);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
