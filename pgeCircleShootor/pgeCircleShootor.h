#pragma once


//#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"

#include "CActor.h"

class pgeCircleShootor : public olc::PixelGameEngine
{
	//float mActorX = 0.0f;
	//float mActorY = 0.0f;

	CActor mActor;


public:
	pgeCircleShootor()
	{
		// Name your application
		sAppName = "pgeCircleShootor";
	}

public:
	bool OnUserCreate() override
	{
		// Called once at the start, so create things here

		//주인공 기체의 초기위치 지정
		/*mActor.mPosition.x = ScreenWidth() * 0.5f;
		mActor.mPosition.y = ScreenHeight() * 0.5f + 80.0f;*/
		mActor.SetPosition(ScreenWidth() * 0.5f, ScreenHeight() * 0.5f + 80.0f);


		return true;
	}
	bool OnUserDestroy() override
	{
		//todo

		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{

		olc::vf2d tVelocity(0.0f, 0.0f);
		mActor.SetVelocity(tVelocity * 0.0f);

		float tXDir = 0.0f;	//x축 입력
		float tYDir = 0.0f;	//y축 입력

		//input
		// 축입력 방식으로 수정
		//왼쪽 방향키가 눌리고 있는 중이라면
		if (GetKey(olc::Key::LEFT).bHeld)
		{
			//std::cout << "dir.left" << std::endl;

			//오일러 축차적 방법에 의한 이동코드
			/*
				속도 * 거리의 변화량 / 시간의 변화량

				속도의 정의로부터 다음 식을 유도했다

				//현재 위치 = 이전 위치 + 속도 * 시간간격

				무한소 개념에 의해 간격이 정해지므로(불연속), 적분에 의한 방법보다는 부정확하다.
			*/

			//현재 위치 = 이전 위치 + 속도 * 시간간격
			//mActorX = mActorX - 0.01f * 1.0f;	//프레임 기반 진행
			//mActor.mActorX = mActor.mActorX - 50.0f * fElapsedTime;	//시간 기반 진행. fElapsedTime: 한 프레임에 걸린 시간

			//mActor.DoMoveX(-50.0f, fElapsedTime);
			//olc::vf2d tVelocity(-1.0f, 0.0f);	//속도의 방향( 단위벡터로 지정함 )
			//mActor.SetVelocity(tVelocity * 50.0f);
			//mActor.Update(fElapsedTime);	//벡터의 스칼라곱셈

			tXDir = -1.0f;
		}

		if (GetKey(olc::Key::RIGHT).bHeld)
		{
			//std::cout << "dir.right" << std::endl;
			//mActor.mPosition.x = mActor.mPosition.x + 50.0f * fElapsedTime;
			//olc::vf2d tVelocity(1.0f, 0.0f);
			//mActor.SetVelocity(tVelocity * 50.0f);
			//mActor.Update(fElapsedTime);

			tXDir = 1.0f;
		}

		if (GetKey(olc::Key::UP).bHeld)
		{
			//std::cout << "dir.up" << std::endl;
			//mActor.mPosition.y = mActor.mPosition.y - 50.0f * fElapsedTime;
			//olc::vf2d tVelocity(0.0f, -1.0f);
			//mActor.SetVelocity(tVelocity * 50.0f);
			//mActor.Update(fElapsedTime);

			tYDir = -1.0f;
		}

		if (GetKey(olc::Key::DOWN).bHeld)
		{
			//std::cout << "dir.down" << std::endl;
			//mActor.mPosition.y = mActor.mPosition.y + 50.0f * fElapsedTime;
			//olc::vf2d tVelocity(0.0f, 1.0f);
			//mActor.SetVelocity(tVelocity * 50.0f);
			//mActor.Update(fElapsedTime);

			tYDir = 1.0f;
		}

		olc::vf2d tXVelocity(1.0f, 0.0f);	//x축 기저벡터로 초기화
		olc::vf2d tYVelocity(0.0f, 1.0f);	//y축 기저벡터로 초기화

		tXVelocity = tXVelocity * tXDir;	//x축 방향 결정	벡터의 스칼라곱셈
		tYVelocity = tYVelocity * tYDir;	//y축 방향 결정	벡터의 스칼라곱셈


		tVelocity = tXVelocity + tYVelocity;	//임의의 크기와 2D벡터	벡터끼리의 덧셈
		if (tVelocity.mag() > 0.0f)										//벡터의 크기
		{
			tVelocity = tVelocity.norm();			//벡터의 정규화, 크기를 1로 만든다
		}

		mActor.SetVelocity(tVelocity * 50.0f);		//	벡터의 스칼라곱셈

		mActor.Update(fElapsedTime);

		//update


		//render
		this->Clear(olc::VERY_DARK_BLUE);

		//DrawLineEquation(0, 0, 100, 100);	//기울기 100 / 100
		//DrawLineEquation(0, 0, 100, 25);	//기울기 25 / 100
		//DrawLineEquation(0, 0, 25, 100);	//기울기 100 / 25
		//DrawLineEquation(100, 100, 100 + 25, 100 - 100);	//기울기 -100 / 25
		//DrawLineEquation(100, 100, 100 + 100, 100 + 0);	//기울기 0 / 100
		//DrawLineEquation(100, 100, 100 + 0, 100 + 100);		//기울기 100 / 0
		//DrawCircleEquation(0 + 100, 0 + 100, 20, olc::WHITE);

		//void Render(PixelGameEngine*)
		//DrawCircleEquation(mActor.mPosition.x, mActor.mPosition.y, 20.0f);
		mActor.Render(this);


		return true;
	}

	//직선 그리기 함수
	//수학적 방법에 의한 그리기( 방정식을 이용한 방법)를 할 것이다
	//직선 그리기에 가장 기초적인 알고리즘
	void DrawLineEquation(int tX_0, int tY_0, int tX_1, int tY_1);

	//원 그리기 함수
	//수학적 방법에 의한 그리기( 방정식을 이용한 방법)를 할 것이다
	//직선 그리기에 가장 기초적인 알고리즘
	void DrawCircleEquation(int tXCenter, int tYCenter, int tRadius, olc::Pixel tColor = olc::WHITE); //매개변수 기본값
};