#pragma once

#include "olcPixelGameEngine.h"
#include "CActor.h"
#include "CBullet.h"

#include <vector>
using namespace std;

class CScene;
class CEnemy;

class pgeCircleShootor : public olc::PixelGameEngine
{
private:
	CScene* mScene = nullptr;

public: //юс╫ц
	CActor* mActor = nullptr;
	CEnemy* mEnemies[3];

	vector<CBullet*> mBullets;
	vector<CBullet*> mBulletsEnemy;
	vector<CBullet*> mBulletsEnemyAimed;
	vector<CBullet*> mBulletsEnemyCircled;


public:
	pgeCircleShootor()
	{
		sAppName = "pgeCircleShootor";
	}

public:
	bool OnUserCreate() override;
	bool OnUserDestroy() override;
	bool OnUserUpdate(float fElapsedTime) override;

	void UpdateTitle(float fElapsedTime);
	void UpdatePlayGame(float fElapsedTime);

	void DrawLineEquation(int tX_0, int tY_0, int tX_1, int tY_1);
	void DrawCircleEquation(int tXCenter, int tYCenter, int tRadius, olc::Pixel tColor = olc::WHITE);

	inline const CScene* GetCurScene()
	{
		return mScene;
	}
	inline void SetScene(CScene* tValue)
	{
		mScene = tValue;
	}
};