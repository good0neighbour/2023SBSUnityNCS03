using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public void AddItemToInven(CItemData tData)
    {
        //참조타입의 객체이므로 새로 생성하여 값을 복사하도록 하겠다
        CItemData t = new CItemData();
        t = tData;
        Debug.Log($"AddItemToInven: id: {t.mId.ToString()}, name: {t.mName}");

        //mId를 키로 삼겠다
        string tKey = t.mId.ToString();

        List<CItemData> tList = null;
        if (mDicItemInventory.ContainsKey(tKey))
        {
            //만약 이미 존재하는 아이템이라면 딕셔너리의 항목을 찾아
            //그 항목에 가변배열 추가한다
            tList = mDicItemInventory[tKey];    //검색 O(1)
            tList.Add(t);
        }
        else
        {
            //만약 존재하지 않는 아이템이라면
            //새롭게 항목을 구성한다
            tList = new List<CItemData>();
            tList.Add(t);

            mDicItemInventory.Add(tKey, tList);
        }
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