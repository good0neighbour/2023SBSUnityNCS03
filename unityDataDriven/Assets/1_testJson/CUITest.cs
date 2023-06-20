using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    JSON JavaScript Object Notation
    원래는 자바스크립트 언어에서 오브젝트 개념을 표기할 때 쓰는 문법이었다.
    하지만 지금은 범용적인 텍스트 형식의 포멧 규격이다.

    xml을 대체한다

    주요 문법 구성요소는 다음과 같다.

    {}      오브젝트를 나타낸다
    키:값   형태의 데이터를 가진다
    키      는 문자열이다. 큰따옴표로 감싼다
    []      매열을 나타낸다.
    각각의 데이터는 ,로 구분
    배열의 원소도 ,로 구분


    JSON규격이 대세가 된 이유는
    텍스트 형식의 데이터의 장점과 바이너리 형식의 데이터의 장점에서 절충점을 찾았기 때문이다.

*/

public class CUITest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //json --> 사용자 정의 클래스 타입의 객체
    public void OnClickBtnFromJson()
    {
        //소스코드 내에 문자열 형태로 만든 json규격의 텍스트 데이터
        string tJson = @"{
                ""mName"":""폭풍류"",
                ""mStringList"":
                [
                    ""weapon_0"",
                    ""weapon_1""
                ],
                ""mLevel"":10,
                ""mExp"":1024
            }";

        //JsonUtility:유니티에서 제공하는 Json 클래스
        //파싱까지 다 해준다.
        CRyuTestInfo tInfo = JsonUtility.FromJson<CRyuTestInfo>(tJson);

        //출력
        Debug.Log(tInfo.mName);
        Debug.Log(tInfo.mLevel.ToString());
        Debug.Log(tInfo.mExp.ToString());

        foreach (var t in tInfo.mStringList)
        {
            Debug.Log(t);
        }
    }
    // 사용자 정의 클래스 타입의 객체 --> json
    public void OnClickBtnToJson()
    {
        CRyuTestInfo tInfo = new CRyuTestInfo();
        tInfo.mName = "알베르토";
        tInfo.mLevel = 7;
        tInfo.mExp = 2048;
        tInfo.mStringList = new List<string>();
        tInfo.mStringList.Add("weapon_777");
        tInfo.mStringList.Add("weapon_999");

        //json데이터 생성
        string tJson = JsonUtility.ToJson(tInfo);

        //출력
        Debug.Log(tJson);
    }

    //Json데이터 덮어쓰기
    public void OnClickBtnOverwriteFromJson()
    {
        //기존의 데이터
        string tJson = @"{
                ""mName"":""폭풍류"",
                ""mStringList"":
                [
                    ""weapon_0"",
                    ""weapon_1""
                ],
                ""mLevel"":10,
                ""mExp"":1024
            }";

        //JsonUtility:유니티에서 제공하는 Json 클래스
        //파싱까지 다 해준다.
        CRyuTestInfo tInfo = JsonUtility.FromJson<CRyuTestInfo>(tJson);

        //출력
        Debug.Log(tInfo.mName);
        Debug.Log(tInfo.mLevel.ToString());
        Debug.Log(tInfo.mExp.ToString());

        foreach (var t in tInfo.mStringList)
        {
            Debug.Log(t);
        }

        //데이터 덮어쓰기
        string tJson_1 = @"{
                ""mName"":""알베르토"",
                ""mStringList"":
                [
                    ""weapon_333"",
                    ""weapon_99""
                ],
                ""mLevel"":7,
                ""mExp"":5000
            }";


        //tInfo에 tJson_1의 데이터를 덮어씌운다.
        JsonUtility.FromJsonOverwrite(tJson_1, tInfo);

        //출력
        Debug.Log("================");
        Debug.Log(tInfo.mName);
        Debug.Log(tInfo.mLevel.ToString());
        Debug.Log(tInfo.mExp.ToString());

        foreach (var t in tInfo.mStringList)
        {
            Debug.Log(t);
        }
    }
}
