#pragma once
//include guard

//부모클래스

class CUnit
{
//private:
protected:  //클래스 상속 계통 구조 안에서 접근 가능
    float mHP = 0.0f;
    float mAP = 0.0f;

public:
    inline const float GetHP() const
    {
        return mHP;
    }

    inline const float GetAP() const
    {
        return mAP;
    }

    //override + virtual
    //부모 클래스의 포인터 타입으로 자식클래스 타입의 객체들을 다룰 수 있다.
    virtual void DoDamage(CUnit* tAttacker) {};
};

