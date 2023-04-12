#pragma once

#define GAME pgeCircleShootor::GetInstance()
#define MAX_RECORD 5

#include "olcPixelGameEngine.h"
#include "CStatus.h"
#include "CActor.h"
#include "CBullet.h"

#include <vector>
using namespace std;

class CEnemy;

class pgeCircleShootor : public olc::PixelGameEngine
{
private:
	static pgeCircleShootor* mpInstance;
	CStatus* mScene = nullptr;
	unsigned int mCoin = 0;
	unsigned int mCurScore = 0;
	unsigned int mScores[5] =
	{
		255, 100, 55, 20, 10
	};
	char mNames[5][3] =
	{
		'A', 'B', 'C',
		'D', 'E', 'F',
		'G', 'H', 'I',
		'J', 'K', 'L',
		'M', 'N', 'O'
	};

private:
	pgeCircleShootor()
	{
		sAppName = "pgeCircleShootor";
	};
	~pgeCircleShootor() {};

public: //юс╫ц
	CActor* mActor = nullptr;
	CEnemy* mEnemies[3];

	vector<CBullet*> mBullets;
	vector<CBullet*> mBulletsEnemy;
	vector<CBullet*> mBulletsEnemyAimed;
	vector<CBullet*> mBulletsEnemyCircled;
	vector<CBullet*> mBulletsEnemyAll;

public:
	bool OnUserCreate() override;
	bool OnUserDestroy() override;
	bool OnUserUpdate(float fElapsedTime) override;

	void UpdateTitle(float fElapsedTime);
	void UpdatePlayGame(float fElapsedTime);

	void DrawLineEquation(int tX_0, int tY_0, int tX_1, int tY_1);
	void DrawCircleEquation(int tXCenter, int tYCenter, int tRadius, olc::Pixel tColor = olc::WHITE);

	static pgeCircleShootor* GetInstance();
	static void ReleaseInstance();

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
	inline void CoinReset()
	{
		mCoin = 0;
	}
	inline const unsigned int GetCoinNum()
	{
		return mCoin;
	}
	inline void ScoreGain()
	{
		mCurScore++;
	}
	inline void ResetScore()
	{
		mCurScore = 0;
	}
	inline const unsigned int GetCurScore()
	{
		return mCurScore;
	}
	inline void SetScoreRecord(int tIndex, int tValue)
	{
		mScores[tIndex] = tValue;
	}
	inline const unsigned int GetScoreRecord(int tIndex)
	{
		return mScores[tIndex];
	}
	inline void SetNameCharacter(int tIndex, int tOrder, char tValue)
	{
		mNames[tIndex][tOrder] = tValue;
	}
	inline void SetNameCharacter(int tIndex, char tFirst, char tMiddle, char tLast)
	{
		mNames[tIndex][0] = tFirst;
		mNames[tIndex][1] = tMiddle;
		mNames[tIndex][2] = tLast;
	}
	inline const char GetNameCharacter(int tIndex, int tOrder)
	{
		return mNames[tIndex][tOrder];
	}
};