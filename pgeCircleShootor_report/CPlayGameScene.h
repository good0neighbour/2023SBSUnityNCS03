#pragma once

#include "CStatus.h"

class CPlayGameScene : public CStatus
{
private:
	float mPlayerMortalTime = 0.0f;
	bool mIsPlayerMortal = true;
	bool mIsGameOver = false;

public:
	virtual void Execute() override;
	virtual void Update(pgeCircleShootor* tGame, float fElapsedTime) override;
};

