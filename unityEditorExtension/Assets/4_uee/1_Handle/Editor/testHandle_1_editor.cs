using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(testHandle_1))]
public class testHandle_1_editor : Editor
{
    private void OnSceneGUI()
    {
        Tools.current = Tool.None;

        //step_0
        //Slider: 화살표로 방향을 포시해준다
        //var tComponent = target as testHandle_1;
        //Handles.Slider(tComponent.transform.position, tComponent.transform.forward);

        //for (int ti = 0; ti < 3; ++ti)
        //{
        //    Vector3 tPos = tComponent.transform.position + ti * tComponent.transform.forward;

        //    Handles.Slider(tPos, tComponent.transform.forward);
        //}


        //step_1
        //var tComponent = target as testHandle_1;

        ////x : r
        ////y : g
        ////z : b
        ////w : a

        ////Handles.color = Color.red;
        //Handles.color = Handles.zAxisColor;
        //Handles.Slider(tComponent.transform.position, tComponent.transform.forward);

        //setp_2
        //var tComponent = target as testHandle_1;
        //Handles.color = Handles.xAxisColor;
        //tComponent.transform.position = Handles.Slider(tComponent.transform.position, tComponent.transform.forward);

        //step_3
        var tComponent = target as testHandle_1;
        Handles.color = Color.black;
        //Handles.Slider(tComponent.transform.position, tComponent.transform.forward, 3f, Handles.ArrowHandleCap, 1.0f);

        Handles.Slider(tComponent.transform.position, tComponent.transform.forward, 3f, Handles.CircleHandleCap, 1.0f);
        //Handles.Slider(tComponent.transform.position, tComponent.transform.forward, 3f, Handles.ConeHandleCap, 1.0f);
    }
}
