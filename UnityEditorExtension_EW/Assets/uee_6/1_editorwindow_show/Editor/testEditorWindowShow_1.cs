using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class testEditorWindowShow_1 : EditorWindow
{
    [MenuItem("Window/show testEditorWindowShow_1")]
    static void Open()
    {
        GetWindow<testEditorWindowShow_1>().Show();
    }
}
