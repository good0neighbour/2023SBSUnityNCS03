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