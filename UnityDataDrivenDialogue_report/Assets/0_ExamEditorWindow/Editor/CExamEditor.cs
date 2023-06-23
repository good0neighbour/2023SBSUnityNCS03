using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class CExamEditor : EditorWindow
{
    //입력된 문자열 변수
    string mInputString = "";

    //접힘 여부
    bool mIsFoldout = false;

    //속성 attribute문법은 나중에 보겠다.
    //유니티에서 제공하는 속성을 이용하여 메뉴 등록
    [MenuItem("CExamEditor/Show CExamEditor")]
    public static void ShowRyu()
    {
        Debug.Log("CExamEditor.ShowRyu");

        //reflection문법: 실행중에 해당 타입에 대한 정보를 얻는 문법이다.
        //              typeof 실행중에 해당 타입에 대한 정보를
        EditorWindow.GetWindow(typeof(CExamTool));

        //유니티 에디터 갱신
        EditorApplication.update();
    }

    private void OnEnable()
    {
        Debug.Log("CExamEditor.OnEnable");
    }
    private void OnGUI()
    {
        //step_0
        //MonoBehaviour의 OnGUI용으로 만들어진 GUI도 여기서 사용이 가능하다.
        /*
        //label
        GUI.Label(new Rect(0f, 0f, 240f, 100f), "this is text for test OnGUI");

        //button
        if (GUI.Button(new Rect(0f, 100f, 240f, 100f), "TestButton"))
        {
            Debug.Log("click TestButton");
        }

        //input textfield
        mInputString = GUI.TextField(new Rect(0f, 200f, 240f, 100f), mInputString);
        Debug.Log(mInputString);
        */

        //step_1
        //세로 배치 레이아웃을 만든다
        EditorGUILayout.BeginVertical();
        //가로 배치 레이아웃을 만든다
        //EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("TestButton_GUILayout_0", GUILayout.Width(240f), GUILayout.Height(50f)))
        {
            Debug.Log("click TestButton_GUILayout_0");
        }

        EditorGUILayout.Space(20);
        //GUILayout.Space(20);

        if (GUILayout.Button("TestButton_GUILayout_1", GUILayout.Width(240f), GUILayout.Height(50f)))
        {
            Debug.Log("click TestButton_GUILayout_1");
        }

        EditorGUILayout.EndVertical();
        //EditorGUILayout.EndHorizontal();


        mIsFoldout = EditorGUILayout.Foldout(mIsFoldout, "Test Foldout");
        if (mIsFoldout)
        {
            EditorGUILayout.BeginVertical();
            //label
            for (int ti = 0; ti < 5; ++ti)
            {
                EditorGUILayout.LabelField($"LabelField_{ti.ToString()}", EditorStyles.helpBox);
            }
            //button
            if (GUILayout.Button("Button", EditorStyles.miniButton, GUILayout.Width(240f), GUILayout.Height(50f)))
            {
                Debug.Log("click Button");
            }
            //textfield
            mInputString = EditorGUILayout.TextField(mInputString);
            Debug.Log(mInputString);

            EditorGUILayout.EndVertical();
        }

    }

}
