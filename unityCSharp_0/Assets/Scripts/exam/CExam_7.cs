using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Generic

    C#���� �Ϲ�ȭ ���α׷���( General Programming )
        �� �����μ� �����Ǵ� �����̴�.

    Ÿ���� �Ű�����ó�� �ٷ��.
    <-- ���� �ٸ� Ÿ�Ե鿡 ���ؼ� ���� ������ �ڵ带 �����.


    C++�� template�� ������ ������ �߷����� ���� Ÿ���� ����������,
    C#�� generic�� ���� ������ �߷����� ���� Ÿ���� �����ȴ�.
    <--��, C++�� ������ ������ ��ü���� �ش� Ÿ�Ե鿡 ���� �Լ����� ���������
        C#�� ������ �������� ���׸� �ڵ� �� ��ü�� �����ϵȴ�.



    C/C++���� �ۼ��� ���α׷��� ���� ���۱���

        native code
        execute

    C#���� �ۼ��� ���α׷��� ���� ���۱���

        Compilation

        IL

        CLR
            JIT
            native code
            execute
*/

public class CExam_7 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int tA = 3;
        int tB = 2;
        DoSwap(ref tA, ref tB);
        Debug.Log($"after: tA: {tA.ToString()}, tB: {tB.ToString()}");

        float tAA = 3.14f;
        float tBB = 1.2f;
        DoSwap(ref tAA, ref tBB);
        Debug.Log($"after: tA: {tAA.ToString()}, tB: {tBB.ToString()}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Generic Function
    //������ ���� Ÿ���� �Ϲ�ȭ��Ű��, ��Ȳ�� ���� ��ü���� Ÿ���� �Լ����� ���������.
    void DoSwap<T>(ref T tA, ref T tB)
    {
        T tTemp;
        tTemp = tA;
        tA = tB;
        tB = tTemp;
    }
    //void DoSwap(ref int tA, ref int tB)
    //{
    //    int tTemp = 0;
    //    tTemp = tA;
    //    tA = tB;
    //    tB = tTemp;
    //}
    //void DoSwap(ref float tA, ref float tB)
    //{
    //    float tTemp = 0;
    //    tTemp = tA;
    //    tA = tB;
    //    tB = tTemp;
    //}
}
