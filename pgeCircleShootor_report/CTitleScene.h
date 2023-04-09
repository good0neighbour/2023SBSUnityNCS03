#pragma once

#include "CStatus.h"

class pgeCircleShootor;

class CTitleScene : public CStatus
{
private:
	float mTime = 0.0f;
	bool mDisplay = true;

public:
	virtual void Execute() override;
	virtual void Update(float fElapsedTime) override;
};

