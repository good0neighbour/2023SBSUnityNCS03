#pragma once

#include "olcPixelGameEngine.h"
#include "config.h"

/*
	Ÿ���� ũ��� 32by32pixel�� �����Ѵ�
*/

class CTile
{
public:
	//��ũ�� �� �ش� Ÿ���� ǥ�õ� ��ġ, �ȼ�����
	float mX = 0.0f;
	float mY = 0.0f;

	//�ش� Ÿ���� �ʺ�, ����
	int mWidth = 0;
	int mHeight = 0;


	//����󿡼��� �ش� Ÿ���� ��ġ, �ȼ�����
	float mTileXWorld = 0.0f;
	float mTileYWorld = 0.0f;

	//���� ���� ����
	olc::PixelGameEngine* mpEngine = nullptr;

public:
	void Create(int tX, int tY, int tWidth = 32, int tHeight = 32);
	void Destroy();

	void Update(float t);
	void Render(int tWorldGrid[][TOTAL_GRID_W], int tCameraColWorld, int tCameraRowWorld);

	void SetEngine(olc::PixelGameEngine* tpEngine);


};

