#include "CUIPlay.h"
#include "CRyuMgr.h"

#include <iostream>

using namespace std;

void CUIPlay::ExpDisplay()
{
	cout << "Brave's Exp: " << CRyuMgr::GetInstance()->mExp << endl;
}

void CUIPlay::UnavailableCommand(char whatCommand)
{
	cout << "\'" << whatCommand << "\' ������ �� ���� ����Դϴ�." << endl;
}

void CUIPlay::NewUIInstanceCreated()
{
	cout << "CUIPlay�� �ν��Ͻ��� �������� �ʾ� ���ο� �ν��Ͻ��� �����˴ϴ�." << endl;
}