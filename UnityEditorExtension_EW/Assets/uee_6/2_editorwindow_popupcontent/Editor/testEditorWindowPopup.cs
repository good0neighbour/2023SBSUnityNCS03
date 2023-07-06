using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class testEditorWindowPopup : EditorWindow
{
    [MenuItem("Window/show testEditorWindowPopup")]
    static void Open()
    {
        GetWindow<testEditorWindowPopup>(typeof(SceneView));
    }

    //UI�� �ܰ� �����
    private void OnGUI()
    {
        EditorGUILayout.LabelField("This is popup Window.", EditorStyles.boldLabel);

        if (GUILayout.Button("Popup Content", GUILayout.Width(150.0f)))
        {
            //PopupWindow.Show(,);
        }
    }
}
