#pragma once

#include "olcPixelGameEngine.h"
#include "config.h"

class CTile
{
public:
	//��ũ�� �� �ش� Ÿ���� ǥ�õ� ��ġ, �ȼ�����
	int mX = 0;
	int mY = 0;

	//�ش� Ÿ���� �ʺ�, ����
	int mWidth = 0;
	int mHeight = 0;

	//���� ���� ����
	olc::PixelGameEngine* mpEngine = nullptr;

public:
	void Create(int tX, int tY, int tWidth = 32, int tHeight = 32);
	void Destroy();

	void Update();
	void Render(int tGrid[][TOTAL_GRID_W], int tX, int tY);

	void SetEngine(olc::PixelGameEngine* tpEngine);


};

