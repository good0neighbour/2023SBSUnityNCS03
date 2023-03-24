//
//  main.cpp
//  4_tiny_brave1d
//
//  Created by ryu on 2020/02/14.
//  Copyright © 2020 ryu. All rights reserved.
//

/*
 created by pokpoongryu


 지형속성:
 100    집
 200    세상의 끝
 1      슬라임 출몰 지역

 */

/*
    CInputMgr 클래스 생성, 사용자 입력에 대한 처리 추상화.
    CBrave 클래스에 Status 추가, 용사의 상태에 따라 사용자의 입력 제한.
    콘솔창 문자열 출력은 CUIPlay가 대신 수행.
    그러는 김에 문자 입력도 CUIPlay가 대신 수행.
    문자열 출력은 언어 설정에 따라 다르게 출력.
*/

#include "CBrave.h"
#include "CSlime.h"

#include "CRyuMgr.h"
#include "CInputMgr.h"
#include "CUIPlay.h"

int main()
{
    int tWorld[5] = { 100, 0, 1, 0, 200 };

    CRyuMgr::GetInstance();
    CUIPlay tUIPlay;
    
    CBrave* tBrave = nullptr;
    tBrave = new CBrave();
    CSlime* tSlime = nullptr;
    tSlime = new CSlime();

    char tMoveDir = 'd';

    //입력매니저 인스턴스 생성
    CInputMgr::GetInstance(&tUIPlay);

    //새로운 콘솔 출력 방식 사용
    tUIPlay.Display(Initiatiation);

    while (true)
    {
        //새로운 콘솔 출력 방식 사용
        tUIPlay.Display(MoveQuestion);

        //새로운 입력 방식 사용
        tMoveDir = tUIPlay.InputFromUser();

        //입력문자를 KeyInput함수에 전달
        //KeyInput함수가 true 반환 시 게임 계속, false 반환 시 루프 종료
        if (!CInputMgr::GetInstance()->KeyInput(tMoveDir, tBrave))
        {
            break;
        }

        int tAttrib = 0;
        tAttrib = tWorld[tBrave->GetX()];
        switch (tAttrib)
        {
        case 0:
        {
            //새로운 콘솔 출력 방식 사용
            tUIPlay.Display(NoOneHere, tBrave->GetX());
        }
        break;
        case 1:
        {
            //전투 상태로 전환
            CRyuMgr::GetInstance()->mStatus = Combat;

            //새로운 콘솔 출력 방식 사용
            tUIPlay.Display(SlimeIsHere, tBrave->GetX());

            char tIsRollDice = 'r';
            while (1)
            {
                //새로운 콘솔 출력 방식 사용
                tUIPlay.Display(RollADice);

                //새로운 입력 방식 사용
                tIsRollDice = tUIPlay.InputFromUser();

                //오버로드된 KeyInput 함수 사용
                //true 반환 시 전투 루프 계속, false 반환 시 전투 루프 탈출
                if (!CInputMgr::GetInstance()->KeyInput(tIsRollDice, tBrave, tSlime))
                {
                    break;
                }
            }

            //이동 상태로 전환
            CRyuMgr::GetInstance()->mStatus = Move;

            //새로운 콘솔 출력 방식 사용
            tUIPlay.Display(Experience, CRyuMgr::GetInstance()->mExp);
        }
        break;
        case 100:
        {
            //새로운 콘솔 출력 방식 사용
            tUIPlay.Display(BraveHome, tBrave->GetX());
        }
        break;
        case 200:
        {
            //새로운 콘솔 출력 방식 사용
            tUIPlay.Display(WorldEnd, tBrave->GetX());
        }
        break;
        }
    }

    //새로운 콘솔 출력 방식 사용
    tUIPlay.Display(GameEnd);

    if (nullptr != tBrave)
    {
        delete tBrave;
        tBrave = nullptr;
    }
    if (nullptr != tSlime)
    {
        delete tSlime;
        tSlime = nullptr;
    }

    CRyuMgr::ReleaseInstance();

    //입력매니저 인스턴스 해제
    CInputMgr::ReleaseInstance();

    return 0;
}