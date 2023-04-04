#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"

/*
	이 예시에서는

	탄착지점에 떨어지는 포물선 궤적을 그리는 탄환 알고리즘을 만들어보자.


	속도의 정의
	Vx = d Sx / d T

		이런 정의에서 유도하여
		Sx = (1 / 2) * Ax * t^2 + Cx0 * t + Cx1
*/
using namespace olc;
using namespace std;

// Override base class with your custom functionality
class Example : public olc::PixelGameEngine
{
	vf2d mPosition;		//현재 위치

	vf2d mPosInit;		//초기 위치<--발사지점(시작지점)
	vf2d mVelocityInit;	//초기 속도

	vf2d G;				//중력가속도

	bool mIsInAir = false;	//날아가고 있는 중 여부

	float t = 0.0f;		//경과 시간




	vf2d mPosTarget;	//탄착지점(탄환이 떨어질 지점)



	//탄착지점에 떨어뜨리기 위해 필요한, 입력할 값 두 가지
	float mDegree = 0.0f;		//각도
	float mSpeedScalar = 0.0f;	//속도의 크기


public:
	Example()
	{
		// Name your application
		sAppName = "Example";
	}

public:
	bool OnUserCreate() override
	{
		//초기 위치 지정
		mPosInit.x = ScreenWidth() * 0.5f;
		mPosInit.y = ScreenHeight() - 50.0f;

		//초기속도 지정
		mVelocityInit.x = 0.0f;
		mVelocityInit.y = 0.0f;

		//중력가속도
		G.x = 0.0f;
		G.y = 9.8f;

		//경과시간
		t = 0.0f;

		//현재 위치는 일단 초기위치로 설정
		//mPosition = 0.5f * G * t * t + mVelocityInit * t + mPosInit;
		mPosition = mPosInit;

		//탄착지점 설정
		mPosTarget.x = ScreenWidth() - 50.0f;
		mPosTarget.y = ScreenHeight() - 50.0f;

		//발사 각도
		mDegree = 45.0f;
		mSpeedScalar = 18.0f;

		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{

		if (GetKey(olc::Key::LEFT).bHeld)
		{
			mPosTarget.x = mPosTarget.x - 100.0f * fElapsedTime;
		}
		if (GetKey(olc::Key::RIGHT).bHeld)
		{
			mPosTarget.x = mPosTarget.x + 100.0f * fElapsedTime;
		}
		if (GetKey(olc::Key::UP).bHeld)
		{
			mPosTarget.y = mPosTarget.y - 100.0f * fElapsedTime;
		}
		if (GetKey(olc::Key::DOWN).bHeld)
		{
			mPosTarget.y = mPosTarget.y + 100.0f * fElapsedTime;
		}

		if (GetKey(olc::Key::ENTER).bHeld)
		{
			//초기 위치 지정
			mPosInit.x = ScreenWidth() * 0.5f;
			mPosInit.y = ScreenHeight() - 50.0f;

			//초기속도 지정
			mVelocityInit.x = 0.0f;
			mVelocityInit.y = 0.0f;

			//중력가속도
			G.x = 0.0f;
			G.y = 9.8f;

			//경과시간
			t = 0.0f;

			//현재 위치는 일단 초기위치로 설정
			//mPosition = 0.5f * G * t * t + mVelocityInit * t + mPosInit;
			mPosition = mPosInit;

			mIsInAir = false;
		}



		//각도 조정
		if (GetKey(olc::Key::A).bHeld)
		{
			mDegree += 0.005f;
		}
		if (GetKey(olc::Key::D).bHeld)
		{
			mDegree -= 0.005f;
		}
		//속력 조정
		if (GetKey(olc::Key::W).bHeld)
		{
			mSpeedScalar += 0.005f;
		}
		if (GetKey(olc::Key::S).bHeld)
		{
			mSpeedScalar -= 0.005f;
		}






		if (GetKey(olc::Key::SPACE).bReleased)
		{
			//크기, 방향
			vf2d tVelocity;	//방향

			float tDX = mPosTarget.x - mPosInit.x;	//x축 차이
			float tDY = mPosTarget.y - mPosInit.y;	//y축 차이

			//윈도우 좌표계를 사용하므로 Y는 뒤집어서 보정
			tDY = (-1.0f) * tDY;

			float tCos = cosf(mDegree * (3.14159f / 180.0f));
			float tSin = sinf(mDegree * (3.14159f / 180.0f));
			float tTan = tSin / tCos;

			//데카르트 좌표계 구성성분과 극좌표계 사이의 관계
			tVelocity.x = tCos;
			tVelocity.y = tSin;
			//윈도우 좌표계를 사용하므로 Y는 뒤집어서 보정
			tVelocity.y = (-1.0) * tVelocity.y;

			//속도의 크기를 구해본다면
			//	중력가속도가 여기서는 +9.8이므로 tTan * tDX - tDY로 함
			//mSpeedScalar = (tDX / tCos) * sqrtf(G.y / (2.0f * (tTan * tDX - tDY)));

			//초기 속도 설정
			mVelocityInit = tVelocity * mSpeedScalar;


			mIsInAir = true;
			t = 0.0f;
		}

		
		if (mIsInAir)
		{
			mPosition = 0.5f * G * t * t + mVelocityInit * t + mPosInit;
		}

		//시간의 흐름
		t = t + fElapsedTime;

		Clear(olc::DARK_BLUE);

		DrawCircle(mPosition, 5.0f, olc::YELLOW);	//탄환

		//궤적 미리보기
		//크기, 방향
		vf2d tVelocity;	//방향
		float tDX = mPosTarget.x - mPosInit.x;	//x축 차이
		float tDY = mPosTarget.y - mPosInit.y;	//y축 차이

		//윈도우 좌표계를 사용하므로 Y는 뒤집어서 보정
		tDY = (-1.0f) * tDY;

		float tCos = cosf(mDegree * (3.14159f / 180.0f));
		float tSin = sinf(mDegree * (3.14159f / 180.0f));
		float tTan = tSin / tCos;

		//데카르트 좌표계 구성성분과 극좌표계 사이의 관계
		tVelocity.x = tCos;
		tVelocity.y = tSin;
		//윈도우 좌표계를 사용하므로 Y는 뒤집어서 보정
		tVelocity.y = (-1.0) * tVelocity.y;
		//초기 속도 설정
		mVelocityInit = tVelocity * mSpeedScalar;

		for (int ti = 0; ti < 20; ++ti)
		{
			vf2d tPos;

			tPos = 0.5f * G * ti * ti + mVelocityInit * ti + mPosInit;

			DrawCircle(tPos, 1.0f);
		}

		char tszTemp[256] = { 0 };
		sprintf_s(tszTemp, "degree: %f", mDegree);
		string tString = tszTemp;
		DrawString(0, 0, tString);

		memset(tszTemp, 0, 256);
		sprintf_s(tszTemp, "speed: %f", mSpeedScalar);
		tString = tszTemp;
		DrawString(0, 50, tString);


		DrawCircle(mPosTarget, 2.0f, olc::RED);	//탄착지점

		return true;
	}
};

int main()
{
	Example demo;
	if (demo.Construct(500, 400, 2, 2))
		demo.Start();
	return 0;
}