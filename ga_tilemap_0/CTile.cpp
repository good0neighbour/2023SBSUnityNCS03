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

void CTile::Update()
{

}
void CTile::Render(int tWorldGrid[][TOTAL_GRID_W], int tCameraColWorld, int tCameraRowWorld)
{
	//step_0
	//타일은 일단 임의의 사각형으로 외관을 표시한다
	//mpEngine->FillRect(mX, mY, mWidth, mHeight, olc::WHITE);
	//mpEngine->DrawRect(mX, mY, mWidth, mHeight, olc::BLACK);


	//step_1
	//
	//월드상에 임의의 위치에 있는 타일의 x, y위치 정보
	int tTileXWorld = 0;
	int tTileYWorld = 0;

	//카메라의 행렬 좌표를 이용하면 카메라의 픽셀단위의 좌표를 구할 수 있다.
	//그리고 3by3짜리 덩어리인 타일집합의 각각의 타일은 카메라의 위치로부터 상대적으로 위치를 구할 수 있다.

	//월드상에서의 카메라의 픽셀단위의 x위치
	// 행열 좌표 --> 픽셀좌표로 변환
	int tCameraXWorld = tCameraColWorld * 32;	//32는 타일 너비
	const int CAMERA_X_SCREEN = 1 * 32;	//스크린 상에서의 카메라의 칙셀단위의 x위치
	int tDiffScreen = mX - CAMERA_X_SCREEN;	//카메라와 임의의 타일의 x위치 차이
	//월드 상에서의 타일의 픽셀단위의 x위치값
	tTileXWorld = tCameraXWorld + tDiffScreen;


	int tCameraYWorld = tCameraRowWorld * 32;
	const int CAMERA_Y_SCREEN = 1 * 32;	//스크린 상에서의 카메라의 칙셀단위의 y위치
	tDiffScreen = mY - CAMERA_Y_SCREEN;	//카메라와 임의의 타일의 Y위치 차이
	//월드 상에서의 타일의 픽셀단위의 y위치값
	tTileYWorld = tCameraYWorld + tDiffScreen;


	//	tileset: 타일 종류의 모음
	//	0: 하얀색 타일
	//	1: 빨간색 타일
	//	2: 파란색 타일
	//	3: 녹색 타일

	//행렬 좌표 기준의 행 열 값
	int tRow = 0;
	int tCol = 0;

	//32는 임의의 타일의 픽셀단위의 너비, 높이
	//픽셀단위의 좌표 --> 행렬 단위의 좌표로 변환
	/*tRow = mY / 32;
	tCol = mX / 32;*/
	//이제 전체 월드맵을 살펴보기 위해 임의의 행열 위치를 수하기 위해서는 전체맵 기준의 픽셀 단위의 타일 위치 정보가 필요하다
	tRow = tTileYWorld / 32;
	tCol = tTileXWorld / 32;

	//임의의 행과 열 위치의 속성값(타일 종류)을 얻으려 함
	//타일 종류를 구함
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