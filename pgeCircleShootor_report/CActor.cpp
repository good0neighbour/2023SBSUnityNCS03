#include "CActor.h"

#include "CBullet.h"
#include "config.h"


void CActor::Update(float t)
{
	//�θ�Ŭ������ ����� �ϴ� �״�� ����
	CUnit::Update(t);

	//todo
	//CActor�μ��� ����� ���⿡ �߰��ϰڴ�
	//���ó��
	//�¿�, ����

	//�¿�
	if (this->mPosition.x - this->mRadius < 0.0f)
	{
		this->mPosition.x = 0.0f + this->mRadius;
	}

	if (this->mPosition.x + this->mRadius > 320.0f)
	{
		this->mPosition.x = 320.0f - this->mRadius;
	}

	//����
	if (this->mPosition.y - this->mRadius < 0.0f)
	{
		this->mPosition.y = 0.0f + this->mRadius;
	}

	if (this->mPosition.y + this->mRadius > 240.0f)
	{
		this->mPosition.y = 240.0f - this->mRadius;
	}
}

//���ΰ� ��ü�� �Ϲ�źȯ �߻� ���
void CActor::DoFire(vector<CBullet*>& tBullets)
{
	//źȯ�߻� �˰���
	/*
		i) źȯ�� �߻���������� �����Ѵ�
		ii) źȯ�� �ӵ��� �����Ѵ�
		iii) źȯ�� Ȱ��ȭ�Ѵ�
	*/

	//step_0
	//�� �߸� �����غ���.
	//tBullets[0]->SetPosition(this->GetPosition());
	//tBullets[0]->SetVelocity(olc::vf2d(0.0f, -1.0f) * 100.0f);
	//tBullets[0]->SetIsActive(true);

	//step_1
	//���縦 ������
	tBullets[mCurIndexBullet]->SetPosition(this->GetPosition());
	tBullets[mCurIndexBullet]->SetVelocity(olc::vf2d(0.0f, -1.0f) * 100.0f);
	tBullets[mCurIndexBullet]->SetIsActive(true);

	if (mCurIndexBullet < ACTOR_BULLET_COUNT - 1)
	{
		mCurIndexBullet++;
	}
	else
	{
		mCurIndexBullet = 0;
	}
}