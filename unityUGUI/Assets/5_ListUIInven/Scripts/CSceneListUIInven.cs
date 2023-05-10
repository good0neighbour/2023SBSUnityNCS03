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
        t.mName = "�鼳������ ���";
        t.mDesc = "�鼳���ָ� ���� ���డ �غ��� ���ִ� �������.";
        t.mCritialRatio = 100;
        t.mRscId = 0;

        CGameDataMgr.GetInst().AddItemToInven(t);

        t = new CItemData();
        t.mId = 1;
        t.mName = "�ƽ� �����";
        t.mDesc = "���� ���ʷ� ������� �ʴ� 1000000�� �߻簡 ������ �����";
        t.mCritialRatio = 1000;
        t.mRscId = 1;

        CGameDataMgr.GetInst().AddItemToInven(t);

        t = new CItemData();
        t.mId = 2;
        t.mName = "ź���̻���";
        t.mDesc = "�����.";
        t.mCritialRatio = 1000;
        t.mRscId = 2;

        CGameDataMgr.GetInst().AddItemToInven(t);

        t = new CItemData();
        t.mId = 3;
        t.mName = "��ũ�ν�";
        t.mDesc = "������ �ź��� ������� ���� �̾߱�";
        t.mCritialRatio = 1000;
        t.mRscId = 3;

        CGameDataMgr.GetInst().AddItemToInven(t);

        t = new CItemData();
        t.mId = 4;
        t.mName = "���";
        t.mDesc = "����.";
        t.mCritialRatio = 1000;
        t.mRscId = 4;

        CGameDataMgr.GetInst().AddItemToInven(t);

        //UI����
        mInven.BuildRyu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //IMGUI
    //�ҽ��ڵ常 �����ϸ� UI ���ŵȴ�.
    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 240, 100), "Test Dx Show"))
        {
            mInven.Show();
        }
        
    }

}
