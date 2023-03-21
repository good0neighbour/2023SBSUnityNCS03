#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"


/*
	PixelGameEngine
		게임프로그램에 필요한 기능들을 모아둔 클래스

	Example
		게임플레이에 관련한 로직을 작성하는 용도의 클래스

	위와 같이 분리하여 작성할 수 있도록 설계된 것이다.


*/


// Override base class with your custom functionality
class pgeCircleShootor : public olc::PixelGameEngine
{
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
		return true;
	}
	bool OnUserDestroy() override
	{
		//todo

		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{


		this->Clear(olc::VERY_DARK_BLUE);


		DrawLineEquation(0, 0, 100, 100);


		
		return true;
	}

	//직선 그리기 함수
	//수학적 방법에 의한 그리기( 방정식을 이용한 방법)를 할 것이다
	//직선 그리기에 가장 기초적인 알고리즘
	void DrawLineEquation(int tX_0, int tY_0, int tX_1, int tY_1);
};

int main()
{
	pgeCircleShootor tShootor;
	if (tShootor.Construct(320, 240, 2, 2))
		tShootor.Start();
	return 0;
}

//실제 직선은 무한하지만,
//컴퓨터로 표현 불가능하다. 그러므로 선분을 직선으로 간주하고 그리겠다
//시점: tX_0, tY_0
//중점: tX_1, tY_1
void pgeCircleShootor::DrawLineEquation(int tX_0, int tY_0, int tX_1, int tY_1)
{
	float tSlopeRatio = 0.0f;	//기울기
	//직선을 정의하기 위해서 기울기 개념을 만든다.


	//수학적 정의에 의한 기울기를 구함: y변화량 / x변화량
	//기울기는 연속적인 공간의 개념으로 다루기 위해 float실수로 형변환
	//	그러므로, 실수의 나눗셈이 일어난다
	tSlopeRatio = (float)(tY_1 - tY_0) / (float)(tX_1 - tX_0);


	//임의의 x, y
	int tX = 0;
	int tY = 0;

	for (tX = tX_0; tX <= tX_1; ++tX)
	{
		//y = a * x + b
		tY = tSlopeRatio * (tX - tX_0) + tY_0;

		//점찍기함수
		Draw(tX, tY);
	}



}