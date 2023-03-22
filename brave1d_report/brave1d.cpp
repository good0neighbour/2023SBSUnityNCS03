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
*/

#include <iostream>

#include "CBrave.h"
#include "CSlime.h"

#include "CRyuMgr.h"
#include "CInputMgr.h"
#include "CUIPlay.h"

using namespace std;

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

    cout << "((용사와 슬라임))" << endl;
    cout << "==종료하려면 n을 입력하세요==" << endl;

    while (true)
    {
        cout << "move?(a/d)";
        cin >> tMoveDir;

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
            cout << "No one here." << "(You are on " << tBrave->GetX() << "Tile)" << endl;
        }
        break;
        case 1:
        {
            tBrave->mStatus = Attack;
            cout << "Slime is here." << "(You are on " << tBrave->GetX() << "Tile)" << endl;

            char tIsRollDice = 'r';
            while (1)
            {
                cout << "Roll a Dice of Fate!(r):";
                cin >> tIsRollDice;

                //오버로드된 KeyInput 함수 사용
                //true 반환 시 전투 루프 계속, false 반환 시 전투 루프 탈출
                if (!CInputMgr::GetInstance()->KeyInput(tIsRollDice, tBrave, tSlime))
                {
                    break;
                }
            }
            tBrave->mStatus = Move;
            tUIPlay.ExpDisplay();
        }
        break;
        case 100:
        {
            cout << "Brave is in home." << "(You are on " << tBrave->GetX() << "Tile)" << endl;
        }
        break;
        case 200:
        {
            cout << "Brave is in End of world." << "(You are on " << tBrave->GetX() << "Tile)" << endl;
        }
        break;
        }
    }

    cout << "슬라임은 심심하다." << endl << "어서 빨리 일어나라! 용사!" << endl;

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