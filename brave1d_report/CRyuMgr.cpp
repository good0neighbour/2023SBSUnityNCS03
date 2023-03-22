#include "CRyuMgr.h"

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