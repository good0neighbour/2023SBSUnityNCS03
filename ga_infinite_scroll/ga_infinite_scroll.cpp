#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"

#include <vector>//가변배열

using namespace olc;
using namespace std;

class CScrollBg
{
private:
	//배경이미지로 사용될 스프라이트 두 장
	Sprite* mpSprA = nullptr;
	Sprite* mpSprB = nullptr;

	//배경이미지 두 장을 출력할 위치
	vf2d mPosA;
	vf2d mPosB;

	//스크롤 속도
	vf2d mScrollVelocity;

	//스크린 높이
	float mHeight = 0.0f;

	//엔진 참조 변수
	PixelGameEngine* mpEngine = nullptr;

public:
	void Create(vf2d tScrollVelocity, vector<Sprite*>& tSprites);
	void Destroy();

	void Update(float t);
	void Render();

	void SetEngine(PixelGameEngine* tpEngine);
};


// Override base class with your custom functionality
class Example : public olc::PixelGameEngine
{
	//자원 목록
	vector<Sprite*> mSprites;

	//포인터로 만드는 게 더 낫다
	CScrollBg mScrollBg;

public:
	Example()
	{
		// Name your application
		sAppName = "Example";
	}

public:
	bool OnUserCreate() override
	{
		//자원 로드
		for (int ti = 0; ti < 2; ti++)
		{
			Sprite* tpSpr = nullptr;
			//tpSpr = new Sprite("resources/bg.png");
			tpSpr = new Sprite("resources/bg_0.png");

			mSprites.push_back(tpSpr);
		}


		mScrollBg.Create(vf2d(0.0f, 1000.0f), mSprites);
		mScrollBg.SetEngine(this);

		return true;
	}
	bool OnUserDestroy() override
	{
		mScrollBg.Destroy();

		for (auto t : mSprites)
		{
			if (t)
			{
				delete t;
				t = nullptr;
			}
		}
		mSprites.clear();

		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{
		mScrollBg.Update(fElapsedTime);

		Clear(olc::BLACK);

		mScrollBg.Render();


		return true;
	}
};

int main()
{
	Example demo;
	if (demo.Construct(480, 800, 1, 1))
		demo.Start();
	return 0;
}


void CScrollBg::Create(vf2d tScrollVelocity, vector<Sprite*>& tSprites)
{
	mScrollVelocity = tScrollVelocity;

	//외부 자원 공유
	mpSprA = tSprites[0];
	mpSprB = tSprites[1];

	//스크린 높이 설정( 배경이미지는 스크린과 동일하게 제작했다고 가정 )
	mHeight = mpSprB->height;

	mPosA.x = 0.0f;
	mPosA.y = 0.0f;

	mPosB.x = 0.0f;
	mPosB.y = (-1.0f) * mHeight;
}
void CScrollBg::Destroy()
{

}

void CScrollBg::Update(float t)
{
	mPosA.y = mPosA.y + mScrollVelocity.y * t;
	mPosB.y = mPosB.y + mScrollVelocity.y * t;

	if (mPosA.y >= mHeight)
	{
		mPosA.y = (-1.0f) * mHeight + mPosB.y;
	}

	if (mPosB.y >= mHeight)
	{
		mPosB.y = (-1.0f) * mHeight + mPosA.y;
	}
}
void CScrollBg::Render()
{
	mpEngine->DrawSprite(mPosA, mpSprA);
	mpEngine->DrawSprite(mPosB, mpSprB);
}

void CScrollBg::SetEngine(PixelGameEngine* tpEngine)
{
	mpEngine = tpEngine;
}