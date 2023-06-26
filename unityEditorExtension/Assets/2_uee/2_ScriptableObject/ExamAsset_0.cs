using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    ScriptableObject Ŭ������
    '�������� ����� ���� Asset�� �ۼ�'�� �� �ִ� Ŭ������.

    <-- ����Ƽ���� �����ϹǷ� �翬�� Serialize����� ������ �ִ�.


    ����� ���:
    ScriptableObject�� ��ӹ��� Ŭ������ ��ũ��Ʈ�� �ۼ��ϰ�
    �� Ŭ������ CreateAssetMenu�Ӽ��� �����Ͽ� �������.
*/

[CreateAssetMenu(menuName = "Example/Create ExamAsset_0")]
public class ExamAsset_0 : ScriptableObject///<--���
{
    public int mA = 777;
}
