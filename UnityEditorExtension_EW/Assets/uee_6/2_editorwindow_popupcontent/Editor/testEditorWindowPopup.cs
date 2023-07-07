using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

/*
*/

public class testEditorWindowPopup : EditorWindow
{
    testPopupContent mPopup = new testPopupContent();

    [MenuItem("Window/show testEditorWindowPopup")]
    static void Open()
    {
        GetWindow<testEditorWindowPopup>(typeof(SceneView));
    }

    //UI의 외관 만들기
    private void OnGUI()
    {
        EditorGUILayout.LabelField("This is popup Window.", EditorStyles.boldLabel);

        if (GUILayout.Button("Popup Content", GUILayout.Width(150.0f)))
        {
            var tActivatorRect = GUILayoutUtility.GetLastRect();
            PopupWindow.Show(tActivatorRect, mPopup);
        }
    }


    public class testPopupContent : PopupWindowContent
    {
        bool toggle1 = true;
        bool toggle2 = true;
        bool toggle3 = true;

        public override void OnGUI(Rect tRect)
        {
            EditorGUILayout.LabelField("This is popup Content.", EditorStyles.boldLabel);
            toggle1 = EditorGUILayout.Toggle("Toggle1", toggle1);
            toggle2 = EditorGUILayout.Toggle("Toggle2", toggle2);
            toggle3 = EditorGUILayout.Toggle("Toggle3", toggle3);

            if (true == GUILayout.Button("no function", GUILayout.Height(100)))
            {
                this.editorWindow.Close();
            }
        }

        public override void OnClose()
        {
            base.OnClose();

            Debug.Log("OnClose");
        }
    }
}
