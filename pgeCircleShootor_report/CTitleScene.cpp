#include "CTitleScene.h"
#include "pgeCircleShootor.h"

void CTitleScene::Execute()
{

}
void CTitleScene::Update(pgeCircleShootor* tGame, float fElapsedTime)
{
	//스페이스바 키입력이 있으면 플레이 시작
	//<-- SCENE_PLAYGAME으로 장면 전환
	if (tGame->GetKey(olc::Key::SPACE).bReleased)
	{
		//tGame->SetCurSceneType(SCENE_PLAYGAME);
		tGame->SetScene(new CTitleScene());
	}

	//render
	tGame->Clear(olc::YELLOW);
}