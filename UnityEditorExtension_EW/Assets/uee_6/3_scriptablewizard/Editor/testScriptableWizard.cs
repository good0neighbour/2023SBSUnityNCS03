using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class testScriptableWizard : ScriptableWizard
{
    [SerializeField]
    string mGameObjectName = "NewGO";
    [SerializeField]
    float mIntensity = 5.0f;
    [SerializeField]
    Color mColor = Color.red;



    [MenuItem("Window/show testScriptableWizard")]
    static void Open()
    {
        //DisplayWizard<testScriptableWizard>("title: testScriptableWizard", "Create");

        //DisplayWizard<testScriptableWizard>("title: testScriptableWizard", "Create", "Find");
        DisplayWizard<testScriptableWizard>("title: testScriptableWizard", "Create", "Apply");
    }

    private void OnWizardCreate()
    {
        GameObject tGO = new GameObject("test");
        Light tLight = tGO.AddComponent<Light>();//Light������Ʈ �߰�
        tLight.intensity = 10.0f;
        tLight.color = Color.blue;

        Debug.Log("OnWizardCreate");
    }

    private void OnWizardOtherButton()
    {
        //���̾��Ű���� ������ ���ӿ�����Ʈ �˻�
        //GameObject tGO = GameObject.Find("test_0");
        //if (null != tGO)
        //{
        //    Debug.Log("Success Find");
        //    //������Ʈ �˻�
        //    Light tLight = tGO.GetComponent<Light>();

        //    if (null != tLight)
        //    {
        //        Debug.Log("success Get");
        //    }
        //}
        //else
        //{
        //    Debug.Log("Failure Find");
        //}


        //������ �� ����
        //������ ���ӿ�����Ʈ�� ���Ͽ�
        if (null != Selection.activeTransform)
        {
            Light tLight = Selection.activeTransform.GetComponent<Light>();

            if (null != tLight)
            {
                tLight.name = mGameObjectName;//"test_light";
                tLight.intensity = mIntensity;//12f;
                tLight.color = mColor;//Color.yellow;
            }
        }
    }

    //�ʵ��� ��ġ ���� �� ���� �� ȣ��Ǵ� �Լ���.
    private void OnWizardUpdate()
    {
        helpString = $"name: {mGameObjectName}, intensity: {mIntensity.ToString()}, color: {mColor.ToString()}";
    }

    //OnGUI��� DrawWizardGUI�� ȣ���Ͽ� �ܰ��� �ٲ۴�.
    protected override bool DrawWizardGUI()
    {
        mGameObjectName = EditorGUILayout.TextField(mGameObjectName);
        EditorGUILayout.Space(100);
        mIntensity = EditorGUILayout.FloatField(mIntensity);
        mColor = EditorGUILayout.ColorField(mColor, null);

        //true�� �����ؾ߸� �ش� �Լ��� �۵��Ѵ�.
        return true;
    }


}
