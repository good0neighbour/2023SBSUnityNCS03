/*
    ����Ƽ ������ Ȯ�� ��� �߿���
    '�ν����Ϳ� ǥ��'�Ǵ�
    '������Ʈ'�� '�ܰ�'�� ��������ִ� ����� �����Ѵ�

    �� �߿� �ϳ���
    CustomEditor��.


    <-- �̰��� '������Ʈ ����'�� ����ȴ�.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(CUnit))]//<--CustomEditor�Ӽ�, Ÿ�� Ÿ���� �˷��ش�
public class CUnitInspector : Editor//<--���
{
    CUnit mpUnit = null;    //<--Ÿ�� Ÿ�Կ� ���� ������ �ϳ� ����

    private void OnEnable()
    {
        mpUnit = this.target as CUnit;  //<-- Ÿ���� ��´�
    }

    //�ν����Ϳ� ǥ�õǴ� ������Ʈ�� �ܰ��� �� �̺�Ʈ �Լ��� Ŀ���͸���¡�Ѵ�
    public override void OnInspectorGUI()
    {
        serializedObject.Update();//����ȭ ����� ����

        base.OnInspectorGUI();  //�θ�Ŭ����Editor�� OnInspectorGUI�� ȣ��

        //Ŀ���͸���¡, ������Ƽ �ܰ� �ۼ� �׸��� ��ư �߰�
        EditorGUILayout.LabelField("AP", mpUnit.mAP.ToString());

        if (GUILayout.Button("Random mEndurance"))
        {
            mpUnit.mEndurance = Random.Range(0, 99);
        }
        if (GUILayout.Button("Random mStr"))
        {
            mpUnit.mStr = Random.Range(0, 9);
        }



        //����ȭ ����� �̿��Ͽ� ����� �ܰ��� ����
        serializedObject.ApplyModifiedProperties();
    }

    public override bool HasPreviewGUI()//<--������ ǥ�ø� ���� �غ�� �̺�Ʈ �Լ�
    {
        //return base.HasPreviewGUI();
        return true;//<--'������' ǥ�� ������ true
    }

    public override GUIContent GetPreviewTitle()
    {
        //return base.GetPreviewTitle();
        return new GUIContent("unit stats");
    }

    public override void OnPreviewSettings()
    {
        base.OnPreviewSettings();

        //UI�� ��Ÿ���� ����
        //GUIStyle tPreLabel = new GUIStyle("preview label");
        //GUIStyle tPreButton = new GUIStyle("preview button");

        ////UI����
        GUILayout.Label("Label test", GUIStyle.none);
        GUILayout.Button("Button test", GUIStyle.none);
    }
    public override void OnPreviewGUI(Rect r, GUIStyle background)
    {
        base.OnPreviewGUI(r, background);

        GUI.Box(r, "AP��������:\nmBaseAP + Mathf.FloorToInt(mBaseAP * (mEndurance + mStr - 8) / 16)");
    }


}
