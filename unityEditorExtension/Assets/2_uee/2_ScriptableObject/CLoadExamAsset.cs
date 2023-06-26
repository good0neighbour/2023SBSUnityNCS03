using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


/*

    ScriptableObject를 이용하면
    나만의 사용자 정의 애셋을 만들 수 있다.

    이를테면
    이전에 xml, json 등으로 파일포멧을 작성하여
    Data Driven 개념을 적용하는 예시를 보였었는데

    여기에 쓰인 ScriptableObject로 xml, json, ... 을 대체하여 사용이 가능하다는 것이다.

    또한 ScriptableObject를 사용하면
    유니티 에디터 상에서 매우 손쉽게 스크립트를 이용하여 애셋 데이터 파일을 작성가능하다
        <--유니티 에디터상에서 편집상에 잇점이 있다.

    <-- xml, json 등은 텍스트 형식이다
    <-- ScriptableObject를 상속받은 스크립트를 사용하여 만든 사용자 정의 애셋은 '바이너리 형식'이다
        <--바이너리 형식의 데이터의 잇점이 있다.




*/

public class CLoadExamAsset : MonoBehaviour
{
    //해당 스크립트 타입의 멤버변수
    ExamAsset_2 mTestData = null;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        //이것은 유니티 에디터 상에서 애셋 '파일'을 가정하여 작성한 코드다.
        mTestData = AssetDatabase.LoadAssetAtPath<ExamAsset_2>("Assets/Resources/ExamAsset_2.asset");//<-- full경로, 확장자 표기
#else
        //게임앱을 가정한 코드다. 그래서 Resources클래스를 이용하여 애셋을 로드하였다
        mTestData = Resources.Load<ExamAsset_2>("ExamAsset_2");//<--애셋이름만 표기
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
#if UNITY_EDITOR
        GUI.Label(new Rect(0f, 0f, 300f, 50f), $"In Editor: mTestAsset.mF: {mTestData.mF.ToString()}");
        GUI.Label(new Rect(0f, 50f, 300f, 50f), $"In Editor: mTestAsset.GetNumber(): {mTestData.GetNumber().ToString()}");
#else
        GUI.Label(new Rect(0f, 0f, 300f, 50f), $"In Game: mTestAsset.mF: {mTestData.mF.ToString()}");
        GUI.Label(new Rect(0f, 50f, 300f, 50f), $"In Game: mTestAsset.GetNumber(): {mTestData.GetNumber().ToString()}");
#endif
    }

}
