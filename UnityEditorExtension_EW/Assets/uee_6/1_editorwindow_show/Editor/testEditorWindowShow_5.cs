using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class testEditorWindowShow_5 : EditorWindow
{
    static testEditorWindowShow_5 mWindow = null;

    [MenuItem("Window/show testEditorWindowShow_5")]
    static void Open()
    {
        if (null == mWindow)
        {
            mWindow = CreateInstance<testEditorWindowShow_5>();

            mWindow.position = new Rect(100.0f, 100.0f, 150.0f, 150.0f);
        }

        mWindow.ShowPopup();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("TEST BUTTON"))
        {
            mWindow.Close();
        }
    }
}
