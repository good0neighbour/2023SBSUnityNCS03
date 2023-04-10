#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"

/*
	타일맵 tilemap의 개념과 사용이유

	i) 통맵: 전체 맵을 하나( 또는 몇 개 )의 통이미지로 표현하는 방식

	ii) 타일맵: 전체 맵을 작은 이미지 단위의 '타일'이라는 개념의 조합으로 표현하는 방식

	iii) 두 개념의 장단점 비교

		통맵:

			장점: 아트 측면에서 보면 아티스트의 의도에 맞게 유려한 그래픽 표현이 가능하다
			단점: 맵 크기만한 이미지가 필요하므로 메모리 용량을 많이 차지한다

		타일맵:

			장점: 맵을 표현 시 타일들의 증복이 이루어지며 통맵 방식에 비해 메모리 용량을 절약할 수 있다
			단점: 아트 측면에서 보면 단위 이미지의 조합이므로 통맵에 비해 표현에 제약이 있고 조약해보일 수 있다.


	iv) 타일맵 방식이 통맵에 비해 메모리 용량 측면에서 이득이 되는 이유

		예를 들면,

		스크린의 크기가 10by10 pixel
		전체 맵의 크기가 100by100 pixel

			픽셀은 4byte ( R:8bit, G:8bit, B:8bit, A:8bit )

		이라고 가정하자

		통맵으로 제작 시
			100 * 100 * 4byte * 40,000byte

		타일맵으로 제작 시
			타일의 크기는 5by5 pixel로 가정
			타일 종류는 2개
			--> 5 * 5 * 2개 * 4byte * 200byte
			스크린 크기가 10by10 pixel이므로 스크린에 표시되는 맵을 표현하기 위해서는 타일 4장이 표시됨
			--> 10 * 10 * 4byte

			그리고 어느 타일종류를 대응시킬지 맵속성( int라고 가정하자 )은
			20 * 20 * 4byte = 1600byte

			200 + 400 + 1600 = 2,200byte

		그러므로 통맵 메모리 용량 vs 타일맵 용량은 다음과 같다.
		40,000byte vs 2,200byte

		37,800byte의 이득이 있다.




*/

// Override base class with your custom functionality
class Example : public olc::PixelGameEngine
{
public:
	Example()
	{
		// Name your application
		sAppName = "Example";
	}

public:
	bool OnUserCreate() override
	{
		// Called once at the start, so create things here
		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{
		Clear(olc::BLACK);
		
		return true;
	}
};

int main()
{
	Example demo;
	if (demo.Construct(800, 600, 1, 1))
		demo.Start();
	return 0;
}