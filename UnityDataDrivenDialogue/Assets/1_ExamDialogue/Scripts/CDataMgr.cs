using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ŭ�� ������ ����� Ŭ����
//  ���⼭�� ��� ������ �����ڷ� �����Ͽ���
public class CDataMgr
{
    private static CDataMgr mpInst = null;

    private CDataMgr()
    {
    }

    public static CDataMgr GetInst()
    {
        if (null == mpInst)
        {
            mpInst = new CDataMgr();
        }

        return mpInst;
    }

    public void LoadDialogueInfos(string tAssetName)
    {
        TextAsset tTextAsset = null;
        Resources.Load<TextAsset>(tAssetName);

        if (null == tTextAsset)
        {
            //�ּ� �ε� ����
            Debug.Log("FAILURE, load asset");
            return;
        }
        //�ּ� �ε� ����
        Debug.Log(tTextAsset.text);

    }
}
