#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"

/*
	속도, 가속도 정의에서부터
	'오일러 수치 해석'을 이용하여
	위치를 구하는 식 유도


	오일러 축차적 방법

	속도의 정의
	Vx = delta Sx / delta T

		이런 정의에서 유도하여
		Sx[n] = Sx[n - 1] + Vx * delta T

	가속도의 정의
	Ax = delta Vx / delta T

		이런 정의에서 유도하여
		Vx[n] = Vx[n - 1] + Ax * delta T

	//

*/
using namespace std;
using namespace olc;

// Override base class with your custom functionality
class Example : public olc::PixelGameEngine
{
	vf2d mPosition;	//위치
	vf2d mVelocity;	//속도
	vf2d mAccel;	//가속도

	//x축은 등가속도 운동
	//y축은 중력가속도(9.8뉴턴)를 고려한 가속도 운동

	//중력가속도
	//y축만 고려한 가속도라서 float스칼라로 결정
	const float GRAVITY = 9.8f;

	//점프 여부
	bool mIsJump = false;


public:
	Example()
	{
		// Name your application
		sAppName = "Example";
	}

public:
	bool OnUserCreate() override
	{
		mPosition.x = 100.0f;
		mPosition.y = 250.0f;
		
		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{
		


		if (GetKey(Key::LEFT).bReleased)
		{
			mVelocity.x = -1.0f * 50.0f;
			mAccel.x = 0.0f;	//등가속도 운동
		}
		if (GetKey(Key::RIGHT).bReleased)
		{
			mVelocity.x = 1.0f * 50.0f;
			mAccel.x = 0.0f;	//등가속도 운동
		}


		if (GetKey(Key::SPACE).bReleased)
		{
			//점프 시작
			
			//중력가속도의 3배 정도의 힘으로 점프
			mVelocity.y = GRAVITY * (-1.0f) * (5.0f);
			//가속도는 중력가속도
			mAccel.y = GRAVITY;

			mIsJump = true;
		}

		float tPhysicTimeRatio = 6.0f;

		//현재 속도 = 이전 속도 + 가속도 * 시간간격
		mVelocity.x = mVelocity.x + mAccel.x * fElapsedTime * tPhysicTimeRatio;

		//현재위치 = 이전위치 + 속도 * 시간간격
		mPosition.x = mPosition.x + mVelocity.x * fElapsedTime * tPhysicTimeRatio;


		if (mIsJump)
		{
			//현재 속도 = 이전 속도 + 가속도 * 시간간격
			mVelocity.y = mVelocity.y + mAccel.y * fElapsedTime * tPhysicTimeRatio;

			//현재위치 = 이전위치 + 속도 * 시간간격
			mPosition.y = mPosition.y + mVelocity.y * fElapsedTime * tPhysicTimeRatio;
		}


		Clear(olc::DARK_BLUE);

		DrawCircle(mPosition, 20.0f);

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