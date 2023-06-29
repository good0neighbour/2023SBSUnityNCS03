using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(testHandle_2))]
public class testHandle_2_editor : Editor
{
    private void OnSceneGUI()
    {
        //step_0
        //var tComponent = target as testHandle_2;

        //Handles.color = Color.red;
        ////라인으로 폴리곤을 그린다.<--3D GUI인 핸들을 커스텀하게 제작가능하다
        //Handles.DrawAAPolyLine(tComponent.mVertexs);


        //step_1
        var tComponent = target as testHandle_2;

        Handles.color = Color.red;
        //PolyLine으로 그리는 데 사용하는 각각의 정점에 대해 Positionhandle을 적용하고 위치 편집도 가능하게 하였다
        for (int ti = 0; ti < tComponent.mVertexs.Length; ++ti)
        {
            tComponent.mVertexs[ti] = Handles.PositionHandle(tComponent.mVertexs[ti], Quaternion.identity);
        }
        //편집된 정점의 위치값을 반영하여 그린다
        Handles.DrawAAPolyLine(tComponent.mVertexs);

    }
}
