#include "CSlime.h"

#include "CBrave.h"

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

    this->mHP = this->mHP - tAttacker->GetAP();
}

//void CSlime::DoDamage(CBrave* tBrave)
//{
//    this->mHP = this->mHP - tBrave->GetAP();
//}