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
        //���Ġ��� ����� �ƴϴ�.
        //SceneView�� �ִ� �ǿ� ��������.
        GetWindow<testEditorWindowShow_3>(typeof(SceneView));
    }
}
