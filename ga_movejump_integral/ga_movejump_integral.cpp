#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"

/*
	속도, 가속도의 정의에서부터
	'적분'을 이용하여
	위치, 속도를 구하는 식을 유도

	속도의 정의
	Vx = d Sx / d T

		이런 정의에서 유도하여
		Sx = (1 / 2) * Ax * t^2 + Cx0 * t + Cx1


		Cx0: 초기속도
		Cx1: 초기위치

	가속도의 정의
	Ax = d Vx / d T

		이런 정의에서 유도하여
		Vx = Ax * t + Cx0



*/

/*
	함수: 독립변수와 종속변수 사이의 '관계'를 나타내는 대수식

	y = f(x)
	이런 함수가 있다고 가정하자

	미분: 한없이 잘게 쪼개서 함수를 분석하는 도구

		y를 x에 대해 미분한 것
		y' = f'(x) = dy / dx

	적분: 미분의 반대, 잘게 쪼개진 것들을 모아 모두 합하는 도구
	
		인테그랄 y' = 인테그랄 f'(x) dx = 인테그랄 dy / dx dx = f(x) = y

======================================

	다항식의 경우

	y = f(x) = x^n
	이러한 경우
	이것을 미분하면 (공식)
	y' = f'(x) = n * x^(n - 1)
	//


	y' = f'(x) = n * x^(n - 1)
	이것을 적분하면 (공식)
	y = f(x) = n * (1 / (n - 1 + 1)) * x^(n - 1 + 1) = x^n
	인데
	여기에 적분상수를 더한다( 적분 상수 C )
	y = f(x) = x^n + C

	//


*/

using namespace olc;
using namespace std;

// Override base class with your custom functionality
class Example : public olc::PixelGameEngine
{
	vf2d mPosition; //현재 위치
	vf2d mVelocity; //속도
	vf2d mAccel;	//가속도

	const float GRAVITY = 9.8;	//중력가속도

	//점프 여부
	bool mIsJump = false;


	//초기위치
	vf2d mPosInit;
	//초기속도
	vf2d mVelocityInit;

	//운동이 시작되고 난 후에 누적되는 시간
	float t = 0.0f;

public:
	Example()
	{
		// Name your application
		sAppName = "Example";
	}

public:
	bool OnUserCreate() override
	{
		//초기위치
		mPosInit.x = ScreenWidth() * 0.5f;
		mPosInit.y = ScreenHeight() - 20.0f;
		//초기위치로 지정
		mPosition = mPosInit;
		
		//가속도
		mAccel.x = 0.0f;
		mAccel.y = 0.0f;

		//초기속도
		mVelocity.x = 0.0f;
		mVelocity.y = 0.0f;
		//초기속도로 지정
		mVelocity = mVelocityInit;

		mIsJump = false;

		return true;
	}

	//x축: 등가속도 운동
	//y축: 중력가속도가 작용하는 가속도 운동

	bool OnUserUpdate(float fElapsedTime) override
	{
		if (GetKey(olc::Key::LEFT).bReleased)
		{
			//t시간 경과 후에 현재 위치를 초기위치로, 현재 속도를 초기 속도로, 현재 가속도를 가속도로 설정
			mPosInit.y = mPosition.y;

			//Vx = Ax * t + Cx0
			mVelocity.y = mAccel.y * t + mVelocityInit.y;
			mAccel.y = (mVelocity.y - mVelocityInit.y) / t;
			mVelocityInit.y = mVelocity.y;//0.0f;


			//이전 시간의 현재 위치가 이제 초기 위치가 된다.
			mPosInit.x = mPosition.x;
			mPosition = mPosInit;

			mAccel.x = 0.0f;
			//초기 x축 속도의 크기는 50
			mVelocityInit.x = -50.0f;
			mVelocity = mVelocityInit;
			//새로운 운동이 시작되므로 t를 0부터 재시작
			t = 0.0f;
		}

		if (GetKey(olc::Key::RIGHT).bReleased)
		{
			//t시간 경과 후에 현재 위치를 초기위치로, 현재 속도를 초기 속도로, 현재 가속도를 가속도로 설정
			mPosInit.y = mPosition.y;

			//Vx = Ax * t + Cx0
			mVelocity.y = mAccel.y * t + mVelocityInit.y;
			mAccel.y = (mVelocity.y - mVelocityInit.y) / t;
			mVelocityInit.y = mVelocity.y;//0.0f;

			//이전 시간의 현재 위치가 이제 초기 위치가 된다.
			mPosInit.x = mPosition.x;
			mPosition = mPosInit;

			mAccel.x = 0.0f;
			//초기 x축 속도의 크기는 50
			mVelocityInit.x = 50.0f;
			mVelocity = mVelocityInit;
			//t를 재시작
			t = 0.0f;
		}

		if (GetKey(olc::Key::SPACE).bReleased)
		{
			mPosInit.x = mPosition.x;

			//이전 시간의 현재 위치가 이제 초기 위치가 된다.
			mPosInit.y = mPosition.y;
			mPosition = mPosInit;

			mAccel.y = GRAVITY;//0.0f;
			//초기 x축 속도의 크기는 50
			mVelocityInit.y = (-1.0f) * 5 * GRAVITY;	//중력가속도의 5배 힘 반대방향
			mVelocity = mVelocityInit;

			t = 0.0f;

			//점프 상태로 변경
			mIsJump = true;
		}




		//Sx = (1 / 2) * Ax * t ^ 2 + Cx0 * t + Cx1

		mAccel.x = 0.0f;
		mPosition.x = 0.5f * mAccel.x * t * t + mVelocityInit.x * t + mPosInit.x;

		if (mIsJump)
		{
			//mAccel.y = GRAVITY;	//중력가속도 적용
			mPosition.y = 0.5f * mAccel.y * t * t + mVelocityInit.y * t + mPosInit.y;
		}

		//시간은 누적
		t = t + fElapsedTime * 3.0f;


		Clear(olc::DARK_BLUE);



		DrawCircle(mPosition, 10.0f);

		return true;
	}
};

int main()
{
	Example demo;
	if (demo.Construct(500, 350, 2, 2))
		demo.Start();
	return 0;
}