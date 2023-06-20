using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

//for xml
using System.Xml;
using System;   //Convert이용을 위해

public class CUIXml : MonoBehaviour
{
    //xml내용을 출력해본다
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

    //버튼 이벤트 핸들러 함수
    public void OnClickBtnLoadFromXml()
    {
        LoadFromXmlFile("stage_info_xml");
    }

    //'Resources특수폴더'로부터 xml파일 에셋의 데이터를 로드하고 파싱하는 함수다.
    // <-- Resources: 이름이 정해져 있다. '애셋'을 샐행 중에 로드할 수 있는 공간으로 준비된 폴더다.
    // <-- 임의의 '파일(자원)'을 '임포트import'하여 유니티 에디터로 가져오면 유니티는 이를 '애셋asset'으로 다룬다

    //  파싱parsing: 임의의 구분자를 기준으로 해서 유효한 요소token을 추출해내는 작업이다.
    //  <-- 즉, 데이터를 임의의 요구대로 조직화하는 것이다.
    bool LoadFromXmlFile(string tFileName)
    {
        Debug.Log($"LoadFromXmlFile {tFileName}");

        //xml( '텍스트 형식', 자기만의 태그를 만들어 자기만의 포멧을 만들 수 있는 규약 )애셋을 로드한다
        TextAsset tTextAsset = null;    //유니티에서 텍스트 형식의 애셋을 위해 마련해둔 클래스
        tTextAsset = Resources.Load<TextAsset>(tFileName);  //유니티에서 준비해둔 실행 중에 애셋을 로드할 수 있는 폴더

        if (null == tTextAsset)
        {
            //애셋 로드 실패
            return false;
        }

        //애셋 로드 성공
        mpTxtXml.text = tTextAsset.text;    //로드한 내용을 출력해본다.



        //xml데이터를 파싱한다(용도에 맞게 해석한다)
        XmlDocument tDoc = new XmlDocument();   //xml 문서 객체를 생성
        tDoc.LoadXml(mpTxtXml.text);    //문자열 --> xml형태의 데이터로 다루도록 하자.

        CRyuStageInfo tStageInfo = null;
        CRyuUnitInfo tUnitInfo = null;

        //연관배열 형태의 표기법, xml문서객체에서 최상위 루트노드를 얻는다
        XmlElement tElementRoot = tDoc["response"];

        mStageInfoBundle.mStageInfos = new List<CRyuStageInfo>();

        foreach (XmlElement tE in tElementRoot.ChildNodes)  //N개의 stage info list
        {
            foreach (XmlElement tElementStageInfo in tE.ChildNodes) //N개의 stage info
            {
                tStageInfo = null;
                tStageInfo = new CRyuStageInfo();

                tStageInfo.mId = System.Convert.ToInt32(tElementStageInfo.ChildNodes[0].InnerText);
                tStageInfo.mTotalEnemyCount = System.Convert.ToInt32(tElementStageInfo.ChildNodes[1].InnerText);

                if (tElementStageInfo.ChildNodes[2].ChildNodes.Count > 0)
                {
                    tStageInfo.mUnitInfos = new List<CRyuUnitInfo>();

                    foreach (XmlElement tElementUnitInfo in tElementStageInfo.ChildNodes[2]) //N개의 unit info
                    {
                        tUnitInfo = null;
                        tUnitInfo = new CRyuUnitInfo();
                        //형변환
                        tUnitInfo.mX = System.Convert.ToInt32(tElementUnitInfo.ChildNodes[0].InnerText);
                        tUnitInfo.mY = System.Convert.ToInt32(tElementUnitInfo.ChildNodes[1].InnerText);

                        //자료구조에 추가
                        tStageInfo.mUnitInfos.Add(tUnitInfo);
                    }
                }
                //자료구조에 추가
                mStageInfoBundle.mStageInfos.Add(tStageInfo);
            }
        }



        //파싱한 데이터를 출력해본다.(로그)
        foreach (CRyuStageInfo tS in this.mStageInfoBundle.mStageInfos)  //N개의 stage info
        {
            Debug.Log($"stage id: {tS.mId.ToString()}");
            Debug.Log($"stage enemy count: {tS.mTotalEnemyCount.ToString()}");

            foreach (CRyuUnitInfo tU in tS.mUnitInfos) //N개의 unity info
            {
                Debug.Log($"unit X: {tU.mX.ToString()}");
                Debug.Log($"unit Y: {tU.mY.ToString()}");
            }
        }

        return true;
    }



}
