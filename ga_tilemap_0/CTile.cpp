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
	//Ÿ���� �ϴ� ������ �簢������ �ܰ��� ǥ���Ѵ�
	//mpEngine->FillRect(mX, mY, mWidth, mHeight, olc::WHITE);
	//mpEngine->DrawRect(mX, mY, mWidth, mHeight, olc::BLACK);


	//step_1
	//
	//����� ������ ��ġ�� �ִ� Ÿ���� x, y��ġ ����
	int tTileXWorld = 0;
	int tTileYWorld = 0;

	//ī�޶��� ��� ��ǥ�� �̿��ϸ� ī�޶��� �ȼ������� ��ǥ�� ���� �� �ִ�.
	//�׸��� 3by3¥�� ����� Ÿ�������� ������ Ÿ���� ī�޶��� ��ġ�κ��� ��������� ��ġ�� ���� �� �ִ�.

	//����󿡼��� ī�޶��� �ȼ������� x��ġ
	// �࿭ ��ǥ --> �ȼ���ǥ�� ��ȯ
	int tCameraXWorld = tCameraColWorld * 32;	//32�� Ÿ�� �ʺ�
	const int CAMERA_X_SCREEN = 1 * 32;	//��ũ�� �󿡼��� ī�޶��� Ģ�������� x��ġ
	int tDiffScreen = mX - CAMERA_X_SCREEN;	//ī�޶�� ������ Ÿ���� x��ġ ����
	//���� �󿡼��� Ÿ���� �ȼ������� x��ġ��
	tTileXWorld = tCameraXWorld + tDiffScreen;


	int tCameraYWorld = tCameraRowWorld * 32;
	const int CAMERA_Y_SCREEN = 1 * 32;	//��ũ�� �󿡼��� ī�޶��� Ģ�������� y��ġ
	tDiffScreen = mY - CAMERA_Y_SCREEN;	//ī�޶�� ������ Ÿ���� Y��ġ ����
	//���� �󿡼��� Ÿ���� �ȼ������� y��ġ��
	tTileYWorld = tCameraYWorld + tDiffScreen;


	//	tileset: Ÿ�� ������ ����
	//	0: �Ͼ�� Ÿ��
	//	1: ������ Ÿ��
	//	2: �Ķ��� Ÿ��
	//	3: ��� Ÿ��

	//��� ��ǥ ������ �� �� ��
	int tRow = 0;
	int tCol = 0;

	//32�� ������ Ÿ���� �ȼ������� �ʺ�, ����
	//�ȼ������� ��ǥ --> ��� ������ ��ǥ�� ��ȯ
	/*tRow = mY / 32;
	tCol = mX / 32;*/
	//���� ��ü ������� ���캸�� ���� ������ �࿭ ��ġ�� ���ϱ� ���ؼ��� ��ü�� ������ �ȼ� ������ Ÿ�� ��ġ ������ �ʿ��ϴ�
	tRow = tTileYWorld / 32;
	tCol = tTileXWorld / 32;

	//������ ��� �� ��ġ�� �Ӽ���(Ÿ�� ����)�� ������ ��
	//Ÿ�� ������ ����
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