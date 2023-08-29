/*
    PlayerPrefs클래스

    유니티에서 제공하는
    플레이 데이터 '저장', '불러오기' ( save, load ) 기능
    관리 클래스

    <--추상화된 형태로 디스크에 save, load 기능 제공을 한다.
    <--local file 대상이다.
    <--단일 데이터만 저장할 수 있다.


    int, float, string 타입을 대상으로 기능이 준비되어 있다.
    각각에 대응되는 setter, getter함수가 마련되어있다.


    '키:값 key:value 쌍'의 데이터 형식으로 데이터를 다룬다.

*/

/*
참고
    SortedDictionary: '이진탐색트리 자료구조'를 컬렉션으로 만들어 놓은 것이다.
    Dictionary: '해시 자료구조'를 만들어놓은 것이다

    키:값 쌍의 데이터를 원소로 다룬다

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLoadSave : MonoBehaviour
{
    //'플레이 관련 데이터'로 가정

    string mPlayerName = "";
    int mLevel = 0;
    int mExp = 0;

    float mPosition = 0.0f;


    private void OnGUI()
    {
        GUIStyle tStyle = new GUIStyle();
        tStyle.fontSize = 36;

        GUI.Label(new Rect(0, 150 + 0, 250, 50), $"플레이어 이름: {mPlayerName}");
        GUI.Label(new Rect(0, 150 + 50, 250, 50), $"레벨: {mLevel.ToString()}");
        GUI.Label(new Rect(0, 150 + 100, 250, 50), $"경험치: {mExp.ToString()}");
        GUI.Label(new Rect(0, 150 + 150, 250, 50), $"위치: {mPosition.ToString()}");


        if (GUI.Button(new Rect(0, 0, 150, 50), "NEW"))
        {
            OnClickNew();
        }
        if (GUI.Button(new Rect(0, 50, 150, 50), "SAVE"))
        {
            OnClickSave();
        }
        if (GUI.Button(new Rect(150, 50, 150, 50), "LOAD"))
        {
            OnClickLoad();
        }

        if (GUI.Button(new Rect(0, 100, 150, 50), "Play it"))
        {
            OnPlayit();
        }


        if (GUI.Button(new Rect(150, 100, 150, 50), "test Clear"))
        {
            //저장된 데이터를 모두 지운다.
            //disk
            PlayerPrefs.DeleteAll();

            //memory
            OnClickNew();
        }

    }

    void OnClickNew()
    {
        //메모리에 있는 플레이관련 데이터를 초기화하여 준비
        mPlayerName = "";
        mLevel = 0;
        mExp = 0;

        mPosition = 0.0f;
    }

    void OnClickSave()
    {
        //memory ----> disk
        //disk에 값을 써넣는다(설정한다)라는 개념이므로 Setter사용
        //  PlayerPrefs는 키로 문자열 타입을 사용한다.
        //  여기서는 일관적인 표현을 위해 변수 이름과 맞췄다.
        PlayerPrefs.SetString("mPlayerName", mPlayerName);
        PlayerPrefs.SetInt("mLevel", mLevel);
        PlayerPrefs.SetInt("mExp", mExp);
        PlayerPrefs.SetFloat("mPosition", mPosition);


        //디스크에 파일로 쓰기 승인완료<--disk에 적용
        //  : 디스크는 IO장치라서 cpu바운더리와 속도차가 있어 이러한 방식을 쓴다.
        PlayerPrefs.Save();
    }

    void OnClickLoad()
    {
        //disk ----> memory
        //disk에 값을 읽어온다(얻는다)라는 개념이므로 Getter사용
        //  PlayerPrefs는 키로 문자열 타입을 사용한다.
        //  여기서는 일관적인 표현을 위해 변수 이름과 맞췄다.
        mPlayerName = PlayerPrefs.GetString("mPlayerName", "");//<--두 번째 매개변수에는 기본값이 들어간다.
        //기본값: 파일에서 데이터를 얻지 못하면 '기본값'을 리턴
        mLevel = PlayerPrefs.GetInt("mLevel", 0);
        mExp = PlayerPrefs.GetInt("mExp", 0);
        mPosition = PlayerPrefs.GetFloat("mPosition", 0f);
    }
    void OnPlayit()
    {
        //다음 플레이를 가정함
        mPlayerName = "pokpoongryu";

        mExp += 10;
        mLevel = (int)(mExp / 100);

        mPosition += 25f;
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
