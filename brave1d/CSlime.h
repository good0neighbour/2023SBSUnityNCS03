#pragma once

//��ȯ���� ������ ������ ����.
//�� �� ������ �� ����.


#include "CUnit.h"

//#include "CBrave.h"

class CBrave;

class CSlime: public CUnit
{
//public:   //��𼭳� ���� ����
//private:    //�ش� Ŭ���� �������� ���� ����
//    float mHP = 200.0f;
//    float mAP = 500.0f;

public:
    CSlime();

public:
    //void DoDamage(CBrave* tBrave);
    virtual void DoDamage(CUnit* tAttacker) override;

    //mHP�� Getter�Լ�

    //const: read only

    //�տ� const�� ���ϵ� ���� read only
    //�ڿ� const�� �ش� �Լ��� ���Ǻ� �ȿ��� �ش� Ŭ������ ��������� read only

    //inline �ش� �Լ��� �ζ��̴� �ĺ� ����
    //<-- ǥ��� �����δ� �Լ����� ������ ����δ� ���� �Լ��� �ƴ� ȣ��ο� ��������� �����ϵȴ�.
    //inline const float GetHP() const
    //{
    //    return mHP;
    //}

    //inline const float GetAP() const
    //{
    //    return mAP;
    //}
};

