using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CGameUnitInfo타입의 데이터(변수)에 적용할 PropertyAttribute를 사용자 정의한다.

public class CGameUnitInfoAttribute : PropertyAttribute
{
    public string mName { get; set; }
    public string mLevel { get; set; }
    public string mTypeJob { get; set; }
}
