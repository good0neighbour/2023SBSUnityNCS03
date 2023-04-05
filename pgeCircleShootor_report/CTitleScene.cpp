#include "CTitleScene.h"
#include "CPlayGameScene.h"
#include "pgeCircleShootor.h"

void CTitleScene::Execute()
{

}
void CTitleScene::Update(pgeCircleShootor* tGame, float fElapsedTime)
{
	//������� Ű �Է�
	if (tGame->GetKey(olc::Key::C).bPressed)
	{
		tGame->CoinInsert();
	}
	else if (tGame->GetKey(olc::Key::SPACE).bReleased)
	{
		tGame->SetScene(new CPlayGameScene());
	}

	//�ð� ����� ���� ���� ��� ����
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