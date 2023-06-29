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
        ////�������� �������� �׸���.<--3D GUI�� �ڵ��� Ŀ�����ϰ� ���۰����ϴ�
        //Handles.DrawAAPolyLine(tComponent.mVertexs);


        //step_1
        var tComponent = target as testHandle_2;

        Handles.color = Color.red;
        //PolyLine���� �׸��� �� ����ϴ� ������ ������ ���� Positionhandle�� �����ϰ� ��ġ ������ �����ϰ� �Ͽ���
        for (int ti = 0; ti < tComponent.mVertexs.Length; ++ti)
        {
            tComponent.mVertexs[ti] = Handles.PositionHandle(tComponent.mVertexs[ti], Quaternion.identity);
        }
        //������ ������ ��ġ���� �ݿ��Ͽ� �׸���
        Handles.DrawAAPolyLine(tComponent.mVertexs);

    }
}
