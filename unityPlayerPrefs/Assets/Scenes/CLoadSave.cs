/*
    PlayerPrefs클래스

    유니티에서 제공하는 플레이 데이터 '저장', '불러오기' ( save, load ) 기능 관리 클래스

    <--추상화된 형태로 디스크에 save, load 기능 제공을 한다.
    <--local file 대상이다.


    int, float, string 타입을 대상으로 기능이 준비되어 있다.
    각각에 대응되는 setter, getter함수가 마련되어있다.


    키:값 key:value 쌍의 데이터 형식으로 데이터를 다룬다.

*/

/*
참고
    SortedDictionary: 이진탐색트리 자료구조를 컬렉션으로 만들어 놓은 것이다.
    Dictionary: 해시 자료구조를 만들어놓은 것이다

    키:값 쌍의 데이터를 원소로 다룬다

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLoadSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
