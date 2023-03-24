#pragma once

//#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"
#include "CActor.h"
#include "CBullet.h"

#include <vector>	//�����迭 �����̳�
using namespace std;

//C���: ����ȭ ���α׷���: ����ȭ
//C++���: ��ü���� ���α׷���: ����
//�Ϲ�ȭ ���α׷���: Ÿ���� �Ű�����ó�� �ٷ�� ���

//C++�� STL Standard Template Library
//<-- �ڷᱸ��, �˰����� �Ϲ�ȭ���� �������� ��
/*
	STL�� ������� 3����

	i) �����̳� <-- �ڷᱸ���� �Ϲ�ȭ
	ii) �ݺ��� <-- �����̳ʿ� �˰���� �Բ� ��� ������ �Ϲ�ȭ�� ������
	iii) �˰��� <-- �˰����� �Ϲ�ȭ
*/


class pgeCircleShootor : public olc::PixelGameEngine
{
	//float mActorX = 0.0f;
	//float mActorY = 0.0f;
	CActor* mActor = nullptr;

	//źȯ ������
	vector<CBullet*> mBullets;


public:
	pgeCircleShootor()
	{
		// Name your application
		sAppName = "pgeCircleShootor";
	}

public:
	bool OnUserCreate() override;
	bool OnUserDestroy() override;
	bool OnUserUpdate(float fElapsedTime) override;


	//���� �׸��� �Լ�
	//������ ����� ���� �׸���( �������� �̿��� ���)�� �� ���̴�
	//���� �׸��⿡ ���� �������� �˰���
	void DrawLineEquation(int tX_0, int tY_0, int tX_1, int tY_1);
	//�� �׸��� �Լ�
	//������ ����� ���� �׸���( �������� �̿��� ���)�� �� ���̴�
	//���� �׸��⿡ ���� �������� �˰���
	void DrawCircleEquation(int tXCenter, int tYCenter, int tRadius, olc::Pixel tColor = olc::WHITE); //�Ű����� �⺻��
};