/*
    Singleton Pattern�� ������ Ŭ����
    �� ��° ����

    static constructor ���������ڿ�
    property�� �̿�

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuMgrStaticConstructor
{
    //�����͸� ���������� �����Ѵٰ� ����
    public int mTestScore = 999;

    //mpInst�� static�� ����( ���� High Frequency Heap������ ����� ���̴� )
    //�����԰� ���ÿ� �Ҵ�
    //��Ÿ�� ���ȭ
    //              ���� �����ڰ� �۵�
    private static readonly CRyuMgrStaticConstructor mpInst = new CRyuMgrStaticConstructor();

    //�̹� ��ü�� �����Ǿ� �ִ�.
    //���⼭�� ������Ƽ ������ ���� ������ ��⸸ �Ѵ�.
    public static CRyuMgrStaticConstructor GetInst
    {
        get
        {
            return mpInst;
        }
    }

    //�����ڴ� public�� �ƴϴ�
    private CRyuMgrStaticConstructor()
    {
        Debug.Log("CRyuMgrStaticConstructor.CRyuMgrStaticConstructor");
    }
}
