using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*

    고전적인 렌더링에서의 셰이더
    : 상황에 따른 재질을 case by case로 모두 만드는 방식이다.

    vs 

    물리기반 렌더링
    : 다양한 재질을 임의의 몇개의 수학적 모델로 표현하여 일반화하여 렌더링한느 방법
        <--물리적으로 측정된 수치에 기반한다는 특징도 있다.

    물리기반 렌더링의 셰이더
    : 물리기반 렌더링에서 사용되는 셰이더



    Diffuse 확산광, 난반사광
    <-- 고전적인 셰이더에서 이야기하는 용어다.
    <-- 우리가 어제 만들어본 램버트 조명 모델은 난반사광 모델이다.
    <-- 빛이 난반사되는 것을 모델로 만드는 것이다.
    <-- 유니티의 물리기반 셰이더에서는 albedo가 이에 대응된다.

    Specular 정반사광
    <-- 고전적인 셰이더에서 이야기하는 용어다.
    <-- 빛이 정반사되는 것을 모델로 만드는 것이다.

*/


#if UNITY_EDITOR

public class CFileIOOperation
{
    [MenuItem("ryuAssetDatabase/FileOperation", false, 1)]
    static void FileOperation()
    {
        //step_0 머터리얼 애셋 생성 <--------
        //Material tMaterial = new Material(Shader.Find("Standard"));
        Material tMaterial = new Material(Shader.Find("Specular"));
        AssetDatabase.CreateAsset(tMaterial, "Assets/0_MyMaterial.mat");

        //step_1 Rename <--------
        //AssetDatabase.RenameAsset("Assets/0_MyMaterial.mat", "0_MatSpecular");

        //step_2 폴더 애셋 생성 <--------
        //AssetDatabase.CreateFolder("Assets", "5_uee_NewFolder");

        //step_3 Move Asset <--------
        //AssetDatabase.MoveAsset(AssetDatabase.GetAssetPath(tMaterial), "Assets/5_uee_NewFolder/0_MatSpecular.mat");

        //step_3 Delete Asset < --------
        AssetDatabase.DeleteAsset("Assets/5_uee_NewFolder/0_MatSpecular.mat");
        AssetDatabase.DeleteAsset("Assets/0_MyMaterial.mat");

        //step_4 Delete Folder < --------
        //폴더도 애셋이다.
        AssetDatabase.DeleteAsset("Assets/5_uee_NewFolder");

        //애셋데이터베이스 갱신 
        AssetDatabase.Refresh();
    }


}

#endif