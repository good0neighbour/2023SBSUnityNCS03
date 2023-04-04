#include "CPlayGameScene.h"
#include "CTitleScene.h"
#include "CEnemy.h"

#include "pgeCircleShootor.h"

void CPlayGameScene::Execute()
{

}
void CPlayGameScene::Update(pgeCircleShootor* tGame, float fElapsedTime)
{
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
						cout << "collision" << endl;
						tEnemy->mTimeTick = 0.0f;
						tEnemy->SetIsActive(false);
						tBullet->SetIsActive(false);

						break;
					}
				}
			}
		}
	}

	olc::vf2d tVelocity(0.0f, 0.0f);
	tGame->mActor->SetVelocity(tVelocity * 0.0f);

	float tXDir = 0.0f;
	float tYDir = 0.0f;

	if (tGame->GetKey(olc::Key::LEFT).bHeld)
	{
		tXDir = -1.0f;
	}

	if (tGame->GetKey(olc::Key::RIGHT).bHeld)
	{
		tXDir = 1.0f;
	}

	if (tGame->GetKey(olc::Key::UP).bHeld)
	{
		tYDir = -1.0f;
	}

	if (tGame->GetKey(olc::Key::DOWN).bHeld)
	{
		tYDir = 1.0f;
	}


	if (tGame->GetKey(olc::Key::SPACE).bReleased)
	{
		tGame->mActor->DoFire(tGame->mBullets);
	}
	if (tGame->GetKey(olc::Key::SPACE).bPressed)
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

	tGame->Clear(olc::VERY_DARK_BLUE);

	tGame->mActor->Render(tGame);
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
}