#include "CActor.h"

void CActor::DoMoveX(float tXSpeed, float t)
{
	mActorX = mActorX +tXSpeed * t;
}