#include "CTitleScene.h"
#include "CPlayGameScene.h"
#include "pgeCircleShootor.h"

void CTitleScene::Execute()
{

}
void CTitleScene::Update(pgeCircleShootor* tGame, float fElapsedTime)
{
	//사용자의 키 입력
	if (tGame->GetKey(olc::Key::C).bPressed)
	{
		tGame->CoinInsert();
	}
	else if (tGame->GetKey(olc::Key::SPACE).bReleased)
	{
		tGame->SetScene(new CPlayGameScene());
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
	tGame->Clear(olc::DARK_YELLOW);
	if (mDisplay)
	{
		tGame->DrawString(70, 100, "Press C to insert coin.\nPress SpaceBar to Start.");
	}

	char tTemp[32] = { 0 };
	sprintf_s(tTemp, "Coin: %d", tGame->GetCoinNum());
	tGame->DrawString(130, 200, tTemp);
}