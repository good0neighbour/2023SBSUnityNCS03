using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    AssetDatabase 관련 기능을 살펴보자
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
