#pragma once

#include "CScene.h"

class CPlayGameScene : public CScene
{
public:
	virtual void Execute() override;
	virtual void Update(pgeCircleShootor* game, float fElapsedTime) override;
};

