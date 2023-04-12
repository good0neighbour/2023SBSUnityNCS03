#include "CGameOverScene.h"
#include "CTitleScene.h"
#include "pgeCircleShootor.h"

void CGameOverScene::Execute()
{
	//점수 기록 확인
	for (mNewPosition = 0; mNewPosition < MAX_RECORD; mNewPosition++)
	{
		if (GAME->GetScoreRecord(mNewPosition) < GAME->GetCurScore())
		{
			for (int tj = MAX_RECORD - 1; tj > mNewPosition; tj--)
			{
				GAME->SetScoreRecord(tj, GAME->GetScoreRecord(tj - 1));
				GAME->SetNameCharacter(tj, GAME->GetNameCharacter(tj - 1, 0), GAME->GetNameCharacter(tj - 1, 1), GAME->GetNameCharacter(tj - 1, 2));
			}
			GAME->SetScoreRecord(mNewPosition, GAME->GetCurScore());
			GAME->SetNameCharacter(mNewPosition, 'A', ' ', ' ');
			mIsNewRecord = true;
			break;
		}
	}
}

void CGameOverScene::Update(float fElapsedTime)
{
	//update
	if (mIsNewRecord)
	{
		if (GAME->GetKey(olc::Key::W).bPressed || GAME->GetKey(olc::Key::UP).bPressed)
		{
			char tNew = GAME->GetNameCharacter(mNewPosition, mCurCursor) + 1;
			if (tNew > 'Z')
			{
				tNew = 'A';
			}
			GAME->SetNameCharacter(mNewPosition, mCurCursor, tNew);
		}
		else if (GAME->GetKey(olc::Key::S).bPressed || GAME->GetKey(olc::Key::DOWN).bPressed)
		{
			char tNew = GAME->GetNameCharacter(mNewPosition, mCurCursor) - 1;
			if (tNew < 'A')
			{
				tNew = 'Z';
			}
			GAME->SetNameCharacter(mNewPosition, mCurCursor, tNew);
		}
		else if (GAME->GetKey(olc::Key::SPACE).bReleased)
		{
			mCurCursor++;
			if (mCurCursor > 2)
			{
				mIsNewRecord = false;
			}
			else
			{
				GAME->SetNameCharacter(mNewPosition, mCurCursor, 'A');
			}
		}
	}
	else if (GAME->GetKey(olc::Key::SPACE).bReleased)
	{
		GAME->SetScene(new CTitleScene());
		GAME->SceneExecute();

		delete this;
		return;
	}


	//render
	GAME->Clear(olc::DARK_GREY);

	//점수 출력
	char tTemp[64] = { 0 };
	for (int ti = 0; ti < MAX_RECORD; ti++)
	{
		sprintf_s(tTemp, "%c%c%c\t%d\n", GAME->GetNameCharacter(ti, 0), GAME->GetNameCharacter(ti, 1), GAME->GetNameCharacter(ti, 2), GAME->GetScoreRecord(ti));
		GAME->DrawString(70, ti * 20 + 50, tTemp, olc::WHITE, 2U);
	}

	//입력 위치 표시용 선분 출력
	if (mIsNewRecord)
	{
		if ((int)(mTimer * 2.0f) % 2 == 0)
		{
			GAME->DrawLine(mCurCursor * 17 + 68, mNewPosition * 20 + 66, mCurCursor * 17 + 82, mNewPosition * 20 + 66);
		}
		mTimer += fElapsedTime;

		//도움말 출력
		GAME->DrawString(58, 200, "Press SpaceBar to confirm.");
	}
	else
	{
		//도움말 출력
		GAME->DrawString(10, 200, "Press SpaceBar to back to title scene.");
	}

}