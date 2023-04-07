
#include <iostream>
#include <queue>//priority_queue를 위해
#include <vector>//가변배열
using namespace std;

/*
	우선순위큐를 이용하여 작성한
	A*알고리즘

	우선순위큐(여기서는 STL의 priority_queue를 사용 )를 이용하여
	OpenList, ClosedList를 만드려고 한다
	왜냐하면
	OpenList 등은 오름차순 정렬하여
	비용이 가장 작은 원소를 맨 앞에 위치시켜야만 하기 때문이다.

	또한 부가적으로
	검토하려는 임의의 원소가 OpenList, ClosedList에 이미 존재하는가를 판정하기 위해
	별도로 자료구조도 만들어 쓰겠다( 우선순위큐에는 순회 기능이 없기 때문이다 )
	가변배열을 사용하겠다

*/

//경로 정보
struct SPathInfo
{
	//행렬 좌표 기준
	//위치 정보
	int mX = 0;	//열
	int mY = 0;	//행

	//비용
	int mTotalCost = 0;		//f
	int mCostFromStart = 0;	//g
	int mCostToGoal = 0;	//h

	//지나온 경로 링크
	SPathInfo* mpParentPathNode = nullptr;
};

//함수 객체 클래스
//SPathInfo의 mTotalCost를 비교하기 위한 함수 객체 클래스다.
class ComparePathInfo
{
public:
	bool operator()(SPathInfo* tA, SPathInfo* tB)
	{
		//오름차순을 위해
		return tA->mTotalCost > tB->mTotalCost;
	}
};

typedef priority_queue<SPathInfo*, vector<SPathInfo*>, ComparePathInfo> CPriorityQ;


struct SRyuVector
{
	int x = 0;
	int y = 0;
};

//최종적으로 구해진 경로정보
vector<SRyuVector> mRoad;
//최종적으로 구해진 경로정보 표시
void DisplayRoad()
{
	cout << "road is..." << endl;

	int tRow = 0;
	int tCol = 0;

	int tCount = mRoad.size();
	for (int ti = 0; ti < tCount; ++ti)
	{
		tRow = mRoad[ti].y;
		tCol = mRoad[ti].x;

		cout << "(" << tRow << ", " << tCol << ")";

		if (ti < tCount - 1)
		{
			cout << " <-- ";
		}
	}
}



#define ROW_COUNT 6
#define COL_COUNT 10

int main()
{
	CPriorityQ tOpenList;	//열린목록
	CPriorityQ tClosedList;	//닫힌목록
	vector<SPathInfo*> tPathInfoForCheck;	//임의의 원소가 열린목록, 닫힌목록에 있는지 검사용 자료구조
	//(예시의 주제는 아니므로, 임의의 원소의 중복을 허용하겠다 )


	//x테스트용 Grid를 준비하자

	int mAttrib[ROW_COUNT][COL_COUNT] =
		//case 0
	{
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
	};

	//case 1
	//case 2
	//case 3
	//case 4


	//지나온 경로정보를 담아둘 최종 링크 노드
	SPathInfo* mpRyuPathInfo = nullptr;


	//최종 목표 위치
	float tEndX = 4;
	float tEndY = 0;

	//최초 시작 경로 정보
	SPathInfo* mpStart = new SPathInfo();
	//mpStart

	//시동을 건다
	tOpenList.push(mpStart);
	tPathInfoForCheck.push_back(mpStart);
	//경로정보는 아직 구성되지 않았다고 가정
	bool mIsRoad = false;

	while (!tOpenList.empty())
	{
		SPathInfo* tpNode = nullptr;

		tpNode = tOpenList.top();
		tOpenList.pop();

		//최종목표지점인지 검사한다.
		if (tpNode->mX == tEndX && tpNode->mY == tEndY)
		{
			mpRyuPathInfo = tpNode;

			mIsRoad = true;

			break;
		}
		else
		{

		}
	}




	return 0;
}