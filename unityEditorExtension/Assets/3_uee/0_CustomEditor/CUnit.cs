using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUnit : MonoBehaviour//<--Unity의 Object계열이므로 당연히 직렬화 적용됨
{
    public CUnitInfo mInfo = null;//<--Serializable이 적용된 커스텀 클래스타입의 멤버변수

    public CUnitInfo[] mInfos = null;

    [Range(0, 255)]
    public int mBaseAP = 0;//<--유니티의 직렬화 규칙에 따르면 public 예약어 적용시 직렬화됨
    [Range(0, 99)]
    public int mEndurance = 0;
    [Range(0, 9)]
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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
