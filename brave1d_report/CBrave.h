#pragma once

#include "CUnit.h"

class CSlime;

//����� ����
//�̰����� ������� �Է��� �����Ѵ�.
enum Status
{
    Move,
    Attack,
    Down
};

class CBrave: public CUnit
{
private:
    int mX = 0;

public:
    //����� �� ����
    enum Status mStatus;

public:
    CBrave();
    virtual ~CBrave() {};

public:
    void DoMove(int tVelocity);

    virtual void DoDamage(CUnit* tAttacker) override;

    inline const int GetX() const
    {
        return mX;
    }
};