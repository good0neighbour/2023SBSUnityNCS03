#pragma once

//#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"
#include "CActor.h"
#include "CBullet.h"

#include <vector>	//가변배열 컨테이너
using namespace std;

//C언어: 구조화 프로그래밍: 구조화
//C++언어: 객체지향 프로그래밍: 관계
//일반화 프로그래밍: 타입을 매개변수처럼 다루는 기법

//C++의 STL Standard Template Library
//<-- 자료구조, 알고리즘을 일반화시켜 만들어놓은 것
/*
	STL의 구성요소 3가지

	i) 컨테이너 <-- 자료구조의 일반화
	ii) 반복자 <-- 컨테이너와 알고리즘과 함께 사용 가능한 일반화된 포인터
	iii) 알고리즘 <-- 알고리즘의 일반화
*/


class pgeCircleShootor : public olc::PixelGameEngine
{
	//float mActorX = 0.0f;
	//float mActorY = 0.0f;
	CActor* mActor = nullptr;

	//탄환 여러발
	vector<CBullet*> mBullets;


public:
	pgeCircleShootor()
	{
		// Name your application
		sAppName = "pgeCircleShootor";
	}

public:
	bool OnUserCreate() override;
	bool OnUserDestroy() override;
	bool OnUserUpdate(float fElapsedTime) override;


	//직선 그리기 함수
	//수학적 방법에 의한 그리기( 방정식을 이용한 방법)를 할 것이다
	//직선 그리기에 가장 기초적인 알고리즘
	void DrawLineEquation(int tX_0, int tY_0, int tX_1, int tY_1);
	//원 그리기 함수
	//수학적 방법에 의한 그리기( 방정식을 이용한 방법)를 할 것이다
	//직선 그리기에 가장 기초적인 알고리즘
	void DrawCircleEquation(int tXCenter, int tYCenter, int tRadius, olc::Pixel tColor = olc::WHITE); //매개변수 기본값
};