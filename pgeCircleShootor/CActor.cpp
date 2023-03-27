#include "CActor.h"

#include "CBullet.h"
#include "config.h"


void CActor::Update(float t)
{
	//부모클래스의 기능은 일단 그대로 실행
	CUnit::Update(t);

	//todo
	//CActor로서의 기능은 여기에 추가하겠다
	//경계처리
	//좌우, 상하

	//좌우
	if (this->mPosition.x - this->mRadius < 0.0f)
	{
		this->mPosition.x = 0.0f + this->mRadius;
	}

	if (this->mPosition.x + this->mRadius > 320.0f)
	{
		this->mPosition.x = 320.0f - this->mRadius;
	}

	//상하
	if (this->mPosition.y - this->mRadius < 0.0f)
	{
		this->mPosition.y = 0.0f + this->mRadius;
	}

	if (this->mPosition.y + this->mRadius > 240.0f)
	{
		this->mPosition.y = 240.0f - this->mRadius;
	}
}

//주인공 기체의 일반탄환 발사 기능
void CActor::DoFire(vector<CBullet*>& tBullets)
{
	//탄환발사 알고리즘
	/*
		i) 탄환의 발사시작지점을 설정한다
		ii) 탄환의 속도를 설정한다
		iii) 탄환을 활성화한다
	*/

	//step_0
	//한 발만 가정해본다.
	//tBullets[0]->SetPosition(this->GetPosition());
	//tBullets[0]->SetVelocity(olc::vf2d(0.0f, -1.0f) * 100.0f);
	//tBullets[0]->SetIsActive(true);

	//step_1
	//연사를 만들자
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