#include "CUIPlay.h"
#include "CRyuMgr.h"

#include <iostream>

using namespace std;

//�ݺ��Ǵ� �ڵ�� ��ũ�η� ��ü
#define DISPLAY_PROCESS \
char* tFrontOutput = nullptr;\
char* tBackOutput = nullptr;\
StringSearch(GetText(tKeyWord), &tFrontOutput, &tBackOutput);\
cout << tFrontOutput << tValue << tBackOutput << endl;\
delete[] tFrontOutput;\
delete[] tBackOutput;

void CUIPlay::Display(KeyWords tKeyWord)
{
	//�ܼ�â�� ���ڿ� ���
	cout << GetText(tKeyWord) << endl;
}
void CUIPlay::Display(KeyWords tKeyWord, int tValue)
{
	//��ũ�� ���
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
	//��ũ�� ���
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
	//�Է¹��� ���ڿ��� Ž���ϱ� ����
	int ti = 0;
	//�߰�ȣ ������ ���� ����
	int tFrontIndex = 0;
	//�߰�ȣ ������ ���� ����
	int tBackIndex = 0;
	//�߰�ȣ �������� ����
	bool tCountingFront = true;

	//�߰�ȣ ���ķ� ���ڿ� ���� Ȯ��
	//�迭 ������ ���� �� �۾��� ���� �ǽ�
	while (tMessage[ti] != '\0')
	{
		//�߰�ȣ �߰� ��
		if (tMessage[ti] == '{')
		{
			//�߰�ȣ ������ ���� ����
			tCountingFront = false;
			//�߰�ȣ �ݱ�� �ٷ� �ǳʶٱ� ���� +2�� �Ѵ�.
			ti += 2;
		}
		else
		{
			if (tCountingFront)
			{
				//�߰�ȣ ������ ���� ���� �߰�
				tFrontIndex++;
			}
			else
			{
				//�߰�ȣ ������ ���� ���� �߰�
				tBackIndex++;
			}
			ti++;
		}
	}

	//�迭 �����Ҵ�
	//char* tFrontString = new char[tFrontIndex + 1];
	//char* tBackString = new char[tBackIndex + 1];

	//ryu
	*tFrontOutput = new char[tFrontIndex + 1];
	*tBackOutput = new char[tBackIndex + 1];
	/**tFrontOutput = new char[33];
	*tBackOutput = new char[33];*/

	cout << strlen(tMessage) << endl;
	cout << tFrontIndex + 2 + tBackIndex << endl;
	

	//���ڿ� ����
	for (int ti = 0; ti < tFrontIndex; ti++)
	{
		//�߱�ȣ ���� �κ��� �״�� ����
		//tFrontString[ti] = tMessage[ti];
		*tFrontOutput[ti] = tMessage[ti];
	}
	for (int ti = 0; ti < tBackIndex; ti++)
	{
		//�߰�ȣ ���� �κ��� �ε��� ���
		//tBackString[ti] = tMessage[tFrontIndex + 2 + ti];
		*tBackOutput[ti] = tMessage[tFrontIndex + 2 + ti];
	}

	//���ڿ� ���� �˸�
	//tFrontString[tFrontIndex] = '\0';
	//tBackString[tBackIndex] = '\0';
	*tFrontOutput[tFrontIndex] = '\0';
	*tBackOutput[tBackIndex] = '\0';

	//�ּҰ� ����
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
		return "((���� ������))\n==�����Ϸ��� n�� �Է��ϼ���==";
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
		return "�������� �ɽ��ϴ�.\n� ���� �Ͼ��! ���!";
	case NewUIInstanceCreated:
		return "CUIPlay�� �ν��Ͻ��� �������� �ʾ� ���ο� �ν��Ͻ��� �����˴ϴ�.";
	case UnavailableCommand:
		return "\'{}\' ������ �� ���� ����Դϴ�.";
	case Experience:
		return "Brave's Exp: {}";
	default:
		return "�߸��� ��";
	}
}