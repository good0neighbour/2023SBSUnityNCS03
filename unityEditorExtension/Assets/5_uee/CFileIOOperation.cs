using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*

    �������� ������������ ���̴�
    : ��Ȳ�� ���� ������ case by case�� ��� ����� ����̴�.

    vs 

    ������� ������
    : �پ��� ������ ������ ��� ������ �𵨷� ǥ���Ͽ� �Ϲ�ȭ�Ͽ� �������Ѵ� ���
        <--���������� ������ ��ġ�� ����Ѵٴ� Ư¡�� �ִ�.

    ������� �������� ���̴�
    : ������� ���������� ���Ǵ� ���̴�



    Diffuse Ȯ�걤, ���ݻ籤
    <-- �������� ���̴����� �̾߱��ϴ� ����.
    <-- �츮�� ���� ���� ����Ʈ ���� ���� ���ݻ籤 ���̴�.
    <-- ���� ���ݻ�Ǵ� ���� �𵨷� ����� ���̴�.
    <-- ����Ƽ�� ������� ���̴������� albedo�� �̿� �����ȴ�.

    Specular ���ݻ籤
    <-- �������� ���̴����� �̾߱��ϴ� ����.
    <-- ���� ���ݻ�Ǵ� ���� �𵨷� ����� ���̴�.

*/


#if UNITY_EDITOR

public class CFileIOOperation
{
    [MenuItem("ryuAssetDatabase/FileOperation", false, 1)]
    static void FileOperation()
    {
        //step_0 ���͸��� �ּ� ���� <--------
        //Material tMaterial = new Material(Shader.Find("Standard"));
        Material tMaterial = new Material(Shader.Find("Specular"));
        AssetDatabase.CreateAsset(tMaterial, "Assets/0_MyMaterial.mat");

        //step_1 Rename <--------
        //AssetDatabase.RenameAsset("Assets/0_MyMaterial.mat", "0_MatSpecular");

        //step_2 ���� �ּ� ���� <--------
        //AssetDatabase.CreateFolder("Assets", "5_uee_NewFolder");

        //step_3 Move Asset <--------
        //AssetDatabase.MoveAsset(AssetDatabase.GetAssetPath(tMaterial), "Assets/5_uee_NewFolder/0_MatSpecular.mat");

        //step_3 Delete Asset < --------
        AssetDatabase.DeleteAsset("Assets/5_uee_NewFolder/0_MatSpecular.mat");
        AssetDatabase.DeleteAsset("Assets/0_MyMaterial.mat");

        //step_4 Delete Folder < --------
        //������ �ּ��̴�.
        AssetDatabase.DeleteAsset("Assets/5_uee_NewFolder");

        //�ּµ����ͺ��̽� ���� 
        AssetDatabase.Refresh();
    }


}

#endif