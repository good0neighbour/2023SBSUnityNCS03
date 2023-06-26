using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


/*

    ScriptableObject�� �̿��ϸ�
    ������ ����� ���� �ּ��� ���� �� �ִ�.

    �̸��׸�
    ������ xml, json ������ ���������� �ۼ��Ͽ�
    Data Driven ������ �����ϴ� ���ø� �������µ�

    ���⿡ ���� ScriptableObject�� xml, json, ... �� ��ü�Ͽ� ����� �����ϴٴ� ���̴�.

    ���� ScriptableObject�� ����ϸ�
    ����Ƽ ������ �󿡼� �ſ� �ս��� ��ũ��Ʈ�� �̿��Ͽ� �ּ� ������ ������ �ۼ������ϴ�
        <--����Ƽ �����ͻ󿡼� ������ ������ �ִ�.

    <-- xml, json ���� �ؽ�Ʈ �����̴�
    <-- ScriptableObject�� ��ӹ��� ��ũ��Ʈ�� ����Ͽ� ���� ����� ���� �ּ��� '���̳ʸ� ����'�̴�
        <--���̳ʸ� ������ �������� ������ �ִ�.




*/

public class CLoadExamAsset : MonoBehaviour
{
    //�ش� ��ũ��Ʈ Ÿ���� �������
    ExamAsset_2 mTestData = null;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        //�̰��� ����Ƽ ������ �󿡼� �ּ� '����'�� �����Ͽ� �ۼ��� �ڵ��.
        mTestData = AssetDatabase.LoadAssetAtPath<ExamAsset_2>("Assets/Resources/ExamAsset_2.asset");//<-- full���, Ȯ���� ǥ��
#else
        //���Ӿ��� ������ �ڵ��. �׷��� ResourcesŬ������ �̿��Ͽ� �ּ��� �ε��Ͽ���
        mTestData = Resources.Load<ExamAsset_2>("ExamAsset_2");//<--�ּ��̸��� ǥ��
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
#if UNITY_EDITOR
        GUI.Label(new Rect(0f, 0f, 300f, 50f), $"In Editor: mTestAsset.mF: {mTestData.mF.ToString()}");
        GUI.Label(new Rect(0f, 50f, 300f, 50f), $"In Editor: mTestAsset.GetNumber(): {mTestData.GetNumber().ToString()}");
#else
        GUI.Label(new Rect(0f, 0f, 300f, 50f), $"In Game: mTestAsset.mF: {mTestData.mF.ToString()}");
        GUI.Label(new Rect(0f, 50f, 300f, 50f), $"In Game: mTestAsset.GetNumber(): {mTestData.GetNumber().ToString()}");
#endif
    }

}
