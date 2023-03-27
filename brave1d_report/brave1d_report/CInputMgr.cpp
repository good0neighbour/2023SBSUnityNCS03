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
        //��簡 �ڰ��ִٴ� �޼��� ���
        mUI->Display(BraveIsSleeping);

        //���� ���� ����
        return false;
    }
    case 'a':
    {
        //����� ���°� Move�� �ƴ� ���
        if (CRyuMgr::GetInstance()->mStatus != Move)
        {
            //������ �� ���� ����̶�� �˸�
            //�ݺ��Ǵ� ���ڿ� ����� �߻�ȭ
            mUI->Display(UnavailableCommand, tMoveDir);

            //���� ���
            return true;
        }

        if (tBrave->GetX() > 0)
        {
            tBrave->DoMove(-1);
            mUI->Display(MoveLeft);
        }
        else
        {
            mUI->Display(CantMove);
        }

        //���� ���
        return true;
    }
    case 'd':
    {
        //����� ���°� Move�� �ƴ� ���
        if (CRyuMgr::GetInstance()->mStatus != Move)
        {
            //�ݺ��Ǵ� ���ڿ� ����� �߻�ȭ
            mUI->Display(UnavailableCommand, tMoveDir);

            //���� ���
            return true;
        }

        if (tBrave->GetX() < 4)
        {
            tBrave->DoMove(+1);

            mUI->Display(MoveRight);
        }
        else
        {
            mUI->Display(CantMove);
        }

        //���� ���
        return true;
    }
    case 'l':
    {
        //���� ���� ����
        mUI->NextLanguage();

        //���� �Ǿ����� �˸��� ���ڿ� ���
        mUI->Display(LanguageChanged);

        //���� ���
        return true;
    }
    default:
    {
        //�ݺ��Ǵ� ���ڿ� ����� �߻�ȭ
        mUI->Display(UnavailableCommand, tMoveDir);

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
        if (CRyuMgr::GetInstance()->mStatus != Combat && CRyuMgr::GetInstance()->mStatus != BossCombat)
        {
            //�ݺ��Ǵ� ���ڿ� ����� �߻�ȭ
            mUI->Display(UnavailableCommand, tMoveDir);

            //���� ���
            return true;
        }

        CUnit* tpUnit = nullptr;
        CUnit* tpAttacker = nullptr;

        int tDiceNumber;

        //���� �����Ӱ��� ����
        if (CRyuMgr::GetInstance()->mStatus == Combat)
        {
            tDiceNumber = rand() % 6 + 1;
            cout << tDiceNumber << endl;

            //�������� ���� switch���� if������ ����
            if (tDiceNumber < 4)
            {
                tpUnit = tBrave;
                tpAttacker = tSlime;

                mUI->Display(BraveDamaged);
            }
            else
            {
                tpUnit = tSlime;
                tpAttacker = tBrave;

                mUI->Display(SlimeDamaged);
            }
            tpUnit->DoDamage(tpAttacker);
        }
        //���� �����Ӱ��� ����
        else
        {
            int tStatus = 0;   //0: ��, 1: ��, 2: ��

            //0: ��, 1: ��, 2: ��
            int tBossDice = rand() % 3;
            tDiceNumber = rand() % 3;

            switch (tDiceNumber)
            {
            case 0:
                mUI->Display(BraveRockPaperScissors, 'R');
                switch (tBossDice)
                {
                case 0:
                    mUI->Display(BossRockPaperScissors, 'R');
                    tStatus = 1;
                    break;
                case 1:
                    mUI->Display(BossRockPaperScissors, 'S');
                    tStatus = 0;
                    break;
                case 2:
                    mUI->Display(BossRockPaperScissors, 'P');
                    tStatus = 2;
                    break;
                }
                break;
            case 1:
                mUI->Display(BraveRockPaperScissors, 'S');
                switch (tBossDice)
                {
                case 0:
                    mUI->Display(BossRockPaperScissors, 'R');
                    tStatus = 2;
                    break;
                case 1:
                    mUI->Display(BossRockPaperScissors, 'S');
                    tStatus = 1;
                    break;
                case 2:
                    mUI->Display(BossRockPaperScissors, 'P');
                    tStatus = 0;
                    break;
                }
                break;
            case 2:
                mUI->Display(BraveRockPaperScissors, 'P');
                switch (tBossDice)
                {
                case 0:
                    mUI->Display(BossRockPaperScissors, 'R');
                    tStatus = 2;
                    break;
                case 1:
                    mUI->Display(BossRockPaperScissors, 'S');
                    tStatus = 0;
                    break;
                case 2:
                    mUI->Display(BossRockPaperScissors, 'P');
                    tStatus = 1;
                    break;
                }
                break;
            }

            //�������� ���� switch���� if������ ����
            if (tStatus == 2)
            {
                tpUnit = tBrave;
                tpAttacker = tSlime;

                mUI->Display(BraveDamaged);
            }
            else if (tStatus == 0)
            {
                tpUnit = tSlime;
                tpAttacker = tBrave;

                mUI->Display(SlimeDamaged);
            }
            else
            {
                //����.
                mUI->Display(Draw);
                //���� ���
                return true;
            }
            tpUnit->DoDamage(tpAttacker);
        }

        if (tSlime->GetHP() <= 0)
        {
            mUI->Display(SlimeTired);

            CRyuMgr::GetInstance()->mExp = CRyuMgr::GetInstance()->mExp + 300;

            //���� �¸� �� ��� ü�� �ʱ�ȭ
            tBrave->SetHP(1000.0f);
            mUI->Display(BraveHpUp);

            //���� ����
            return false;
        }
        else if (tBrave->GetHP() <= 0)
        {
            mUI->Display(BraveTired);

            //���� �й� �� ������ ü�� �ʱ�ȭ
            tSlime->SetHP(200.0f);

            //���� ����
            return false;
        }

        //���� ���
        return true;
    }
    default:
    {
        //�ݺ��Ǵ� ���ڿ� ����� �߻�ȭ
        mUI->Display(UnavailableCommand, tMoveDir);

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
        mInstance->mUI->Display(NewUIInstanceCreated);
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