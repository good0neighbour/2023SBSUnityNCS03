using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class testEditorWindowShow_4 : EditorWindow
{
    static testEditorWindowShow_4 mWindow = null;

    [MenuItem("Window/show testEditorWindowShow_4")]
    static void Open()
    {
        if (null == mWindow)
        {
            mWindow = CreateInstance<testEditorWindowShow_4>();
        }

        mWindow.ShowUtility();
    }
}
