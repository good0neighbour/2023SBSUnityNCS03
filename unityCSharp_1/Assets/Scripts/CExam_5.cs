/*
    ����ȯ

    C#������ ����ȯ�� �����ϴ� ����� ũ�� �� ������ �ִ�.

    i) �����Ϸ��� Ÿ�� ĳ��Ʈ(����ȯ) ������ ���� <--�츮�� �˰� �ִ� �� ����ȯ �����ڴ�.
    ii) as ������
        �⺻Ÿ���� �ȵ�( nullable(null���� ���� �� �ִ� Ÿ��)�� Ÿ�Կ� �����ϴ� )
        <-- ������ ��ü�� ������ ����

        is ������: ����ȯ�� �������� �˻��ϴ� �����ڴ�.
            <-- �� �ƴϸ� ������ ����


        as�����ڸ� ����� �� �ִ� �����
        as�����ڸ� ����ϴ� ���� Ÿ��ĳ��Ʈ �����ڸ� ����ϴ� ��캸�� �����ϴ�.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class CUnitRyu
{
}
class CActorRyu : CUnitRyu
{
}
class CBraveRyu : CActorRyu
{
}



public class CExam_5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //step_0
        int tA = 3;
        float tB = 3.14f;
        //�⺻Ÿ��, �����Ϸ����� �����ϴ� Ÿ��ĳ��Ʈ ����
        tA = (int)tB;

        //�⺻Ÿ�Կ� as ������ �ȵ�
        //tA = tB as int;



        //step_1, step_2
        //'�θ�Ŭ���� Ÿ���� ����'�� '�ڽ�Ŭ����Ÿ���� ��ü'�� ����Ų��. �̷��� ��츸 ����ȯ�� �����Ѵ�.

        //step_1
        //-----step_2 ���ٴ� step_1ǥ���� ���� �����ϴ�.-----

        CUnitRyu tUnit = new CUnitRyu();
        CActorRyu tActor = new CActorRyu();
        CBraveRyu tBrave = new CBraveRyu();

        //����ȯ ����
        //��Ÿ�ӿ� ��ü�� Ÿ���� ��ȯ�Ϸ��� Ÿ�԰� ��ġ�ϴ� ��쿡�� ����ȯ�� �����Ѵ�.
        //'���� ��'�� ����ȯ�� �����ϰ� �������� ���ο� ���� ������(�Ǵ� ��ȿ��) ������ �����Ѵ�.
        CUnitRyu u = tActor as CUnitRyu;
        if (null != u)
        {
            Debug.Log("OK, actor as unit");
        }
        //����ȯ ����
        CBraveRyu v = tActor as CBraveRyu;
        if (null != v)
        {
            Debug.Log("___OK, actor as brave");
        }


        //step_1.5
        //is�����ڴ� �� �ƴϸ� ������ ����
        bool tIsU = tActor is CUnitRyu;
        if (false != tIsU)
        {
            Debug.Log("___OK, actor as unit");
        }
        //����ȯ ����
         bool tIsV= tActor is CBraveRyu;
        if (false != tIsV)
        {
            Debug.Log("OK, actor as brave");
        }




        //step_2
        //������ ������ ����ȯ�� ������ ������ �����Ǿ� �ִ�.
        //�׷��Ƿ� ������ ����ȯ�� �����Ϸ��� �Ѵ�.
        //<-- ������ ���������� ��Ÿ�Կ� ��� ���� ���� �� �� ����.

        try    //���� ó�� ����
        {
            //���⿡ ������ ������ �ΰ�, ���� �ش� �������� �������� ��Ȳ(������ ����)�� �߻��ϸ� catch��������
            //�����ϰ� ������ ������ �̵��Ͽ� ���ܻ�Ȳ�� ó���� �� �ְ� �ϴ� �����̴�.

            CUnitRyu uu = (CUnitRyu)tActor;
        }
        catch(InvalidCastException)
        {
            Debug.Log("-->NOT OK, actor as NOT unit");
        }

        try    //���� ó�� ����
        {
            CBraveRyu vv = (CBraveRyu)tActor;
        }
        catch (InvalidCastException)
        {
            Debug.Log("-->NOT OK, actor as NOT brave");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
