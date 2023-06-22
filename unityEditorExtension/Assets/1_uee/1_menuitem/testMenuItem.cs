using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
/*
    상단메뉴 추가 attribute

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

    //이 카테고리에 속한 다른 메뉴의 가장 큰 우선순위 수치(2)와 11이상 차이나면 구분선이 생긴다
    [MenuItem("RyuMenu/testMenu_2", false, 13)]
    static void testMenu_2()
    {
        Debug.Log("testMenu_2");
    }
}
