#pragma once

#include "CUnit.h"

//#include "CSlime.h"

//Ŭ���� ���� ����, �𷡽��� �̸��� �̸� �˷��ش�
class CSlime;

class CBrave: public CUnit
{
//public:
private:
    int mX = 0;
    /*float mHP = 1000.0f;
    float mAP = 100.0f;*/

public:
    CBrave();
    virtual ~CBrave() {};

public:
    void DoMove(int tVelocity);

    //void DoDamage(CSlime* tSlime);
    virtual void DoDamage(CUnit* tAttacker) override;

    //inline: �ζ��̴� ���δ� �����Ϸ��� �����Ѵ�.
    //�ζ��̴� �ĺ����� �����Ϸ���
    //  �ڵ尡 �۰�, ������ �۾ƾ� �Ѵ�.
    inline const int GetX() const
    {
        return mX;
    }

    /*inline const float GetHP() const
    {
        return mHP;
    }

    inline const float GetAP() const
    {
        return mAP;
    }*/
};

