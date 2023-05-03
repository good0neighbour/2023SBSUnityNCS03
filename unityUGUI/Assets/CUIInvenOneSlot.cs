using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class CUIInvenOneSlot : MonoBehaviour
{
    public Image mImgItem = null;
    public TMPro.TMP_Text mTxtName = null;

    public void BuidUI()
    {
        //clean
        mImgItem.sprite = null;
        mTxtName.text = "";

        //build
        CItemInfo tInfo = null;
        if (CRyuMgr.GetInst().mInventory.Count > 0)
        {
            //�������� �ϳ��ۿ� �����Ƿ� �̷��� �����ϰڴ�.
            tInfo = CRyuMgr.GetInst().mInventory[0];
        }

        if (null != tInfo)
        {
            //Document�� ������ �����Ͽ�
            //View�� ����( ���⼭�� View�� UI )

            //System.Convert.ToInt32 ���ڿ��� ������ ����ȯ �Լ�
            int tIndex = System.Convert.ToInt32(tInfo.mImgRscId);
            mImgItem.sprite = CRyuMgr.GetInst().mSprites[tIndex];

            mTxtName.text = tInfo.mName;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //�̰��� �������α׷��� ���ۺκ��̶�� �����ϴ�
        //������ ���� ���� ����
        CRyuMgr.GetInst().CreateRyu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
