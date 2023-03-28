#pragma once

//#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"
#include "CActor.h"
#include "CBullet.h"

#include <vector>	//�����迭 �����̳�
using namespace std;

class CEnemy;

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

//�Ϲ�źȯ: ���۽ÿ� ������ ���س��� ���� źȯ
//����źȯ: �������������� ������ ���� �߿� �����Ͽ� �߻��ϴ� źȯ
//����źȯ: 45�� �������� ���� �׸��� �������� ������ �����Ͽ� �߻��ϴ� źȯ, 8���� ���ÿ� �߻��ϰڴ�


//������: �ش� Ÿ���� ���� �� �ִ� ������ �����س��� Ÿ��
//����� ����
enum
{
	SCENE_TITLE = 0,
	SCENE_PLAYGAME
};




class pgeCircleShootor : public olc::PixelGameEngine
{
	int mCurSceneType = SCENE_TITLE;

	CActor* mActor = nullptr;
	CEnemy* mEnemy = nullptr;

	CEnemy* mEnemyAimed = nullptr;
	//����ź �߻� ��
	CEnemy* mEnemyCircled = nullptr;

	//źȯ ������
	vector<CBullet*> mBullets;	//���ΰ��� �Ϲ�źȯ
	vector<CBullet*> mBulletsEnemy;	//���� �Ϲ�źȯ
	vector<CBullet*> mBulletsEnemyAimed;	//���� ����źȯ
	vector<CBullet*> mBulletsEnemyCircled;	//���� ����źȯ


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

	void UpdateTitle(float fElapsedTime);
	void UpdatePlayGame(float fElapsedTime);


	//���� �׸��� �Լ�
	//������ ����� ���� �׸���( �������� �̿��� ���)�� �� ���̴�
	//���� �׸��⿡ ���� �������� �˰���
	void DrawLineEquation(int tX_0, int tY_0, int tX_1, int tY_1);
	//�� �׸��� �Լ�
	//������ ����� ���� �׸���( �������� �̿��� ���)�� �� ���̴�
	//���� �׸��⿡ ���� �������� �˰���
	void DrawCircleEquation(int tXCenter, int tYCenter, int tRadius, olc::Pixel tColor = olc::WHITE); //�Ű����� �⺻��
};