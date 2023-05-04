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
            //아이템이 하나밖에 없으므로 이렇게 가정하겠다.
            tInfo = CRyuMgr.GetInst().mInventory[0];
        }

        if (null != tInfo)
        {
            //Document의 내용을 참고하여
            //View를 갱신( 여기서의 View는 UI )

            //System.Convert.ToInt32 문자열을 정수로 형변환 함수
            int tIndex = System.Convert.ToInt32(tInfo.mImgRscId);
            mImgItem.sprite = CRyuMgr.GetInst().mSprites[tIndex];

            mTxtName.text = tInfo.mName;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //이곳을 게임프로그램의 시작부분이라고 가정하다
        //아이템 도감 정보 구축
        CRyuMgr.GetInst().CreateRyu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
