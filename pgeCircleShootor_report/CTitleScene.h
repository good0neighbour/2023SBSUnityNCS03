#pragma once

#include "CScene.h"

class pgeCircleShootor;

class CTitleScene : public CScene
{
public:
	virtual void Execute() override;
	virtual void Update(pgeCircleShootor* game, float fElapsedTime) override;
};

