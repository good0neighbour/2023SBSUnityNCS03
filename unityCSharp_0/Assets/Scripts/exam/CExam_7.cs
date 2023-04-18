using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Generic

    C#���� �Ϲ�ȭ ���α׷���( General Programming )
        �� �����μ� �����Ǵ� �����̴�.

    Ÿ���� �Ű�����(�� �Ϲ�ȭ�Ͽ�)ó�� �ٷ��.
    <-- ���� �ٸ� Ÿ�Ե鿡 ���ؼ� ���� ������ �ڵ带 �����.


    C++�� template�� ������ ������ �߷����� ���� Ÿ���� ����������,
    C#�� generic�� ���� ������ �߷����� ���� Ÿ���� �����ȴ�.
    <--��, C++�� ������ ������ ��ü���� �ش� Ÿ�Ե鿡 ���� �Լ����� ���������
        C#�� ������ �������� ���׸� �ڵ� �� ��ü�� �����ϵȴ�.



    C/C++���� �ۼ��� ���α׷��� ���� ���۱���

        native code
        execute

    C#���� �ۼ��� ���α׷��� ���� ���۱���

        Compilation( C#�����Ϸ��� ���� �����, C#���� ���鿡�� ���� �������� ���� ��, ������ ����� �����Ϸ����� ������� ���� )

        IL( Intermediate Language ) //<-- CLR�� ���� �߰� ���

        CLR( Common Language Runtime )
            JIT( Just In Time )�����Ϸ�     //<-- ��������� �ʿ��ϸ� IL�� �ؼ��Ͽ� �ʿ��ϸ� native code�� ������
            native code     //<--CPU���� �ؼ��Ͽ� ����
            execute
*/


public class CStack<T>
{
    int mCurIndex = 0;
    T[] mArray = new T[100];    //����� �����Ҵ�

    public void Push(T t)
    {
        mArray[mCurIndex++] = t;
    }
    public T Pop()
    {
        return mArray[--mCurIndex];
    }
}

public class CExam_7 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //step_0
        //��
        int tA = 3;
        int tB = 2;
        DoSwap(ref tA, ref tB);
        Debug.Log($"after: tA: {tA.ToString()}, tB: {tB.ToString()}");

        float tAA = 3.14f;
        float tBB = 1.2f;
        DoSwap(ref tAA, ref tBB);
        Debug.Log($"after: tA: {tAA.ToString()}, tB: {tBB.ToString()}");



        //generic�� �ƴ����� ���� ������ �� �� ����.
        //var Ÿ�� �߷� �����
        var tX = 3; //��������� tX�� Ÿ���� �����ȴ�. ������ c#�� ��������� CLR�� ���� �ؼ��ǹǷ� �ӵ��� �������� ����
        Debug.Log($"tX: {tX.ToString()}");


        //step_1
        //���׸� Ŭ����
        CStack<int> tStack = new CStack<int>();
        tStack.Push(5);
        tStack.Push(10);

        int tXX = tStack.Pop();
        int tXXX = tStack.Pop();
        //10, 5
        Debug.Log($"tXX: {tXX.ToString()}, tXXX: {tXXX.ToString()}");

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
