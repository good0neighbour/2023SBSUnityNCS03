#include "CRyuMgr.h"

//static 멤버변수 초기화
CRyuMgr* CRyuMgr::mpInstance = nullptr;

CRyuMgr::CRyuMgr()
{

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