#pragma once

#include "olcPixelGameEngine.h"
#include "CActor.h"
#include "CBullet.h"

#include <vector>
using namespace std;

class CStatus;
class CEnemy;

class pgeCircleShootor : public olc::PixelGameEngine
{
private:
	CStatus* mScene = nullptr;
	unsigned int mCoin = 0;

public: //юс╫ц
	CActor* mActor = nullptr;
	CEnemy* mEnemies[3];

	vector<CBullet*> mBullets;
	vector<CBullet*> mBulletsEnemy;
	vector<CBullet*> mBulletsEnemyAimed;
	vector<CBullet*> mBulletsEnemyCircled;
	vector<CBullet*> mBulletsEnemyAll;


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

	inline void SetScene(CStatus* tValue)
	{
		mScene = tValue;
	}
	inline void SceneExecute()
	{
		mScene->Execute();
	}
	inline void CoinInsert()
	{
		mCoin++;
	}
	inline void CoinDecrease()
	{
		mCoin--;
	}
	inline const unsigned int GetCoinNum()
	{
		return mCoin;
	}
};