using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameDataMgr
{
    private static CGameDataMgr mpInst = null;


    //public Sprite[] mSprites = null;



    //인벤토리 정보 ( 획득 아이템 목록 정보 )
    //<-- 실제 아이템 데이터는 따로따로 저장할 것이고
    //UI에는 같은 종류의 아이템이면 한 슬롯만 할당하여 보여줄 것이다.( 개수는 표시 )
    public SortedDictionary<string, List<CItemData>> mDicItemInventory = new SortedDictionary<string, List<CItemData>>();

    
    public void CreateRyu()
    {
        //mSprites = Resources.LoadAll<Sprite>("Sprites/item");
    }

    private CGameDataMgr()
    {
        Debug.Log("CGameDataMgr.CGameDataMgr");
    }
    //1개만 인스턴스화한다
    public static CGameDataMgr GetInst()
    {
        if(null == mpInst)
        {
            mpInst = new CGameDataMgr();
        }

        return mpInst;
    }
}