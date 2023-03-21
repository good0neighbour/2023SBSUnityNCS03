#pragma once


//����� �÷��� �����͸� �����ϴ� �Ŵ��� ������ Ŭ����

/*
	������ �� ���� ������ �����Ͽ� �����

	i) static�� ������ �ش� Ŭ���� Ÿ���� ������ ���� mpInstance�� �����.
	ii) �����ڴ� public�� �ƴϴ�
	iii) GetInstance() �Լ��� ���ǿ��� ��ü�� �ִ���������� 1���� ���Ѵٴ� �Ǵ�������� ��ġ�Ѵ�.
*/

class CRyuMgr
{
private:
	static CRyuMgr* mpInstance;// = nullptr;

	//�ܺο����� ���� ǥ���� ���´�
private:
	CRyuMgr();
	~CRyuMgr();

public:
	//static���� �����Ͽ����Ƿ� ǥ��������δ� ����Լ�����, �����Լ��� ������ ������
	static CRyuMgr* GetInstance();
	static void ReleaseInstance();


public:
	//����� ����ġ
	int mExp = 0;
};

