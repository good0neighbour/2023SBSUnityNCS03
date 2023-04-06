#pragma once

#include "CUnit.h"

#include <vector>
using namespace std;

class CBullet;

class CActor: public CUnit	//»ó¼Ó
{
private:
	int mCurIndexBullet = 0;

public:
	virtual void Update(float t) override;
	void DoFire(vector<CBullet*> &tBullets);
};

