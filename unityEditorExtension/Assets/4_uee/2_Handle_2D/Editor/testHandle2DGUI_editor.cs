using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;//<--

//씬뷰에 2D GUI를 표시하는 것이다.

[CustomEditor(typeof(testHandle2DGUI))]//<--
public class testHandle2DGUI_editor : Editor//<--
{
    //step_0
    //private void OnSceneGUI()//<--
    //{
    //    //2D 영역에 그리기
    //    //다음 두 함수 호출 사이에 넣어야만 한다
    //    Handles.BeginGUI();

    //    GUILayout.Button("test Button", GUILayout.Width(100.0f));

    //    Handles.EndGUI();
    //}


    int mWinId = 123456;
    Rect mRect;


    bool mIsToggle = false;

    //step_1
    //private void OnSceneGUI()//<--
    //{
    //    //2D 영역에 그리기
    //    //다음 두 함수 호출 사이에 넣어야만 한다
    //    Handles.BeginGUI();

    //    mRect = GUILayout.Window(mWinId, mRect,
    //        (id) =>
    //        {
    //            EditorGUILayout.LabelField("label test");
    //            mIsToggle = EditorGUILayout.ToggleLeft("Toggle", mIsToggle);

    //            GUILayout.Button("Test Button", GUILayout.Width(100.0f));

    //            GUI.DragWindow();
    //        },
    //        "Window",
    //        GUILayout.Width(100));


    //    Handles.EndGUI();
    //}

    //step_2
    private void OnSceneGUI()//<--
    {
        var t = target as testHandle2DGUI;

        Handles.BeginGUI();

        EditorGUILayout.LabelField(t.mString, EditorStyles.helpBox, GUILayout.Width(300));


        Handles.EndGUI();
    }
}
