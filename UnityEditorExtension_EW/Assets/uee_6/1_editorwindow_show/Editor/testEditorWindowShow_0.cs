using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class testEditorWindowShow_0 : EditorWindow
{
    [MenuItem("Window/show testEditorWindowShow_0")]
    static void Open()
    {
        var t = CreateInstance<testEditorWindowShow_0>();
        t.Show();
    }
}
