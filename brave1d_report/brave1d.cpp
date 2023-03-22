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

#include <iostream>
#include <time.h>

#include "CBrave.h"
#include "CSlime.h"

#include "CRyuMgr.h"
#include "CInputMgr.h"
#include "CUIPlay.h"

using namespace std;

int main()
{
    srand((unsigned int)time(nullptr));
    int tWorld[5] = { 100, 0, 1, 0, 200 };

    CRyuMgr::GetInstance();
    CUIPlay tUIPlay;
    
    CBrave* tBrave = nullptr;
    tBrave = new CBrave();
    CSlime* tSlime = nullptr;
    tSlime = new CSlime();

    char tMoveDir = 'd';

    //입력매니저 인스턴스 생성
    CInputMgr::GetInstance();

    cout << "((용사와 슬라임))" << endl;
    cout << "==종료하려면 n을 입력하세요==" << endl;

    while (true)
    {
        cout << "move?(a/d)";
        cin >> tMoveDir;

        //입력문자를 KeyInput함수에 전달
        //KeyInput함수가 true 반환 시 게임 계속, false 반환 시 루프 종료
        if (CInputMgr::GetInstance()->KeyInput(tMoveDir, tBrave) == false)
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
            cout << "Slime is here." << "(You are on " << tBrave->GetX() << "Tile)" << endl;

            char tIsRollDice = 'r';
            while (1)
            {
                cout << "Roll a Dice of Fate!(r):";
                cin >> tIsRollDice;

                if ('r' == tIsRollDice)
                {
                    int tDiceNumber = rand() % 6 + 1;
                    cout << tDiceNumber << endl;

                    CUnit* tpUnit = nullptr;
                    CUnit* tpAttacker = nullptr;

                    switch (tDiceNumber)
                    {
                    case 1:
                    case 2:
                    case 3:
                    {
                        tpUnit = tBrave;
                        tpAttacker = tSlime;

                        cout << "Brave is damaged" << endl;
                    }
                    break;
                    case 4:
                    case 5:
                    case 6:
                    {
                        tpUnit = tSlime;
                        tpAttacker = tBrave;

                        cout << "Slime is damaged." << endl;
                    }
                    break;
                    }
                    tpUnit->DoDamage(tpAttacker);

                    if (tSlime->GetHP() <= 0)
                    {
                        cout << "Slime is very tired." << endl;

                        CRyuMgr::GetInstance()->mExp = CRyuMgr::GetInstance()->mExp + 300;

                        break;
                    }
                    else if (tBrave->GetHP() <= 0)
                    {
                        cout << "Brave is very tired." << endl;

                        break;
                    }
                }
            }

            tUIPlay.Display();
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