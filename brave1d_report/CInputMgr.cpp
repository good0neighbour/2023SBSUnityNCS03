#include "CInputMgr.h"
#include "CRyuMgr.h"
#include "CUIPlay.h"
#include "CBrave.h"
#include "CSlime.h"

#include <iostream>
#include <time.h>
using namespace std;

CInputMgr* CInputMgr::mInstance = nullptr;

CInputMgr::CInputMgr(CUIPlay* tUI)
{
    //������ ȣ�� �� ���� �ʱ�ȭ
    srand((unsigned int)time(nullptr));
    //�ܼ�â ǥ�ÿ� ��ü �ּ� ����
    mUI = tUI;
}
CInputMgr::~CInputMgr()
{

}

bool CInputMgr::KeyInput(char tMoveDir, CBrave* tBrave)
{
    //������ �� �����ϵ��� if������ �Ǿ��ִ� ���� switch������ ����
    //�������� ���� �� case�� �߰�ȣ �߰�
    switch (tMoveDir)
    {
    case 'n':
    {
        cout << "brave is sleeping." << endl;

        //���� ���� ����
        return false;
    }
    case 'a':
    {
        //����� ���°� Move�� �ƴ� ���
        if (tBrave->mStatus != Move)
        {
            //�ݺ��Ǵ� ���ڿ� ����� �߻�ȭ
            mUI->UnavailableCommand(tMoveDir);

            //���� ���
            return true;
        }

        if (tBrave->GetX() > 0)
        {
            tBrave->DoMove(-1);
            cout << "<--move left" << endl;
        }
        else
        {
            cout << "Brave can not move any more." << endl;
        }

        //���� ���
        return true;
    }
    case 'd':
    {
        //����� ���°� Move�� �ƴ� ���
        if (tBrave->mStatus != Move)
        {
            //�ݺ��Ǵ� ���ڿ� ����� �߻�ȭ
            mUI->UnavailableCommand(tMoveDir);

            //���� ���
            return true;
        }

        if (tBrave->GetX() < 4)
        {
            tBrave->DoMove(+1);

            cout << "-->move right" << endl;
        }
        else
        {
            cout << "Brave can not move any more." << endl;
        }

        //���� ���
        return true;
    }
    default:
    {
        //�ݺ��Ǵ� ���ڿ� ����� �߻�ȭ
        mUI->UnavailableCommand(tMoveDir);

        //���� ���
        return true;
    }
    }
}
bool CInputMgr::KeyInput(char tMoveDir, CBrave* tBrave, CSlime* tSlime)
{
    switch (tMoveDir)
    {
    case 'r':
    {
        //����� ���°� Attack�� �ƴ� ���
        if (tBrave->mStatus != Attack)
        {
            //�ݺ��Ǵ� ���ڿ� ����� �߻�ȭ
            mUI->UnavailableCommand(tMoveDir);

            //���� ���
            return true;
        }

        int tDiceNumber = rand() % 6 + 1;
        cout << tDiceNumber << endl;

        CUnit* tpUnit = nullptr;
        CUnit* tpAttacker = nullptr;

        //�������� ���� switch���� if������ ����
        if (tDiceNumber < 4)
        {
            tpUnit = tBrave;
            tpAttacker = tSlime;

            cout << "Brave is damaged" << endl;
        }
        else
        {
            tpUnit = tSlime;
            tpAttacker = tBrave;

            cout << "Slime is damaged." << endl;
        }
        tpUnit->DoDamage(tpAttacker);

        if (tSlime->GetHP() <= 0)
        {
            cout << "Slime is very tired." << endl;

            CRyuMgr::GetInstance()->mExp = CRyuMgr::GetInstance()->mExp + 300;

            //���� ����
            return false;
        }
        else if (tBrave->GetHP() <= 0)
        {
            cout << "Brave is very tired." << endl;

            //���� ����
            return false;
        }

        //���� ���
        return true;
    }
    default:
    {
        //�ݺ��Ǵ� ���ڿ� ����� �߻�ȭ
        mUI->UnavailableCommand(tMoveDir);

        //���� ���
        return true;
    }
    }
}

CInputMgr* CInputMgr::GetInstance(CUIPlay* tUI)
{
    if (mInstance == nullptr)
    {
        mInstance = new CInputMgr(tUI);
    }
    return mInstance;
}
CInputMgr* CInputMgr::GetInstance()
{
    if (mInstance == nullptr)
    {
        //���� ������ CUIPlay�� ���� ����������, ������� ����
        mInstance = new CInputMgr(new CUIPlay());
        mInstance->mUI->NewUIInstanceCreated();
    }
    return mInstance;
}

void CInputMgr::ReleaseInstance()
{
    if (mInstance != nullptr)
    {
        delete mInstance;
        mInstance = nullptr;
    }
}