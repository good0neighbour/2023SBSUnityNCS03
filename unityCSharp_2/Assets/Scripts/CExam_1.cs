/*


    LinkedList<T>

        ��ũ�帮��Ʈ

    �ڷᱸ��DataStructure: �ڷḦ ��� ������.
        ������ ���� ��� Ư���� �ٸ���.

    �迭: ������ Ÿ���� ���ҵ��� �������� �޸� ��
    ��ũ�帮��Ʈ: '���Node'�� '������'�� '��ũlink'�� ������, ������ ��ũ�� ���� '��������(���ٷ�)' '����'�Ǿ� �ִ� �ڷ�


        �ܹ��� ��ũ�帮��Ʈ Single Linked List: �Ӹ��������� ����
        ����� ��ũ�帮��Ʈ Double Linked List: �Ӹ��������� ����, ���������� ���� ����
            <-- C#�� ��ũ�帮��Ʈ�� ����ũ�帮��Ʈ�� ��������ִ�.

        ����:
            i) (����)�迭�� ����, ���� �߿� �ڷḦ �߰�, ���� ������ ������ �޸� ����
            ii) �ڷḦ �߰�, �����ϴµ� �ɸ��� �ð��� �����ϴ� O(1)
        ����:
            i) ��������(random access)�� �Ұ�
            ii) ������ �ڷḦ ã�µ� �ð��� ���� �ɸ� ���� �ִ�. Ž�� O(n)

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CExam_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //��ũ�帮��Ʈ ��ü�� �ϳ� ����
        LinkedList<string> tNames = new LinkedList<string>();

        tNames.AddFirst("Aa");  //Head�ʿ� �߰�
        tNames.AddLast("Zz");   //Tail�ʿ� �߰�

        foreach (var t in tNames)
        {
            Debug.Log(t);
        }

        //��ũ�� ����Ʈ�� ���������� ������� �ʴ´�
        //tNames[0] = "Hh";   //<-- �׷��Ƿ� �̰��� �ȵ�

        Debug.Log("=======");

        //Head������ �����Ͽ� �߰�
        tNames.AddAfter(tNames.First, "Bb");
        tNames.AddAfter(tNames.First.Next, "Cc");
        //Tail������ �����Ͽ� �߰�
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
        //�����˻� O(n)
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
