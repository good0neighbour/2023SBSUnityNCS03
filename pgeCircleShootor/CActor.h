#pragma once

//#include "olcPixelGameEngine.h"
#include "CUnit.h"

#include <vector>	//�����迭 �����̳�
using namespace std;

//Ŭ���� ���漱��
class CBullet;

class CActor: public CUnit	//���
{
public:
	void DoFire(vector<CBullet*> &tBullets);
};

