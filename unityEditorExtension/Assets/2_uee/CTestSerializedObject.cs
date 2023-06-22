using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//����Ƽ �󿡼� �ٷ�� ��� Object�� SerializedObject�� ������� �Ѵ�.
//( ����ȭ ����� ������ ������Ʈ )

public class CTestSerializedObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�Ͼ�� �⺻ �ؽ��ķ� SerializedObject�� ����
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
