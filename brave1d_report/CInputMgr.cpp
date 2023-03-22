#include "CInputMgr.h"
#include "CBrave.h"

#include <iostream>
using namespace std;

CInputMgr* CInputMgr::mInstance = nullptr;

CInputMgr::CInputMgr()
{

}
CInputMgr::~CInputMgr()
{

}

bool CInputMgr::KeyInput(char tMoveDir, CBrave* tBrave)
{
    if ('n' == tMoveDir)
    {
        cout << "brave is sleeping." << endl;
        return false;
    }
    else if ('a' == tMoveDir)
    {
        if (tBrave->GetX() > 0)
        {
            tBrave->DoMove(-1);
            cout << "<--move left" << endl;
        }
        else
        {
            cout << "Brave can not move any more." << endl;
        }
    }
    else if ('d' == tMoveDir)
    {
        if (tBrave->GetX() < 4)
        {
            tBrave->DoMove(+1);

            cout << "-->move right" << endl;
        }
        else
        {
            cout << "Brave can not move any more." << endl;
        }
    }
    return true;
}

CInputMgr* CInputMgr::GetInstance()
{
    if (mInstance == nullptr)
    {
        mInstance = new CInputMgr();
    }
    return mInstance;
}

void CInputMgr::ReleaseInstance()
{
    if (mInstance != nullptr)
    {
        delete mInstance;
        mInstance = nullptr;
    }
}