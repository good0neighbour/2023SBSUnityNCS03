#pragma once

//#include "olcPixelGameEngine.h"
#include "CUnit.h"

#include <vector>	//가변배열 컨테이너
using namespace std;

//클래스 전방선언
//<--컴파일만 일단 통과시켜주기 위해 클래스 이름만 알려준다.
//(<-- 컴파일러는 포인터 변수의 크기를 이미 알고 있기 째문에 가능하다.)
class CBullet;

class CActor: public CUnit	//상속
{
public:
	virtual void Update(float t) override;

	void DoFire(vector<CBullet*> &tBullets);


private:
	int mCurIndexBullet = 0;
};

