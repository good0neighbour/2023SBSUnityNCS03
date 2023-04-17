using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    boxing, unboxing


        boxing, unboxing�� C#���� type system�� ������ �����ϱ� ���� ������� �����̴�.
*/

public class CExam_6 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //object
        //C#���� ��� ����Ÿ���� �ñ����� �θ�Ŭ����(���Ŭ����)��.

        //step_0
        int tA = 777;   //��Ÿ���� ���� tA
        object tObjectA = tA;   //boxing    ��Ÿ�� --> ����Ÿ��
        // ���޸𸮿� ��ü�� ����� ���� �����ϴ� ������ �Ͼ�Ƿ�
        //���ɻ� ���� �ʴ�
        Debug.Log("boxing " + tObjectA);

        //unboxing  ����Ÿ�� --> ��Ÿ��
        int tB = (int)tObjectA; //unboxing�� ��������� ������߸� �Ѵ�. ���ɻ� ���� �ʴ�.
        Debug.Log("unboxing " + tB);




        //step_1
        object tD = 999;    //boxing //999�� ����� intŸ��(��Ÿ��), tD�� objectŸ�� (����Ÿ��)
        long tLong_0 = (int)tD;  //unboxing, ��Ÿ�Գ����� ����ȯ�� �Ϲ���

        object tE = 777;
        //long tLong_1 = (long)tE;    //unboxing�� �����Ƿ� ���� �� ����

        object tF = 333;
        long tLong_2 = (long)(int)tF;   //unboxing, ��Ÿ�Գ����� ����ȯ�� �����


        //step_2
        int tFirst = 1;
        int tSecond = 2;
        //������ ���ڿ� ���������� boxing�� �Ͼ��. int -> object, ��-->����Ÿ��
        Debug.Log($"A few Numbers: {tFirst}, {tSecond}");
        //������ ���ڿ� ���������� boxing�� �Ͼ�� �ʴ´�.
        //�׷��Ƿ� �ش� ǥ���� ���ɻ� �����̴�.
        Debug.Log($"A few Numbers: {tFirst.ToString()}, {tSecond.ToString()}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
