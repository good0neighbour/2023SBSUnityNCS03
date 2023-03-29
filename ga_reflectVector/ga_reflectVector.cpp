#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"


class CUnit
{
public:
	olc::vf2d mPosition;	//위치
	olc::vf2d mVelocity;	//속도

public:
	void Update(float t)
	{
		//현재위치 = 이전위치 + 속도 * 시간간격
		mPosition = mPosition + mVelocity * t;
	}

	void Render(olc::PixelGameEngine* tpEngine)
	{
		tpEngine->DrawCircle(mPosition, 10.0f);
	}
};

// Override base class with your custom functionality
class Example : public olc::PixelGameEngine
{
	CUnit mUnitA;

public:
	Example()
	{
		// Name your application
		sAppName = "Example";
	}

public:
	bool OnUserCreate() override
	{
		// Called once at the start, so create things here
		//초기 위치
		mUnitA.mPosition.x = 100.0f;
		mUnitA.mPosition.y = 100.0f;

		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{
		if (GetKey(olc::Key::SPACE).bReleased)
		{
			//속도 적용
			mUnitA.mVelocity.x = 1.0f;
			mUnitA.mVelocity.y = 0.0f;

			mUnitA.mVelocity = mUnitA.mVelocity * 50.0f;
		}
		//오른쪽 경계에 닿으면
		if (mUnitA.mPosition.x >= ScreenWidth())
		{
			//평면의 법선벡터
			olc::vf2d tN;
			tN.x = -1.0f;
			tN.y = 0.0f;

			//반사 벡터
			olc::vf2d tVectorR;
			tVectorR = mUnitA.mVelocity + (2.0f * (((-1.0f) * mUnitA.mVelocity).dot(tN))) * tN;
			//반사시킨다.
			mUnitA.mVelocity = tVectorR;
		}

		mUnitA.Update(fElapsedTime);

		Clear(olc::VERY_DARK_BLUE);

		mUnitA.Render(this);

		return true;
	}
};

int main()
{
	Example demo;
	if (demo.Construct(400, 300, 2, 2))
		demo.Start();
	return 0;
}