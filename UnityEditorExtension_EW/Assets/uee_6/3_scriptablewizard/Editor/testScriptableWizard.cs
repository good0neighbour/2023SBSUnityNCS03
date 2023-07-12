using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class testScriptableWizard : ScriptableWizard
{
    [SerializeField]
    string mGameObjectName = "NewGO";
    [SerializeField]
    float mIntensity = 5.0f;
    [SerializeField]
    Color mColor = Color.red;



    [MenuItem("Window/show testScriptableWizard")]
    static void Open()
    {
        //DisplayWizard<testScriptableWizard>("title: testScriptableWizard", "Create");

        //DisplayWizard<testScriptableWizard>("title: testScriptableWizard", "Create", "Find");
        DisplayWizard<testScriptableWizard>("title: testScriptableWizard", "Create", "Apply");
    }

    private void OnWizardCreate()
    {
        GameObject tGO = new GameObject("test");
        Light tLight = tGO.AddComponent<Light>();//Light컴포넌트 추가
        tLight.intensity = 10.0f;
        tLight.color = Color.blue;

        Debug.Log("OnWizardCreate");
    }

    private void OnWizardOtherButton()
    {
        //항이어라키에서 임의의 게임오브젝트 검색
        //GameObject tGO = GameObject.Find("test_0");
        //if (null != tGO)
        //{
        //    Debug.Log("Success Find");
        //    //컴포넌트 검색
        //    Light tLight = tGO.GetComponent<Light>();

        //    if (null != tLight)
        //    {
        //        Debug.Log("success Get");
        //    }
        //}
        //else
        //{
        //    Debug.Log("Failure Find");
        //}


        //임의의 값 설정
        //선택한 게임오브젝트에 대하여
        if (null != Selection.activeTransform)
        {
            Light tLight = Selection.activeTransform.GetComponent<Light>();

            if (null != tLight)
            {
                tLight.name = mGameObjectName;//"test_light";
                tLight.intensity = mIntensity;//12f;
                tLight.color = mColor;//Color.yellow;
            }
        }
    }

    //필드의 수치 변경 후 갱신 시 호출되는 함수다.
    private void OnWizardUpdate()
    {
        helpString = $"name: {mGameObjectName}, intensity: {mIntensity.ToString()}, color: {mColor.ToString()}";
    }

    //OnGUI대신 DrawWizardGUI를 호출하여 외관을 바꾼다.
    protected override bool DrawWizardGUI()
    {
        mGameObjectName = EditorGUILayout.TextField(mGameObjectName);
        EditorGUILayout.Space(100);
        mIntensity = EditorGUILayout.FloatField(mIntensity);
        mColor = EditorGUILayout.ColorField(mColor, null);

        //true를 리턴해야만 해당 함수가 작동한다.
        return true;
    }


}
