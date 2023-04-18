/*
    struct vs class

    C#������ struct�� class�� ������ �ٸ���
    ������ ���� ���� �ٸ���

    i) struct�� ��Ÿ��, class�� ����Ÿ��
    ii) struct�� ������� ���� �� �ʱ�ȭ ǥ���� �Ұ��ϴ�
    iii) struct�� �Ű����� ���� �⺻ �����ڸ� ��������� ���� �� ����
    iv) struct�� ����� �������� �ʴ´�

*/


using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public struct SUnitInfo
{
    //������� ���� �� �ʱ�ȭ ǥ���� �Ұ��ϴ�
    public int mX;// = 0;
    public int mY;// = 0;

    //�⺻�����ڸ� ��������� ���� �� ����
    //public SUnitInfo()
    //{

    //}
    //�Ű����� �ִ� �����ڸ� ��������� ����
    //<--�̰��� ����
    public SUnitInfo(int tX, int tY)
    {
        mX = tX;
        mY = tY;
    }
}

//struct�� ����� �������� �ʴ´�
//public struct SActorInfo: SUnitInfo
//{

//}


public struct SUnit
{
    public string mName;
}

public class CExam_0 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //step_0
        //�⺻ ���� Ÿ���̹Ƿ� ��Ÿ��
        //�׸��� ������ü���̹Ƿ� ���� �޸𸮿� �ִ�
        int tA = 0;         //�ش� ǥ���� �����ڸ� ȣ������ �ʰ�, �޸𸮸� �ʱ�ȭ�ϴ� �ڵ��.
        int tB = new int(); //�ش� ǥ���� �����ڸ� ȣ���ϴ� ǥ���̴�.
        tB = 3;

        //����ü�� ���� Ÿ���̹Ƿ� '��Ÿ��'
        //�׸��� ������ü���̹Ƿ� ���� �޸𸮿� �ִ�
        SUnitInfo tInfo_0 = new SUnitInfo();    //<-- �����ڸ� ȣ��, �޸��� ���� 0���� ��� �ʱ�ȭ
        SUnitInfo tInfo_1 = new SUnitInfo(3, 2);    //<-- �����ڸ� ȣ��, 3, 2�� �ʱ�ȭ

        //����ü ��ü�� ������
        //new�����ڸ� ������� �ʰ� ���� ��(�ν��Ͻ�ȭ) �ִ�
        // <-- �����ڸ� ȣ������ �ʰ�, �޸𸮸� �Ҵ��Ѵ�
        SUnitInfo tInfo_2;
        //�ʵ�(�������)�� �ʱ�ȭ�Ǿ� ���� �����Ƿ�, �� ��ü�� ����Ϸ��� �ʱ�ȭ�� �� �Ŀ� ����ؾ� �Ѵ�
        tInfo_2.mX = 10;
        tInfo_2.mY = 20;

        Debug.Log($"tInfo_0: {tInfo_0.mX.ToString()}, {tInfo_0.mY.ToString()}");
        Debug.Log($"tInfo_1: {tInfo_1.mX.ToString()}, {tInfo_1.mY.ToString()}");
        Debug.Log($"tInfo_2: {tInfo_2.mX.ToString()}, {tInfo_2.mY.ToString()}");

        //step_1
        //List<T> �����迭
        //SUnit�� ����ü�̹Ƿ� ��Ÿ������ ����
        var tUnits = new List<SUnit>();

        SUnit t = new SUnit { mName = "First Man" };
        tUnits.Add(t);

        SUnit s = tUnits[0];
        s.mName = "New man";

        //���⼭ tUnits[0].mName�� �����̳�?
        Debug.Log($"tUnits[0].mName: {tUnits[0].mName}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
