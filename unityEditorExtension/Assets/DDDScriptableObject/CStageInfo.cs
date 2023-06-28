using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Example/Create StageInfo")]
public class CStageInfo : ScriptableObject
{
    public CUnitInfo[] mStageInfos = null;

    [Serializable]
    public class CUnitInfo
    {
        public int mId = 0;
        public int mTotalEnemyCount = 0;
        public Vector2[] mUnitInfos = null;
    }
}