/*
    �ڷᱸ��DataStructure: �ڷḦ ��� ������.
        ������ ���� ��� Ư���� �ٸ���.

    �迭: ������ Ÿ���� ���ҵ��� '����'���� �޸� ��
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


    Ʈ��: 1:n�� ��������, ������ �ڷᱸ��
    ����Ʈ��
	    i)Ʈ��
	    ii)�ִ� 2�������� �ڽĳ��
	    iii)lt, rt �ڽĳ��


    ����Ž��Ʈ��
	    i)����Ʈ��
	    ii)�ߺ��� ���� ������� �ʴ´�
	    iii)lt subtree�� ���� root���� �۰�, rt subtree�� ���� root���� ũ��
        iv)����Ʈ���� ����Ž��Ʈ��

    �ؽ����̺�: �����Ͱ� �� ��ġ�� �Ǵ� �ڷᱸ��


    ŰKey: �˻��� ������
    ��Value: ���� ������

    Dictionary

        �ؽ����̺��� �÷������� ������� ���̴�.
        �˻��ӵ� O(1)

        Ű�� �ߺ��� ������� �ʴ´�

        <--�ڷᱸ�� �̷� �����δ� ���ĵ��� �ʴ� �ڷᱸ����.
            ������ C# Dictionary�� ������� ���ĵ� �����͸� ��� ǥ���� �����Ѵ�.

    SortedDictionary
        ����Ž��Ʈ���� �÷������� ������� ���̴�.
        �˻��ӵ� O(log n)

        Ű�� �ߺ��� ������� �ʴ´�

        <-- ���� �߰� �� �ڵ����� ���ĵ� ���°� �ȴ�. �̰��� ����Ž��Ʈ���� Ư¡�̴�.
            ( �׷��Ƿ� ������ȸ�ϸ� ���ĵ� ���·� ���´� )

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

        tDic.Add("One", 1); //���� �߰� �Լ�
        tDic.Add("Two", 2);
        tDic["Three"] = 3;  //�ش� �����ʹ� �ش� �÷��ǿ� '�������� �����Ƿ� �߰�'
        tDic["Three"] = 33; //�ߺ��� ������� �����Ƿ�, ���ο� ������ ��������� ��.
        //<--�����迭 ǥ��� �߰� ����, ������ �ǵ����� ���� ������ �� ���� �����Ƿ� ����

        foreach (var t in tDic)
        {
            Debug.Log($"key: {t.Key}, value: {t.Value.ToString()}");
        }

        Debug.Log(tDic["One"].ToString());
        //Ű�� �ε���ó�� ����Ͽ� �����迭 ǥ���ϸ� ���� ���´�.
        //<-- Ű�� ����� �˻� O(1)
        Debug.Log(tDic.ContainsKey("One").ToString());
        //<-- Ű�� ����� �˻� O(1)
        Debug.Log(tDic.ContainsValue(1).ToString());
        //<-- ���� ����� �˻� O(n)





        Debug.Log("=====SortedDictionary");


        SortedDictionary<string, int> tSortedD = new SortedDictionary<string, int>();

        tSortedD.Add("a", 11);
        tSortedD.Add("c", 3333);
        tSortedD.Add("b", 222);

        //������ȸ�Ͽ� �����ϱ� ������ ���ĵ� ���·� ���´�
        foreach (var t in tSortedD)
        {
            Debug.Log($"key: {t.Key}, value: {t.Value.ToString()}");
        }
        //�˻� �ð����⵵�� O(log n)
        Debug.Log(tSortedD["c"].ToString());
        //�˻� �ð����⵵�� O(log n)
        Debug.Log(tSortedD.ContainsKey("d").ToString());
        //�ð����⵵�� O(log n), ���� ��ü�� O(1)
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
