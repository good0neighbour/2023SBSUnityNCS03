using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

/*
    임의의 기즈모 설명 분류용을 따로 만들었다.


    DrawGizmo속성을 이용하여 기즈모를 출력할 수도 있다.

*/
public class CGizmoDesc
{
#if UNITY_EDITOR
    [DrawGizmo(GizmoType.NonSelected)]
    static void DrawGizmosNonSelected(testGizmo_1 t, GizmoType tGizmoType)
    {
        Gizmos.color = new Color(1f, 1f, 0f, 1f);//노란색//<--[0, 1]로 정규화
        Gizmos.DrawWireCube(t.transform.position, t.transform.lossyScale * 1.2f);
    }

    [DrawGizmo(GizmoType.InSelectionHierarchy)]
    static void OnDrawGizmosSelected(testGizmo_1 t, GizmoType tGizmoType)
    {
        Gizmos.color = new Color(1f, 0f, 0f, 1f);
        Gizmos.DrawWireCube(t.transform.position, t.transform.lossyScale * 1.1f);
    }

#endif
}
