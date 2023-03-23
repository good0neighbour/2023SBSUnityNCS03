#include "CUIPlay.h"
#include "CRyuMgr.h"

#include <iostream>

using namespace std;

//반복되는 코드는 매크로로 대체
#define DISPLAY_PROCESS \
char* tFrontOutput = nullptr;\
char* tBackOutput = nullptr;\
StringSearch(GetText(tKeyWord), &tFrontOutput, &tBackOutput);\
cout << tFrontOutput << tValue << tBackOutput << endl;\
delete[] tFrontOutput;\
delete[] tBackOutput;

void CUIPlay::Display(KeyWords tKeyWord)
{
	//콘솔창에 문자열 출력
	cout << GetText(tKeyWord) << endl;
}
void CUIPlay::Display(KeyWords tKeyWord, int tValue)
{
	//매크로 사용
	//DISPLAY_PROCESS
	char* tFrontOutput = nullptr;
	char* tBackOutput = nullptr;

	StringSearch(GetText(tKeyWord), &tFrontOutput, &tBackOutput);
	cout << tFrontOutput << tValue << tBackOutput << endl;

	delete[] tFrontOutput;
	delete[] tBackOutput;
}
void CUIPlay::Display(KeyWords tKeyWord, char tValue)
{
	//매크로 사용
	//DISPLAY_PROCESS
	char* tFrontOutput = nullptr;
	char* tBackOutput = nullptr;

	StringSearch(GetText(tKeyWord), &tFrontOutput, &tBackOutput);
	cout << tFrontOutput << tValue << tBackOutput << endl;

	delete[] tFrontOutput;
	delete[] tBackOutput;
}

void CUIPlay::StringSearch(const char* tMessage, char** tFrontOutput, char** tBackOutput)
{
	//입력받은 문자열을 탐색하기 위함
	int ti = 0;
	//중괄호 이전의 문자 개수
	int tFrontIndex = 0;
	//중괄호 이후의 문자 개수
	int tBackIndex = 0;
	//중괄호 이전인지 여부
	bool tCountingFront = true;

	//중괄호 전후로 문자열 개수 확인
	//배열 생성을 위해 이 작업을 먼저 실시
	while (tMessage[ti] != '\0')
	{
		//중괄호 발견 시
		if (tMessage[ti] == '{')
		{
			//중괄호 이전의 문자 끝남
			tCountingFront = false;
			//중괄호 닫기는 바로 건너뛰기 위해 +2를 한다.
			ti += 2;
		}
		else
		{
			if (tCountingFront)
			{
				//중괄호 이전의 문자 개수 추가
				tFrontIndex++;
			}
			else
			{
				//중괄호 이후의 문자 개수 추가
				tBackIndex++;
			}
			ti++;
		}
	}

	//배열 동적할당
	//char* tFrontString = new char[tFrontIndex + 1];
	//char* tBackString = new char[tBackIndex + 1];

	//ryu
	*tFrontOutput = new char[tFrontIndex + 1];
	*tBackOutput = new char[tBackIndex + 1];
	/**tFrontOutput = new char[33];
	*tBackOutput = new char[33];*/

	cout << strlen(tMessage) << endl;
	cout << tFrontIndex + 2 + tBackIndex << endl;
	

	//문자열 복사
	for (int ti = 0; ti < tFrontIndex; ti++)
	{
		//중광호 이전 부분은 그대로 복사
		//tFrontString[ti] = tMessage[ti];
		*tFrontOutput[ti] = tMessage[ti];
	}
	for (int ti = 0; ti < tBackIndex; ti++)
	{
		//중괄호 이후 부분은 인덱스 고려
		//tBackString[ti] = tMessage[tFrontIndex + 2 + ti];
		*tBackOutput[ti] = tMessage[tFrontIndex + 2 + ti];
	}

	//문자열 종료 알림
	//tFrontString[tFrontIndex] = '\0';
	//tBackString[tBackIndex] = '\0';
	*tFrontOutput[tFrontIndex] = '\0';
	*tBackOutput[tBackIndex] = '\0';

	//주소값 전달
	//*tFrontOutput = tFrontString;
	//*tBackOutput = tBackString;
}

char CUIPlay::InputFromUser()
{
	char tChar;
	cin >> tChar;
	return tChar;
}

const char* CUIPlay::GetText(KeyWords tKeyWord)
{
	switch (tKeyWord)
	{
	case Initiatiation:
		return "((용사와 슬라임))\n==종료하려면 n을 입력하세요==";
	case MoveQuestion:
		return "move?(a/d)";
	case NoOneHere:
		return "No one here. (You are on Tile{})";
	case SlimeIsHere:
		return "Slime is here. (You are on Tile{})";
	case RollADice:
		return "Roll a Dice of Fate!(r):";
	case BraveHome:
		return "Brave is in home. (You are on Tile{})";
	case WorldEnd:
		return "Brave is in End of world. (You are on Tile{})";
	case GameEnd:
		return "슬라임은 심심하다.\n어서 빨리 일어나라! 용사!";
	case NewUIInstanceCreated:
		return "CUIPlay에 인스턴스를 전달하지 않아 새로운 인스턴스가 생성됩니다.";
	case UnavailableCommand:
		return "\'{}\' 수행할 수 없는 명령입니다.";
	case Experience:
		return "Brave's Exp: {}";
	default:
		return "잘못된 값";
	}
}