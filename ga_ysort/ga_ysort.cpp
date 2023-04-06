#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"


/*
	y-sort 알고리즘

	'왜곡된 탑뷰 시점'의 게임 형식을 만들 때
	'입체감'을 모사한다

	이 입체감을 모사하기 위해서는 y축 값을 기준으로 어느 것을 먼저 렌더(화면에 표시)할지를
	실행중에 결정해야 한다.

	이 때 쓰이는 게임 알고리즘이 y-sort 알고리즘이다.

	<-- sort 정렬: 순서 없이 나열된 것을 순서 있게 나열하는 것.


*/


/*
	C++의 STL

	STL Standard Template Library

	STL의 세 가지 구성요소

	컨테이너: 자료구조를 타입에 대해 일반화시켜 만들어둔 것
	반복자: 컨테이너와 알고리즘과 함께 사용할 수 있게 일반화된 포인터
	알고리즘: 알고리즘을 타입에 대해 일반화시켜 만들어둔 것

*/

#include <vector>	//<--가변배열 컨테이너
#include <algorithm>	//<--알고이즘 사용을 위해 ( 정렬 알고리즘을 사용하겠다 )

using namespace olc;
using namespace std;

class CUnit
{
public:
	void Create(Sprite* tpSprite, vf2d tPosInit);
	void Render();

	void SetEngine(PixelGameEngine* tpEngine);

	void SetAnchor(float tAnchorX = 0.5f, float tAnchorY = 0.5f);

	//예시 작성의 편의를 위해서 은닉화를 제거하겠다(실제 프로젝트라면 그러면 안 됩니다 )
//private:
public:
	vf2d mPosition;	//위치

	//앵커(피벗) 좌표<-- 앵커는 중심점을 말한다
	float mAnchorX = 0.0f;
	float mAnchorY = 0.0f;

	//이미지 실제 출력좌표
	float mDisplayX = 0.0f;
	float mDisplayY = 0.0f;

	////이미지 너비 높이
	//float mWidth = 0.0f;
	//float mHeight = 0.0f;

	Sprite* mpSprite = nullptr;	//스프라이트 ( 공유된 오브젝트로 취급한다 FlyWeight Pattern )

	//엔진 참조 변수
	PixelGameEngine* mpEngine = nullptr;
};

bool DoCompared(CUnit* tA, CUnit* tB)
{
	//이 규칙을 맞춘다
	//	A < B가 참이면 오름차순
	//	A > B가 참이면 내림차순

	return tA->mPosition.y < tB->mPosition.y;
}

//함수 호출 연산자가 연산자 오버로드되어 정의된
//클래스로 만들어진
//객체를
//'함수 객체'라고 한다
class CCompared
{
public:
	//연산자 오버로드 문법을 사용하여 다음을 작성
	//	만드는 방법: operator예약어를 쓰고 그 다음에 오버로드할 연산자를 적어준다.
	//여기서 ()는 함수 호출 연산자
	bool operator()(CUnit* tA, CUnit* tB)
	{
		return tA->mPosition.y < tB->mPosition.y;
	}
};




// Override base class with your custom functionality
class Example : public olc::PixelGameEngine
{
	//자원 resource
	Sprite* mpSpriteA = nullptr;
	Sprite* mpSpriteB = nullptr;


	CUnit* mpUnitA = nullptr;
	CUnit* mpUnitB = nullptr;

public:
	Example()
	{
		// Name your application
		sAppName = "Example";
	}

public:
	bool OnUserCreate() override
	{
		mpSpriteA = new Sprite("resources/alberto_idle.png");
		mpSpriteB = new Sprite("resources/slime.png");
		
		mpUnitA = new CUnit();
		mpUnitA->Create(mpSpriteA, vf2d(150.0f, 150.0f));
		mpUnitA->SetEngine(this);
		mpUnitA->SetAnchor(0.5f, 1.0f);
		
		mpUnitB = new CUnit();
		mpUnitB->Create(mpSpriteB, vf2d(150.0f, 300.0f));
		mpUnitB->SetEngine(this);
		mpUnitB->SetAnchor(0.5f, 1.0f);


		return true;
	}

	bool OnUserDestroy() override
	{
		if (mpUnitB)
		{
			delete mpUnitB;
			mpUnitB = nullptr;
		}

		if (mpSpriteB)
		{
			delete mpSpriteB;
			mpSpriteB = nullptr;
		}



		if (mpUnitA)
		{
			delete mpUnitA;
			mpUnitA = nullptr;
		}


		if (mpSpriteA)
		{
			delete mpSpriteA;
			mpSpriteA = nullptr;
		}
		
		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{
		if (GetKey(olc::Key::UP).bHeld)
		{
			mpUnitA->mPosition.y = mpUnitA->mPosition.y - 50.0f * fElapsedTime;
		}
		if (GetKey(olc::Key::DOWN).bHeld)
		{
			mpUnitA->mPosition.y = mpUnitA->mPosition.y + 50.0f * fElapsedTime;
		}




		Clear(olc::VERY_DARK_BLUE);

		//실행 중에 y값을 기준으로 정렬하여 렌더 순서를 결정하겠다

		//정렬을 위해 하나의 자료구조에 게임오브젝트를 담아둔다.
		vector<CUnit*> tUnits;	//게임 오브젝트들을 담아두는 가변배열( 지역변수 )
		tUnits.reserve(256);	//메모리 예약
		tUnits.push_back(mpUnitA);
		tUnits.push_back(mpUnitB);

		//y값 기준으로 정렬한다
		//sort(tUnits.begin(), tUnits.end(), DoCompared);
		//<--여기서는 마지막 인자로 간접호출의 도구로써 '함수포인터'가 작동한다. ( 인자로 넘겨준 것은 전역함수 )

		//간접호출의 도구로써 '함수 객체' 사용
		//sort(tUnits.begin(), tUnits.end(), CCompared());
		// <-- 여기서 CCompared()는 생성자 표현, 즉 함수객체가 생성되어 인자로 넘어간다.

		//간접호출 도구로써 '람다' 사용

		//람다: 이름이 없는 함수
		// 함수 형태를 가지도록 코드를 만들 수 있다.
		// 컴파일 결과물은 쌩제어구조다. <-- 함수호출 비용이 없으므로 빠르다.
		//=================
		//[]() {};	//람다함수의 선언정의
		//[]() {}();	//람다함수의 선언정의호출
		//=================

		sort(tUnits.begin(), tUnits.end(),
			
			[](CUnit* tA, CUnit* tB)
			{
				return tA->mPosition.y < tB->mPosition.y;
			}			

			);
		//람다함수의 선언정의를 만들어 인자로 넘겨준다
		//<-- 변경의 국지화가 이루어졌다



		//이제 정렬된 순서대로 렌더된다.
		for (auto t : tUnits)
		{
			t->Render();
		}

		//가변배열 자료구조는 쓰임새가 끝났으므로 파기한다.
		tUnits.clear();


		//코드 작성 시( 제작 중에, compile-time에 ) 렌더 순서가 정해져 있다.
		/*mpUnitA->Render();
		mpUnitB->Render();*/

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




void CUnit::Create(Sprite* tpSprite, vf2d tPosInit)
{
	mpSprite = tpSprite;

	mPosition = tPosInit;
}
void CUnit::Render()
{
	float tWidth = mpSprite->width;
	float tHeight = mpSprite->height;

	mDisplayX = mPosition.x - tWidth * mAnchorX;
	mDisplayY = mPosition.y - tHeight * mAnchorY;

	//mpEngine->DrawSprite(mPosition, mpSprite);
	mpEngine->DrawSprite(mDisplayX, mDisplayY, mpSprite);



	//debug
	//개발 시 알아보기 쉽게 Anchor(pivot)를 출력하자
	mpEngine->FillCircle(mPosition, 5.0f, olc::YELLOW);
	mpEngine->DrawCircle(mPosition, 5.0f, olc::RED);
}
void CUnit::SetEngine(PixelGameEngine* tpEngine)
{
	mpEngine = tpEngine;
}
void CUnit::SetAnchor(float tAnchorX, float tAnchorY)
{
	mAnchorX = tAnchorX;
	mAnchorY = tAnchorY;
}