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
        if (CRyuMgr::GetInstance()->mStatus != Combat)
        {
            //반복되는 문자열 출력을 추상화
            mUI->Display(UnavailableCommand, tMoveDir);

            //게임 계속
            return true;
        }

        int tDiceNumber = rand() % 6 + 1;
        cout << tDiceNumber << endl;

        CUnit* tpUnit = nullptr;
        CUnit* tpAttacker = nullptr;

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

        if (tSlime->GetHP() <= 0)
        {
            mUI->Display(SlimeTired);

            CRyuMgr::GetInstance()->mExp = CRyuMgr::GetInstance()->mExp + 300;

            //전투 종료
            return false;
        }
        else if (tBrave->GetHP() <= 0)
        {
            mUI->Display(BraveTired);

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