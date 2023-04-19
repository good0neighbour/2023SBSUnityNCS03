/*
    ���� lambda

        delegate�� �ν��Ͻ��� ���̴� ����
            delegate�ν��Ͻ� ��� ��밡���ϴ�.( ����ȣ�� ������ )
        �̸��� ���� �Լ���.

        ()=>{}

        �Ű���������Ʈ=>���Ǻ� or ǥ����

        i) ������ ������� ���������.( ��, �Լ�ȣ�� ����� �����Ƿ� ������ )
        ii) ������ ����ȭ�� �޼��ȴ�.


    �͸����� anonymouse type

        �̸��� ���� Ÿ���̴�.

        ������ ����ȭ�� �޼��ȴ�


*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Func, Action ���� ����ϱ� ����
using System;

public class CExam_4 : MonoBehaviour
{

    delegate int RyuFunc(int tX);
    // Start is called before the first frame update
    void Start()
    {
        //����
        RyuFunc tRyu_0 = (tVal)=> { return tVal * tVal; };
        int tResult = tRyu_0(7);

        Debug.Log($"tResult: {tResult.ToString()}");


        //C# ���� �̸� �غ�� ��������Ʈ�� �ִ�.

        //Func ��������Ʈ
        //Func�� ���׸����� �Ǿ� �־� ��� Ÿ�Կ� ���� �����Ѵ�
        //�׷��Ƿ�, ��������Ʈ�� ���� �ǰ�, �̸� �غ�� Func�� ����ص� �ȴ�
        //  Func�� �Լ�function�� �����̴�. ��, �Է°��� ��°����� ���ǵȴ�
        Func<int, int> tRyu_1 = (tVal) => { return tVal + tVal; };
        tResult = tRyu_1(7);
        Debug.Log($"tResult: {tResult.ToString()}");

        //Action ��������Ʈ
        //  Action�� ���ν���procedure�� �����̴�. ��, �Է°��� �ִ�.
        Action<int> tRyu_2 = (tVal) => { Debug.Log(tVal.ToString()); };
        tRyu_2(1024);


        //ĸ��, �ܺκ��� ������
        //outer variable, captured variable, closure
        int tFactor = 5;    //���ٿ��� ���� �ܺκ���

        Func<int, int> tRyu_3 = (tVal) => { return tVal * tFactor; }; //ĸ��
        tResult = tRyu_3(3);
        Debug.Log($"tResult: {tResult.ToString()}");


        //�͸�����
        //�͸������� ��ü�� ������ ���� �ݵ�� var�� ����Ѵ�
        //�ֳ��ϸ� Ÿ���̸��� ���� �����̴�.
        var tRyu = new { mName = "ryu", mAge = 21 };

        Debug.Log(tRyu.ToString());

        Debug.Log(tRyu.mName.ToString());
        Debug.Log(tRyu.mAge.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
