using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameDataMgr
{
    private static CGameDataMgr mpInst = null;


    //public Sprite[] mSprites = null;



    //�κ��丮 ���� ( ȹ�� ������ ��� ���� )
    //<-- ���� ������ �����ʹ� ���ε��� ������ ���̰�
    //UI���� ���� ������ �������̸� �� ���Ը� �Ҵ��Ͽ� ������ ���̴�.( ������ ǥ�� )
    public SortedDictionary<string, List<CItemData>> mDicItemInventory = new SortedDictionary<string, List<CItemData>>();

    
    public void CreateRyu()
    {
        //mSprites = Resources.LoadAll<Sprite>("Sprites/item");
    }

    private CGameDataMgr()
    {
        Debug.Log("CGameDataMgr.CGameDataMgr");
    }
    //1���� �ν��Ͻ�ȭ�Ѵ�
    public static CGameDataMgr GetInst()
    {
        if(null == mpInst)
        {
            mpInst = new CGameDataMgr();
        }

        return mpInst;
    }
}