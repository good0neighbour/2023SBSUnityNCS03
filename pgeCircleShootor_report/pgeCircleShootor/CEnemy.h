#pragma once
#include "CUnit.h"

#include <vector>
using namespace std;

class CBullet;

class CEnemy :
    public CUnit
{
public:
	virtual void Update(float t) override;
	
	void DoFire(vector<CBullet*>& tBullets);
	void DoFireAimed(vector<CBullet*>& tBullets, CUnit* tpTarget);
	void DoFireCircled(vector<CBullet*>& tBullets);


private:
	int mCurIndexBullet = 0;

public:
	//delta Time 누적 결과값
	float mTimeTick = 0.0f;
};

