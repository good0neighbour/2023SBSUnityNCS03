#pragma once


#include "olcPixelGameEngine.h"

class CUnit
{
//public:
protected:
	/*float mActorX = 0.0f;
	float mActorY = 0.0f;*/
	olc::vf2d mPosition;	//2D���ͷ� ��ġ ���� ����

	olc::vf2d mVelocity;	//�ӵ�

	float mRadius = 0.0f;	//�ܰ��� ũ��

	//Ȱ��ȭ ����
	bool mIsActive = false;

public:
	void Create(float tRadius = 20.0f);
	//void DoMoveX(float tXSpeed, float t);
	void Update(float t);
	void Render(olc::PixelGameEngine* tpEngine);

	inline void SetPosition(float tX, float tY)
	{
		mPosition.x = tX;
		mPosition.y = tY;
	}
	inline void SetPosition(const olc::vf2d tPosition)
	{
		mPosition = tPosition;
	}
	inline olc::vf2d GetPosition() const
	{
		return mPosition;
	}


	inline void SetVelocity(const olc::vf2d tVelocity)
	{
		mVelocity = tVelocity;
	}
	inline olc::vf2d GetVelocity() const
	{
		return mVelocity;
	}

	inline void SetIsActive(const bool tIsActive)
	{
		mIsActive = tIsActive;
	}
	inline const bool GetIsActive() const
	{
		return mIsActive;
	}
};

