#include "CUnit.h"

#include "pgeCircleShootor.h"

//void CUnit::DoMoveX(float tXSpeed, float t)
//{
//	//mActorX = mActorX +tXSpeed * t;
//	mPosition.x = mPosition.x + tXSpeed * t;
//}


void CUnit::Create(float tRadius)
{
	mRadius = tRadius;
}

void CUnit::Update(float t)
{
	if (mIsActive)
	{
		//������ġ = ������ġ + �ӵ� * �ð�����
		mPosition = mPosition + mVelocity * t;	//������ ��Į���, ���ͳ����� ����
	}
}

void CUnit::Render(olc::PixelGameEngine* tpEngine)
{
	if (mIsActive)
	{
		((pgeCircleShootor*)tpEngine)->DrawCircleEquation(this->mPosition.x, this->mPosition.y, mRadius);
	}
}