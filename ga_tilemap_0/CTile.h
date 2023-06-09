#pragma once

#include "olcPixelGameEngine.h"
#include "config.h"

/*
	타일의 크기는 32by32pixel로 가정한다
*/

class CTile
{
public:
	//스크린 상에 해당 타일이 표시될 위치, 픽셀단위
	int mX = 0;
	int mY = 0;

	//해당 타일의 너비, 높이
	int mWidth = 0;
	int mHeight = 0;

	//엔진 참조 변수
	olc::PixelGameEngine* mpEngine = nullptr;

public:
	void Create(int tX, int tY, int tWidth = 32, int tHeight = 32);
	void Destroy();

	void Update();
	void Render(int tWorldGrid[][TOTAL_GRID_W], int tCameraColWorld, int tCameraRowWorld);

	void SetEngine(olc::PixelGameEngine* tpEngine);


};

