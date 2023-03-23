#pragma once


#include "olcPixelGameEngine.h"

class CUnit
{
//public:
protected:
	/*float mActorX = 0.0f;
	float mActorY = 0.0f;*/
	olc::vf2d mPosition;	//2Dº¤ÅÍ·Î À§Ä¡ °³³ä ¸¸µê

	olc::vf2d mVelocity;	//¼Óµµ


public:
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
};

