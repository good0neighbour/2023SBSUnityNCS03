#include "CTitleScene.h"
#include "pgeCircleShootor.h"

void CTitleScene::Execute()
{

}
void CTitleScene::Update(pgeCircleShootor* tGame, float fElapsedTime)
{
	//�����̽��� Ű�Է��� ������ �÷��� ����
	//<-- SCENE_PLAYGAME���� ��� ��ȯ
	if (tGame->GetKey(olc::Key::SPACE).bReleased)
	{
		//tGame->SetCurSceneType(SCENE_PLAYGAME);
		tGame->SetScene(new CTitleScene());
	}

	//render
	tGame->Clear(olc::YELLOW);
}