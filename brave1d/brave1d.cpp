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
    OOP의 4가지 특징


    추상화
        데이터의 추상화 + 코드의 추상화 ---> 데이터의 추상화

    은닉화

        멤버함수 뒤로 멤버변수를 감춘다.

    상속성

        공통된 속성들을 부모클래스에 두고,
        자식클래스들은 부모클래스를 이어받아 작성한다.

    다형성
    
        같은 메시지에 다른 반응




    디자인 패턴 Design Pattern : 프로그램 구조를 만드는 것에 대한, OOP의 모범답안집


    싱글톤 패턴
    Singleton Pattern
    : 큰 분류상 생성 패턴(객체를 어떻게 생성할 것인지에 대한 해결책)에 속한다

        싱글톤 패턴의 목적: 객체의 최대 생성 개수를 1개로 제한하는 패턴



    용사의 경험치 플레이 데이터는 CRyuMgr에서 관리한다

    -슬라임을 데미지 입혔을 시 100 경험치를 얻는다
    -슬라임을 처치했을 시 300 경험치를 얻는다
    -배틀이 끝나면 UI로 용사의 플레이 데이터를 표시한다

*/

#include <iostream>
#include <time.h>

//해더파일: 클래스 등의 정의부의 선언이 담긴 부분이다. (함수의 선언이 담긴 부분이다 ). 즉 형태를 담고있는 부분이다.
#include "CBrave.h"
#include "CSlime.h"

#include "CRyuMgr.h"
#include "CUIPlay.h"

using namespace std;


//void DoMove(CBrave* tBrave, int tVelocity);

//함수의 오버로드: 함수가 이름은 같고, 매개변수리스트가 다른 것
//  <-- 매개변수 리스트가 다르다( 매개변수 개수가 다르거나, 매개변수의 타입이 다른 것 )

//void DoDamage(CBrave* tBrave, CSlime* tSlime);
//void DoDamage(CSlime* tSlime, CBrave* tBrave);


int main()
{
    
    srand((unsigned int)time(nullptr));
    //지형정보 구축
    int tWorld[5] = { 100, 0, 1, 0, 200 };

    //용사의 전역적 플레이 데이터 생성
    CRyuMgr::GetInstance();
    //용사의 플레이 데이터 UI객체
    CUIPlay tUIPlay;
    

    //동적할당한 객체로 변경
    //new
    //CBrave tBrave;  //지역객체
    //CSlime tSlime;  //지역객체
    CBrave* tBrave = nullptr;
    tBrave = new CBrave();
    CSlime* tSlime = nullptr;
    tSlime = new CSlime();

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
            if (tBrave->GetX() > 0)
            {
                tBrave->DoMove(-1);
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
            if (tBrave->GetX() < 4)
            {
                //tBrave.mX = tBrave.mX + 1;
                tBrave->DoMove(+1);

                cout << "-->move right" << endl;
            }
            else
            {
                cout << "Brave can not move any more." << endl;
            }
        }

        int tAttrib = 0;
        tAttrib = tWorld[tBrave->GetX()];
        switch (tAttrib)
        {
        case 0: //아무것도 없음
        {
            cout << "No one here." << "(You are on " << tBrave->GetX() << "Tile)" << endl;
        }
        break;
        case 1: //슬라임 있음
        {
            cout << "Slime is here." << "(You are on " << tBrave->GetX() << "Tile)" << endl;

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

                    /*switch (tDiceNumber)
                    {
                    case 1:
                    case 2:
                    case 3:
                    {
                        tBrave->DoDamage(tSlime);

                        cout << "Brave is damaged" << endl;
                    }
                    break;
                    case 4:
                    case 5:
                    case 6:
                    {
                        tSlime->DoDamage(tBrave);

                        cout << "Slime is damaged." << endl;
                    }
                    break;
                    }*/


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
                    //다형성: 같은 메시지에 다른 반응
                    //  override + virtual + 부모클래스포인터 타입
                    tpUnit->DoDamage(tpAttacker);



                    
                    if (tSlime->GetHP() <= 0)
                    {
                        cout << "Slime is very tired." << endl;

                        //to do
                        //경험치 100 얻기
                        CRyuMgr::GetInstance()->mExp = CRyuMgr::GetInstance()->mExp + 300;

                        break;
                    }
                    if (tBrave->GetHP() <= 0)
                    {
                        cout << "Brave is very tired." << endl;

                        break;
                    }
                }
            }

            //to do
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

    //delete
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

    return 0;
}




//void DoMove(CBrave* tBrave, int tVelocity)
//{
//    tBrave->mX = tBrave->mX + tVelocity;
//}

//void DoDamage(CBrave* tBrave, CSlime* tSlime)
//{
//    tBrave->mHP = tBrave->mHP - tSlime->mAP;
//}

//void DoDamage(CSlime* tSlime, CBrave* tBrave)
//{
//    tSlime->mHP = tSlime->mHP - tBrave->mAP;
//}