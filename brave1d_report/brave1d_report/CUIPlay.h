#pragma once

//�ֿܼ� ����� �޽����� Ű����
enum KeyWords
{
	Initiatiation,
	MoveQuestion,
	NoOneHere,
	SlimeIsHere,
	RollADice,
	BraveHome,
	WorldEnd,
	GameEnd,
	NewUIInstanceCreated,
	UnavailableCommand,
	Experience,
	BraveIsSleeping,
	MoveLeft,
	CantMove,
	MoveRight,
	BraveDamaged,
	SlimeDamaged,
	SlimeTired,
	BraveTired,
	RockScissorsPaper,
	BossIsHere,
	BraveHpUp,
	BraveRockPaperScissors,
	BossRockPaperScissors,
	Draw,
	LanguageChanged
};

//��� ���
enum Languages
{
	Korean,
	English,
	Spanish,
	LanguagesEnd
};

class CUIPlay
{
private:
	Languages mLanguage = Korean;

public:
	//�ֿܼ� ���ڿ� ���
	void Display(KeyWords tKeyWord);
	//���ڿ� ���̿� int�� ���� ���� ���
	void Display(KeyWords tKeyWord, int tValue);
	//���ڿ� ���̿� char�� ���� ���� ���
	void Display(KeyWords tKeyWord, char tValue);

	//�߰�ȣ�� �ִ� ���ڿ��� ���, �߰�ȣ �������� ��, �ĸ� �и��ϱ� ���� �Լ�
	//���ڿ��� �����͸� �Ű������� �ޱ� ���� �������� �����͸� ���
	void StringSearch(const char* tMessage, char** tFrontOutput, char** tBackOutput);

	//main ��ũ��Ʈ�� ���̻� iostream�� ������ �ʿ䰡 ������ ���� �Էµ� �� �Լ��� ���� �ǽ��Ѵ�.
	//main ��ũ��Ʈ�� �ణ �� ������� ���̴�.
	char InputFromUser();

	void NextLanguage();

private:
	//Ű���带 �����ϸ� �޽����� ��ȯ�ϴ� �Լ�
	//public�� �ʿ䰡 ��� ����ȭ�ߴ�.
	const char* GetText(KeyWords tKeyWord);
};

