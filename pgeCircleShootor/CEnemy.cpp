#include "CEnemy.h"

#include "CBullet.h"
#include "config.h"

void CEnemy::Update(float t)
{
	CUnit::Update(t);
	//�¿� ��迡�� ������ �ٲ۴�.
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

//�� ��ü�� �Ϲ�źȯ �߻� ���
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

	//����źȯ�� ���� ����
	olc::vf2d tVelocity;

	//��ǥ �������� ��ġ�� ���ʹ� ������ �������� ���յǾ��ִ�.
	//������ ũ���� ������ ���� ���ϱ� = �������� - ��������

	olc::vf2d tTargetPos = tpTarget->GetPosition();
	olc::vf2d tStartPos = this->GetPosition();
	//������ ũ���� ������ ������ ����
	olc::vf2d tVector = tTargetPos - tStartPos;
	//������ ����ȭ�� �����Ͽ� �������͸� ��´�.
	//<-- �츮�� ���ϴ� �ӷ��� �����ϱ� ���ؼ���.
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