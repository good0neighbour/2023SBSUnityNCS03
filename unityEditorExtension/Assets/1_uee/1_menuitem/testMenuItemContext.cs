using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class testMenuItemContext
{
    //미리 정해져있는 단어다. CONTEXT, Component
    // '컴포넌트'에 문맥에 따른 메뉴를 만든다.
    // Component <-- 모든 컴포넌트에 적용된다.
    [MenuItem("CONTEXT/Component/testMenu_0")]
    static void testMenu_0()
    {
        Debug.Log("testMenu_0");
    }
    
    //컴포넌트 명을 적어주면 해당컴포넌트에만 적용

    // Transform 컴포넌트에만 적용
    [MenuItem("CONTEXT/Transform/testMenu_1")]
    static void testMenu_1()
    {
        Debug.Log("testMenu_1");
    }

    // testAttribute_4 컴포넌트에만 적용
    [MenuItem("CONTEXT/testAttribute_4/testMenu_2")]
    static void testMenu_2()
    {
        Debug.Log("testMenu_2");
    }
}
