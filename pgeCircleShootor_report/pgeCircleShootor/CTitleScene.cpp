#include "CTitleScene.h"
#include "CPlayGameScene.h"
#include "pgeCircleShootor.h"

void CTitleScene::Execute()
{

}
void CTitleScene::Update(float fElapsedTime)
{
	//사용자의 키 입력
	if (GAME->GetKey(olc::Key::C).bPressed)
	{
		GAME->CoinInsert();
	}
	else if (GAME->GetKey(olc::Key::SPACE).bReleased)
	{
		GAME->SetScene(new CPlayGameScene());
		GAME->SceneExecute();

		delete this;
		return;
	}

	//시간 경과에 따른 글자 출력 여부
	if (mTime >= 0.7f)
	{
		mDisplay = !mDisplay;
		mTime -= 0.7f;
	}
	else
	{
		mTime += fElapsedTime;
	}

	//render
	GAME->Clear(olc::DARK_YELLOW);
	if (mDisplay)
	{
		GAME->DrawString(70, 100, "Press C to insert coin.\nPress SpaceBar to Start.");
	}

	char tTemp[32] = { 0 };
	sprintf_s(tTemp, "Coin: %d", GAME->GetCoinNum());
	GAME->DrawString(130, 200, tTemp);
}