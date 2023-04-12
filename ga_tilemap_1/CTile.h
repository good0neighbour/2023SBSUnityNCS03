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
	float mX = 0.0f;
	float mY = 0.0f;

	//해당 타일의 너비, 높이
	int mWidth = 0;
	int mHeight = 0;


	//월드상에서의 해당 타일의 위치, 픽셀단위
	float mTileXWorld = 0.0f;
	float mTileYWorld = 0.0f;

	//엔진 참조 변수
	olc::PixelGameEngine* mpEngine = nullptr;

public:
	void Create(int tX, int tY, int tWidth = 32, int tHeight = 32);
	void Destroy();

	void Update(float t);
	void Render(int tWorldGrid[][TOTAL_GRID_W], int tCameraColWorld, int tCameraRowWorld);

	void SetEngine(olc::PixelGameEngine* tpEngine);


};

