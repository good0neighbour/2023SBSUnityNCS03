
#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"

#include <stack>

using namespace olc;
using namespace std;

// Override base class with your custom functionality
class Example : public olc::PixelGameEngine
{
	stack<int> mIntStack;

	//색상 정보, 6개의 색상을 준비한다고 가정한다
	//가장 기본은 검정( 비어있는 셀이라고 가정 )
	Pixel mColor[6] = { BLACK,
						WHITE, RED, GREEN, BLUE, YELLOW };

	//게임 보드 속성
	//5by5 board
	unsigned int mBoardAttrib[5][5] =
	{
		5, 5, 1, 1, 3,
		5, 2, 2, 2, 3,
		5, 4, 2, 3, 2,
		4, 4, 2, 3, 2,
		4, 1, 1, 3, 3
	};

	//검토 성공 여부 기록 보드
	//검토 성공이면 1, 아니면 0
	unsigned int tCheckVisit[5][5] =
	{
		0, 0, 0, 0, 0,
		0, 0, 0, 0, 0,
		0, 0, 0, 0, 0,
		0, 0, 0, 0, 0,
		0, 0, 0, 0, 0
	};


	//선택UI위치(행, 열 좌표기준)
	int mCurCol = 0;
	int mCurRow = 0;


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
		srand(time(nullptr));
		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{
		if (GetKey(olc::Key::LEFT).bPressed)
		{
			if (mCurCol > 0)
			{
				mCurCol--;
			}
		}
		if (GetKey(olc::Key::RIGHT).bPressed)
		{
			if (mCurCol < 4)
			{
				mCurCol++;
			}
		}
		if (GetKey(olc::Key::UP).bPressed)
		{
			if (mCurRow > 0)
			{
				mCurRow--;
			}
		}
		if (GetKey(olc::Key::DOWN).bPressed)
		{
			if (mCurRow < 4)
			{
				mCurRow++;
			}
		}

		if (GetKey(olc::Key::SPACE).bReleased)
		{
			cout << "colour check" << endl;

			//선택된 퍼즐조각의 색상 정보
			int tColourIndex = mBoardAttrib[mCurRow][mCurCol];

			cout << "tColourIndex\t" << tColourIndex << endl;

			//선택된 퍼즐 조각의 색상 정보와
			//같은 색상정보를 가진 퍼즐조각들이
			//몇 개나 인접해있는지 검사하는 함수 <--4방향 검사 수행
			int tCount = DoCheckBlockAttrib(mCurCol, mCurRow, tColourIndex);

			cout << "=== connecting block count: " << tCount << "\n" << endl;

			if (tCount >= 3)
			{
				cout << "block success" << endl;

				//해당 위치에 퍼즐 블록들 제거
				for (int tRow = 0; tRow < 5; ++tRow)
				{
					for (int tCol = 0; tCol < 5; ++tCol)
					{
						if (1 == tCheckVisit[tRow][tCol])
						{
							mBoardAttrib[tRow][tCol] = 0;
						}
					}
				}

				//새로운 퍼즐 블록 생성
				for (int tRow = 0; tRow < 5; ++tRow)
				{
					for (int tCol = 0; tCol < 5; ++tCol)
					{
						if (1 == tCheckVisit[tRow][tCol])
						{
							int tRandomColourIndex = rand() % 5 + 1;
							mBoardAttrib[tRow][tCol] = tRandomColourIndex;
						}
					}
				}
			}
		}


		// Called once per frame, draws random coloured pixels
		Clear(olc::BLACK);



		const int tBoardStartX = 70;
		const int tBoardStartY = 70;
		const int tCellW = 20;
		const int tCellH = 20;

		//게임보드, 색상퍼즐조각 렌더
		for (int tRow = 0; tRow < 5; ++tRow)
		{
			for (int tCol = 0; tCol < 5; ++tCol)
			{
				int tIndex = mBoardAttrib[tRow][tCol];
				DrawCircle(tCol * tCellW + tBoardStartX,
						   tRow * tCellH + tBoardStartY,
						   tCellW * 0.5 - 1,
						   mColor[tIndex]);
			}
		}

		//선택UI렌더
		DrawCircle(mCurCol * tCellW + tBoardStartX,
				   mCurRow * tCellH + tBoardStartY,
				   5,
				   WHITE);


		return true;
	}

	int DoCheckBlockAttrib(int tCol, int tRow, int tColourIndex);
};

int main()
{
	Example demo;
	if (demo.Construct(320, 240, 2, 2))
		demo.Start();
	return 0;
}



int Example::DoCheckBlockAttrib(int tCol, int tRow, int tColourIndex)
{
	int tResult = 0;

	//검토용 보드 clear
	for (int tRow = 0; tRow < 5; ++tRow)
	{
		for (int tCol = 0; tCol < 5; ++tCol)
		{
			tCheckVisit[tRow][tCol] = 0;
		}
	}

	//clear
	while (!mIntStack.empty())
	{
		mIntStack.pop();
	}


	//시동을 건다
	mIntStack.push(tCol);
	mIntStack.push(tRow);

	while (!mIntStack.empty())
	{
		tRow = mIntStack.top();
		mIntStack.pop();
		tCol = mIntStack.top();
		mIntStack.pop();

		//경계를 넘어갔다면 처리하지 않는다
		if (tRow < 0 || tRow > 4)
		{
			continue;
		}

		if (tCol < 0 || tCol > 4)
		{
			continue;
		}
		//색상정보가 일치하지 않는다면 처리하지 않는다
		if (tColourIndex != mBoardAttrib[tRow][tCol])
		{
			continue;
		}
			//이미 검토가 성공한 셀이라면 처리하지 않는다
			if (1 == tCheckVisit[tRow][tCol])
			{
				continue;
			}

			//색상이 같은 블록임을 체크하는 처리를 수행한다
			tCheckVisit[tRow][tCol] = 1;
			cout << "remember block: " << tRow << ", " << tCol << endl;

			//연속적으로 연결된 블록이 몇 개인지, 개수를 센다
			tResult++;


		//좌, 우, 상, 하
		mIntStack.push(tCol - 1);
		mIntStack.push(tRow);

		mIntStack.push(tCol + 1);
		mIntStack.push(tRow);

		mIntStack.push(tCol);
		mIntStack.push(tRow - 1);

		mIntStack.push(tCol);
		mIntStack.push(tRow + 1);
	}



	return tResult;
}