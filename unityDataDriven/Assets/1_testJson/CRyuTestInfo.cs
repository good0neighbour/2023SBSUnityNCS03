using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    JsonUtility를 사용하기 위한 데이터 클래스 규칙

    i) json데이터의 키의 이름과 똑같이 변수이름을 만든다.
    ii) 해당 클래스에서 직렬화를 적용해야만 한다
        [Serializable]

*/


public class CRyuTestInfo
{
    public string mName = "";

    public int mLevel = 0;
    public int mExp = 0;

    public List<string> mStringList = null;
}
