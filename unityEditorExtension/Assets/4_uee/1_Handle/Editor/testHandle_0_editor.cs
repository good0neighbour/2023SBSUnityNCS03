using System.Collections;
using System.Collections.Generic;
using UnityEngine;



using UnityEditor;

/*
    Handle

    ����Scene View���� ���ӿ�����Ʈ�� ��� ���� �غ�� 3D GUI��.

*/
[CustomEditor(typeof(testHandle_0))]//<--CustomEditor, Ÿ�� Ÿ���� �ѱ�testHandle_0
public class testHandle_0_editor : Editor//<--Editor���
{
    //step_0
    //private void OnSceneGUI()
    //{
    //    //'���信�� �ƹ� �ڵ� ������ ������� �ʰڴ�'�� ����
    //    Tools.current = Tool.None;
    //}

    //step_1
    private void OnSceneGUI()
    {
        //�̵� �� �ڵ�

        //'���信�� �ƹ� �ڵ� ������ ������� �ʰڴ�'�� ����
        Tools.current = Tool.None;

        var tComponent = target as testHandle_0;

        //���ϰ����� �������� ������ �̵� �Ұ�
        //Handles.PositionHandle(tCompoment.transform.position, tCompoment.transform.rotation);

        //�̵�����
        tComponent.transform.position = Handles.PositionHandle(tComponent.transform.position, tComponent.transform.rotation);


        //ȸ��Ʋ �ڵ�
        tComponent.transform.rotation = Handles.RotationHandle(tComponent.transform.rotation, tComponent.transform.position);

        //������ �� �ڵ�
        tComponent.transform.localScale= Handles.ScaleHandle(tComponent.transform.localScale, tComponent.transform.position, tComponent.transform.rotation);
    }
}
