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
}
void CPlayGameScene::Update(pgeCircleShootor* tGame, float fElapsedTime)
{
	//플레이어 탄환 충돌
	for (auto tBullet : tGame->mBullets)
	{
		if (tBullet->GetIsActive())
		{
			for (auto tEnemy : tGame->mEnemies)
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

						break;
					}
				}
			}
		}
	}

	//적 탄환 충돌
	if (mIsPlayerMortal)
	{
		for (auto tBullet : tGame->mBulletsEnemyAll)
		{
			if (tBullet->GetIsActive())
			{
				float tAdd = 0.0f;
				float tDistance = 0.0f;

				tAdd = (tBullet->GetRadius() + tGame->mActor->GetRadius()) * (tBullet->GetRadius() + tGame->mActor->GetRadius());
				tDistance = (tBullet->GetPosition().x - tGame->mActor->GetPosition().x) * (tBullet->GetPosition().x - tGame->mActor->GetPosition().x) + (tBullet->GetPosition().y - tGame->mActor->GetPosition().y) * (tBullet->GetPosition().y - tGame->mActor->GetPosition().y);

				if (tAdd >= tDistance)
				{
					cout << "Player killed in action" << endl;
					mIsPlayerMortal = false;
					tGame->mActor->SetPosition(tGame->ScreenWidth() * 0.5f, tGame->ScreenHeight() * 0.5f + 80.0f);
					tBullet->SetIsActive(false);
					if (tGame->GetCoinNum() > 0)
					{
						tGame->CoinDecrease();
					}
					else
					{
						mIsGameOver = true;
						tGame->mActor->SetIsActive(false);
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
	tGame->mActor->SetVelocity(tVelocity * 0.0f);

	float tXDir = 0.0f;
	float tYDir = 0.0f;

	if (tGame->GetKey(olc::Key::LEFT).bHeld || tGame->GetKey(olc::Key::A).bHeld)
	{
		tXDir = -1.0f;
	}

	if (tGame->GetKey(olc::Key::RIGHT).bHeld || tGame->GetKey(olc::Key::D).bHeld)
	{
		tXDir = 1.0f;
	}

	if (tGame->GetKey(olc::Key::UP).bHeld || tGame->GetKey(olc::Key::W).bHeld)
	{
		tYDir = -1.0f;
	}

	if (tGame->GetKey(olc::Key::DOWN).bHeld || tGame->GetKey(olc::Key::S).bHeld)
	{
		tYDir = 1.0f;
	}


	if (tGame->GetKey(olc::Key::SPACE).bReleased || tGame->GetKey(olc::Key::SPACE).bPressed)
	{
		tGame->mActor->DoFire(tGame->mBullets);
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

	tGame->mActor->SetVelocity(tVelocity * 75.0f);

	tGame->mActor->Update(fElapsedTime);
	tGame->mEnemies[0]->Update(fElapsedTime);
	tGame->mEnemies[1]->Update(fElapsedTime);
	tGame->mEnemies[2]->Update(fElapsedTime);

	if (tGame->mEnemies[0]->GetIsActive())
	{
		if (tGame->mEnemies[0]->mTimeTick >= 2.0f)
		{
			tGame->mEnemies[0]->DoFire(tGame->mBulletsEnemy);
			cout << "Enemy Do Fire" << endl;

			tGame->mEnemies[0]->mTimeTick -= 2.0f;
		}
		else
		{
			tGame->mEnemies[0]->mTimeTick = tGame->mEnemies[0]->mTimeTick + fElapsedTime;
		}
	}
	else
	{
		if (tGame->mEnemies[0]->mTimeTick >= 2.0f)
		{
			tGame->mEnemies[0]->SetIsActive(true);
		}
		else
		{
			tGame->mEnemies[0]->mTimeTick = tGame->mEnemies[0]->mTimeTick + fElapsedTime;
		}
	}

	if (tGame->mEnemies[1]->GetIsActive())
	{
		if (tGame->mEnemies[1]->mTimeTick >= 2.7f)
		{
			tGame->mEnemies[1]->DoFireAimed(tGame->mBulletsEnemyAimed, tGame->mActor);
			cout << "EnemyAimed Do Fire Aimed" << endl;

			tGame->mEnemies[1]->mTimeTick = 0.0f;
		}
		else
		{
			tGame->mEnemies[1]->mTimeTick = tGame->mEnemies[1]->mTimeTick + fElapsedTime;
		}
	}
	else
	{
		if (tGame->mEnemies[1]->mTimeTick >= 2.0f)
		{
			tGame->mEnemies[1]->SetIsActive(true);
		}
		else
		{
			tGame->mEnemies[1]->mTimeTick = tGame->mEnemies[1]->mTimeTick + fElapsedTime;
		}
	}

	if (tGame->mEnemies[2]->GetIsActive())
	{
		if (tGame->mEnemies[2]->mTimeTick >= 4.03f)
		{
			tGame->mEnemies[2]->DoFireCircled(tGame->mBulletsEnemyCircled);
			cout << "EnemyAimed Do Fire Circled" << endl;

			tGame->mEnemies[2]->mTimeTick = 0.0f;
		}
		else
		{
			tGame->mEnemies[2]->mTimeTick = tGame->mEnemies[2]->mTimeTick + fElapsedTime;
		}
	}
	else
	{
		if (tGame->mEnemies[2]->mTimeTick >= 2.0f)
		{
			tGame->mEnemies[2]->SetIsActive(true);
		}
		else
		{
			tGame->mEnemies[2]->mTimeTick = tGame->mEnemies[2]->mTimeTick + fElapsedTime;
		}
	}

	for (auto t = tGame->mBullets.begin(); t != tGame->mBullets.end(); ++t)
	{
		(*t)->Update(fElapsedTime);
	}

	for (auto t = tGame->mBulletsEnemy.begin(); t != tGame->mBulletsEnemy.end(); ++t)
	{
		(*t)->Update(fElapsedTime);
	}

	for (auto t = tGame->mBulletsEnemyAimed.begin(); t != tGame->mBulletsEnemyAimed.end(); ++t)
	{
		(*t)->Update(fElapsedTime);
	}

	for (auto t = tGame->mBulletsEnemyCircled.begin(); t != tGame->mBulletsEnemyCircled.end(); ++t)
	{
		(*t)->Update(fElapsedTime);
	}

	//render
	tGame->Clear(olc::VERY_DARK_BLUE);

	if ((int)(mPlayerMortalTime * 10.0f) % 2 == 0)
	{
		tGame->mActor->Render(tGame);
	}
	tGame->mEnemies[0]->Render(tGame);
	tGame->mEnemies[1]->Render(tGame);
	tGame->mEnemies[2]->Render(tGame);

	for (vector<CBullet*>::iterator t = tGame->mBullets.begin(); t != tGame->mBullets.end(); ++t)
	{
		(*t)->Render(tGame);
	}

	for (auto t = tGame->mBulletsEnemy.begin(); t != tGame->mBulletsEnemy.end(); ++t)
	{
		(*t)->Render(tGame);
	}

	for (auto t = tGame->mBulletsEnemyAimed.begin(); t != tGame->mBulletsEnemyAimed.end(); ++t)
	{
		(*t)->Render(tGame);
	}

	for (auto t = tGame->mBulletsEnemyCircled.begin(); t != tGame->mBulletsEnemyCircled.end(); ++t)
	{
		(*t)->Render(tGame);
	}

	//남은 동전 수 출력
	char tTemp[32] = { 0 };
	sprintf_s(tTemp, "Coin: %d", tGame->GetCoinNum());
	tGame->DrawString(0, 0, tTemp);

	//게임 종료 텍스트 출력
	if (mIsGameOver)
	{
		tGame->DrawString(50, 100, "Game Over", olc::WHITE, 5U);
		if (mPlayerMortalTime > 2.0f)
		{
			tGame->SetScene(new CGameOverScene());
			tGame->SceneExecute();

			delete this;
		}
	}
}