using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//싱클톤 패턴이 적용된 클래스
//  여기서는 대사 데이터 관리자로 가정하였다
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
            //애셋 로드 실패
            Debug.Log("FAILURE, load asset");
            return;
        }
        //애셋 로드 성공
        Debug.Log(tTextAsset.text);

    }
}
