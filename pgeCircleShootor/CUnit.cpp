#include "CUnit.h"

#include "pgeCircleShootor.h"

//void CUnit::DoMoveX(float tXSpeed, float t)
//{
//	//mActorX = mActorX +tXSpeed * t;
//	mPosition.x = mPosition.x + tXSpeed * t;
//}

void CUnit::Update(float t)
{
	//������ġ = ������ġ + �ӵ� * �ð�����
	mPosition = mPosition + mVelocity * t;	//������ ��Į���, ���ͳ����� ����
}

void CUnit::Render(olc::PixelGameEngine* tpEngine)
{
	((pgeCircleShootor*)tpEngine)->DrawCircleEquation(this->mPosition.x, this->mPosition.y, 20.0f);
}