#include "CSlime.h"

#include "CBrave.h"
#include "CRyuMgr.h"

#include <iostream>
using namespace std;


CSlime::CSlime()
{
    mHP = 200.0f;
    mAP = 500.0f;
}


void CSlime::DoDamage(CUnit* tAttacker)
{
    cout << "CSlime::DoDamage" << endl;

    //to do
    this->mHP = this->mHP - tAttacker->GetAP();

    //경험치 100 얻기
    CRyuMgr::GetInstance()->mExp = CRyuMgr::GetInstance()->mExp + 100;
}

//void CSlime::DoDamage(CBrave* tBrave)
//{
//    this->mHP = this->mHP - tBrave->GetAP();
//}