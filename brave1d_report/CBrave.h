#pragma once

#include "CUnit.h"

class CSlime;

//용사의 상태
//이것으로 사용자의 입력을 제한한다.
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
    //용사의 현 상태
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