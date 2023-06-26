using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
