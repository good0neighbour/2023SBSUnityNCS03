using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    ������Ƽ

    base�����
*/


public class CUnit
{
    private decimal mCurAP;

    //������Ƽ ���� ����    :setter, getter�� ������ִ� ����
    public decimal _CurAP
    {
        get { return mCurAP; }
        set { mCurAP = value; }
    }
    public void Doit()
    {
        Debug.Log("CUnit.Doit");
    }
}

public class CActor : CUnit
{    
    public void DoThat()
    {
        base.Doit();    //�θ�Ŭ������ ����Լ��� ȣ��

        Debug.Log("CAvtor.DoThat");
    }
}



public class CExam_5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CUnit tUnit = new CUnit();

        //������Ƽ ��� ��
        tUnit._CurAP = 777; //set
        Debug.Log($"unit cur ap: {tUnit._CurAP.ToString()}");   //get



        CActor tActor = new CActor();
        tActor.DoThat();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
