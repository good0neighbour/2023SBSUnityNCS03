#pragma once

//#include "olcPixelGameEngine.h"
#include "CUnit.h"

#include <vector>	//�����迭 �����̳�
using namespace std;

//Ŭ���� ���漱��
//<--�����ϸ� �ϴ� ��������ֱ� ���� Ŭ���� �̸��� �˷��ش�.
//(<-- �����Ϸ��� ������ ������ ũ�⸦ �̹� �˰� �ֱ� °���� �����ϴ�.)
class CBullet;

class CActor: public CUnit	//���
{
public:
	virtual void Update(float t) override;

	void DoFire(vector<CBullet*> &tBullets);


private:
	int mCurIndexBullet = 0;
};

