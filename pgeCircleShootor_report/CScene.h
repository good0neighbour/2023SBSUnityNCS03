#pragma once

class pgeCircleShootor;

class CScene
{
public:
	virtual void Execute() {};
	virtual void Update(pgeCircleShootor* game, float fElapsedTime) {};
};

