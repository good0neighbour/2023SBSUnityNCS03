using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//유니티 상에서 다루는 모든 Object는 SerializedObject를 기반으로 한다.
//( 직렬화 기능을 가지는 오브젝트 )

/*

SerializedObject는 유니티에서 제공하는 오브젝트로서
Serialize기능을 제공하는 클래스다.

유니티 상에서 다루는 오브젝트는 모두 SerializedObject를 기반으로 한다.
즉, 유니티 상에서 다루는 오브젝트는 모두 Serialize 기능이 있다.

유니티의 리소스 파일을 통칭하는 Asset도 마찬자기다.
<-- 이미지파일을 임포트import하여 애셋화하면
해당 애셋에서도 이러한 특징을 관찰할 수 있다.

meta파일에는 Asset의 부가적인 정보를 기록하고 있다.
메모리 상에 '애셋(오브젝트의 형태)'는 디스크 상에 '애셋파일'과 'meta파일'로 저장되게 된다.

*/

public class CTestSerializedObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //하얀색 기본 텍스쳐로 SerializedObject를 생성
        var tSO = new SerializedObject(Texture2D.whiteTexture);

        //내용을 살펴보기 위해 순회
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
