#include "CPlayGameScene.h"
#include "CTitleScene.h"
#include "CGameOverScene.h"
#include "CEnemy.h"

#include "pgeCircleShootor.h"

void CPlayGameScene::Execute()
{
	mPlayerMortalTime = 0.0f;
	mIsPlayerMortal = true;
	mIsGameOver = false;
	GAME->ResetScore();
	GAME->mActor->SetIsActive(true);
	for (auto tEnemy : GAME->mEnemies)
	{
		tEnemy->SetIsActive(true);
	}
	for (auto tBullet : GAME->mBulletsEnemyAll)
	{
		tBullet->SetIsActive(false);
	}
	for (auto tBullet : GAME->mBullets)
	{
		tBullet->SetIsActive(false);
	}
}
void CPlayGameScene::Update(float fElapsedTime)
{
	//플레이어 탄환 충돌
	for (auto tBullet : GAME->mBullets)
	{
		if (tBullet->GetIsActive())
		{
			for (auto tEnemy : GAME->mEnemies)
			{
				if (tEnemy->GetIsActive())
				{
					float tAdd = 0.0f;
					float tDistance = 0.0f;

					tAdd = (tBullet->GetRadius() + tEnemy->GetRadius()) * (tBullet->GetRadius() + tEnemy->GetRadius());
					tDistance = (tBullet->GetPosition().x - tEnemy->GetPosition().x) * (tBullet->GetPosition().x - tEnemy->GetPosition().x) + (tBullet->GetPosition().y - tEnemy->GetPosition().y) * (tBullet->GetPosition().y - tEnemy->GetPosition().y);

					if (tAdd >= tDistance)
					{
						cout << "Enemy killed in action" << endl;
						tEnemy->mTimeTick = 0.0f;
						tEnemy->SetIsActive(false);
						tBullet->SetIsActive(false);
						GAME->ScoreGain();

						break;
					}
				}
			}
		}
	}

	//적 탄환 충돌
	if (mIsPlayerMortal)
	{
		for (auto tBullet : GAME->mBulletsEnemyAll)
		{
			if (tBullet->GetIsActive())
			{
				float tAdd = 0.0f;
				float tDistance = 0.0f;

				tAdd = (tBullet->GetRadius() + GAME->mActor->GetRadius()) * (tBullet->GetRadius() + GAME->mActor->GetRadius());
				tDistance = (tBullet->GetPosition().x - GAME->mActor->GetPosition().x) * (tBullet->GetPosition().x - GAME->mActor->GetPosition().x) + (tBullet->GetPosition().y - GAME->mActor->GetPosition().y) * (tBullet->GetPosition().y - GAME->mActor->GetPosition().y);

				if (tAdd >= tDistance)
				{
					cout << "Player killed in action" << endl;
					mIsPlayerMortal = false;
					GAME->mActor->SetPosition(GAME->ScreenWidth() * 0.5f, GAME->ScreenHeight() * 0.5f + 80.0f);
					tBullet->SetIsActive(false);
					if (GAME->GetCoinNum() > 0)
					{
						GAME->CoinDecrease();
					}
					else
					{
						mIsGameOver = true;
						GAME->mActor->SetIsActive(false);
					}

					break;
				}
			}
		}
	}
	//충돌 직후
	else if (mPlayerMortalTime < 2.0f)
	{
		mPlayerMortalTime += fElapsedTime;
	}
	//충돌 후 일정 시간 경과
	else
	{
		mPlayerMortalTime = 0.0f;
		mIsPlayerMortal = true;
	}

	olc::vf2d tVelocity(0.0f, 0.0f);
	GAME->mActor->SetVelocity(tVelocity * 0.0f);

	float tXDir = 0.0f;
	float tYDir = 0.0f;

	if (GAME->GetKey(olc::Key::LEFT).bHeld || GAME->GetKey(olc::Key::A).bHeld)
	{
		tXDir = -1.0f;
	}

	if (GAME->GetKey(olc::Key::RIGHT).bHeld || GAME->GetKey(olc::Key::D).bHeld)
	{
		tXDir = 1.0f;
	}

	if (GAME->GetKey(olc::Key::UP).bHeld || GAME->GetKey(olc::Key::W).bHeld)
	{
		tYDir = -1.0f;
	}

	if (GAME->GetKey(olc::Key::DOWN).bHeld || GAME->GetKey(olc::Key::S).bHeld)
	{
		tYDir = 1.0f;
	}


	if (GAME->GetKey(olc::Key::SPACE).bReleased || GAME->GetKey(olc::Key::SPACE).bPressed)
	{
		GAME->mActor->DoFire(GAME->mBullets);
	}


	olc::vf2d tXVelocity(1.0f, 0.0f);
	olc::vf2d tYVelocity(0.0f, 1.0f);

	tXVelocity = tXVelocity * tXDir;
	tYVelocity = tYVelocity * tYDir;


	tVelocity = tXVelocity + tYVelocity;
	if (tVelocity.mag() > 0.0f)
	{
		tVelocity = tVelocity.norm();
	}

	GAME->mActor->SetVelocity(tVelocity * 75.0f);

	GAME->mActor->Update(fElapsedTime);
	GAME->mEnemies[0]->Update(fElapsedTime);
	GAME->mEnemies[1]->Update(fElapsedTime);
	GAME->mEnemies[2]->Update(fElapsedTime);

	if (GAME->mEnemies[0]->GetIsActive())
	{
		if (GAME->mEnemies[0]->mTimeTick >= 2.0f)
		{
			GAME->mEnemies[0]->DoFire(GAME->mBulletsEnemy);
			cout << "Enemy Do Fire" << endl;

			GAME->mEnemies[0]->mTimeTick -= 2.0f;
		}
		else
		{
			GAME->mEnemies[0]->mTimeTick = GAME->mEnemies[0]->mTimeTick + fElapsedTime;
		}
	}
	else
	{
		if (GAME->mEnemies[0]->mTimeTick >= 2.0f)
		{
			GAME->mEnemies[0]->SetIsActive(true);
		}
		else
		{
			GAME->mEnemies[0]->mTimeTick = GAME->mEnemies[0]->mTimeTick + fElapsedTime;
		}
	}

	if (GAME->mEnemies[1]->GetIsActive())
	{
		if (GAME->mEnemies[1]->mTimeTick >= 2.7f)
		{
			GAME->mEnemies[1]->DoFireAimed(GAME->mBulletsEnemyAimed, GAME->mActor);
			cout << "EnemyAimed Do Fire Aimed" << endl;

			GAME->mEnemies[1]->mTimeTick = 0.0f;
		}
		else
		{
			GAME->mEnemies[1]->mTimeTick = GAME->mEnemies[1]->mTimeTick + fElapsedTime;
		}
	}
	else
	{
		if (GAME->mEnemies[1]->mTimeTick >= 2.0f)
		{
			GAME->mEnemies[1]->SetIsActive(true);
		}
		else
		{
			GAME->mEnemies[1]->mTimeTick = GAME->mEnemies[1]->mTimeTick + fElapsedTime;
		}
	}

	if (GAME->mEnemies[2]->GetIsActive())
	{
		if (GAME->mEnemies[2]->mTimeTick >= 4.03f)
		{
			GAME->mEnemies[2]->DoFireCircled(GAME->mBulletsEnemyCircled);
			cout << "EnemyAimed Do Fire Circled" << endl;

			GAME->mEnemies[2]->mTimeTick = 0.0f;
		}
		else
		{
			GAME->mEnemies[2]->mTimeTick = GAME->mEnemies[2]->mTimeTick + fElapsedTime;
		}
	}
	else
	{
		if (GAME->mEnemies[2]->mTimeTick >= 2.0f)
		{
			GAME->mEnemies[2]->SetIsActive(true);
		}
		else
		{
			GAME->mEnemies[2]->mTimeTick = GAME->mEnemies[2]->mTimeTick + fElapsedTime;
		}
	}

	for (auto t = GAME->mBullets.begin(); t != GAME->mBullets.end(); ++t)
	{
		(*t)->Update(fElapsedTime);
	}

	for (auto t = GAME->mBulletsEnemy.begin(); t != GAME->mBulletsEnemy.end(); ++t)
	{
		(*t)->Update(fElapsedTime);
	}

	for (auto t = GAME->mBulletsEnemyAimed.begin(); t != GAME->mBulletsEnemyAimed.end(); ++t)
	{
		(*t)->Update(fElapsedTime);
	}

	for (auto t = GAME->mBulletsEnemyCircled.begin(); t != GAME->mBulletsEnemyCircled.end(); ++t)
	{
		(*t)->Update(fElapsedTime);
	}


	//render
	GAME->Clear(olc::VERY_DARK_BLUE);

	if ((int)(mPlayerMortalTime * 10.0f) % 2 == 0)
	{
		GAME->mActor->Render(GAME);
	}
	GAME->mEnemies[0]->Render(GAME);
	GAME->mEnemies[1]->Render(GAME);
	GAME->mEnemies[2]->Render(GAME);

	for (vector<CBullet*>::iterator t = GAME->mBullets.begin(); t != GAME->mBullets.end(); ++t)
	{
		(*t)->Render(GAME);
	}

	for (auto t = GAME->mBulletsEnemy.begin(); t != GAME->mBulletsEnemy.end(); ++t)
	{
		(*t)->Render(GAME);
	}

	for (auto t = GAME->mBulletsEnemyAimed.begin(); t != GAME->mBulletsEnemyAimed.end(); ++t)
	{
		(*t)->Render(GAME);
	}

	for (auto t = GAME->mBulletsEnemyCircled.begin(); t != GAME->mBulletsEnemyCircled.end(); ++t)
	{
		(*t)->Render(GAME);
	}

	//남은 동전 수 출력
	char tTemp[32] = { 0 };
	sprintf_s(tTemp, "Coin: %d", GAME->GetCoinNum());
	GAME->DrawString(0, 0, tTemp);

	//현재 점수 출력
	sprintf_s(tTemp, "Score: %d", GAME->GetCurScore());
	GAME->DrawString(0, 10, tTemp);

	//게임 종료 텍스트 출력
	if (mIsGameOver)
	{
		GAME->DrawString(50, 100, "Game Over", olc::WHITE, 3U);
		if (mPlayerMortalTime > 2.0f)
		{
			GAME->SetScene(new CGameOverScene());
			GAME->SceneExecute();

			delete this;
		}
	}
}