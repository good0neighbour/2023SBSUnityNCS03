using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;   //직렬화를 위해

/*
    이 클래스는
    Document-View 개념에서

    Document에 해당하는
    클래스다

    어떤 아이템의 실체를 '실제 본질적인 데이터 + 외관'으로 구분한다면
    이것은 '실제 본질적인 데이터', 즉, Document에 해당하는 부분이다.
 */


/*
    Serialize란
    직렬화라는 개념이다.

    임의의 데이터를 다른 저장소(이를테면 쉽게 이야기하면 네트워크상에 다른 컴퓨터 )에 그대로 보내어 똑같은 데이터를 만들어 내는 것을 이야기한다
    보내는 과정에서, 바이트 단위로 일렬로 늘어세워 직렬 형태로 만들어 전송하므로
    직렬화 Serialization이라는 이름이 붙었다.

    <--MonoBehaviour 클래스에는 직렬화가 적용되어 있다.
    --> 그러므로 유니티 에디터 상에서 해석하여 에디터 상에 필요한 형태로 노출가능하다.

    CItemInfo는 쌩 클래스다.
    그래서 Serialize가 적용되어 있지 않다.
    <-- 그래서 유니티 에디터 상에서 해석 불가하여 에디터 상에 필요한 형태로 노출 불가하다.


    C#의 속성(attribute)문법을 이용하여
    쌩 클래스에
    직렬화를 적용하겠다.
*/

//쌩클래스에 '직렬화' 적용
[Serializable]  //<--C#의 속성문법
public class CItemInfo
{
    public int mId = 0; //아이템마다의 고유 식별자

    public string mName = "";   //아이템 이름
    public string mImgRscId = "";   //아이템 이미지 식별자
}
