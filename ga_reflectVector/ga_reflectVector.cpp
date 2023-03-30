#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"


#include <cmath> //<--앱실론: 아주 극히 작은 양의 정수

using namespace olc;

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

class CLine
{
public:
	vf2d mLineP_0;
	vf2d mLineP_1;

public:
	void Render(olc::PixelGameEngine* tpEngine)
	{
		tpEngine->DrawLine(mLineP_0, mLineP_1);
	}
};

// Override base class with your custom functionality
class Example : public olc::PixelGameEngine
{
	CUnit mUnitA;

	//임의의 선분
	/*vf2d mLineP_0;
	vf2d mLineP_1;*/
	CLine mLineA;
	CLine mLineB;


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
		mUnitA.mPosition.x = 200.0f;
		mUnitA.mPosition.y = 100.0f;



		mLineA.mLineP_0.x = 300;
		mLineA.mLineP_0.y = 50;

		mLineA.mLineP_1.x = 300;
		mLineA.mLineP_1.y = 180 + 40;



		mLineB.mLineP_0.x = 300;
		mLineB.mLineP_0.y = 230;

		mLineB.mLineP_1.x = 100;
		mLineB.mLineP_1.y = 220;



		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{

		//원 vs 직선(선분) 충돌 알고리즘
		//여기서는 직선(선분)의 벡터 방정식을 이용하여 충돌을 검사하겠다.
		/*
			직선의 벡터 방정식은 다음과 같다
			P = P_0 + t * (P_1 - P_0)


			여기서 P는 직선위의 임의의 한 점( 직선은 P들의 집합 )
			P_0은 시점
			P_1은 종점
			t는 P_0을 0으로, P_1을 1로 대응시킨 매개변수(수학의 개념)

			//

			투영 projection: N차원의 것을 N-1차원의 것으로 변환하는 것이다.
			내적을 이용하여 1차원의 것을 1차원의 것으로 바꿀 수 있다.


			//
			원 vs 직선 충돌 검사
			i) 직선의 벡터 방정식을 구해둔다. 이 직선을 L이라고 하자
			ii) 직선의 시점과 원의 중심으로 이루어지는 직선을 구한다. 이 직선을 C라고 하자
			iii) 직선 C를 직선 L에 투영시킨다 그리고 직선 L과 투영된 직선의 비율을 구한다
			이것으로 직선 C가 0에서 1사이인지 알 수 있다
			iv) 직선 C가 0에서 1사이인 경우 최단 거리 d를 구한다
			v)최단거리 d와 원의 반지름을 비교한다

		*/

		//float tW = (mUnitA.mPosition - mLineA.mLineP_0).dot(mLineA.mLineP_1 - mLineA.mLineP_0);	//분모: 투영된 직선
		//float tWW = (mLineA.mLineP_1 - mLineA.mLineP_0).dot(mLineA.mLineP_1 - mLineA.mLineP_0);			//분자: 원래 직선의 자기자신 내적

		//float tT = tW / tWW;	//투영된 직선의 비율을 구함

		//if (tT < 0.0f)
		//{
		//	//최단거리를 가지는 직선의 점은 P_0
		//}
		////else if (tT == 0.0f)	<--실수 연산의 오차에 의한 잘못된 실행을 방지하기 위해 다음 표현으로 수정
		//else if (std::abs(tT - 0.0f) < FLT_EPSILON)
		//{
		//	//P_0과 수직이다
		//}
		////else if (tT == 1.0f)	<--실수 연산의 오차에 의한 잘못된 실행을 방지하기 위해 다음 표현으로 수정
		//else if (std::abs(tT - 1.0f) < FLT_EPSILON)
		//{
		//	//P_1과 수직이다
		//}
		//else if (tT > 1.0f)
		//{
		//	//최단거리를 가지는 직선의 점은 P_1
		//}
		//else //0~1
		//{
		//	//지선의 벡터 방정식
		//	vf2d tP = mLineA.mLineP_0 + tT * (mLineA.mLineP_1 - mLineA.mLineP_0);
		//	//<--여기서 tP는 직선위의 임의의 한 점

		//	//원의 중심과 tP와의 거리
		//	float tDistance = (mUnitA.mPosition - tP).mag();

		//	//if( 거리 <= 반지름 )
		//	if (tDistance <= 10.0f)
		//	{
		//		//충돌 처리
		//		std::cout << ">>>>>>collision" << std::endl;

		//		//충돌시 처리해야 할 작업. 반사
		//		vf2d tV = (mLineA.mLineP_1 - mLineA.mLineP_0).norm();
		//		vf2d tN;	//법선벡터
		//		/*
		//			임의의 벡터(점)의 회전
		//			x` = cosT * x - sinT * y
		//			y` = sinT * x + cosT * y
		//			//
		//		*/
		//		tN.x = cosf(90.0f * (3.14159f / 180.0f)) * tV.x - sinf(90.0f * (3.14159f / 180.0f)) * tV.y;
		//		tN.y = sinf(90.0f * (3.14159f / 180.0f)) * tV.x + cosf(90.0f * (3.14159f / 180.0f)) * tV.y;

		//		//입사벡터
		//		vf2d tInput = mUnitA.mVelocity;

		//		//반사벡터
		//		vf2d tR;
		//		tR = tInput + tN * (((tInput * (-1.0f)).dot(tN)) * 2.0f);
		//		//속도에 반사벡터를 설정
		//		mUnitA.mVelocity = tR;
		//	}
		//}



		DoCollisionCircleLine(mUnitA, mLineA);
		DoCollisionCircleLine(mUnitA, mLineB);



		if (GetKey(olc::Key::SPACE).bReleased)
		{
			//속도 적용
			/*mUnitA.mVelocity.x = 1.0f;
			mUnitA.mVelocity.y = 0.0f;*/
			float tDegree = 60.0f;
			mUnitA.mVelocity.x = 1.0f * cosf(tDegree * (3.14159f / 180.0f));
			mUnitA.mVelocity.y = 1.0f * sinf(tDegree * (3.14159f / 180.0f));

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

		//선분 그리기
		//DrawLine(mLineP_0, mLineP_1);
		mLineA.Render(this);
		mLineB.Render(this);

		return true;
	}
	void DoCollisionCircleLine(CUnit& tUnitA, CLine& tLineA)
	{
		float tW = (tUnitA.mPosition - tLineA.mLineP_0).dot(tLineA.mLineP_1 - tLineA.mLineP_0);	//분모: 투영된 직선
		float tWW = (tLineA.mLineP_1 - tLineA.mLineP_0).dot(tLineA.mLineP_1 - tLineA.mLineP_0);			//분자: 원래 직선의 자기자신 내적

		float tT = tW / tWW;	//투영된 직선의 비율을 구함

		if (tT < 0.0f)
		{
			//최단거리를 가지는 직선의 점은 P_0
		}
		//else if (tT == 0.0f)	<--실수 연산의 오차에 의한 잘못된 실행을 방지하기 위해 다음 표현으로 수정
		else if (std::abs(tT - 0.0f) < FLT_EPSILON)
		{
			//P_0과 수직이다
		}
		//else if (tT == 1.0f)	<--실수 연산의 오차에 의한 잘못된 실행을 방지하기 위해 다음 표현으로 수정
		else if (std::abs(tT - 1.0f) < FLT_EPSILON)
		{
			//P_1과 수직이다
		}
		else if (tT > 1.0f)
		{
			//최단거리를 가지는 직선의 점은 P_1
		}
		else //0~1
		{
			//지선의 벡터 방정식
			vf2d tP = tLineA.mLineP_0 + tT * (tLineA.mLineP_1 - tLineA.mLineP_0);
			//<--여기서 tP는 직선위의 임의의 한 점

			//원의 중심과 tP와의 거리
			float tDistance = (tUnitA.mPosition - tP).mag();

			//if( 거리 <= 반지름 )
			if (tDistance <= 10.0f)
			{
				//충돌 처리
				std::cout << ">>>>>>collision" << std::endl;

				//충돌시 처리해야 할 작업. 반사
				vf2d tV = (tLineA.mLineP_1 - tLineA.mLineP_0).norm();
				vf2d tN;	//법선벡터
				/*
				임의의 벡터(점)의 회전
				x` = cosT * x - sinT * y
				y` = sinT * x + cosT * y
				//
				*/
				tN.x = cosf(90.0f * (3.14159f / 180.0f)) * tV.x - sinf(90.0f * (3.14159f / 180.0f)) * tV.y;
				tN.y = sinf(90.0f * (3.14159f / 180.0f)) * tV.x + cosf(90.0f * (3.14159f / 180.0f)) * tV.y;

				//입사벡터
				vf2d tInput = tUnitA.mVelocity;

				//반사벡터
				vf2d tR;
				tR = tInput + tN * (((tInput * (-1.0f)).dot(tN)) * 2.0f);
				//속도에 반사벡터를 설정
				tUnitA.mVelocity = tR;
			}
		}
	}
};

int main()
{
	Example demo;
	if (demo.Construct(400, 300, 2, 2))
		demo.Start();
	return 0;
}