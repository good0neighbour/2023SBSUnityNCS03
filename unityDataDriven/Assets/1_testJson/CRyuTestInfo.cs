using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    JsonUtility�� ����ϱ� ���� ������ Ŭ���� ��Ģ

    i) json�������� Ű�� �̸��� �Ȱ��� �����̸��� �����.
    ii) �ش� Ŭ�������� ����ȭ�� �����ؾ߸� �Ѵ�
        [Serializable]

*/


public class CRyuTestInfo
{
    public string mName = "";

    public int mLevel = 0;
    public int mExp = 0;

    public List<string> mStringList = null;
}
