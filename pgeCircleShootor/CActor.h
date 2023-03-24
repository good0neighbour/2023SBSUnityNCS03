#pragma once

//#include "olcPixelGameEngine.h"
#include "CUnit.h"

#include <vector>	//가변배열 컨테이너
using namespace std;

//클래스 전방선언
class CBullet;

class CActor: public CUnit	//상속
{
public:
	void DoFire(vector<CBullet*> &tBullets);
};

