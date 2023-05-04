using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

[Serializable]
//아이템의 본질적인 정보
public class CItemData
{
    public int mId = 0; //해당 아이템의 유니크한 식별자

    public string mName = "";   //아이템의 이름 정보
    public string mDesc = "";   //아이템의 상세 설명 정보

    public int mRscId = 0;  //아이템의 UI에서 표시 이미지 정보

    //그 외에 여러 스탯에 관한 정보도 있을 수 있겠다.
    public int mCritialRatio = 0;
}
