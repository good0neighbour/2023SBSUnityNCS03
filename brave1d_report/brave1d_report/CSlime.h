#pragma once

#include "CUnit.h"

class CBrave;

class CSlime: public CUnit
{
public:
    CSlime();
    virtual ~CSlime() {};

public:
    virtual void DoDamage(CUnit* tAttacker) override;
};

