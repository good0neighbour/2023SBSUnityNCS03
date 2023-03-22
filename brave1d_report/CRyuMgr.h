#pragma once

class CRyuMgr
{
private:
	static CRyuMgr* mpInstance;

private:
	CRyuMgr();
	~CRyuMgr();

public:
	static CRyuMgr* GetInstance();
	static void ReleaseInstance();

public:
	int mExp = 0;
};

