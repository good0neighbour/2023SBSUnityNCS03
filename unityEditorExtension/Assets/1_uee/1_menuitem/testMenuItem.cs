using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
/*
    ��ܸ޴� �߰� attribute

*/

public class testMenuItem
{
    [MenuItem("RyuMenu/testMenu_0", false, 2)]
    static void testMenu_0()
    {
        Debug.Log("testMenu_0");
    }

    [MenuItem("RyuMenu/testMenu_1", false, 1)]
    static void testMenu_1()
    {
        Debug.Log("testMenu_1");
    }

    //�� ī�װ��� ���� �ٸ� �޴��� ���� ū �켱���� ��ġ(2)�� 11�̻� ���̳��� ���м��� �����
    [MenuItem("RyuMenu/testMenu_2", false, 13)]
    static void testMenu_2()
    {
        Debug.Log("testMenu_2");
    }
}
