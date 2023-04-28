/*

    Stack<T>
    Queue<T>

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


    ���۸��� ������ �ִ� �ڷᱸ��
    ����: LIFO    Last Input First Output
    ť: FIFO      First Input First Output
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CExam_2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Stack<int> tStack = new Stack<int>();

        tStack.Push(1);
        tStack.Push(777);
        tStack.Push(9);

        while (tStack.Count > 0)
        {
            int t = tStack.Peek();

            Debug.Log(t.ToString());

            tStack.Pop();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
