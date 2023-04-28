/*
    '�̱��� ����'�� �����غ���
    singleton pattern
    <-- ��ü�� �ִ� ���������� 1���� �����ϴ� ���� ������ ����

    ���� ������ ù ��° ����


    i) mpInst�� static�� �����Ѵ�
    ii) �����ڴ� public�� �ƴϴ�
    iii)GetInst �Լ� �ȿ��� ��ü�� 1���� ���������ϴ� �Ǵ� ������ �����Ѵ�
    
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuMgr
{
    //mpInst�� static�� �����Ѵ�
    private static CRyuMgr mpInst = null;   //C#������ static���������� ���� �� null�� �ʱ�ȭ ǥ���� �����ϴ�
    //<-- C#���� static�� ����� ������ ��(�� Ư���� ��ġ High Frequency Heap)�� ��ġ�Ѵ�

    //�����ڴ� public�� �ƴϴ�
    private CRyuMgr()
    {
        Debug.Log("CRyuMgr.CRyuMgr");
    }
    //1���� �ν��Ͻ�ȭ�Ѵ�
    public static CRyuMgr GetInst()
    {
        if(null == mpInst)
        {
            mpInst = new CRyuMgr();
        }

        return mpInst;
    }
}


/*
    C#���� ��ü ���� �ܰ�

    ������ Ÿ������
    'ù ��°' �ν��Ͻ�'�� ������ ��
    ����Ǵ� ������ ������ ����.

    �������� �ܰ�

        i) ���� ������ �������(�޸�)�� 0���� �ʱ�ȭ
        ii) ���� ������ ���� �ʱ�ȭ ������ ����

        iii) ���� ������ ����
            ���࿡ ��Ӱ�����
            ��) ���̽� Ŭ������ ���� ������ ����
            ��) �ڽ��� ���� ������ ����

    ============
    �ν��Ͻ� ���� �ܰ�

        i) �ν��Ͻ� ������ �������(�޸�)�� 0���� �ʱ�ȭ
        ii) �ν��Ͻ� ������ ���� �ʱ�ȭ ������ ����

        iii) �ν��Ͻ� ������ ����
            ���࿡ ��Ӱ�����
            ��) ���̽� Ŭ������ �ν��Ͻ� ������ ����
            ��) �ڽ��� �ν��Ͻ� ������ ����

*/