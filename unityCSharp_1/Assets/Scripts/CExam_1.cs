/*
    delegate
    �븮��

        C#ü�� �����ϴ� '����ȣ�� ����'��.

        ������ �޼ҵ�(�Լ�)�� ȣ���ϴ� ����� ���� '��ü'��.

        delegate��ü�� �޼ҵ�(�Լ�)�� �����ϴ� ������ ��������� �Ͼ��.
        <-- ȣ���� ����� ��������� �����ϰ� �ȴ�.
            --> ���ϴ� ���� �ݹ޴� ���� ������ ���ϰ� �����

    ����� ���: delegate���࿡�� �����ϸ� �ȴ�.

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUnit
{
    
    public void Doit(int tX)
    {
        Debug.Log($"CUnit.Doit {tX.ToString()}");
    }
}



public class CExam_1 : MonoBehaviour
{
    //��������Ʈ ���� ( ����ȣ�⵵��, C++�� ġ�� �Լ������� )
    delegate void RyuFunc(int t);   //��ü

    delegate void RyuMultiFunc();

    // Start is called before the first frame update
    void Start()
    {
        RyuFunc tRyu_0 = null;
        tRyu_0 = DoThat;
        tRyu_0(7);  //����ȣ��

        CUnit tUnit = new CUnit();

        RyuFunc tRyu_1 = null;
        tRyu_1 = tUnit.Doit;    //��ü�� �޼ҵ�(�Լ�)�� ������� �ϴ� ��쿡�� �ش� ��ü(�ν��Ͻ�)�� ǥ������� �Ѵ�
        tRyu_1(3);  //����ȣ��


        //multicast delegate
        //C#���� �����ϴ� ��������Ʈ�� ���� �޼ҵ带 ���ÿ� ������ �� �ִ�.
        RyuMultiFunc tCall = null;
        tCall += InputControl;
        tCall += UpdateControl;
        tCall += RenderControl;

        tCall();

        tCall -= UpdateControl;

        tCall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void DoThat(int tX)
    {
        Debug.Log($"CExam_1.DoThat {tX.ToString()}");
    }


    void InputControl()
    {
        Debug.Log("InputConstrol");
    }
    void UpdateControl()
    {
        Debug.Log("UpdateConstrol");
    }
    void RenderControl()
    {
        Debug.Log("RenderConstrol");
    }
}
