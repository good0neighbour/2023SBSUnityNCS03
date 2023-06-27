using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using UnityEditor;
/*

    PropertyDrawer는 컴포넌트의 외관을 변경한다

    CustomEditor는 컴포넌트 단위로 기능을 수행하고
    PropertyDrawer는 데이터 별로( 프로퍼티 별로 ) 외관변경을 수행한다
    는 점이 다르다

*/
[CustomPropertyDrawer(typeof(CGameUnitInfoAttribute))]//<-- CustomPropertyDrawer속성 적용, 원래 데이터 클래스에 짝으로 만들어둔 PropertyAttribute타입을 알려준다
public class CGameUnitInfoDrawer : PropertyDrawer//<--PropertyDrawer상속
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //base.OnGUI(position, property, label);

        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position,GUIUtility.GetControlID(FocusType.Passive) , label);

        var indent = EditorGUI.indentLevel; //기존 들여쓰기 옵션을 기억해둔다
        EditorGUI.indentLevel = 0;  //들여쓰기 0레벨로 설정

        //영역 결정
        var amountRect = new Rect(position.x, position.y, 60, position.height - 50f);
        var unitRect = new Rect(position.x + 65, position.y, 30, position.height - 50f);
        var nameRect = new Rect(position.x + 100, position.y, position.width - 100, position.height - 50f);

        var tBtnRect = new Rect(position.x, position.y + 20, position.width, position.height - 20f);

        //field UI 설정
        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("mName"), GUIContent.none);
        EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("mLevel"), GUIContent.none);
        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("mTypeJob"), GUIContent.none);



        EditorGUI.indentLevel = indent; //기존 들여쓰기 옵션으로 돌린다

        EditorGUI.EndProperty();//<-----


        if (GUI.Button(tBtnRect, "Test Button"))
        {
            //프로퍼티를 이용하여 해당 변수에 값을 얻는 예 get
            Debug.Log(property.FindPropertyRelative("mName").stringValue.ToString());
            Debug.Log(property.FindPropertyRelative("mLevel").intValue.ToString());
            Debug.Log(property.FindPropertyRelative("mTypeJob").enumValueIndex.ToString());

            //프로퍼티를 이용하여 해당 변수에 값을 설정하는 예 set
            property.FindPropertyRelative("mName").stringValue = "superman";
            property.FindPropertyRelative("mLevel").intValue = 999;
            property.FindPropertyRelative("mTypeJob").enumValueIndex = (int)TYPE_JOB.JOB_ARCHOR;
        }


    }


    //컴포넌트의 높이를 추가로 확보하기 위해 다음 함수를 재정의
    float mSomeAdditionalHeight = 50.0f;
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + mSomeAdditionalHeight;
    }


}
