#pragma once

//����� ����
//�̰����� ������� �Է��� �����Ѵ�.
enum Status
{
	Move,
	Combat,
	BossCombat,
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
