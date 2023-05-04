/*
    자료구조DataStructure: 자료를 담는 구조물.
        구조에 따라 모두 특성이 다르다.

    배열: 동일한 타입의 원소들의 '연속'적인 메모리 블럭
    링크드리스트: '노드Node'가 '데이터'와 '링크link'를 가지고, 각각의 링크에 의해 '선형으로(한줄로)' '연결'되어 있는 자료


        단방향 링크드리스트 Single Linked List: 머리에서부터 접근
        양방향 링크드리스트 Double Linked List: 머리에서부터 접근, 꼬리에서도 접근 가능
            <-- C#의 링크드리스트는 더블링크드리스트로 만들어져있다.

        장점:
            i) (원시)배열에 비해, 실행 중에 자료를 추가, 삭제 가능한 유연한 메모리 구조
            ii) 자료를 추가, 삭제하는데 걸리는 시간이 일정하다 O(1)
        단점:
            i) 임의접근(random access)는 불가
            ii) 임의의 자료를 찾는데 시간이 오래 걸릴 수도 있다. 탐색 O(n)


    동작명세가 정해져 있는 자료구조
    스택: LIFO    Last Input First Output
    큐: FIFO      First Input First Output


    트리: 1:n의 비선형구조, 계층형 자료구조
    이진트리
	    i)트리
	    ii)최대 2개까지의 자식노드
	    iii)lt, rt 자식노드


    이진탐색트리
	    i)이진트리
	    ii)중복된 값을 허용하지 않는다
	    iii)lt subtree의 값은 root보다 작고, rt subtree의 값은 root보다 크다
        iv)서브트리도 이진탐색트리

    해쉬테이블: 데이터가 곧 위치가 되는 자료구조


    키Key: 검색용 데이터
    값Value: 실제 데이터

    Dictionary

        해쉬테이블이 컬렉션으로 만들어진 것이다.
        검색속도 O(1)

        키는 중복을 허용하지 않는다

        <--자료구조 이론 상으로는 정렬되지 않는 자료구조다.
            하지만 C# Dictionary를 대상으로 정렬된 데이터를 얻는 표현이 존재한다.

    SortedDictionary
        이진탐색트리가 컬렉션으로 만들어진 것이다.
        검색속도 O(log n)

        키는 중복을 허용하지 않는다

        <-- 원소 추가 시 자동으로 정렬된 상태가 된다. 이것은 이진탐색트리의 특징이다.
            ( 그러므로 중위순회하면 정렬된 형태로 나온다 )

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CExam_3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("=====Dictionary");

        Dictionary<string, int> tDic = new Dictionary<string, int>();

        tDic.Add("One", 1); //원소 추가 함수
        tDic.Add("Two", 2);
        tDic["Three"] = 3;  //해당 데이터는 해당 컬렉션에 '존재하지 않으므로 추가'
        tDic["Three"] = 33; //중복을 허용하지 않으므로, 새로운 값으로 덮어씌워지게 됨.
        //<--연관배열 표기로 추가 가능, 하지만 의도하지 않은 동작이 될 수도 있으므로 주의

        foreach (var t in tDic)
        {
            Debug.Log($"key: {t.Key}, value: {t.Value.ToString()}");
        }

        Debug.Log(tDic["One"].ToString());
        //키를 인덱스처럼 사용하여 연관배열 표기하면 값이 나온다.
        //<-- 키를 사용한 검색 O(1)
        Debug.Log(tDic.ContainsKey("One").ToString());
        //<-- 키를 사용한 검색 O(1)
        Debug.Log(tDic.ContainsValue(1).ToString());
        //<-- 값를 사용한 검색 O(n)





        Debug.Log("=====SortedDictionary");


        SortedDictionary<string, int> tSortedD = new SortedDictionary<string, int>();

        tSortedD.Add("a", 11);
        tSortedD.Add("c", 3333);
        tSortedD.Add("b", 222);

        //중위순회하여 열거하기 때문에 정렬된 형태로 나온다
        foreach (var t in tSortedD)
        {
            Debug.Log($"key: {t.Key}, value: {t.Value.ToString()}");
        }
        //검색 시간복잡도는 O(log n)
        Debug.Log(tSortedD["c"].ToString());
        //검색 시간복잡도는 O(log n)
        Debug.Log(tSortedD.ContainsKey("d").ToString());
        //시간복잡도는 O(log n), 삭제 자체는 O(1)
        tSortedD.Remove("a");

        Debug.Log("remove=====");
        foreach (var t in tSortedD)
        {
            Debug.Log($"key: {t.Key}, value: {t.Value.ToString()}");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
