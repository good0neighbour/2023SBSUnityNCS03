#define OLC_PGE_APPLICATION
//#include "olcPixelGameEngine.h"

#include "config.h"


/*
	PixelGameEngine
		게임프로그램에 필요한 기능들을 모아둔 클래스

	Example
		게임플레이에 관련한 로직을 작성하는 용도의 클래스

	위와 같이 분리하여 작성할 수 있도록 설계된 것이다.


*/

/*
	
	좌표계 coordinate system
	데카르트 좌표계, 직교돠표계
	물체의 위치를 지정하기 위한 시스템

	벡터: '크기'와 '방향'을 아우르는 개념
	스칼라: 크기

	벡터의 표기법

	i)수벡터

	(1, 0)


	ii)기하벡터

	->




	수학에서 다루는 것들: 수나 수학적 구조물

	연산: 수나 수학적 구조물에 정체성을 밝히는 도구다.

	벡터의 연산

		i) 벡터끼리의 덧셈(뺄셈)

			각각의 구성성분끼리 더한다.
			A = (1, 0)
			B = (0, 1)

			A + B = (1, 0) + (0, 1) = (1 + 0, 0 + 1) = (1, 1)

		ii) 벡터의 스칼라곱셈

			스칼라를 벡터의 각각의 구성성분에 곱한다

			A = (1, 0)
			S = 2

			A * S = (1, 0) * 2 = (1 * 2, 0 * 2) = (2, 0)

		iii) 벡터끼리의 곱셈

			가) 내적 dot product, inner product

			A . B = ||A|| ||B|| cosT

			= A.x * B.x + A.y * B.y

			A = (A.x ,A.y)
			B = (B.x, B.y)

			예)
			A = (1, 0)
			B = (0, 1)

			A . B = 1 * 0 + 0 * 1 = 0

			

			벡터끼리의 내적의 결과는 '스칼라'다.

			나) 외적 cross product, outer product

			A x B = ||A|| ||B|| sinT U
			(U는 A와 B에 모두 수직인 단위벡터 )

			벡터끼리의 외적의 결과는 '벡터'다.


			A = (1, 0)
			B = (0, 1)

			A = (1, 0, 0)
			B = (0, 1, 0)

			외적의 정의에 의해서 일단 구해보자.
			A x B = 1 * 1 * 1 * (0, 0, 1) = (0, 0, 1)

			//3차원의 기저(basis)<--기저벡터들의 집합
			i = (1, 0, 0)	//x축 기저벡터
			j = (0, 1, 0)	//y축 기저벡터
			k = (0, 0, 1)	//z축 기저벡터

			A x B = (0 * 0 - 0 * 1) * i + (0 * 0 - 1 * 0) * j + (1 * 1 - 0 * 0) * k
				= (1 - 0) * (0, 0, 1)
				= 1 * (0, 0, 1) = (0, 0, 1)



		iv) 정규화 normalize: 임의의 크기의 벡터를 크기가 1인 벡터로 만드는 연산
		v) 벡터의 크기

	단위벡터 unit vector: 크기가 1인 벡터
	법선벡터 normal vector: 평면에 수직인 단위벡터
	
	벡터의 회전: 크기는 그대로고, 방향이 바뀌는 것이다.



	---좌표공간에서는 점(위치)과 벡터의 연산이
	벡터의 연산으로 통합되어있다. ---


*/


#include "pgeCircleShootor.h"

#include "CActor.h"
#include "CEnemy.h"

// Override base class with your custom functionality
//class pgeCircleShootor : public olc::PixelGameEngine
//{
//	//float mActorX = 0.0f;
//	//float mActorY = 0.0f;
//
//	CActor mActor;
//
//
//public:
//	pgeCircleShootor()
//	{
//		// Name your application
//		sAppName = "pgeCircleShootor";
//	}
//
//public:
//	bool OnUserCreate() override
//	{
//		// Called once at the start, so create things here
//
//		//주인공 기체의 초기위치 지정
//		/*mActor.mPosition.x = ScreenWidth() * 0.5f;
//		mActor.mPosition.y = ScreenHeight() * 0.5f + 80.0f;*/
//		mActor.SetPosition(ScreenWidth() * 0.5f, ScreenHeight() * 0.5f + 80.0f);
//
//
//		return true;
//	}
//	bool OnUserDestroy() override
//	{
//		//todo
//
//		return true;
//	}
//
//	bool OnUserUpdate(float fElapsedTime) override
//	{
//
//		olc::vf2d tVelocity(0.0f, 0.0f);
//		mActor.SetVelocity(tVelocity * 0.0f);
//
//		float tXDir = 0.0f;	//x축 입력
//		float tYDir = 0.0f;	//y축 입력
//
//		//input
//		// 축입력 방식으로 수정
//		//왼쪽 방향키가 눌리고 있는 중이라면
//		if (GetKey(olc::Key::LEFT).bHeld)
//		{
//			//std::cout << "dir.left" << std::endl;
//
//			//오일러 축차적 방법에 의한 이동코드
//			/*
//				속도 * 거리의 변화량 / 시간의 변화량
//
//				속도의 정의로부터 다음 식을 유도했다
//
//				//현재 위치 = 이전 위치 + 속도 * 시간간격
//
//				무한소 개념에 의해 간격이 정해지므로(불연속), 적분에 의한 방법보다는 부정확하다.
//			*/
//
//			//현재 위치 = 이전 위치 + 속도 * 시간간격
//			//mActorX = mActorX - 0.01f * 1.0f;	//프레임 기반 진행
//			//mActor.mActorX = mActor.mActorX - 50.0f * fElapsedTime;	//시간 기반 진행. fElapsedTime: 한 프레임에 걸린 시간
//
//			//mActor.DoMoveX(-50.0f, fElapsedTime);
//			//olc::vf2d tVelocity(-1.0f, 0.0f);	//속도의 방향( 단위벡터로 지정함 )
//			//mActor.SetVelocity(tVelocity * 50.0f);
//			//mActor.Update(fElapsedTime);	//벡터의 스칼라곱셈
//
//			tXDir = -1.0f;
//		}
//
//		if (GetKey(olc::Key::RIGHT).bHeld)
//		{
//			//std::cout << "dir.right" << std::endl;
//			//mActor.mPosition.x = mActor.mPosition.x + 50.0f * fElapsedTime;
//			//olc::vf2d tVelocity(1.0f, 0.0f);
//			//mActor.SetVelocity(tVelocity * 50.0f);
//			//mActor.Update(fElapsedTime);
//
//			tXDir = 1.0f;
//		}
//
//		if (GetKey(olc::Key::UP).bHeld)
//		{
//			//std::cout << "dir.up" << std::endl;
//			//mActor.mPosition.y = mActor.mPosition.y - 50.0f * fElapsedTime;
//			//olc::vf2d tVelocity(0.0f, -1.0f);
//			//mActor.SetVelocity(tVelocity * 50.0f);
//			//mActor.Update(fElapsedTime);
//
//			tYDir = -1.0f;
//		}
//		
//		if (GetKey(olc::Key::DOWN).bHeld)
//		{
//			//std::cout << "dir.down" << std::endl;
//			//mActor.mPosition.y = mActor.mPosition.y + 50.0f * fElapsedTime;
//			//olc::vf2d tVelocity(0.0f, 1.0f);
//			//mActor.SetVelocity(tVelocity * 50.0f);
//			//mActor.Update(fElapsedTime);
//
//			tYDir = 1.0f;
//		}
//
//		olc::vf2d tXVelocity(1.0f, 0.0f);	//x축 기저벡터로 초기화
//		olc::vf2d tYVelocity(0.0f, 1.0f);	//y축 기저벡터로 초기화
//
//		tXVelocity = tXVelocity * tXDir;	//x축 방향 결정	벡터의 스칼라곱셈
//		tYVelocity = tYVelocity * tYDir;	//y축 방향 결정	벡터의 스칼라곱셈
//
//
//		tVelocity = tXVelocity + tYVelocity;	//임의의 크기와 2D벡터	벡터끼리의 덧셈
//		if (tVelocity.mag() > 0.0f)										//벡터의 크기
//		{
//			tVelocity = tVelocity.norm();			//벡터의 정규화, 크기를 1로 만든다
//		}
//
//		mActor.SetVelocity(tVelocity * 50.0f);		//	벡터의 스칼라곱셈
//
//		mActor.Update(fElapsedTime);
//
//		//update
//
//
//		//render
//		this->Clear(olc::VERY_DARK_BLUE);
//
//		//DrawLineEquation(0, 0, 100, 100);	//기울기 100 / 100
//		//DrawLineEquation(0, 0, 100, 25);	//기울기 25 / 100
//		//DrawLineEquation(0, 0, 25, 100);	//기울기 100 / 25
//		//DrawLineEquation(100, 100, 100 + 25, 100 - 100);	//기울기 -100 / 25
//		//DrawLineEquation(100, 100, 100 + 100, 100 + 0);	//기울기 0 / 100
//		//DrawLineEquation(100, 100, 100 + 0, 100 + 100);		//기울기 100 / 0
//		//DrawCircleEquation(0 + 100, 0 + 100, 20, olc::WHITE);
//
//		//void Render(PixelGameEngine*)
//		DrawCircleEquation(mActor.mPosition.x, mActor.mPosition.y, 20.0f);
//
//
//		return true;
//	}
//
//	//직선 그리기 함수
//	//수학적 방법에 의한 그리기( 방정식을 이용한 방법)를 할 것이다
//	//직선 그리기에 가장 기초적인 알고리즘
//	void DrawLineEquation(int tX_0, int tY_0, int tX_1, int tY_1);
//
//	//원 그리기 함수
//	//수학적 방법에 의한 그리기( 방정식을 이용한 방법)를 할 것이다
//	//직선 그리기에 가장 기초적인 알고리즘
//	void DrawCircleEquation(int tXCenter, int tYCenter, int tRadius, olc::Pixel tColor = olc::WHITE); //매개변수 기본값
//};

int main()
{
	pgeCircleShootor tShootor;
	if (tShootor.Construct(320, 240, 2, 2))
		tShootor.Start();
	return 0;
}



bool pgeCircleShootor::OnUserCreate()
{
	// Called once at the start, so create things here
	//동적할당으로 생성
	mActor = new CActor();
	mActor->Create();
	mActor->SetPosition(ScreenWidth() * 0.5f, ScreenHeight() * 0.5f + 80.0f);
	mActor->SetIsActive(true);

	mEnemy = new CEnemy();
	mEnemy->Create();
	mEnemy->SetPosition(ScreenWidth() * 0.5f, 0.0f + 80.0f);
	mEnemy->SetIsActive(true);

	mEnemy->SetVelocity(olc::vf2d(-1.0f, 0.0f) * 20.0f);



	mEnemyAimed = new CEnemy();
	mEnemyAimed->Create();
	mEnemyAimed->SetPosition(ScreenWidth() * 0.5f - 50.0f, 0.0f + 80.0f);
	mEnemyAimed->SetIsActive(true);

	mEnemyAimed->SetVelocity(olc::vf2d(0.0f, 0.0f));


	mEnemyCircled = new CEnemy();
	mEnemyCircled->Create();
	mEnemyCircled->SetPosition(ScreenWidth() * 0.5f + 80.0f, 0.0f + 80.0f);
	mEnemyCircled->SetIsActive(true);

	mEnemyCircled->SetVelocity(olc::vf2d(1.0f, 0.0f) * 20.0f);



	mBullets.clear();	//원소 모두 지우기
	//탄환 10발 생성
	CBullet* tpBullet = nullptr;
	for (int ti = 0; ti < ACTOR_BULLET_COUNT; ++ti)
	{
		tpBullet = new CBullet;
		tpBullet->Create(5.0f);
		tpBullet->SetPosition(ScreenWidth() * 0.5f, ScreenHeight() * 0.5f + 80.0f);
		tpBullet->SetIsActive(false);
		mBullets.push_back(tpBullet);
	}

	//적의 일반탄환 생성
	mBulletsEnemy.clear();
	tpBullet = nullptr;
	for (int ti = 0; ti < ENEMY_BULLET_COUNT; ++ti)
	{
		tpBullet = new CBullet;
		tpBullet->Create(5.0f);
		tpBullet->SetPosition(ScreenWidth() * 0.5f, 0.0f + 80.0f);
		tpBullet->SetIsActive(false);
		mBulletsEnemy.push_back(tpBullet);
	}


	//적의 조준탄환 생성
	mBulletsEnemyAimed.clear();
	tpBullet = nullptr;
	for (int ti = 0; ti < ENEMY_BULLET_COUNT; ++ti)
	{
		tpBullet = new CBullet;
		tpBullet->Create(5.0f);
		tpBullet->SetPosition(ScreenWidth() * 0.5f, 0.0f + 80.0f);
		tpBullet->SetIsActive(false);
		mBulletsEnemyAimed.push_back(tpBullet);
	}


	//적의 원형탄환 생성
	mBulletsEnemyCircled.clear();
	tpBullet = nullptr;
	for (int ti = 0; ti < ENEMY_BULLET_COUNT * 8; ++ti)
	{
		tpBullet = new CBullet;
		tpBullet->Create(5.0f);
		tpBullet->SetPosition(ScreenWidth() * 0.5f + 80.0f, 0.0f + 80.0f);
		tpBullet->SetIsActive(false);
		mBulletsEnemyCircled.push_back(tpBullet);
	}

	//주인공 기체의 초기위치 지정
	/*mActor.mPosition.x = ScreenWidth() * 0.5f;
	mActor.mPosition.y = ScreenHeight() * 0.5f + 80.0f;*/
	mActor->SetPosition(ScreenWidth() * 0.5f, ScreenHeight() * 0.5f + 80.0f);

	return true;
}
bool pgeCircleShootor::OnUserDestroy()
{

	//적 조준탄환 해제
	for (vector<CBullet*>::iterator t = mBulletsEnemyCircled.begin(); t != mBulletsEnemyCircled.end(); ++t)
	{
		if (nullptr != (*t))
		{
			delete (*t);
			*t = nullptr;
		}
	}
	mBulletsEnemyCircled.clear();



	//적 조준탄환 해제
	for (vector<CBullet*>::iterator t = mBulletsEnemyAimed.begin(); t != mBulletsEnemyAimed.end(); ++t)
	{
		if (nullptr != (*t))
		{
			delete (*t);
			*t = nullptr;
		}
	}
	mBulletsEnemyAimed.clear();


	//적 일반탄환 해제
	for (vector<CBullet*>::iterator t = mBulletsEnemy.begin(); t != mBulletsEnemy.end(); ++t)
	{
		if (nullptr != (*t))
		{
			delete (*t);
			*t = nullptr;
		}
	}
	mBulletsEnemy.clear();


	//반복자를 이용하여 원소들을 순회
	for (vector<CBullet*>::iterator t = mBullets.begin(); t != mBullets.end(); ++t)
	{
		if (nullptr != (*t))
		{
			delete (*t);
			*t = nullptr;
		}
	}
	mBullets.clear();



	if (nullptr != mEnemyCircled)
	{
		delete mEnemyCircled;
		mEnemyCircled = nullptr;
	}

	if (nullptr != mEnemyAimed)
	{
		delete mEnemyAimed;
		mEnemyAimed = nullptr;
	}

	if (nullptr != mEnemy)
	{
		delete mEnemy;
		mEnemy = nullptr;
	}

	//todo
	if (nullptr != mActor)
	{
		//동적할당한 메모리 해제
		delete mActor;
		mActor = nullptr;
	}

	return true;
}
bool pgeCircleShootor::OnUserUpdate(float fElapsedTime)
{
	switch (mCurSceneType)
	{
	case SCENE_TITLE:
	{
		UpdateTitle(fElapsedTime);
	}
	break;
	case SCENE_PLAYGAME:
	{
		UpdatePlayGame(fElapsedTime);
	}
	break;
	}



	return true;
}

void pgeCircleShootor::UpdateTitle(float fElapsedTime)
{
	//update

	//스페이스바 키입력이 있으면 플레이 시작
	//<-- SCENE_PLAYGAME으로 장면 전환
	if (GetKey(olc::Key::SPACE).bReleased)
	{
		mCurSceneType = SCENE_PLAYGAME;
	}



	//render
	this->Clear(olc::YELLOW);


}

void pgeCircleShootor::UpdatePlayGame(float fElapsedTime)
{
	//collision처리
	//원 vs 원 충돌 알고리즘 :
	//	충돌 알고리즘 중에서 가장 방법이 간단하고
	//	연산이 작은 알고리즘이다.
	// 주인공 일반탄환 vs 적 기체 충돌을 가정

	for (auto t : mBullets) //cpp11에서 추가된 for문
	{
		if (t->GetIsActive())
		{
			if (mEnemy->GetIsActive())
			{
				//충돌 체크

				float tAdd = 0.0f;		//두 원의 반지름의 합
				float tDistance = 0.0f;	//두 원의 중심 사이의 거리

				/*tAdd = t->GetRadius() + mEnemy->GetRadius();
				tDistance = std::sqrtf((t->GetPosition().x - mEnemy->GetPosition().x) * (t->GetPosition().x - mEnemy->GetPosition().x) + (t->GetPosition().y - mEnemy->GetPosition().y) * (t->GetPosition().y - mEnemy->GetPosition().y));*/

				//tAdd, tDistance 모두 양수다( 길이의 개념이므로 그렇다 )
				//양변이 양수라면 그 등식은 제곱해도 똑같이 성립한다.
				//이러한 성질을 이용하여 양변을 제곱하여 제곱근을 구하기를 없애겠다.
				//<-- 왜냐하면 제곱근을 구한다는 것에는 무한의 개념이 들어있다. 그런데, 무한개념이 들어간 값을 구하는 것은 컴퓨터에서 비교적 연산이 많이 먹는 것이다. 그러므로 이러한 연산을 제거할 수 있다면 제거하는 것이 좋다.
				tAdd = (t->GetRadius() + mEnemy->GetRadius()) * (t->GetRadius() + mEnemy->GetRadius());
				tDistance = (t->GetPosition().x - mEnemy->GetPosition().x) * (t->GetPosition().x - mEnemy->GetPosition().x) + (t->GetPosition().y - mEnemy->GetPosition().y) * (t->GetPosition().y - mEnemy->GetPosition().y);

				if (tAdd >= tDistance)
				{
					cout << "collision" << endl;
					//적 제거
					mEnemy->SetIsActive(false);
					//탄환 제거
					t->SetIsActive(false);

					break;
				}
			}
		}
	}





	olc::vf2d tVelocity(0.0f, 0.0f);
	mActor->SetVelocity(tVelocity * 0.0f);

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


	if (GetKey(olc::Key::SPACE).bReleased)
	{
		//주인공 기체의 일반탄환 발사
		mActor->DoFire(mBullets);
	}
	if (GetKey(olc::Key::SPACE).bPressed)
	{
		//주인공 기체의 일반탄환 발사
		mActor->DoFire(mBullets);
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

	mActor->SetVelocity(tVelocity * 75.0f);		//	벡터의 스칼라곱셈

	//update
	//Update Method패턴이 적용된 결과다.
	mActor->Update(fElapsedTime);
	mEnemy->Update(fElapsedTime);
	/*mEnemyAimed->Update(fElapsedTime);
	mEnemyCircled->Update(fElapsedTime);*/

	//적기는 일반탄환을
	//일정 시간 간격으로 순차적으로 한 발씩 연사한다
	//<-- 타이머 개념을 만들어야 한다.

	//게임엔진이 fElapsedTime을 알려주고 있다.
	//fElapsedTime은 한 프레임에 걸리는 실제 시간이다.
	//그러므로 이것을 이용하여 타이머 개념을 만들 수 있다.
	//if (mEnemy->mTimeTick >= 2.0f)
	//{
	//	//fire
	//	mEnemy->DoFire(mBulletsEnemy);
	//	cout << "Enemy Do Fire" << endl;

	//	mEnemy->mTimeTick -= 2.0f;
	//}
	//else
	//{
	//	mEnemy->mTimeTick = mEnemy->mTimeTick + fElapsedTime;
	//}

	//if (mEnemyAimed->mTimeTick >= 1.0f)
	//{
	//	//fire
	//	mEnemyAimed->DoFireAimed(mBulletsEnemyAimed, mActor);
	//	cout << "EnemyAimed Do Fire Aimed" << endl;

	//	mEnemyAimed->mTimeTick = 0.0f;
	//}
	//else
	//{
	//	mEnemyAimed->mTimeTick = mEnemyAimed->mTimeTick + fElapsedTime;
	//}

	////circled의 타이머
	//if (mEnemyCircled->mTimeTick >= 1.0f)
	//{
	//	//fire
	//	mEnemyCircled->DoFireCircled(mBulletsEnemyCircled);
	//	cout << "EnemyAimed Do Fire Circled" << endl;

	//	mEnemyCircled->mTimeTick = 0.0f;
	//}
	//else
	//{
	//	mEnemyCircled->mTimeTick = mEnemyCircled->mTimeTick + fElapsedTime;
	//}


	for (auto t = mBullets.begin(); t != mBullets.end(); ++t)
	{
		(*t)->Update(fElapsedTime);
	}

	//적 기체 일반탄환
	for (auto t = mBulletsEnemy.begin(); t != mBulletsEnemy.end(); ++t)
	{
		(*t)->Update(fElapsedTime);
	}

	//적 기체 조준탄환
	for (auto t = mBulletsEnemyAimed.begin(); t != mBulletsEnemyAimed.end(); ++t)
	{
		(*t)->Update(fElapsedTime);
	}

	//적 기체 원형탄환
	for (auto t = mBulletsEnemyCircled.begin(); t != mBulletsEnemyCircled.end(); ++t)
	{
		(*t)->Update(fElapsedTime);
	}


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
	mActor->Render(this);
	mEnemy->Render(this);
	/*mEnemyAimed->Render(this);
	mEnemyCircled->Render(this);*/

	for (vector<CBullet*>::iterator t = mBullets.begin(); t != mBullets.end(); ++t)
	{
		(*t)->Render(this);
	}

	//적 기체 일반탄환
	for (auto t = mBulletsEnemy.begin(); t != mBulletsEnemy.end(); ++t)
	{
		(*t)->Render(this);
	}

	//적 기체 조준탄환
	for (auto t = mBulletsEnemyAimed.begin(); t != mBulletsEnemyAimed.end(); ++t)
	{
		(*t)->Render(this);
	}

	//적 기체 원형탄환
	for (auto t = mBulletsEnemyCircled.begin(); t != mBulletsEnemyCircled.end(); ++t)
	{
		(*t)->Render(this);
	}
}

//실제 직선은 무한하지만,
//컴퓨터로 표현 불가능하다. 그러므로 선분을 직선으로 간주하고 그리겠다
//시점: tX_0, tY_0
//중점: tX_1, tY_1
void pgeCircleShootor::DrawLineEquation(int tX_0, int tY_0, int tX_1, int tY_1)
{
	
	//x변화량이 0인 경우, 수직선(vertical line)인 경우
	if (tX_0 == tX_1)
	{
		//가정과 다르다면 선분의 양끝점 값을 바꿔준다.
		if (tY_0 > tY_1)
		{
			std::swap(tY_0, tY_1);
		}

		//임의의 x, y
		int tX = 0;
		int tY = 0;
		
		tX = tX_0;
		for (tY = tY_0; tY <= tY_1; ++tY)
		{
			Draw(tX, tY);
		}

		return;
	}





	float tSlopeRatio = 0.0f;	//기울기
	//직선을 정의하기 위해서 기울기 개념을 만든다.

	//수학적 정의에 의한 기울기를 구함: y변화량 / x변화량
	//기울기는 연속적인 공간의 개념으로 다루기 위해 float실수로 형변환
	//	그러므로, 실수의 나눗셈이 일어난다
	tSlopeRatio = (float)(tY_1 - tY_0) / (float)(tX_1 - tX_0);


	if (tSlopeRatio > -1 && tSlopeRatio < 1)
	{
		//가정에 맞게 시점과 중점을 유지한다.( 시점이 x축입장에서 보았을 때 왼쪽에 있다고 가정했다 )
		if (tX_0 > tX_1)
		{
			std::swap(tX_0, tX_1);
			std::swap(tY_0, tY_1);
		}

		//임의의 x, y
		int tX = 0;
		int tY = 0;

		for (tX = tX_0; tX <= tX_1; ++tX)
		{
			//y = a * x + b
			tY = tSlopeRatio * (tX - tX_0) + tY_0 + 0.5f;	//반올림 +0.5, 보다 증가가 자연스러운 정수 단위를 만들기 위해

			//점찍기함수
			Draw(tX, tY);
		}
	}
	else    //tSlopeRatio >= 1 || tSlopeRatio <= -1, 이 경우에는 정직하게 표시하면 직선으로서 품질이 떨어진다.
	{
		if (tY_0 > tY_1)
		{
			std::swap(tX_0, tX_1);
			std::swap(tY_0, tY_1);
		}

		int tX = 0;
		int tY = 0;

		for (tY = tY_0; tY <= tY_1; ++tY)
		{
			//y를 독립변수, x를 종속변수로 보았으므로 기울기의 역수를 취한다
			tX = (1.0f / tSlopeRatio) * (tY - tY_0) + tX_0 + 0.5f;

			Draw(tX, tY);
		}
	}



}

void pgeCircleShootor::DrawCircleEquation(int tXCenter, int tYCenter, int tRadius, olc::Pixel tColor)
{
	//임의의 x, y
	int tX = 0;
	int tY = 0;

	tX = 0;
	tY = tRadius;

	while (tY >= tX)
	{
		//1사분면의 원의 일부를 그린다
		Draw(tX + tXCenter, tY + tYCenter, tColor);
		Draw(tY + tXCenter, tX + tYCenter, tColor);

		//나머지는 원은 모든 방향에서 동형(모양이 같다)이므로 위의 두 문장을 그대로 쓰되
		//각각의 사분면에 적합한 부호의 값을 넣어준다.
		Draw(tX + tXCenter, -tY + tYCenter, tColor);
		Draw(tY + tXCenter, -tX + tYCenter, tColor);
		
		Draw(-tX + tXCenter, tY + tYCenter, tColor);
		Draw(-tY + tXCenter, tX + tYCenter, tColor);
		
		Draw(-tX + tXCenter, -tY + tYCenter, tColor);
		Draw(-tY + tXCenter, -tX + tYCenter, tColor);

		tX++;
		//원의 방정식 (x - a)^2 + (y - b)^2 = r^2
		//	a, b는 원의 중심	r은 반지름
		tY = (int)(std::sqrtf((float)tRadius * tRadius - tX * tX) + 0.5f);
	}
}

/*
	C++ integral promotion규칙

	i) 한 쪽은 실수, 한 쪽은 정수		--> 정수가 실수로 변환				float * int --> float
	ii) 양쪽 다 정수, 양쪽 다 실수		--> 보다 넓은 범위의 것으로 변환	float * double --> double, short int * int --> int
	iii) 양쪽 다 int보다 작은 정수		--> int로 변환						short int * int --> int, char * int --> int
	iv) 부호 없는 정수와 부호 있는 정수	--> 부호 없는 정수로 변환			int * unsigned int --> unsigned int

*/