#pragma once

#include "CStatus.h"

class CGameOverScene : public CStatus
{
private:
	bool mIsNewRecord = false;
	int mNewPosition = 0;
	int mCurCursor = 0;
	float mTimer = 0.0f;

public:
	virtual void Execute() override;
	virtual void Update(float fElapsedTime) override;
};

