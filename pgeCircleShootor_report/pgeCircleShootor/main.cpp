#define OLC_PGE_APPLICATION
#include "pgeCircleShootor.h"

int main()
{
	if (pgeCircleShootor::GetInstance()->Construct(320, 240, 2, 2))
		pgeCircleShootor::GetInstance()->Start();
	pgeCircleShootor::ReleaseInstance();
	return 0;
}