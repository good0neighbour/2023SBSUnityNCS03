using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class CRyuTestPrefab : MonoBehaviour
{
    public int mTest = 0;

    //���Ǻ� ������
    //����Ƽ ������ �󿡼���� �� �ڵ� ������ �������Ѵ�
#if UNITY_EDITOR
    [MenuItem("RyuMenu/make CRyuTestPrefab")]
    static void CreateRyuTestPrefab()
    {
        //�������� ��ũ��Ʈ�� ������
        //�޸�
        //�������� ����
        GameObject tParent = new GameObject("PFRyuTesrPrefab");
        GameObject tChild = new GameObject("instBody");
        tChild.transform.SetParent(tParent.transform);
        //������Ʈ ����
        tParent.AddComponent(typeof(CRyuTestPrefab));
        tParent.AddComponent(typeof(Rigidbody));

        //��ũ
        //������ �ּ�(����)�� ����
        PrefabUtility.SaveAsPrefabAsset(tParent, "Assets/Resources/PFRyuTestPrefab.prefab");

        //�ּ� �����ͺ��̽� ����
        AssetDatabase.Refresh();
    }


#endif

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
