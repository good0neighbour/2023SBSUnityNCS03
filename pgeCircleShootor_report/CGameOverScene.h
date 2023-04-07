#pragma once

#include "CStatus.h"

class CGameOverScene : public CStatus
{
public:
	virtual void Execute() override;
	virtual void Update(pgeCircleShootor* tGame, float fElapsedTime) override;
};

