#define OLC_PGE_APPLICATION

#include "config.h"

/*
	PixelGameEngine
		게임프로그램에 필요한 기능들을 모아둔 클래스

	Example
		게임플레이에 관련한 로직을 작성하는 용도의 클래스

	위와 같이 분리하여 작성할 수 있도록 설계된 것이다.


*/

#include "pgeCircleShootor.h"

#include "CActor.h"
#include "CEnemy.h"
#include "CTitleScene.h"

int main()
{
	pgeCircleShootor tShootor;
	if (tShootor.Construct(320, 240, 2, 2))
		tShootor.Start();
	return 0;
}

bool pgeCircleShootor::OnUserCreate()
{
	mScene = new CTitleScene();

	mActor = new CActor();
	mActor->Create();
	mActor->SetPosition(ScreenWidth() * 0.5f, ScreenHeight() * 0.5f + 80.0f);
	mActor->SetIsActive(true);

	mEnemies[0] = new CEnemy();
	mEnemies[0]->Create();
	mEnemies[0]->SetPosition(ScreenWidth() * 0.5f, 0.0f + 80.0f);
	mEnemies[0]->SetIsActive(true);

	mEnemies[0]->SetVelocity(olc::vf2d(-1.0f, 0.0f) * 20.0f);



	mEnemies[1] = new CEnemy();
	mEnemies[1]->Create();
	mEnemies[1]->SetPosition(ScreenWidth() * 0.5f - 50.0f, 0.0f + 80.0f);
	mEnemies[1]->SetIsActive(true);

	mEnemies[1]->SetVelocity(olc::vf2d(0.0f, 0.0f));


	mEnemies[2] = new CEnemy();
	mEnemies[2]->Create();
	mEnemies[2]->SetPosition(ScreenWidth() * 0.5f + 80.0f, 0.0f + 80.0f);
	mEnemies[2]->SetIsActive(true);

	mEnemies[2]->SetVelocity(olc::vf2d(1.0f, 0.0f) * 20.0f);



	mBullets.clear();
	CBullet* tpBullet = nullptr;
	for (int ti = 0; ti < ACTOR_BULLET_COUNT; ++ti)
	{
		tpBullet = new CBullet;
		tpBullet->Create(5.0f);
		tpBullet->SetPosition(ScreenWidth() * 0.5f, ScreenHeight() * 0.5f + 80.0f);
		tpBullet->SetIsActive(false);
		mBullets.push_back(tpBullet);
	}

	mBulletsEnemy.clear();
	tpBullet = nullptr;
	for (int ti = 0; ti < ENEMY_BULLET_COUNT; ++ti)
	{
		tpBullet = new CBullet;
		tpBullet->Create(5.0f);
		tpBullet->SetPosition(ScreenWidth() * 0.5f, 0.0f + 80.0f);
		tpBullet->SetIsActive(false);
		mBulletsEnemy.push_back(tpBullet);
	}

	mBulletsEnemyAimed.clear();
	tpBullet = nullptr;
	for (int ti = 0; ti < ENEMY_BULLET_COUNT; ++ti)
	{
		tpBullet = new CBullet;
		tpBullet->Create(5.0f);
		tpBullet->SetPosition(ScreenWidth() * 0.5f, 0.0f + 80.0f);
		tpBullet->SetIsActive(false);
		mBulletsEnemyAimed.push_back(tpBullet);
	}

	mBulletsEnemyCircled.clear();
	tpBullet = nullptr;
	for (int ti = 0; ti < ENEMY_BULLET_COUNT * 8; ++ti)
	{
		tpBullet = new CBullet;
		tpBullet->Create(5.0f);
		tpBullet->SetPosition(ScreenWidth() * 0.5f + 80.0f, 0.0f + 80.0f);
		tpBullet->SetIsActive(false);
		mBulletsEnemyCircled.push_back(tpBullet);
	}

	mActor->SetPosition(ScreenWidth() * 0.5f, ScreenHeight() * 0.5f + 80.0f);

	return true;
}
bool pgeCircleShootor::OnUserDestroy()
{
	for (vector<CBullet*>::iterator t = mBulletsEnemyCircled.begin(); t != mBulletsEnemyCircled.end(); ++t)
	{
		if (nullptr != (*t))
		{
			delete (*t);
			*t = nullptr;
		}
	}
	mBulletsEnemyCircled.clear();

	for (vector<CBullet*>::iterator t = mBulletsEnemyAimed.begin(); t != mBulletsEnemyAimed.end(); ++t)
	{
		if (nullptr != (*t))
		{
			delete (*t);
			*t = nullptr;
		}
	}
	mBulletsEnemyAimed.clear();

	for (vector<CBullet*>::iterator t = mBulletsEnemy.begin(); t != mBulletsEnemy.end(); ++t)
	{
		if (nullptr != (*t))
		{
			delete (*t);
			*t = nullptr;
		}
	}
	mBulletsEnemy.clear();

	for (vector<CBullet*>::iterator t = mBullets.begin(); t != mBullets.end(); ++t)
	{
		if (nullptr != (*t))
		{
			delete (*t);
			*t = nullptr;
		}
	}
	mBullets.clear();

	if (nullptr != mEnemies[2])
	{
		delete mEnemies[2];
		mEnemies[2] = nullptr;
	}

	if (nullptr != mEnemies[1])
	{
		delete mEnemies[1];
		mEnemies[1] = nullptr;
	}

	if (nullptr != mEnemies[0])
	{
		delete mEnemies[0];
		mEnemies[0] = nullptr;
	}

	if (nullptr != mActor)
	{
		delete mActor;
		mActor = nullptr;
	}

	return true;
}
bool pgeCircleShootor::OnUserUpdate(float fElapsedTime)
{
	mScene->Update(this, fElapsedTime);
	
	return true;
}

void pgeCircleShootor::DrawLineEquation(int tX_0, int tY_0, int tX_1, int tY_1)
{
	if (tX_0 == tX_1)
	{
		if (tY_0 > tY_1)
		{
			std::swap(tY_0, tY_1);
		}

		int tX = 0;
		int tY = 0;
		
		tX = tX_0;
		for (tY = tY_0; tY <= tY_1; ++tY)
		{
			Draw(tX, tY);
		}

		return;
	}

	float tSlopeRatio = 0.0f;
	tSlopeRatio = (float)(tY_1 - tY_0) / (float)(tX_1 - tX_0);


	if (tSlopeRatio > -1 && tSlopeRatio < 1)
	{
		if (tX_0 > tX_1)
		{
			std::swap(tX_0, tX_1);
			std::swap(tY_0, tY_1);
		}

		int tX = 0;
		int tY = 0;

		for (tX = tX_0; tX <= tX_1; ++tX)
		{
			tY = tSlopeRatio * (tX - tX_0) + tY_0 + 0.5f;	//반올림 +0.5, 보다 증가가 자연스러운 정수 단위를 만들기 위해

			Draw(tX, tY);
		}
	}
	else
	{
		if (tY_0 > tY_1)
		{
			std::swap(tX_0, tX_1);
			std::swap(tY_0, tY_1);
		}

		int tX = 0;
		int tY = 0;

		for (tY = tY_0; tY <= tY_1; ++tY)
		{
			tX = (1.0f / tSlopeRatio) * (tY - tY_0) + tX_0 + 0.5f;

			Draw(tX, tY);
		}
	}
}

void pgeCircleShootor::DrawCircleEquation(int tXCenter, int tYCenter, int tRadius, olc::Pixel tColor)
{
	int tX = 0;
	int tY = 0;

	tX = 0;
	tY = tRadius;

	while (tY >= tX)
	{
		Draw(tX + tXCenter, tY + tYCenter, tColor);
		Draw(tY + tXCenter, tX + tYCenter, tColor);

		Draw(tX + tXCenter, -tY + tYCenter, tColor);
		Draw(tY + tXCenter, -tX + tYCenter, tColor);
		
		Draw(-tX + tXCenter, tY + tYCenter, tColor);
		Draw(-tY + tXCenter, tX + tYCenter, tColor);
		
		Draw(-tX + tXCenter, -tY + tYCenter, tColor);
		Draw(-tY + tXCenter, -tX + tYCenter, tColor);

		tX++;
		tY = (int)(std::sqrtf((float)tRadius * tRadius - tX * tX) + 0.5f);
	}
}