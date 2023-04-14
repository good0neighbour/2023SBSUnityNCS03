/*
    �Ű�����


        �Լ��� �Ű������� �ѱ�� ���

            ������ ����(����) pass by value
            ref����� pass by reference

            out�����: pass by reference + �ش� �Լ��� ���Ǹ� ������ ���� �ݵ�� �ش� ������ ���� �����Ǿ�� �Ѵ�


            param�����: N���� �Ű������� �޴´�
            ������ �Ű�����( �Ű����� �⺻�� �����̴� )
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
}
