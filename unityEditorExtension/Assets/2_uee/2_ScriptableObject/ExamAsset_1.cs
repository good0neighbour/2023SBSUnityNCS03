using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

/*

����� ���:

ScriptableObject�� ��ӹ��� Ŭ������ ��ũ��Ʈ�� �ۼ��ϰ�
CreateInstance �Լ��� �̿��Ͽ� �޸𸮿� �ν��Ͻ� ���� ��
AssetDatabase�� CreateAsset�Լ��� �̿��Ͽ� �ּ����� �����ϰ�
Refresh�Ѵ�.

*/


public class ExamAsset_1 : ScriptableObject//<--���
{
    public int mTest = 999;

#if UNITY_EDITOR
    [MenuItem("Example/Create ExamAsset_1")]
    static void CreateExamAsset_1()
    {
        var tExamAsset_1 = CreateInstance<ExamAsset_1>();  //�޸𸮿� �ν��Ͻ��� �ϳ� �����

        AssetDatabase.CreateAsset(tExamAsset_1, "Assets/ExamAsset_1.asset");//��ũ�� �ּ� ���Ϸ� �����Ѵ�
        AssetDatabase.Refresh();    //�ּµ����ͺ��̽� ����
    }
#endif
}
