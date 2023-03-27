#pragma once

//콘솔에 출력할 메시지의 키워드
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

//언어 목록
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
	//콘솔에 문자열 출력
	void Display(KeyWords tKeyWord);
	//문자열 사이에 int형 값을 끼워 출력
	void Display(KeyWords tKeyWord, int tValue);
	//문자열 사이에 char형 값을 끼워 출력
	void Display(KeyWords tKeyWord, char tValue);

	//중괄호가 있는 문자열의 경우, 중괄호 기준으로 전, 후를 분리하기 위한 함수
	//문자열의 포인터를 매개변수로 받기 위해 포인터의 포인터를 사용
	void StringSearch(const char* tMessage, char** tFrontOutput, char** tBackOutput);

	//main 스크립트가 더이상 iostream을 포함할 필요가 없도록 문자 입력도 이 함수를 통해 실시한다.
	//main 스크립트는 약간 더 깔끔해질 것이다.
	char InputFromUser();

	void NextLanguage();

private:
	//키워드를 전달하면 메시지를 반환하는 함수
	//public일 필요가 없어서 은닉화했다.
	const char* GetText(KeyWords tKeyWord);
};

