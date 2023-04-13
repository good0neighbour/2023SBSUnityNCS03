/*
    '��Ÿ��' vs '���� Ÿ��'

    ����ü vs Ŭ����

    C# ������
    ����ü�� �� Ÿ������ ��޵ȴ�
    Ŭ������ ���� Ÿ������ ��޵ȴ�

*/
/*
    �̸��׸�, C++���� ������ ���� ǥ���� �ִٸ�

        ��)
	    CUnit tUnit;

        ��)
	    CUnit* tUnit = nullptr;
	    tUnit = new CUnit();

        ��)�� ��Ÿ������ �ٷ�� ����̰�, ��)�� ����Ÿ������ �ٷ�� ����̴�.
        ��, C#���� ����Ÿ���̶� C++���� �����ͺ����� �ٷ�� ����� ���� ���� ����� ���� ���̴�.

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SPoint
{
    //����ü�� ������� ���� �� �ʱ�ȭ ǥ���� �Ұ����ϴ�.
    public int mX;// = 0;
    public int mY;// = 0;
}

public class CRyuPoint
{
    //Ŭ������ ������� ���� �� �ʱ�ȭ ǥ���� �����ϴ�.
    public int mX = 0;
    public int mY = 0;
}



public class CExam_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�迭�� ����Ÿ��
        SPoint[] tPointArray_0 = null;
        tPointArray_0 = new SPoint[5];
        //����
        for(int ti = 0; ti < tPointArray_0.Length; ++ti)
        {
            tPointArray_0[ti].mX = ti;
            tPointArray_0[ti].mY = ti;
        }
        //ǥ��
        for (int ti = 0; ti < tPointArray_0.Length; ++ti)
        {
            string tString = $"x: {tPointArray_0[ti].mX.ToString()}, y: {tPointArray_0[ti].mY.ToString()}";

            Debug.Log(tString);
        }

        Debug.Log("==============");


        CRyuPoint[] tPointArray_1 = null;
        tPointArray_1 = new CRyuPoint[5];

        //����
        for (int ti = 0; ti < tPointArray_1.Length; ++ti)
        {
            //CRyuPointŸ������ ������� ���ҿ��� null�� ��Ʈ�˾� �ִ�.
            //�׷��Ƿ� ���� ��ü�� ������־�� �Ѵ�.
            tPointArray_1[ti] = new CRyuPoint();

            tPointArray_1[ti].mX = ti;
            tPointArray_1[ti].mY = ti;
        }
        //ǥ��
        for (int ti = 0; ti < tPointArray_1.Length; ++ti)
        {
            string tString = $"x: {tPointArray_1[ti].mX.ToString()}, y: {tPointArray_1[ti].mY.ToString()}";

            Debug.Log(tString);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
