using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class testScriptableWizard : ScriptableWizard
{

    [MenuItem("Window/show testScriptableWizard")]
    static void Open()
    {
        DisplayWizard<testScriptableWizard>("title: testScriptableWizard", "Create");
    }

    private void OnWizardCreate()
    {
        GameObject tGO = new GameObject("test");
        Light tLight = tGO.AddComponent<Light>();//Light컴포넌트 추가
        tLight.intensity = 10.0f;
        tLight.color = Color.blue;

        Debug.Log("OnWizardCreate");
    }
}
