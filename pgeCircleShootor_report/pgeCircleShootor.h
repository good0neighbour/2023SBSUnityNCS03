#pragma once

#include "olcPixelGameEngine.h"
#include "CActor.h"
#include "CBullet.h"

#include <vector>
using namespace std;

class CScene;
class CEnemy;

enum
{
	SCENE_TITLE = 0,
	SCENE_PLAYGAME
};

class pgeCircleShootor : public olc::PixelGameEngine
{
private:
	int mCurSceneType = SCENE_TITLE;
	CScene* mScene = nullptr;

	CActor* mActor = nullptr;
	CEnemy* mEnemy = nullptr;

	CEnemy* mEnemyAimed = nullptr;
	CEnemy* mEnemyCircled = nullptr;

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

	inline const int GetCurSceneType()
	{
		return mCurSceneType;
	}
	inline void SetCurSceneType(int tValue)
	{
		mCurSceneType = tValue;
	}

	inline const CScene* GetCurScene()
	{
		return mScene;
	}
	inline void SetScene(CScene* tValue)
	{
		mScene = tValue;
	}
};