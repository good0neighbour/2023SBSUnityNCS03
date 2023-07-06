using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class testEditorWindowShow_3 : EditorWindow
{
    //static testEditorWindowShow_3 mWindow;

    [MenuItem("Window/show testEditorWindowShow_3")]
    static void Open()
    {
        //공식젇인 기능은 아니다.
        //SceneView가 있는 탭에 보여진다.
        GetWindow<testEditorWindowShow_3>(typeof(SceneView));
    }
}
