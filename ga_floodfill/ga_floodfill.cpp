
/*
	플러드 필 Flood Fill 알고리즘

	원래는 색칠하기 알고리즘이나
	속도가 너무 느려 색칠하기 알고리즘으로 사용되지는 않는다

	하지만,
	응용되어
	'임의의 연결된 셀들을 검토'하는 알고리즘으로 사용되는 경우가 많다.
*/

#include <iostream>
using namespace std;

//2차원 격자Grid
//0: 빈 곳, 1: 칠한 곳, 2: 벽(경계)
int Grid[6][6] =
{
	2, 2, 2, 2, 2, 2,
	2, 0, 0, 0, 0, 2,
	2, 2, 2, 2, 2, 2,
	2, 0, 0, 0, 0, 2,
	2, 0, 0, 0, 0, 2,
	2, 2, 2, 2, 2, 2
};


void DoFloodFill(int tCol, int tRow);

void DisplayGrid()
{
	string tString = "";
	char tszTemp[256] = { 0 };

	for (int tRow = 0; tRow < 6; ++tRow)
	{
		for (int tCol = 0; tCol < 6; ++tCol)
		{
			sprintf_s(tszTemp, "%d", Grid[tRow][tCol]);

			tString += tszTemp;
		}
		tString += "\n";
	}

	cout << tString;
}

int main()
{
	//befoer
	DisplayGrid();

	DoFloodFill(1, 1);

	//after
	cout << endl;
	DisplayGrid();

	DoFloodFill(1, 3);

	//after
	cout << endl;
	DisplayGrid();

	return 0;
}

void DoFloodFill(int tCol, int tRow)
{
	//이미 칠한 곳이거나 벽이라면 칠하지 않는다
	if (1 == Grid[tRow][tCol] || 2 == Grid[tRow][tCol])
	{
		//base case, 재귀호출의 종료조건
		return;
	}
	else
	{
		//recursive case
		//빈 곳이라면 칠한다
		Grid[tRow][tCol] = 1;

		//사방의 셀에 대해서도 같은 동작을 취한다
		DoFloodFill(tCol - 1, tRow);
		DoFloodFill(tCol + 1, tRow);
		DoFloodFill(tCol, tRow - 1);
		DoFloodFill(tCol, tRow + 1);

	}
}

//함수의 재귀호출에 대한 예시
//
////픽토리얼 예시
//
//unsigned int DoFactorial(unsigned int tN);
//
//
//int main()
//{
//    int tResult = DoFactorial(4);
//    cout << tResult << endl;
//    return 0;
//}
//
////재귀함수
// 재귀함수의 장단점
// 장점
// i) 코드가 심미적이다(아름답다)
// 단점
// i) 비재귀 버전에 비해서 함수호출 비용이 많이 든다
// ii) 스택 오버 플로우 stack overflow가 일어날 가능성이 크다
//unsigned int DoFactorial(unsigned int tN)
//{
//    if (0 == tN)
//    {
//        //base case 종료조건
//        return 1;
//    }
//    else
//    {
//        //recursive case 재귀호출되는 부분
//        return tN * DoFactorial(tN - 1);
//    }
//}