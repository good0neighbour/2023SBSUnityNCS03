#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"

#include "config.h"
#include "CTile.h"

/*
	여기서는 픽셀 단위의 스크롤을 추가해서 살펴보도록 하겠다.

	관찰의 용이함을 위해 1차원 세계를 가정한다
*/

// Override base class with your custom functionality
class Example : public olc::PixelGameEngine
{
	//전체 월드의 속성 그리드
	//	tileset: 타일 종류의 모음
	//	0: 하얀색 타일
	//	1: 빨간색 타일
	//	2: 파란색 타일
	//	3: 녹색 타일
	int mWorldGrid[TOTAL_GRID_H][TOTAL_GRID_W] =
	{
		1, 0, 0,  1, 0, 0,  1, 0, 2
	};


	CTile mTiles[SCREEN_GRID_H][SCREEN_GRID_W];


	//이 예시는 쉬운 구현을 위해 행열단위로 이동(스크롤)하겠다
	//카메라의 행열좌표에서의 위치
	int mCameraCol = 0;
	int mCameraRow = 0;




public:
	Example()
	{
		// Name your application
		sAppName = "Example";
	}

public:
	bool OnUserCreate() override
	{
		//지형구축
		for (int tRow = 0; tRow < SCREEN_GRID_H; ++tRow)
		{
			for (int tCol = 0; tCol < SCREEN_GRID_W; ++tCol)
			{
				mTiles[tRow][tCol].Create(tCol * 32, tRow * 32, 32, 32);
				mTiles[tRow][tCol].SetEngine(this);
			}
		}

		//카메라 설정
		//카메라는 처음 시작 시 스크린 상에서 1행, 1열에 위치한다.
		mCameraCol = 1;
		mCameraRow = 1;


		return true;
	}
	bool OnUserDestroy() override
	{
		for (int tRow = 0; tRow < SCREEN_GRID_H; ++tRow)
		{
			for (int tCol = 0; tCol < SCREEN_GRID_W; ++tCol)
			{
				mTiles[tRow][tCol].Destroy();
			}
		}

		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{

		if (GetKey(olc::Key::LEFT).bReleased)
		{
			mCameraCol = mCameraCol - 1;
			//경계처리, camera의 col의 하한선은 1로 고정
			if (mCameraCol - 1 < 0)
			{
				mCameraCol = 1;
			}

			std::cout << "mCameraCol: " << mCameraCol << std::endl;
		}
		if (GetKey(olc::Key::RIGHT).bReleased)
		{
			mCameraCol = mCameraCol + 1;
			//경계처리, camera의 col의 상한선은 9 - 1 - 1로 고정
			if (mCameraCol + 1 > 9 - 1)
			{
				mCameraCol = 9 - 1 - 1;
			}

			std::cout << "mCameraCol: " << mCameraCol << std::endl;
		}
		if (GetKey(olc::Key::UP).bReleased)
		{
			mCameraRow = mCameraRow - 1;
			//경계처리, camera의 row의 하한선은 1로 고정
			if (mCameraRow - 1 < 0)
			{
				mCameraRow = 1;
			}

			std::cout << "mCameraRow: " << mCameraRow << std::endl;
		}
		if (GetKey(olc::Key::DOWN).bReleased)
		{
			mCameraRow = mCameraRow + 1;
			//경계처리, camera의 row의 상한선은 9 - 1 - 1로 고정
			if (mCameraRow + 1 > 9 - 1)
			{
				mCameraRow = 9 - 1 - 1;
			}

			std::cout << "mCameraRow: " << mCameraRow << std::endl;
		}





		for (int tRow = 0; tRow < SCREEN_GRID_H; ++tRow)
		{
			for (int tCol = 0; tCol < SCREEN_GRID_W; ++tCol)
			{
				mTiles[tRow][tCol].Update(fElapsedTime);
			}
		}

		Clear(olc::BLACK);

		for (int tRow = 0; tRow < SCREEN_GRID_H; ++tRow)
		{
			for (int tCol = 0; tCol < SCREEN_GRID_W; ++tCol)
			{
				//월드맵속정 전달, 현재 카메라 위치(행렬좌표) 전달
				mTiles[tRow][tCol].Render(mWorldGrid, mCameraCol, mCameraRow);
			}
		}
		

		//test
		//'1by1스크린'을 가정하고 살펴보기 위해 다음의 장치를 설정
		FillRect(32, 0, 100, 100, olc::BLACK);

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