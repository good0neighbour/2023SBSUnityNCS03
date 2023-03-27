#pragma once

#include "CUnit.h"

class CSlime;

class CBrave: public CUnit
{
private:
    int mX = 0;

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