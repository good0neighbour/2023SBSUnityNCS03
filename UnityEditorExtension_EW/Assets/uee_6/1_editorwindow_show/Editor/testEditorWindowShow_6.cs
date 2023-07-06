using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class testEditorWindowShow_6 : EditorWindow
{
    static testEditorWindowShow_6 mWindow = null;

    [MenuItem("Window/show testEditorWindowShow_6")]
    static void Open()
    {
        if (null == mWindow)
        {
            mWindow = CreateInstance<testEditorWindowShow_6>();

            mWindow.position = new Rect(100.0f, 100.0f, 150.0f, 150.0f);
        }

        //focus�� �������, �ڵ����� �����찡 �Ҹ�ȴ�.
        //mWindow.ShowPopup();
        mWindow.ShowAuxWindow();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("TEST BUTTON"))
        {
            mWindow.Close();
        }
    }
}
