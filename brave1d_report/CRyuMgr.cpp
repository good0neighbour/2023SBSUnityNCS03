#include "CRyuMgr.h"

CRyuMgr* CRyuMgr::mpInstance = nullptr;

CRyuMgr::CRyuMgr()
{
	//객체 생성 시 용사의 상태를 Move로 한다.
	mStatus = Move;
}
CRyuMgr::~CRyuMgr()
{

}

CRyuMgr* CRyuMgr::GetInstance()
{
	if ( nullptr == mpInstance )
	{
		mpInstance = new CRyuMgr();
	}
	return mpInstance;
}

void CRyuMgr::ReleaseInstance()
{
	if (nullptr != mpInstance)
	{
		delete mpInstance;
		mpInstance = nullptr;
	}
}