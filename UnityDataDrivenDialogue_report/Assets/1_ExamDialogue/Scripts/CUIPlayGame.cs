using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class CUIPlayGame : MonoBehaviour
{
    [SerializeField]
    TMP_Text mpTxtDialogue = null;

    //��� �ε���
    int mCurIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //��� �����͸� �����Ѵ�
        CDataMgr.GetInst().CreateRyu();

        //ù ��° ��� ���
        mpTxtDialogue.text = $"{CDataMgr.GetInst().mDialogueInfos[mCurIndex].mSpeakerName}\n{CDataMgr.GetInst().mDialogueInfos[mCurIndex].mDialogue}";
        //���� ��縦 ���� �ε��� ����
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

        //N��° ��� ���
        mpTxtDialogue.text = $"{CDataMgr.GetInst().mDialogueInfos[mCurIndex].mSpeakerName}\n{CDataMgr.GetInst().mDialogueInfos[mCurIndex].mDialogue}";
        //���� ��縦 ���� �ε��� ����
        if (mCurIndex < CDataMgr.GetInst().mDialogueInfos.Count - 1)
        {
            mCurIndex++;
        }
    }
}
