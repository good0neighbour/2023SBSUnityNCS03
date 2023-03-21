#include "CUIPlay.h"

#include "CRyuMgr.h"

#include <iostream>
using namespace std;


void CUIPlay::Display()
{
	cout << "Brave's Exp: " << CRyuMgr::GetInstance()->mExp << endl;
}