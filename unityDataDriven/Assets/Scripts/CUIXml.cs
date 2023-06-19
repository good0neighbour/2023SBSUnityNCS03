using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

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

    //Resources폴더로부터 xml파일 에셋의 데이터를 로드하고 파싱하는 함수다.
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


        return true;
    }



}
