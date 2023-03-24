#include "CUIPlay.h"
#include "CRyuMgr.h"

#include <iostream>

using namespace std;

//가독성을 위한 매크로
#define LANGUAGE_SELECT(tKorean, tEnglish, tSpanish) \
switch (mLanguage)\
{\
case Korean:\
return tKorean;\
case English:\
return tEnglish;\
case Spanish:\
return tSpanish;\
default:\
return "잘못된 언어";\
}

void CUIPlay::Display(KeyWords tKeyWord)
{
	//콘솔창에 문자열 출력
	cout << GetText(tKeyWord) << endl;
}
void CUIPlay::Display(KeyWords tKeyWord, int tValue)
{
	//중괄호 이전의 문자열을 담을 것
	char* tFrontOutput = nullptr;
	//중괄호 이후의 문자열을 담을 것
	char* tBackOutput = nullptr;

	//중괄호를 기준으로 문자열을 전, 후로 분리.
	StringSearch(GetText(tKeyWord), &tFrontOutput, &tBackOutput);
	//중간에 값을 끼워 넣어 출력
	cout << tFrontOutput << tValue << tBackOutput << endl;

	//동적할당 해제
	delete[] tFrontOutput;
	delete[] tBackOutput;
}
void CUIPlay::Display(KeyWords tKeyWord, char tValue)
{
	//중괄호 이전의 문자열을 담을 것
	char* tFrontOutput = nullptr;
	//중괄호 이후의 문자열을 담을 것
	char* tBackOutput = nullptr;

	//중괄호를 기준으로 문자열을 전, 후로 분리.
	StringSearch(GetText(tKeyWord), &tFrontOutput, &tBackOutput);
	//중간에 값을 끼워 넣어 출력
	cout << tFrontOutput << tValue << tBackOutput << endl;

	//동적할당 해제
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
	char* tFrontString = new char[tFrontIndex + 1];
	char* tBackString = new char[tBackIndex + 1];

	//ryu
	//*tFrontOutput = new char[tFrontIndex + 1];
	//*tBackOutput = new char[tBackIndex + 1];
	/**tFrontOutput = new char[33];
	*tBackOutput = new char[33];*/

	//cout << strlen(tMessage) << endl;
	//cout << tFrontIndex + 2 + tBackIndex << endl;
	

	//문자열 복사
	for (int ti = 0; ti < tFrontIndex; ti++)
	{
		//중광호 이전 부분은 그대로 복사
		tFrontString[ti] = tMessage[ti];
		//*tFrontOutput[ti] = tMessage[ti];
	}
	for (int ti = 0; ti < tBackIndex; ti++)
	{
		//중괄호 이후 부분은 인덱스 고려
		tBackString[ti] = tMessage[tFrontIndex + 2 + ti];
		//*tBackOutput[ti] = tMessage[tFrontIndex + 2 + ti];
	}

	//문자열 종료 알림
	tFrontString[tFrontIndex] = '\0';
	tBackString[tBackIndex] = '\0';
	//*tFrontOutput[tFrontIndex] = '\0';
	//*tBackOutput[tBackIndex] = '\0';

	//주소값 전달
	*tFrontOutput = tFrontString;
	*tBackOutput = tBackString;
}

char CUIPlay::InputFromUser()
{
	char tChar;
	cin >> tChar;
	return tChar;
}

void CUIPlay::NextLanguage()
{
	mLanguage = (Languages)(mLanguage + 1);
	if (mLanguage == LanguagesEnd)
	{
		mLanguage = (Languages)0;
	}
}

const char* CUIPlay::GetText(KeyWords tKeyWord)
{
	switch (tKeyWord)
	{
	case Initiatiation:
		LANGUAGE_SELECT(
			//국어
			"((용사와 슬라임))\n\
******************************\n\
l을 입력하여 언어 변경\n\
******************************\n\
==종료하려면 n을 입력하세요==\n",

			//영문
			"((Brave and Slime))\n\
******************************\n\
Change language by typing l\n\
******************************\n\
==Type n to quit==\n",

			//스페인어
			"((valiente y limo))\n\
******************************\n\
Cambia el idioma escribiendo l\n\
******************************\n\
==Escriba n para salir==\n"
		);
	case MoveQuestion:
		LANGUAGE_SELECT(
			"이동?(a/d)",
			"move?(a/d)",
			"mover?(a/d)"
		);
	case NoOneHere:
		LANGUAGE_SELECT(
			"아무도 없다. (당신은 {}번째 타일에 있다.)\n",
			"No one here. (You are on Tile{})\n",
			"Nadie aqui. (Estás en Tile{})\n"
		);
	case SlimeIsHere:
		LANGUAGE_SELECT(
			"슬라임이 있다. (당신은 {}번째 타일에 있다.)",
			"Slime is here. (You are on Tile{})",
			"El limo está aquí. (Estás en Tile{})"
		);
	case RollADice:
		LANGUAGE_SELECT(
			"운명의 주사위를 굴려라!(r):",
			"Roll a Dice of Fate!(r):",
			"¡Tira un Dado del Destino!(r):"
		);
	case BraveHome:
		LANGUAGE_SELECT(
			"용자는 집에 있다. (당신은 {}번째 타일에 있다.)\n",
			"Brave is in home. (You are on Tile{})\n",
			"Valiente está en casa. (Estás en Tile{})\n"
		);
	case WorldEnd:
		LANGUAGE_SELECT(
			"용사는 세상의 끝에 있다. (당신은 {}번째 타일에 있다.)\n",
			"Brave is in End of world. (You are on Tile{})\n",
			"Brave está en Fin del mundo. (Estás en Tile{})\n"
		);
	case GameEnd:
		LANGUAGE_SELECT(
			"슬라임은 심심하다.\n어서 빨리 일어나라! 용사!\n",
			"Slime is boring.\nGet up quickly! Brave!\n",
			"El limo es aburrido.\n¡Levántate rápido! ¡Corajudo!\n"
		);
	case NewUIInstanceCreated:
		LANGUAGE_SELECT(
			"CUIPlay에 인스턴스를 전달하지 않아 새로운 인스턴스가 생성됩니다.\n",
			"You didn't pass an instance to CUIPlay, so a new instance is created.\n",
			"No pasó una instancia a CUIPlay, por lo que se crea una nueva instancia.\n"
		);
	case UnavailableCommand:
		LANGUAGE_SELECT(
			"\'{}\' 수행할 수 없는 명령입니다.\n",
			"\'{}\' This command cannot be performed.\n",
			"\'{}\' Este comando no se puede ejecutar.\n"
		);
	case Experience:
		LANGUAGE_SELECT(
			"용사의 경험치: {}\n",
			"Brave's Exp: {}\n",
			"Experiencia de valiente: {}\n"
		);
	case BraveIsSleeping:
		LANGUAGE_SELECT(
			"용사는 자고있다.",
			"brave is sleeping.",
			"valiente esta durmiendo."
		);
	case MoveLeft:
		LANGUAGE_SELECT(
			"<--좌로 이동",
			"<--move left",
			"<--mover hacia la izquierda"
		);
	case CantMove:
		LANGUAGE_SELECT(
			"용사는 더이상 이동할 수 없다.",
			"Brave can not move any more.",
			"Valiente no puede moverse más."
		);
	case MoveRight:
		LANGUAGE_SELECT(
			"-->우로 이동",
			"-->move right",
			"-->mover a la derecha"
		);
	case BraveDamaged:
		LANGUAGE_SELECT(
			"용사는 피해입었다",
			"Brave is damaged",
			"Valiente está dañado"
		);
	case SlimeDamaged:
		LANGUAGE_SELECT(
			"슬라임은 피해입었다.",
			"Slime is damaged.",
			"El limo está dañado."
		);
	case SlimeTired:
		LANGUAGE_SELECT(
			"슬라임은 매우 지쳤다.",
			"Slime is very tired.",
			"El limo está muy cansado."
		);
	case BraveTired:
		LANGUAGE_SELECT(
			"용사는 매우 지쳤다.",
			"Brave is very tired.",
			"Valiente está muy cansado."
		);
	case LanguageChanged:
		LANGUAGE_SELECT(
			"\nCurrent language: 한국어",
			"\nCurrent language: English",
			"\nCurrent language: Español"
		);
	default:
		return "잘못된 값\n";
	}
}