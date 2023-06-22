using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class testMenuItemContext
{
    //�̸� �������ִ� �ܾ��. CONTEXT, Component
    // '������Ʈ'�� ���ƿ� ���� �޴��� �����.
    // Component <-- ��� ������Ʈ�� ����ȴ�.
    [MenuItem("CONTEXT/Component/testMenu_0")]
    static void testMenu_0()
    {
        Debug.Log("testMenu_0");
    }
    
    //������Ʈ ���� �����ָ� �ش�������Ʈ���� ����

    // Transform ������Ʈ���� ����
    [MenuItem("CONTEXT/Transform/testMenu_1")]
    static void testMenu_1()
    {
        Debug.Log("testMenu_1");
    }

    // testAttribute_4 ������Ʈ���� ����
    [MenuItem("CONTEXT/testAttribute_4/testMenu_2")]
    static void testMenu_2()
    {
        Debug.Log("testMenu_2");
    }
}
