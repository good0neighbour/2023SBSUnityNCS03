using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class CExamEditor : EditorWindow
{
    //�Էµ� ���ڿ� ����
    string mInputString = "";

    //���� ����
    bool mIsFoldout = false;

    //�Ӽ� attribute������ ���߿� ���ڴ�.
    //����Ƽ���� �����ϴ� �Ӽ��� �̿��Ͽ� �޴� ���
    [MenuItem("CExamEditor/Show CExamEditor")]
    public static void ShowRyu()
    {
        Debug.Log("CExamEditor.ShowRyu");

        //reflection����: �����߿� �ش� Ÿ�Կ� ���� ������ ��� �����̴�.
        //              typeof �����߿� �ش� Ÿ�Կ� ���� ������
        EditorWindow.GetWindow(typeof(CExamTool));

        //����Ƽ ������ ����
        EditorApplication.update();
    }

    private void OnEnable()
    {
        Debug.Log("CExamEditor.OnEnable");
    }
    private void OnGUI()
    {
        //step_0
        //MonoBehaviour�� OnGUI������ ������� GUI�� ���⼭ ����� �����ϴ�.
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
        //���� ��ġ ���̾ƿ��� �����
        EditorGUILayout.BeginVertical();
        //���� ��ġ ���̾ƿ��� �����
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
