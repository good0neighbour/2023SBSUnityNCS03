#include "CTile.h"


void CTile::Create(int tX, int tY, int tWidth, int tHeight)
{
	mX = tX;
	mY = tY;

	mWidth = tWidth;
	mHeight = tHeight;
}
void CTile::Destroy()
{

}

void CTile::Update(float t)
{
	if (mTileXWorld <= -32.0f * (9 - 1))
	{
		//월드의 오른쪽 경계에 다다르면 스크롤 멈춤
		//<--- 타일 하나는 항상 보여야 하므로 -32.0f * (9 - 1)
		mTileXWorld = -32.0f * (9 - 1);
	}
	else
	{
		//다음 두 가지는 동일하게 스크롤값 갱신
		//
		//월드 좌표 갱신
		mTileXWorld = mTileXWorld - 20.0f * t;
		//스크린 좌표 갱신
		mX = mX - 20.0f * t;

		//스크린상에 표시되는 타일은 두 개므로
		//저글링( 무한스크롤에서 사용했던 방법 )
		if (mX <= -32.0f)
		{
			mX = 0 + 32.0f;

			std::cout << "juggling time" << std::endl;
		}
	}

}
void CTile::Render(int tWorldGrid[][TOTAL_GRID_W], int tCameraColWorld, int tCameraRowWorld)
{
	//보정
	float tX = -1.0f * mTileXWorld + mX + 0.5f;


	int tRow = 0;
	int tCol = 0;
	tRow = mTileYWorld / 32;
	//tCol = mTileXWorld / 32;
	tCol = tX / 32;



	char szTemp[256] = { 0 };
	sprintf_s(szTemp, "mTileXWorld: %f, mX: %f, tX: %f", mTileXWorld, mX, tX);

	std::string tString = szTemp;
	mpEngine->DrawString(0, 200, tString);


	int tAttrib = tWorldGrid[tRow][tCol];
	switch (tAttrib)
	{
	case 0:
	{
		mpEngine->FillRect(mX, mY, mWidth, mHeight, olc::WHITE);
		mpEngine->DrawRect(mX, mY, mWidth, mHeight, olc::BLACK);
	}
	break;
	case 1:
	{
		mpEngine->FillRect(mX, mY, mWidth, mHeight, olc::RED);
		mpEngine->DrawRect(mX, mY, mWidth, mHeight, olc::BLACK);
	}
	break;
	case 2:
	{
		mpEngine->FillRect(mX, mY, mWidth, mHeight, olc::BLUE);
		mpEngine->DrawRect(mX, mY, mWidth, mHeight, olc::BLACK);
	}
	break;
	case 3:
	{
		mpEngine->FillRect(mX, mY, mWidth, mHeight, olc::GREEN);
		mpEngine->DrawRect(mX, mY, mWidth, mHeight, olc::BLACK);
	}
	break;
	}


}

void CTile::SetEngine(olc::PixelGameEngine* tpEngine)
{
	mpEngine = tpEngine;
}