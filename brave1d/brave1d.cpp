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

//해더파일: 클래스 등의 정의부의 선언이 담긴 부분이다. (함수의 선언이 담긴 부분이다 ). 즉 형태를 담고있는 부분이다.
#include "CBrave.h"
#include "CSlime.h"

using namespace std;


void DoMove(CBrave* tBrave, int tVelocity);


int main()
{
    srand((unsigned int)time(nullptr));

    int tWorld[5] = { 100, 0, 1, 0, 200 };

    //int tBraveX = 0;
    //float tBraveHP = 1000.0f;
    //float tBraveAP = 100.0f;
    CBrave tBrave;  //지역객체

    //CSlime으로 데이터 추상화
    CSlime tSlime;  //지역객체
    //float tSlimeHP = 200.0f;
    //float tSlimeAP = 500.0f;



    char tMoveDir = 'd';




    cout << "((용사와 슬라임))" << endl;
    cout << "==종료하려면 n을 입력하세요==" << endl;

    //game loop 게임 프로그램의 가장 핵심적인 구조
    //  일반 프로그램과 다르게 게임 프로그램은 게임루프라는 구조가 반드시 존재한다.
    while (true)
    {
        //input
        cout << "move?(a/d)";
        cin >> tMoveDir;


        if ('n' == tMoveDir)
        {
            cout << "brave is sleeping." << endl;
            break;  //거슬러 올라가봤을 때 처음 만나는 반복 제어구조를 탈출
        }

        if ('a' == tMoveDir)
        {
            if (tBrave.mX > 0)
            {
                DoMove(&tBrave, -1);
                //tBrave.mX = tBrave.mX - 1;
                cout << "<--move left" << endl;
            }
            else
            {
                cout << "Brave can not move any more." << endl;
            }
        }

        if ('d' == tMoveDir)
        {
            if (tBrave.mX < 4)
            {
                //tBrave.mX = tBrave.mX + 1;
                DoMove(&tBrave, +1);

                cout << "-->move right" << endl;
            }
            else
            {
                cout << "Brave can not move any more." << endl;
            }
        }

        int tAttrib = 0;
        tAttrib = tWorld[tBrave.mX];
        switch (tAttrib)
        {
        case 0: //아무것도 없음
        {
            cout << "No one here." << "(You are on" << tBrave.mX << "Tile)" << endl;
        }
        break;
        case 1: //슬라임 있음
        {
            cout << "Slime is here." << "(You are on" << tBrave.mX << "Tile)" << endl;

            char tIsRollDice = 'r';
            while (1)
            {
                cout << "Roll a Dice of Fate!(r):";
                cin >> tIsRollDice;

                if ('r' == tIsRollDice)
                {
                    //roll dice
                    int tDiceNumber = rand() % 6 + 1;
                    cout << tDiceNumber << endl;

                    switch (tDiceNumber)
                    {
                    case 1:
                    case 2:
                    case 3:
                    {
                        tBrave.mHP = tBrave.mHP - tSlime.mAP;

                        cout << "Brave is damaged" << endl;
                    }
                    break;
                    case 4:
                    case 5:
                    case 6:
                    {
                        tSlime.mHP = tSlime.mHP - tBrave.mAP;

                        cout << "Slime is damaged." << endl;
                    }
                    break;
                    }

                    if (tSlime.mHP <= 0)
                    {
                        cout << "Slime is very tired." << endl;

                        break;
                    }
                    if (tBrave.mHP <= 0)
                    {
                        cout << "Brave is very tired." << endl;

                        break;
                    }
                }
            }
        }
        break;
        case 100:
        {
            cout << "Brave is in home." << "(You are on" << tBrave.mX << "Tile)" << endl;
        }
        break;
        case 200:
        {
            cout << "Brave is in End of world." << "(You are on" << tBrave.mX << "Tile)" << endl;
        }
        break;
        }
    }


    cout << "슬라임은 심심하다." << endl << "어서 빨리 일어나라! 용사!" << endl;


    return 0;
}




void DoMove(CBrave* tBrave, int tVelocity)
{
    tBrave->mX = tBrave->mX + tVelocity;
}