#pragma once

#include "CUnit.h"

//#include "CSlime.h"

//클래스 전방 선언, 쿨래스의 이름만 미리 알려준다
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

    //inline: 인라이닝 여부는 컴파일러가 결정한다.
    //인라이닝 후보군에 적합하려면
    //  코드가 작고, 연산이 작아야 한다.
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

