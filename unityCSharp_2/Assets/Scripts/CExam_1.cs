/*


    LinkedList<T>

        링크드리스트

    자료구조DataStructure: 자료를 담는 구조물.
        구조에 따라 모두 특성이 다르다.

    배열: 동일한 타입의 원소들의 연속적인 메모리 블럭
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

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CExam_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //링크드리스트 객체를 하나 만듦
        LinkedList<string> tNames = new LinkedList<string>();

        tNames.AddFirst("Aa");  //Head쪽에 추가
        tNames.AddLast("Zz");   //Tail쪽에 추가

        foreach (var t in tNames)
        {
            Debug.Log(t);
        }

        //링크드 리스트는 임의접근을 허용하지 않는다
        //tNames[0] = "Hh";   //<-- 그러므로 이것은 안됨

        Debug.Log("=======");

        //Head쪽으로 접근하여 추가
        tNames.AddAfter(tNames.First, "Bb");
        tNames.AddAfter(tNames.First.Next, "Cc");
        //Tail쪽으로 접근하여 추가
        tNames.AddBefore(tNames.Last, "Yy");

        foreach (var t in tNames)
        {
            Debug.Log(t);
        }

        Debug.Log("=======");

        tNames.RemoveFirst();
        tNames.RemoveLast();

        foreach (var t in tNames)
        {
            Debug.Log(t);
        }

        Debug.Log("=======");
        //순차검색 O(n)
        LinkedListNode<string> tNode = tNames.Find("Cc");
        if (null != tNode)
        {
            Debug.Log("Find Success Cc");
        }

        LinkedListNode<string> tNode_0 = tNames.Find("Qq");
        if (null != tNode_0)
        {
            Debug.Log("Find Success Qq");
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
