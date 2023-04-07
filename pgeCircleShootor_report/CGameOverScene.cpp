#include "CGameOverScene.h"
#include "pgeCircleShootor.h"

void CGameOverScene::Execute()
{

}

void CGameOverScene::Update(pgeCircleShootor* tGame, float fElapsedTime)
{
	//render
	tGame->Clear(olc::DARK_YELLOW);
	tGame->DrawString(70, 100, "asdf");
}