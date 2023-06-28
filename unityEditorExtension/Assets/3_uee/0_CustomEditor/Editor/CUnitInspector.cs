/*
    유니티 에디터 확장 기능 중에는
    '인스펙터에 표시'되는
    '컴포넌트'의 '외관'을 변경시켜주는 기능을 제공한다

    그 중에 하나가
    CustomEditor다.


    <-- 이것은 '컴포넌트 단위'로 적용된다.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(CUnit))]//<--CustomEditor속성, 타겟 타입을 알려준다
public class CUnitInspector : Editor//<--상속
{
    CUnit mpUnit = null;    //<--타겟 타입에 대한 변수를 하나 선언

    private void OnEnable()
    {
        mpUnit = this.target as CUnit;  //<-- 타겟을 얻는다
    }

    //인스펙터에 표시되는 컴포넌트의 외관은 이 이벤트 함수를 커스터마이징한다
    public override void OnInspectorGUI()
    {
        serializedObject.Update();//직렬화 기능을 갱신

        base.OnInspectorGUI();  //부모클래스Editor의 OnInspectorGUI를 호출

        //커스터마이징, 프로퍼티 외관 작성 그리고 버튼 추가
        EditorGUILayout.LabelField("AP", mpUnit.mAP.ToString());

        if (GUILayout.Button("Random mEndurance"))
        {
            mpUnit.mEndurance = Random.Range(0, 99);
        }
        if (GUILayout.Button("Random mStr"))
        {
            mpUnit.mStr = Random.Range(0, 9);
        }



        //직렬화 기능을 이용하여 변경된 외관을 적용
        serializedObject.ApplyModifiedProperties();
    }

    public override bool HasPreviewGUI()//<--프리뷰 표시를 위해 준비된 이벤트 함수
    {
        //return base.HasPreviewGUI();
        return true;//<--'프리뷰' 표시 있음은 true
    }

    public override GUIContent GetPreviewTitle()
    {
        //return base.GetPreviewTitle();
        return new GUIContent("unit stats");
    }

    public override void OnPreviewSettings()
    {
        base.OnPreviewSettings();

        //UI의 스타일을 만듦
        //GUIStyle tPreLabel = new GUIStyle("preview label");
        //GUIStyle tPreButton = new GUIStyle("preview button");

        ////UI만듦
        GUILayout.Label("Label test", GUIStyle.none);
        GUILayout.Button("Button test", GUIStyle.none);
    }
    public override void OnPreviewGUI(Rect r, GUIStyle background)
    {
        base.OnPreviewGUI(r, background);

        GUI.Box(r, "AP결정수식:\nmBaseAP + Mathf.FloorToInt(mBaseAP * (mEndurance + mStr - 8) / 16)");
    }


}
