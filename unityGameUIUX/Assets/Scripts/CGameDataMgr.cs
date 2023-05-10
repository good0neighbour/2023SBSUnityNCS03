using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public void AddItemToInven(CItemData tData)
    {
        //����Ÿ���� ��ü�̹Ƿ� ���� �����Ͽ� ���� �����ϵ��� �ϰڴ�
        CItemData t = new CItemData();
        t = tData;
        Debug.Log($"AddItemToInven: id: {t.mId.ToString()}, name: {t.mName}");

        //mId�� Ű�� ��ڴ�
        string tKey = t.mId.ToString();

        List<CItemData> tList = null;
        if (mDicItemInventory.ContainsKey(tKey))
        {
            //���� �̹� �����ϴ� �������̶�� ��ųʸ��� �׸��� ã��
            //�� �׸� �����迭 �߰��Ѵ�
            tList = mDicItemInventory[tKey];    //�˻� O(1)
            tList.Add(t);
        }
        else
        {
            //���� �������� �ʴ� �������̶��
            //���Ӱ� �׸��� �����Ѵ�
            tList = new List<CItemData>();
            tList.Add(t);

            mDicItemInventory.Add(tKey, tList);
        }
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