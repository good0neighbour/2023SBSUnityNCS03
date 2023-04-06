#pragma once

class pgeCircleShootor;

class CStatus
{
public:
	virtual void Execute() {};
	virtual void Update(pgeCircleShootor* game, float fElapsedTime) {};
};

