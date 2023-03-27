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
    //생성자 호출 시 랜덤 초기화
    srand((unsigned int)time(nullptr));
    //콘솔창 표시용 객체 주소 저장
    mUI = tUI;
}
CInputMgr::~CInputMgr()
{

}

bool CInputMgr::KeyInput(char tMoveDir, CBrave* tBrave)
{
    //관리가 더 용이하도록 if문으로 되어있던 것을 switch문으로 변경
    //가독성을 위해 각 case에 중괄호 추가
    switch (tMoveDir)
    {
    case 'n':
    {
        //용사가 자고있다는 메세지 출력
        mUI->Display(BraveIsSleeping);

        //게임 루프 종료
        return false;
    }
    case 'a':
    {
        //용사의 상태가 Move가 아닌 경우
        if (CRyuMgr::GetInstance()->mStatus != Move)
        {
            //수행할 수 없는 명령이라고 알림
            //반복되는 문자열 출력을 추상화
            mUI->Display(UnavailableCommand, tMoveDir);

            //게임 계속
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

        //게임 계속
        return true;
    }
    case 'd':
    {
        //용사의 상태가 Move가 아닌 경우
        if (CRyuMgr::GetInstance()->mStatus != Move)
        {
            //반복되는 문자열 출력을 추상화
            mUI->Display(UnavailableCommand, tMoveDir);

            //게임 계속
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

        //게임 계속
        return true;
    }
    case 'l':
    {
        //다음 언어로 변경
        mUI->NextLanguage();

        //변경 되었음을 알리는 문자열 출력
        mUI->Display(LanguageChanged);

        //게임 계속
        return true;
    }
    default:
    {
        //반복되는 문자열 출력을 추상화
        mUI->Display(UnavailableCommand, tMoveDir);

        //게임 계속
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
        //용사의 상태가 Attack이 아닌 경우
        if (CRyuMgr::GetInstance()->mStatus != Combat && CRyuMgr::GetInstance()->mStatus != BossCombat)
        {
            //반복되는 문자열 출력을 추상화
            mUI->Display(UnavailableCommand, tMoveDir);

            //게임 계속
            return true;
        }

        CUnit* tpUnit = nullptr;
        CUnit* tpAttacker = nullptr;

        int tDiceNumber;

        //보통 슬라임과의 전투
        if (CRyuMgr::GetInstance()->mStatus == Combat)
        {
            tDiceNumber = rand() % 6 + 1;
            cout << tDiceNumber << endl;

            //가독성을 위해 switch문을 if문으로 변경
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
        //보스 슬라임과의 전투
        else
        {
            int tStatus = 0;   //0: 승, 1: 무, 2: 패

            //0: 묵, 1: 찌, 2: 빠
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

            //가독성을 위해 switch문을 if문으로 변경
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
                //비겼다.
                mUI->Display(Draw);
                //전투 계속
                return true;
            }
            tpUnit->DoDamage(tpAttacker);
        }

        if (tSlime->GetHP() <= 0)
        {
            mUI->Display(SlimeTired);

            CRyuMgr::GetInstance()->mExp = CRyuMgr::GetInstance()->mExp + 300;

            //전투 승리 시 용사 체력 초기화
            tBrave->SetHP(1000.0f);
            mUI->Display(BraveHpUp);

            //전투 종료
            return false;
        }
        else if (tBrave->GetHP() <= 0)
        {
            mUI->Display(BraveTired);

            //전투 패배 시 슬라임 체력 초기화
            tSlime->SetHP(200.0f);

            //전투 종료
            return false;
        }

        //전투 계속
        return true;
    }
    default:
    {
        //반복되는 문자열 출력을 추상화
        mUI->Display(UnavailableCommand, tMoveDir);

        //전투 계속
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
        //오류 방지로 CUIPlay를 새로 생성했으나, 권장되지 않음
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