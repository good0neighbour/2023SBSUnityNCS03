using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

//for xml
using System.Xml;
using System;   //Convert�̿��� ����

public class CUIXml : MonoBehaviour
{
    //xml������ ����غ���
    public TMPro.TMP_Text mpTxtXml = null;

    public CRyuStageInfoList mStageInfoBundle = null;


    // Start is called before the first frame update
    void Start()
    {
        mStageInfoBundle = new CRyuStageInfoList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //��ư �̺�Ʈ �ڵ鷯 �Լ�
    public void OnClickBtnLoadFromXml()
    {
        LoadFromXmlFile("stage_info_xml");
    }

    //'ResourcesƯ������'�κ��� xml���� ������ �����͸� �ε��ϰ� �Ľ��ϴ� �Լ���.
    // <-- Resources: �̸��� ������ �ִ�. '�ּ�'�� ���� �߿� �ε��� �� �ִ� �������� �غ�� ������.
    // <-- ������ '����(�ڿ�)'�� '����Ʈimport'�Ͽ� ����Ƽ �����ͷ� �������� ����Ƽ�� �̸� '�ּ�asset'���� �ٷ��

    //  �Ľ�parsing: ������ �����ڸ� �������� �ؼ� ��ȿ�� ���token�� �����س��� �۾��̴�.
    //  <-- ��, �����͸� ������ �䱸��� ����ȭ�ϴ� ���̴�.
    bool LoadFromXmlFile(string tFileName)
    {
        Debug.Log($"LoadFromXmlFile {tFileName}");

        //xml( '�ؽ�Ʈ ����', �ڱ⸸�� �±׸� ����� �ڱ⸸�� ������ ���� �� �ִ� �Ծ� )�ּ��� �ε��Ѵ�
        TextAsset tTextAsset = null;    //����Ƽ���� �ؽ�Ʈ ������ �ּ��� ���� �����ص� Ŭ����
        tTextAsset = Resources.Load<TextAsset>(tFileName);  //����Ƽ���� �غ��ص� ���� �߿� �ּ��� �ε��� �� �ִ� ����

        if (null == tTextAsset)
        {
            //�ּ� �ε� ����
            return false;
        }

        //�ּ� �ε� ����
        mpTxtXml.text = tTextAsset.text;    //�ε��� ������ ����غ���.



        //xml�����͸� �Ľ��Ѵ�(�뵵�� �°� �ؼ��Ѵ�)
        XmlDocument tDoc = new XmlDocument();   //xml ���� ��ü�� ����
        tDoc.LoadXml(mpTxtXml.text);    //���ڿ� --> xml������ �����ͷ� �ٷ絵�� ����.

        CRyuStageInfo tStageInfo = null;
        CRyuUnitInfo tUnitInfo = null;

        //�����迭 ������ ǥ���, xml������ü���� �ֻ��� ��Ʈ��带 ��´�
        XmlElement tElementRoot = tDoc["response"];

        mStageInfoBundle.mStageInfos = new List<CRyuStageInfo>();

        foreach (XmlElement tE in tElementRoot.ChildNodes)  //N���� stage info list
        {
            foreach (XmlElement tElementStageInfo in tE.ChildNodes) //N���� stage info
            {
                tStageInfo = null;
                tStageInfo = new CRyuStageInfo();

                tStageInfo.mId = System.Convert.ToInt32(tElementStageInfo.ChildNodes[0].InnerText);
                tStageInfo.mTotalEnemyCount = System.Convert.ToInt32(tElementStageInfo.ChildNodes[1].InnerText);

                if (tElementStageInfo.ChildNodes[2].ChildNodes.Count > 0)
                {
                    tStageInfo.mUnitInfos = new List<CRyuUnitInfo>();

                    foreach (XmlElement tElementUnitInfo in tElementStageInfo.ChildNodes[2]) //N���� unit info
                    {
                        tUnitInfo = null;
                        tUnitInfo = new CRyuUnitInfo();
                        //����ȯ
                        tUnitInfo.mX = System.Convert.ToInt32(tElementUnitInfo.ChildNodes[0].InnerText);
                        tUnitInfo.mY = System.Convert.ToInt32(tElementUnitInfo.ChildNodes[1].InnerText);

                        //�ڷᱸ���� �߰�
                        tStageInfo.mUnitInfos.Add(tUnitInfo);
                    }
                }
                //�ڷᱸ���� �߰�
                mStageInfoBundle.mStageInfos.Add(tStageInfo);
            }
        }



        //�Ľ��� �����͸� ����غ���.(�α�)
        foreach (CRyuStageInfo tS in this.mStageInfoBundle.mStageInfos)  //N���� stage info
        {
            Debug.Log($"stage id: {tS.mId.ToString()}");
            Debug.Log($"stage enemy count: {tS.mTotalEnemyCount.ToString()}");

            foreach (CRyuUnitInfo tU in tS.mUnitInfos) //N���� unity info
            {
                Debug.Log($"unit X: {tU.mX.ToString()}");
                Debug.Log($"unit Y: {tU.mY.ToString()}");
            }
        }

        return true;
    }



}
