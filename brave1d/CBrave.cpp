#include "CBrave.h"


#include "CSlime.h"
#include <iostream>

using namespace std;


CBrave::CBrave()
{
    mX = 0;
    mHP = 1000.0f;
    mAP = 100.0f;
}


//::영역 결정 연산자( 범위 지정 연산자 )

void CBrave::DoMove(int tVelocity)
{
    //this: 객체 자기 자신을 가리키는 포인터 변수
    //  암묵적으로 만들어져 있다.

    this->mX = this->mX + tVelocity;
}

void CBrave::DoDamage(CUnit* tAttacker)
{
    cout << "CBrave::DoDamage" << endl;

    this->mHP = this->mHP - tAttacker->GetAP();
}
//void CBrave::DoDamage(CSlime* tSlime)
//{
//    this->mHP = this->mHP - tSlime->GetAP();
//}