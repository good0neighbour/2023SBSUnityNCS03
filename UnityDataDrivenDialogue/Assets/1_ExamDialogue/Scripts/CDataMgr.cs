using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

//��Ŭ�� ������ ����� Ŭ����
//  ���⼭�� ��� ������ �����ڷ� �����Ͽ���
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

    //���������� �����Ǵ� ��� ������ü�� �����Ѵ�
    public void CreateRyu()
    {
        mDialogueInfos = new List<CDialogueInfo>();
        //�ּ��̹Ƿ� Ȯ���ڴ� ǥ������ �ʴ´�
        LoadDialogueInfos("dialogue_list");
    }

    public void LoadDialogueInfos(string tAssetName)
    {
        //text asset �ε�
        TextAsset tTextAsset = null;
        tTextAsset = Resources.Load<TextAsset>(tAssetName);

        if (null == tTextAsset)
        {
            //�ּ� �ε� ����
            Debug.Log("FAILURE, load asset");
            return;
        }
        //�ּ� �ε� ����
        Debug.Log(tTextAsset.text);

        //xml�� �Ľ�
        XmlDocument tDoc = new XmlDocument();
        tDoc.LoadXml(tTextAsset.text);

        XmlElement tElementRoot = tDoc["DialogueInfoList"];


        int ti = 0; //ī��Ʈ�� ����
        int tCount = tElementRoot.ChildNodes.Count;  //xml�� ��忡 �� ��� ����

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
