using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

//싱클톤 패턴이 적용된 클래스
//  여기서는 대사 데이터 관리자로 가정하였다
public class CDataMgr
{
    private static CDataMgr mpInst = null;

    public List<CDialogueInfo> mDialogueInfos = null;

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

    //전역적으로 관리되는 대사 정보객체를 생성한다
    public void CreateRyu()
    {
        mDialogueInfos = new List<CDialogueInfo>();
        //애셋이므로 확장자는 표기하지 않는다
        LoadDialogueInfos("dialogue_list");
    }

    public void LoadDialogueInfos(string tAssetName)
    {
        //text asset 로드
        TextAsset tTextAsset = null;
        tTextAsset = Resources.Load<TextAsset>(tAssetName);

        if (null == tTextAsset)
        {
            //애셋 로드 실패
            Debug.Log("FAILURE, load asset");
            return;
        }
        //애셋 로드 성공
        Debug.Log(tTextAsset.text);

        //xml로 파싱
        XmlDocument tDoc = new XmlDocument();
        tDoc.LoadXml(tTextAsset.text);

        XmlElement tElementRoot = tDoc["DialogueInfoList"];


        int ti = 0; //카운트용 변수
        int tCount = tElementRoot.ChildNodes.Count;  //xml의 노드에 총 대사 개수

        CDialogueInfo tInfo = null;
        XmlElement tElement_0 = null;

        for (ti = 0; ti < tCount; ++ti)
        {
            tElement_0 = null;
            tElement_0 = tElementRoot.ChildNodes[ti] as XmlElement;

            tInfo = null;
            tInfo = new CDialogueInfo();

            tInfo.mId = System.Convert.ToInt32(tElement_0.ChildNodes[0].InnerText);
            tInfo.mDialogue = tElement_0.ChildNodes[1].InnerText;

            mDialogueInfos.Add(tInfo);
        }

    }
}
