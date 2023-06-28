using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class CSOUI : MonoBehaviour
{
    CStageInfo mStageInfo = null;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        mStageInfo = AssetDatabase.LoadAssetAtPath<CStageInfo>("Assets/Resources/stage_info_list_so.asset");

        Debug.Log("EDITOR: stage_info_list.Count: " + mStageInfo.mStageInfos.Length);
        foreach (var t in mStageInfo.mStageInfos)
        {
            Debug.Log("id: " + t.mId);
            Debug.Log("totqal_enemy_count: " + t.mTotalEnemyCount);
            foreach (var s in t.mUnitInfos)
            {
                Debug.Log("unit.x: " + s.x);
                Debug.Log("unit.y: " + s.y);
            }
        }
#else
        mStageInfo = Resources.Load<CStageInfo>("stage_info_list_so");
#endif
    }

    private void OnGUI()
    {
#if UNITY_EDITOR

#else
        GUI.Label(new Rect(0f, 0f, 300f, 50f), $"In Game: stage_info_list.Count: {mStageInfo.mStageInfos.Length.ToString()}");

        int ti = 0;
        int tj = 0;
        foreach (var t in mStageInfo.mStageInfos)
        {
            GUI.Label(new Rect(0f, 20f + ti * 100f, 300f, 50f), $"id: {t.mId.ToString()}");
            GUI.Label(new Rect(0f, 40f + ti * 100f, 300f, 50f), $"total_enemy_count: {t.mTotalEnemyCount.ToString()}");

            foreach (var s in t.mUnitInfos)
            {
                GUI.Label(new Rect(0f, 60f + ti * 100f + tj * 40f, 300f, 50f), $"unit.x: {s.x.ToString()}");
                GUI.Label(new Rect(0f, 80f + ti * 100f + tj * 40f, 300f, 50f), $"unit.y: {s.y.ToString()}");
            }
        }
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
