#include "CEnemy.h"

#include "CBullet.h"
#include "config.h"

void CEnemy::Update(float t)
{
	CUnit::Update(t);
	//좌우 경계에서 방향을 바꾼다.
	if (this->mPosition.x - this->mRadius < 0.0f)
	{
		//this->mPosition.x = 0.0f + this->mRadius;
		this->SetVelocity(olc::vf2d(1.0f, 0.0f) * 20.0f);
	}

	if (this->mPosition.x + this->mRadius > 320.0f)
	{
		//this->mPosition.x = 320.0f - this->mRadius;
		this->SetVelocity(olc::vf2d(-1.0f, 0.0f) * 20.0f);
	}

	/*if (this->mPosition.y - this->mRadius < 0.0f)
	{
		this->mPosition.y = 0.0f + this->mRadius;
	}

	if (this->mPosition.y + this->mRadius > 240.0f)
	{
		this->mPosition.y = 240.0f - this->mRadius;
	}*/
}

//적 기체의 일반탄환 발사 기능
void CEnemy::DoFire(vector<CBullet*>& tBullets)
{
	tBullets[mCurIndexBullet]->SetPosition(this->GetPosition());
	tBullets[mCurIndexBullet]->SetVelocity(olc::vf2d(0.0f, 1.0f) * 50.0f);
	tBullets[mCurIndexBullet]->SetIsActive(true);

	if (mCurIndexBullet < ENEMY_BULLET_COUNT - 1)
	{
		mCurIndexBullet++;
	}
	else
	{
		mCurIndexBullet = 0;
	}

}

void CEnemy::DoFireAimed(vector<CBullet*>& tBullets, CUnit* tpTarget)
{
	tBullets[mCurIndexBullet]->SetPosition(this->GetPosition());

	//조준탄환의 방향 결정
	olc::vf2d tVelocity;

	//좌표 공간에서 위치와 벡터는 벡터의 연산으로 톨합되어있다.
	//임의의 크기의 방향의 벡터 구하기 = 목적지점 - 시작지점

	olc::vf2d tTargetPos = tpTarget->GetPosition();
	olc::vf2d tStartPos = this->GetPosition();
	//임의의 크기의 임의의 방향의 벡터
	olc::vf2d tVector = tTargetPos - tStartPos;
	//벡터의 정규화를 수행하여 단위벡터를 얻는다.
	//<-- 우리가 원하는 속력을 적용하기 위해서다.
	tVelocity = tVector.norm();

	tBullets[mCurIndexBullet]->SetVelocity(tVelocity * 50.0f);
	tBullets[mCurIndexBullet]->SetIsActive(true);

	if (mCurIndexBullet < ENEMY_BULLET_COUNT - 1)
	{
		mCurIndexBullet++;
	}
	else
	{
		mCurIndexBullet = 0;
	}
}

void CEnemy::DoFireCircled(vector<CBullet*>& tBullets)
{
	//8발을 동시에 발사
	for (int ti = mCurIndexBullet * 8; ti < mCurIndexBullet * 8 + 8; ++ti)
	{
		tBullets[ti]->SetPosition(this->GetPosition());

		//방향 결정 코드
		olc::vf2d tVelocity;
		//	속도는 벡터, 벡터는 수벡터 형식으로 다룬다
		//데카르트 좌표계의 x, y 성분을 구한다
		// x = r * cosT
		// y = r * sinT
		// degree 각도 vs radian 호도
		//<-- degree는 한 바퀴를 360등분한 거의 한 조각이다. 즉 측정치다.
		//<-- 반면에 radian은 지름이 1인 원의 둘레의 길이. 즉, 원주율이 3.14...인데에 착안하여 만들어진 도법이다. 즉, 원의 호의 길이를 각도로 삼는다
		//<--<-- 그러므로, radian은 실수 연산 체계에 통합된다
		//		 그러므로 모든 수학함수에서는 radian을 사용한다.
		//
		//		반지름이 1인 원을 가정했을 때 원의 둘레 길이는 2 * PI * 1
		//	그러므로, 비례식을 세우면 360 : 2PI = 1 : x
		//	그러므로, x = PI / 180
		tVelocity.x = 1.0f * std::cosf(45.0f * ti * (3.14159f / 180.0f));
		tVelocity.y = 1.0f * std::sinf(45.0f * ti * (3.14159f / 180.0f));

		tBullets[ti]->SetVelocity(tVelocity * 50.0f);
		tBullets[ti]->SetIsActive(true);
	}

	if (mCurIndexBullet < ENEMY_BULLET_COUNT - 1)
	{
		mCurIndexBullet++;
	}
	else
	{
		mCurIndexBullet = 0;
	}
}