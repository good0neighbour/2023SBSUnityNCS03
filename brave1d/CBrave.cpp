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


//::���� ���� ������( ���� ���� ������ )

void CBrave::DoMove(int tVelocity)
{
    //this: ��ü �ڱ� �ڽ��� ����Ű�� ������ ����
    //  �Ϲ������� ������� �ִ�.

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