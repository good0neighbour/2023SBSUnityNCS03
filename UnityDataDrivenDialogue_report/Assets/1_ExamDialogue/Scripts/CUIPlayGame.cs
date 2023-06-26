using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class CUIPlayGame : MonoBehaviour
{
    [SerializeField]
    TMP_Text mpTxtDialogue = null;

    //대사 인덱스
    int mCurIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //대사 데이터를 구축한다
        CDataMgr.GetInst().CreateRyu();

        //첫 번째 대사 출력
        mpTxtDialogue.text = $"{CDataMgr.GetInst().mDialogueInfos[mCurIndex].mSpeakerName}\n{CDataMgr.GetInst().mDialogueInfos[mCurIndex].mDialogue}";
        //다음 대사를 위해 인덱스 증가
        if (mCurIndex < CDataMgr.GetInst().mDialogueInfos.Count - 1)
        {
            mCurIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickBtnNextDialogue()
    {
        Debug.Log("next");

        //N번째 대사 출력
        mpTxtDialogue.text = $"{CDataMgr.GetInst().mDialogueInfos[mCurIndex].mSpeakerName}\n{CDataMgr.GetInst().mDialogueInfos[mCurIndex].mDialogue}";
        //다음 대사를 위해 인덱스 증가
        if (mCurIndex < CDataMgr.GetInst().mDialogueInfos.Count - 1)
        {
            mCurIndex++;
        }
    }
}
