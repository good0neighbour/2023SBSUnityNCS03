#pragma once

//Ŭ���� ���� ����
class CBrave;
class CSlime;
class CUIPlay;

//����� �Է��� �����ϴ� Ŭ����
class CInputMgr
{
private:
	//���� �� �ν��Ͻ��� �ʿ��ϱ� ������ �̱��� ���� ����
	static CInputMgr* mInstance;
	//main ��ũ��Ʈ�κ��� �ܼ� ǥ�ÿ� ��ü�� �����ؿ��� ����
	CUIPlay* mUI;

private:
	//�ܺο��� ���Ƿ� ��ü �����ϴ� ���� �����ϱ� ���� �����ڸ� ����ȭ
	//�ܼ� ǥ�ÿ� Ŭ������ ���� �������� �ʱ� ���� ������ �ִ� ���� tUI�� ����
	CInputMgr(CUIPlay* tUI);
	//������ ����ȭ�� ���ϼ��� ���߱� ���� �Ҹ��ڵ� ����ȭ
	~CInputMgr();

public:
	//������� Ű���� �Է¿� ���� ó���� �߻�ȭ
	//���� ���� ���� ���θ� �����ϱ� ���� bool�� ��ȯ
	bool KeyInput(char tMoveDir, CBrave* tBrave);
	//���� ���� �Լ�
	//�Ű������� �� �ʿ��ؼ� �Լ��� �����ε��Ѵ�.
	bool KeyInput(char tMoveDir, CBrave* tBrave, CSlime* tSlime);
	//ó�� ������ �ݵ�� ȣ���� ��, �����ε�
	static CInputMgr* GetInstance(CUIPlay* tUI);
	//�ν��Ͻ��� �����ϰ� ���� �Լ�
	static CInputMgr* GetInstance();
	//�ν��Ͻ� ���� �Լ�
	static void ReleaseInstance();
};

