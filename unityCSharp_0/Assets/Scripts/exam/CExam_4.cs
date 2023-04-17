/*
    �Ű�����


        �Լ��� �Ű������� �ѱ�� ���

            ������ ����(����) pass by value
            ref����� pass by reference

            out�����: pass by reference + �ش� �Լ��� ���Ǹ� ������ ���� �ݵ�� �ش� ������ ���� �����Ǿ�� �Ѵ�


            ������ �Ű�����( �Ű����� �⺻�� �����̴� )
            param�����: N���� �Ű������� �޴´�
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CExam_4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int tA = 3;
        int tB = 2;

        //before
        Debug.Log($"DoSwap before {tA.ToString()}, {tB.ToString()}");

        //DoSwap(tA, tB);
        DoSwapRef(ref tA, ref tB);

        //after
        Debug.Log($"DoSwap after {tA.ToString()}, {tB.ToString()}");



        Doit(ref tA, out tB);

        DoPrint(3, 2);

        //�̷��� ǥ���� �����ϴ�
        int tResult = DoSum(3, 2, 0, 1, 2, 3);
        Debug.Log($"tResult: {tResult.ToString()}");
        //�̷��� ǥ���� �����ϴ�
        tResult = DoSum(3, 2, new int[] {0, 1, 2, 3});
        Debug.Log($"tResult: {tResult.ToString()}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DoSwap(int tA, int tB)
    {
        int tTemp = 0;
        tTemp = tA;
        tA = tB;
        tB = tTemp;
    }

    void DoSwapRef(ref int tA, ref int tB)
    {
        int tTemp = 0;
        tTemp = tA;
        tA = tB;
        tB = tTemp;
    }

    void Doit(ref int tA, out int tB)
    {
        //out���� ����� ������ �ش� �Լ��� ���Ǹ� ������ ���� �ݵ�� ���� �����Ǿ�� �Ѵ�.
        tB = 0;
    }

    //������ �Ű�����: �Ű������� ������ �� �ʱ�ȭ�� ������ �� �ִ�. <--ȣ���� �� ���ڸ� �������� ������ �ʱ⿡ ������ ������ ȣ���Ѵ�
    //�� ° �ʱⰪ�� '������ Ÿ�� ���'���߸� �Ѵ�
    //
    //ref, out������ ������ �Ű������޴� �Ű������� �⺻���� �����Ұ��ϴ�
    void DoPrint(int tA, int tB, /*ref*/ int tVal = 777)
    {
        Debug.Log($"{tA.ToString()}, {tB.ToString()}, {tVal.ToString()}");
    }

    //params ������ ������ �Ű��������� ���������ϴ�.
    int DoSum(int tA, int tB, params int[] tIntArray)
    {
        int tResult = 0;

        tResult += tA;
        tResult += tB;

        for(int i = 0; i < tIntArray.Length; i++)
        {
            tResult += tIntArray[i];
        }

        return tResult;
    }
}
