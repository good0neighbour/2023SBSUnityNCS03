using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ '����� ���� �ּ�' �� ��ũ��Ʈ��� ����

[CreateAssetMenu(menuName = "Example/Create ExamAsset_2")]
public class ExamAsset_2 : ScriptableObject
{
    [SerializeField]
    string tString = "test";

    [SerializeField]
    int mNumber = 0;

    public float mF = 0.0f;

    public int GetNumber()
    {
        return mNumber;
    }
}
