using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    AssetDatabase ���� ����� ���캸��
*/

#if UNITY_EDITOR
using UnityEditor;


public class CImportAsset
{
    [MenuItem("ryuAssetDatabase/importAssetTest", false, 0)]
    static void ImportAssetTest()
    {
        AssetDatabase.ImportAsset("Assets/5_uee/BloodDecal.psd",
            ImportAssetOptions.Default);
    }
}
#endif
