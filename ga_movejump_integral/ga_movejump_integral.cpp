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

// Override base class with your custom functionality
class Example : public olc::PixelGameEngine
{
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
		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{
		Clear(olc::DARK_BLUE);

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