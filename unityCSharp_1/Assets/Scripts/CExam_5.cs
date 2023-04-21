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



        //step_1
        CUnitRyu tUnit = new CUnitRyu();
        CActorRyu tActor = new CActorRyu();
        CBraveRyu tBrave = new CBraveRyu();

        //����ȯ ����
        //��Ÿ�ӿ� ��ü�� Ÿ���� ��ȯ�Ϸ��� Ÿ�԰� ��ġ�ϴ� ��쿡�� ����ȯ�� �����Ѵ�.
        CUnitRyu u = tActor as CUnitRyu;
        if (null != u)
        {
            Debug.Log("OK, actor as unit");
        }
        //����ȯ ����
        CBraveRyu v = tActor as CBraveRyu;
        if (null != v)
        {
            Debug.Log("OK, actor as brave");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
