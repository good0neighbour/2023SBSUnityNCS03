using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSceneListUIInven : MonoBehaviour
{
    [SerializeField]
    CDxItemInventory mInven = null;

    // Start is called before the first frame update
    void Start()
    {
        CItemData t = null;
        t = new CItemData();
        t.mId = 0;
        t.mName = "백설공주의 사과";
        t.mDesc = "백설공주를 위해 마녀가 준비한 맛있는 독사과다.";
        t.mCritialRatio = 100;
        t.mRscId = 0;

        CGameDataMgr.GetInst().AddItemToInven(t);

        t = new CItemData();
        t.mId = 1;
        t.mName = "맥심 기관총";
        t.mDesc = "세계 최초로 만들어진 초당 1000000번 발사가 가능한 기관총";
        t.mCritialRatio = 1000;
        t.mRscId = 1;

        CGameDataMgr.GetInst().AddItemToInven(t);

        t = new CItemData();
        t.mId = 2;
        t.mName = "탄도미사일";
        t.mDesc = "대륙간.";
        t.mCritialRatio = 1000;
        t.mRscId = 2;

        CGameDataMgr.GetInst().AddItemToInven(t);

        t = new CItemData();
        t.mId = 3;
        t.mName = "마크로스";
        t.mDesc = "전설의 신비한 나디아의 전함 이야기";
        t.mCritialRatio = 1000;
        t.mRscId = 3;

        CGameDataMgr.GetInst().AddItemToInven(t);

        t = new CItemData();
        t.mId = 4;
        t.mName = "우라늄";
        t.mDesc = "방사능.";
        t.mCritialRatio = 1000;
        t.mRscId = 4;

        CGameDataMgr.GetInst().AddItemToInven(t);

        //UI구축
        mInven.BuildRyu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //IMGUI
    //소스코드만 제거하면 UI 제거된다.
    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 240, 100), "Test Dx Show"))
        {
            mInven.Show();
        }
        
    }

}
