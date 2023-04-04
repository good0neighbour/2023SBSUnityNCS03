#include "CTitleScene.h"
#include "CPlayGameScene.h"
#include "pgeCircleShootor.h"

void CTitleScene::Execute()
{

}
void CTitleScene::Update(pgeCircleShootor* tGame, float fElapsedTime)
{
	if (tGame->GetKey(olc::Key::SPACE).bReleased)
	{
		tGame->SetScene(new CPlayGameScene());
	}

	tGame->Clear(olc::YELLOW);
}