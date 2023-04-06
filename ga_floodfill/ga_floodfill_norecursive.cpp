#include <iostream>
#include <stack> //스택 컨테이너를 사용하기 위해 포함

using namespace std;
//플러드 필 알고리즘의 비재귀버전을 만들겠다
//이것을 만들기 위해서는 스택 자료구조가 필요하다
//
//위치 정보(행, 열)을 기록해둘 자료구조
stack<int> mIntStack;



/*
	자료구조: 자료를 담아두는 구조물
	<-- 그러므로 자료구조마다 구조가 다 다르고 그러므로 특징도 다 다르다

	배열: 동일한 타입의 원소들의 연속적인 메모리 블럭
	링크드 리스트: 노드가 데이터와 링크를 가지고, 각각의 링크에 의해 선형으로 연결된 자료구조
		<-- 데이터를 추가, 삭제하는데 걸리는 시간이 O(1)이다.

	동작 명세가 정해져 있는 자료구조
		스택: LIFO	Last Input First Out
		큐: FIFO	First Input First Out

	트리
	이진트리
	이진탐색트리

	해쉬

	그래프

*/

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

void DoFloodFill(int tCol, int tRow);


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
	//clear
	//스택 자료구조에 원소를 모두 날린다
	while (!mIntStack.empty())
	{
		mIntStack.pop();
	}


	//시동을 건다
	mIntStack.push(tCol);
	mIntStack.push(tRow);

	//재귀호출은 비재귀버전에서는 반복제어구조로 만들어진다
	//스택에 원소가 하나라도 있다면 반복
	while (!mIntStack.empty())
	{
		tRow = mIntStack.top();
		mIntStack.pop();

		tCol = mIntStack.top();
		mIntStack.pop();
		//이미 칠한 곳이거나 벽(경계)라면
		if (1 == Grid[tRow][tCol] || 2 == Grid[tRow][tCol])
		{
			continue;
		}

		//빈 곳이라면
		//칠한다
		Grid[tRow][tCol] = 1;


		//좌, 우, 상, 하	4개의 위치정보를 스택자료구조에 넣는다
		mIntStack.push(tCol - 1);
		mIntStack.push(tRow);

		mIntStack.push(tCol + 1);
		mIntStack.push(tRow);

		mIntStack.push(tCol);
		mIntStack.push(tRow - 1);

		mIntStack.push(tCol);
		mIntStack.push(tRow + 1);
	}
}



/*
//프로그램의 속도, 안정성,
//프로그램의 변경 가능성 등을 염두에 둔다면
//같은 기능을 구현한다면, 재귀버전보다는 비재귀버전을 만들어 적용하는 것이 낫다
unsigned int DoFactorial(unsigned int tN);

int main()
{
	int tResult = DoFactorial(33);
	cout << tResult << endl;

	return 0;
}
//비 재귀 버전의 팩토리얼 함수
//비 재귀 버전의 장단점
//장점
// i) 재귀 버전에 비해서 함수호출 비용이 적게 든다
// ii) 재귀 버전에 비해서 스택 오버 플로우 stack overflow가 일어날 가능성이 적다
//단점
//i) 재귀 버전에 비해서 구현이 비교적 까다롭다
unsigned int DoFactorial(unsigned int tN)
{
	if (0 == tN)
	{
		return 1;
	}
	else
	{
		//누적한 곱셈을 담아둘 변수
		int tTemp = 1;
		//재귀호출 버전의 코드는 반복제어구조가 되었다.
		for (int ti = tN; ti > 0; --ti)
		{
			tTemp = tTemp * ti;
		}

		return tTemp;
	}
}
*/