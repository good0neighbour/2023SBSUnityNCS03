#pragma once

//Ŭ���� ���� ����
class CBrave;

//����� �Է��� �����ϴ� Ŭ����
class CInputMgr
{
private:
	//���� �� �ν��Ͻ��� �ʿ��ϱ� ������ �̱��� ���� ����
	static CInputMgr* mInstance;

private:
	//�ܺο��� ���Ƿ� ��ü �����ϴ� ���� �����ϱ� ���� �����ڸ� ����ȭ
	CInputMgr();
	//������ ����ȭ�� ���ϼ��� ���߱� ���� �Ҹ��ڵ� ����ȭ
	~CInputMgr();

public:
	//������� Ű���� �Է¿� ���� ó���� �߻�ȭ
	//���� ���� ���� ���θ� �����ϱ� ���� bool�� ��ȯ
	bool KeyInput(char tMoveDir, CBrave* tBrave);
	//�ν��Ͻ��� �����ϰ� ���� �Լ�
	static CInputMgr* GetInstance();
	//�ν��Ͻ� ���� �Լ�
	static void ReleaseInstance();
};

