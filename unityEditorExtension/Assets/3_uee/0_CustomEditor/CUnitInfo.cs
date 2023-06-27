using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

//데이터 클래스 용도의 클래스다. 멤버는 public

//쌩짜 클래스에 직렬화를 적용하는 속성
[Serializable]
public class CUnitInfo
{
    //멤버변수
    [Range(0, 255)]
    public int mBaseAP = 0;//<--유니티의 직렬화 규칙에 따르면 public 예약어 적용시 직렬화됨
    [Range(0, 255)]
    public int mEndurance = 0;
    [Range(0, 255)]
    public int mStr = 0;

    //프로퍼티<--유니티의 기본 직렬화 규칙에서 제외됨
    public int mAP
    {
        get
        {
            //임의의 수식으로 공격력 결정
            return mBaseAP + Mathf.FloorToInt(mBaseAP * (mEndurance + mStr - 8) / 16);
        }
    }
}
