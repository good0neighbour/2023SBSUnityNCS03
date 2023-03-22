#pragma once

//����� ����
//�̰����� ������� �Է��� �����Ѵ�.
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
	//����� �� ����
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

