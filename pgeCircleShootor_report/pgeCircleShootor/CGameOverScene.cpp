#include "CGameOverScene.h"
#include "pgeCircleShootor.h"

void CGameOverScene::Execute()
{

}

void CGameOverScene::Update(float fElapsedTime)
{
	//render
	GAME->Clear(olc::DARK_GREY);

	//점수 출력
	char tTemp[64] = { 0 };
	for (int ti = 0; ti < 5; ti++)
	{
		sprintf_s(tTemp, "%c%c%c\t%d\n", GAME->GetNameCharacter(ti, 0), GAME->GetNameCharacter(ti, 1), GAME->GetNameCharacter(ti, 2), GAME->GetScoreRecord(ti));
		GAME->DrawString(70, ti * 20 + 50, tTemp, olc::WHITE, 2U);
	}
}