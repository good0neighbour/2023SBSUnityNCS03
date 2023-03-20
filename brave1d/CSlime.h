#pragma once

//순환참조 컴파일 오류가 난다.
//둘 다 정의할 수 없다.


#include "CUnit.h"

//#include "CBrave.h"

class CBrave;

class CSlime: public CUnit
{
//public:   //어디서나 접근 가능
//private:    //해당 클래스 내에서만 접근 가능
//    float mHP = 200.0f;
//    float mAP = 500.0f;

public:
    CSlime();

public:
    //void DoDamage(CBrave* tBrave);
    virtual void DoDamage(CUnit* tAttacker) override;

    //mHP의 Getter함수

    //const: read only

    //앞에 const는 리턴된 값에 read only
    //뒤에 const는 해당 함수의 정의부 안에서 해당 클래스의 멤버변수의 read only

    //inline 해당 함수의 인라이닝 후보 적용
    //<-- 표기법 상으로는 함수지만 컴파일 결과로는 실제 함수가 아닌 호출부에 쌩제어구조로 컴파일된다.
    //inline const float GetHP() const
    //{
    //    return mHP;
    //}

    //inline const float GetAP() const
    //{
    //    return mAP;
    //}
};

