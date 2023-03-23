#pragma once


//#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"

#include "CActor.h"

class pgeCircleShootor : public olc::PixelGameEngine
{
	//float mActorX = 0.0f;
	//float mActorY = 0.0f;

	CActor mActor;


public:
	pgeCircleShootor()
	{
		// Name your application
		sAppName = "pgeCircleShootor";
	}

public:
	bool OnUserCreate() override
	{
		// Called once at the start, so create things here

		//���ΰ� ��ü�� �ʱ���ġ ����
		/*mActor.mPosition.x = ScreenWidth() * 0.5f;
		mActor.mPosition.y = ScreenHeight() * 0.5f + 80.0f;*/
		mActor.SetPosition(ScreenWidth() * 0.5f, ScreenHeight() * 0.5f + 80.0f);


		return true;
	}
	bool OnUserDestroy() override
	{
		//todo

		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{

		olc::vf2d tVelocity(0.0f, 0.0f);
		mActor.SetVelocity(tVelocity * 0.0f);

		float tXDir = 0.0f;	//x�� �Է�
		float tYDir = 0.0f;	//y�� �Է�

		//input
		// ���Է� ������� ����
		//���� ����Ű�� ������ �ִ� ���̶��
		if (GetKey(olc::Key::LEFT).bHeld)
		{
			//std::cout << "dir.left" << std::endl;

			//���Ϸ� ������ ����� ���� �̵��ڵ�
			/*
				�ӵ� * �Ÿ��� ��ȭ�� / �ð��� ��ȭ��

				�ӵ��� ���Ƿκ��� ���� ���� �����ߴ�

				//���� ��ġ = ���� ��ġ + �ӵ� * �ð�����

				���Ѽ� ���信 ���� ������ �������Ƿ�(�ҿ���), ���п� ���� ������ٴ� ����Ȯ�ϴ�.
			*/

			//���� ��ġ = ���� ��ġ + �ӵ� * �ð�����
			//mActorX = mActorX - 0.01f * 1.0f;	//������ ��� ����
			//mActor.mActorX = mActor.mActorX - 50.0f * fElapsedTime;	//�ð� ��� ����. fElapsedTime: �� �����ӿ� �ɸ� �ð�

			//mActor.DoMoveX(-50.0f, fElapsedTime);
			//olc::vf2d tVelocity(-1.0f, 0.0f);	//�ӵ��� ����( �������ͷ� ������ )
			//mActor.SetVelocity(tVelocity * 50.0f);
			//mActor.Update(fElapsedTime);	//������ ��Į�����

			tXDir = -1.0f;
		}

		if (GetKey(olc::Key::RIGHT).bHeld)
		{
			//std::cout << "dir.right" << std::endl;
			//mActor.mPosition.x = mActor.mPosition.x + 50.0f * fElapsedTime;
			//olc::vf2d tVelocity(1.0f, 0.0f);
			//mActor.SetVelocity(tVelocity * 50.0f);
			//mActor.Update(fElapsedTime);

			tXDir = 1.0f;
		}

		if (GetKey(olc::Key::UP).bHeld)
		{
			//std::cout << "dir.up" << std::endl;
			//mActor.mPosition.y = mActor.mPosition.y - 50.0f * fElapsedTime;
			//olc::vf2d tVelocity(0.0f, -1.0f);
			//mActor.SetVelocity(tVelocity * 50.0f);
			//mActor.Update(fElapsedTime);

			tYDir = -1.0f;
		}

		if (GetKey(olc::Key::DOWN).bHeld)
		{
			//std::cout << "dir.down" << std::endl;
			//mActor.mPosition.y = mActor.mPosition.y + 50.0f * fElapsedTime;
			//olc::vf2d tVelocity(0.0f, 1.0f);
			//mActor.SetVelocity(tVelocity * 50.0f);
			//mActor.Update(fElapsedTime);

			tYDir = 1.0f;
		}

		olc::vf2d tXVelocity(1.0f, 0.0f);	//x�� �������ͷ� �ʱ�ȭ
		olc::vf2d tYVelocity(0.0f, 1.0f);	//y�� �������ͷ� �ʱ�ȭ

		tXVelocity = tXVelocity * tXDir;	//x�� ���� ����	������ ��Į�����
		tYVelocity = tYVelocity * tYDir;	//y�� ���� ����	������ ��Į�����


		tVelocity = tXVelocity + tYVelocity;	//������ ũ��� 2D����	���ͳ����� ����
		if (tVelocity.mag() > 0.0f)										//������ ũ��
		{
			tVelocity = tVelocity.norm();			//������ ����ȭ, ũ�⸦ 1�� �����
		}

		mActor.SetVelocity(tVelocity * 50.0f);		//	������ ��Į�����

		mActor.Update(fElapsedTime);

		//update


		//render
		this->Clear(olc::VERY_DARK_BLUE);

		//DrawLineEquation(0, 0, 100, 100);	//���� 100 / 100
		//DrawLineEquation(0, 0, 100, 25);	//���� 25 / 100
		//DrawLineEquation(0, 0, 25, 100);	//���� 100 / 25
		//DrawLineEquation(100, 100, 100 + 25, 100 - 100);	//���� -100 / 25
		//DrawLineEquation(100, 100, 100 + 100, 100 + 0);	//���� 0 / 100
		//DrawLineEquation(100, 100, 100 + 0, 100 + 100);		//���� 100 / 0
		//DrawCircleEquation(0 + 100, 0 + 100, 20, olc::WHITE);

		//void Render(PixelGameEngine*)
		//DrawCircleEquation(mActor.mPosition.x, mActor.mPosition.y, 20.0f);
		mActor.Render(this);


		return true;
	}

	//���� �׸��� �Լ�
	//������ ����� ���� �׸���( �������� �̿��� ���)�� �� ���̴�
	//���� �׸��⿡ ���� �������� �˰���
	void DrawLineEquation(int tX_0, int tY_0, int tX_1, int tY_1);

	//�� �׸��� �Լ�
	//������ ����� ���� �׸���( �������� �̿��� ���)�� �� ���̴�
	//���� �׸��⿡ ���� �������� �˰���
	void DrawCircleEquation(int tXCenter, int tYCenter, int tRadius, olc::Pixel tColor = olc::WHITE); //�Ű����� �⺻��
};