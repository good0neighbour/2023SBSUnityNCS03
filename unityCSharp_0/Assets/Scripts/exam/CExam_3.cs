/*
    ����, �� �޸�

        ��������, �Ű������� ���ÿ� ����ȴ�

        ����Ÿ���� �ν��Ͻ�( �޸𸮿� ������ ������� ��ü )
        ( �׷��Ƿ� ����Ÿ���� �ν��Ͻ��� '������ ������ ���� �������� �����Ҵ�� ��ü')
        �� �� �޸𸮿� ����ȴ�.
        <-- C#���� �����Ҵ�� �޸𸮴� ��������� ������ �� ����.
            ������ ����� ��ü(�޸𸮴���, ��۸� ������)�� �ڵ����� ���ŵȴ�.( �ڵ����� �޸𸮰� �����ȴ� )



    Ȯ������


*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//StringBuilderŬ������ ����ϱ� ����
using System.Text;

public class CExam_3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //step_0
        int tResult = 0;    //�⺻Ÿ�Ե��� �� Ÿ������ ����Ѵ�
        tResult = DoFactorial(3);
        Debug.Log($"DoFactorial {tResult.ToString()}");


        //step_1
        StringBuilder tRef_0 = new StringBuilder("object0");
        Debug.Log(tRef_0);

        StringBuilder tRef_1 = new StringBuilder("object1");
        StringBuilder tRef_2 = tRef_1;
        Debug.Log(tRef_2);


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    int DoFactorial(int tN)
    {
        if (0 == tN)
        {
            return 1;
        }
        else
        {
            return tN * DoFactorial(tN - 1);
        }
    }
}
