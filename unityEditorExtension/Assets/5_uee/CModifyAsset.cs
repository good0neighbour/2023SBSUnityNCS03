using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CModifyAsset
{
    [MenuItem("ryuAssetDatabase/Create ryuAnimationClip", false, 12)]
    static void DoCreateAnimationClip()
    {
        var t = new AnimationClip();

        AssetDatabase.CreateAsset(t, "Assets/New ryuAnimationClip.anim");
    }

    [MenuItem("ryuAssetDatabase/Change AniClip FrameRate", false, 13)]
    static void DoChangeAnimationClipFrameRate()
    {
        var t = AssetDatabase.LoadAssetAtPath<AnimationClip>("Assets/New ryuAnimationClip.anim");

        t.frameRate++;

        AssetDatabase.SaveAssets();//디스크에 파일 형태로 애셋으로 저장
    }

}
