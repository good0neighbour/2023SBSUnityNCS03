using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using UnityEditor;
/*

    PropertyDrawer�� ������Ʈ�� �ܰ��� �����Ѵ�

    CustomEditor�� ������Ʈ ������ ����� �����ϰ�
    PropertyDrawer�� ������ ����( ������Ƽ ���� ) �ܰ������� �����Ѵ�
    �� ���� �ٸ���

*/
[CustomPropertyDrawer(typeof(CGameUnitInfoAttribute))]//<-- CustomPropertyDrawer�Ӽ� ����, ���� ������ Ŭ������ ¦���� ������ PropertyAttributeŸ���� �˷��ش�
public class CGameUnitInfoDrawer : PropertyDrawer//<--PropertyDrawer���
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //base.OnGUI(position, property, label);

        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position,GUIUtility.GetControlID(FocusType.Passive) , label);

        var indent = EditorGUI.indentLevel; //���� �鿩���� �ɼ��� ����صд�
        EditorGUI.indentLevel = 0;  //�鿩���� 0������ ����

        //���� ����
        var amountRect = new Rect(position.x, position.y, 60, position.height - 50f);
        var unitRect = new Rect(position.x + 65, position.y, 30, position.height - 50f);
        var nameRect = new Rect(position.x + 100, position.y, position.width - 100, position.height - 50f);

        var tBtnRect = new Rect(position.x, position.y + 20, position.width, position.height - 20f);

        //field UI ����
        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("mName"), GUIContent.none);
        EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("mLevel"), GUIContent.none);
        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("mTypeJob"), GUIContent.none);



        EditorGUI.indentLevel = indent; //���� �鿩���� �ɼ����� ������

        EditorGUI.EndProperty();//<-----


        if (GUI.Button(tBtnRect, "Test Button"))
        {
            //������Ƽ�� �̿��Ͽ� �ش� ������ ���� ��� �� get
            Debug.Log(property.FindPropertyRelative("mName").stringValue.ToString());
            Debug.Log(property.FindPropertyRelative("mLevel").intValue.ToString());
            Debug.Log(property.FindPropertyRelative("mTypeJob").enumValueIndex.ToString());

            //������Ƽ�� �̿��Ͽ� �ش� ������ ���� �����ϴ� �� set
            property.FindPropertyRelative("mName").stringValue = "superman";
            property.FindPropertyRelative("mLevel").intValue = 999;
            property.FindPropertyRelative("mTypeJob").enumValueIndex = (int)TYPE_JOB.JOB_ARCHOR;
        }


    }


    //������Ʈ�� ���̸� �߰��� Ȯ���ϱ� ���� ���� �Լ��� ������
    float mSomeAdditionalHeight = 50.0f;
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + mSomeAdditionalHeight;
    }


}
