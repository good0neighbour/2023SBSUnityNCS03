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
	cout << "\'" << whatCommand << "\' 수행할 수 없는 명령입니다." << endl;
}

void CUIPlay::NewUIInstanceCreated()
{
	cout << "CUIPlay에 인스턴스를 전달하지 않아 새로운 인스턴스가 생성됩니다." << endl;
}