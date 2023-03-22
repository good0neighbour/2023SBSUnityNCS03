#pragma once

//용사의 상태
//이것으로 사용자의 입력을 제한한다.
enum Status
{
	Move,
	Attack,
	Down
};

class CRyuMgr
{
private:
	static CRyuMgr* mpInstance;

public:
	//용사의 현 상태
	enum Status mStatus;

private:
	CRyuMgr();
	~CRyuMgr();

public:
	static CRyuMgr* GetInstance();
	static void ReleaseInstance();

public:
	int mExp = 0;
};

