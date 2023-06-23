using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class CRyuTestPrefab : MonoBehaviour
{
    public int mTest = 0;

    //조건부 컴파일
    //유니티 에디터 상에서라면 이 코드 영역을 컴파일한다
#if UNITY_EDITOR
    [MenuItem("RyuMenu/make CRyuTestPrefab")]
    static void CreateRyuTestPrefab()
    {
        //프리팹을 스크립트로 만들자
        //메모리
        //계층구조 제작
        GameObject tParent = new GameObject("PFRyuTesrPrefab");
        GameObject tChild = new GameObject("instBody");
        tChild.transform.SetParent(tParent.transform);
        //컴포넌트 부착
        tParent.AddComponent(typeof(CRyuTestPrefab));
        tParent.AddComponent(typeof(Rigidbody));

        //디스크
        //프리팹 애셋(파일)로 저장
        PrefabUtility.SaveAsPrefabAsset(tParent, "Assets/Resources/PFRyuTestPrefab.prefab");

        //애셋 데이터베이스 갱신
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
