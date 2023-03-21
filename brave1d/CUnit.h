#pragma once
//include guard

//부모클래스

class CUnit
{
public:
    CUnit() {};
    virtual ~CUnit() {};
    //가상함수를 포함한 클래스의 소멸자는
    //가상소멸자로 만들어야만 한다.
    //그렇지 않으면 자식클래스 소멸자 실행이 되지 않는다

    //생성자 호출
    //부모클래스 생성자 실행
    //자식클래스 생성자 실행

    //소멸자 실행
    //  (자식클래스 소멸자 실행) <--이런 현상을 방지하기 위해 가상소멸자를 적용
    //  부모클래스 소멸자 실행

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

