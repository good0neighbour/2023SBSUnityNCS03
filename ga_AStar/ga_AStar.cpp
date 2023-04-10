
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
	/*{
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0,
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0,
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0,

		0, 0, 0, 0, 0,  0, 0, 0, 0, 0,
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0,
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0
	};*/

	//case 1
	/*{
		0, 0, 1, 0, 0,  0, 0, 0, 0, 0,
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0,
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0,
		
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0,
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0,
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0
	};*/
	//case 2
	/*{
		0, 0, 1, 0, 0,  0, 0, 0, 0, 0,
		0, 1, 1, 0, 0,  0, 0, 0, 0, 0,
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0,
		
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0,
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0,
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0
	};*/
	//case 3
	/*{
		0, 0, 0, 1, 0,  0, 0, 0, 0, 0,
		0, 1, 1, 1, 0,  0, 0, 0, 0, 0,
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0,
		
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0,
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0,
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0
	};*/
	//case 4
	/*{
		0, 0, 1, 0, 0,  0, 0, 0, 0, 0,
		0, 0, 1, 0, 0,  0, 0, 0, 0, 0,
		1, 1, 1, 0, 0,  0, 0, 0, 0, 0,
		
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0,
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0,
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0
	};*/
	//case 5
	{
		0, 1, 1, 0, 0,  1, 1, 1, 1, 0,
		0, 1, 1, 1, 1,  1, 0, 0, 0, 0,
		0, 1, 1, 1, 1,  1, 1, 1, 0, 0,

		0, 0, 1, 1, 1,  1, 1, 0, 0, 0,
		0, 0, 1, 0, 1,  0, 0, 0, 0, 0,
		0, 0, 0, 0, 0,  0, 0, 0, 0, 0
	};


	//지나온 경로정보를 담아둘 최종 링크 노드
	SPathInfo* mpRyuPathInfo = nullptr;


	//최종 목표 위치
	float tEndX = 4;
	float tEndY = 0;

	//최초 시작 경로 정보
	SPathInfo* mpStart = new SPathInfo();
	//mpStart

	//최초 시작지점은 0, 0으로 가정
	mpStart->mX = 0;
	mpStart->mY = 0;
	mpStart->mpParentPathNode = nullptr;	//아무데서도 안 왔다.

	//g
	mpStart->mCostFromStart = 0;

	//h: 최종 목적지점까지의 추정비용
	// 크게 다음 두 가지 정도가 있다. 여기서는 i)의 방법을 사용하겠다
	//	i) 기하학적 직선거리 재기
	//	ii) 맨해튼 거리 재기
	mpStart->mCostToGoal = (tEndX - mpStart->mX) * (tEndX - mpStart->mX) + (tEndY - mpStart->mY) * (tEndY - mpStart->mY);

	//f = g + h
	mpStart->mTotalCost = mpStart->mCostFromStart + mpStart->mCostToGoal;





	//시동을 건다
	tOpenList.push(mpStart);
	tPathInfoForCheck.push_back(mpStart);
	//경로정보는 아직 구성되지 않았다고 가정
	bool mIsRoad = false;

	//새로운 경로정보 후보군을 위한 지역변수
	SPathInfo* mpNew = nullptr;

	int tClosest = mpStart->mCostToGoal;

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
			//사방에 인접한 cell들에 대해 검사
			for (int tDir = 0; tDir < 4; ++tDir)
			{
				//임의의 cell에 대한 경로정보를 만든다
				mpNew = nullptr;
				mpNew = new SPathInfo();

				//해당 경로정보에 대한 데이터를 설정하자
				//위치 정보
				switch (tDir)
				{
				case 0:	//우
				{
					mpNew->mX = tpNode->mX + 1;
					mpNew->mY = tpNode->mY;
				}
				break;
				case 1:	//하, 하를 행의 감소 방향으로 보겠다
				{
					mpNew->mX = tpNode->mX;
					mpNew->mY = tpNode->mY - 1;
				}
				break;
				case 2:	//좌
				{
					mpNew->mX = tpNode->mX - 1;
					mpNew->mY = tpNode->mY;
				}
				break;
				case 3:	//상
				{
					mpNew->mX = tpNode->mX;
					mpNew->mY = tpNode->mY + 1;
				}
				break;
				}

				//다음 경우들은 해당 경로정보들을 후보로 삼지 않는다
				//
				//해당 셀이 그리드 너비를 벗어난 경우
				//해당 셀이 그리드 높이를 벗어난 경우
				//해당 셀이 장애물인 경우( 셀 속성이 1이면 장애물 )
				//ClosedList에 이미 있는 경우, OpenList에 이미 있는 경우

				if (mpNew->mX < 0 || mpNew->mX > COL_COUNT - 1)
				{
					delete mpNew;
					mpNew = nullptr;
					continue;
				}

				if (mpNew->mY < 0 || mpNew->mY > ROW_COUNT - 1)
				{
					delete mpNew;
					mpNew = nullptr;
					continue;
				}

				if (1 == mAttrib[mpNew->mY][mpNew->mX])
				{
					delete mpNew;
					mpNew = nullptr;
					continue;
				}

				//순차검색
				bool mIs = false;
				for (int i = 0; i < tPathInfoForCheck.size(); ++i)
				{
					if (tPathInfoForCheck[i]->mX == mpNew->mX && tPathInfoForCheck[i]->mY == mpNew->mY)
					{
						mIs = true;
						break;
					}
				}

				if (mIs)
				{
					delete mpNew;
					mpNew = nullptr;
					continue;
				}


				//어디에서 왔니?
				mpNew->mpParentPathNode = tpNode;


				//비용계산
				int tNewCost = 0;
				//새로운 후보군 경로정보의 g를 구한다
				//이것은 tpNode의 g에다가 mpNew와 tpNode사이의 거리를 더한 것이다
				tNewCost = tpNode->mCostFromStart + (tpNode->mX - mpNew->mX) * (tpNode->mX - mpNew->mX) + (tpNode->mY - mpNew->mY) * (tpNode->mY - mpNew->mY);
				//g
				mpNew->mCostFromStart = tNewCost;

				//h: 최종 목적지점까지의 추정비용
				mpNew->mCostToGoal = (tEndX - mpNew->mX) * (tEndX - mpNew->mX) + (tEndY - mpNew->mY) * (tEndY - mpNew->mY);

				if (tClosest > mpNew->mCostToGoal)
				{
					tClosest = mpNew->mCostToGoal;
					mpRyuPathInfo = mpNew;
				}

				//f = g + h
				mpNew->mTotalCost = mpNew->mCostFromStart + mpNew->mCostToGoal;





				//검사 대상이 될 노드는 open list에 담는다
				tOpenList.push(mpNew);
				tPathInfoForCheck.push_back(mpNew);
			}
		}

		//검사가 끝난 노드는 closed list에 담는다
		tClosedList.push(tpNode);
		tPathInfoForCheck.push_back(tpNode);
	}

	//여기까지 오면, OpenList에 데이터가 없거나, 경로를 찾은 것이다.
	if (!mIsRoad)
	{
		cout << "Can't reach the goal." << endl;
	}
	else
	{
		cout << "Road exists." << endl;
	}

	//경로정보를 구성하자
	if (nullptr != mpRyuPathInfo)
	{
		SRyuVector tRoadElement;

		while (nullptr != mpRyuPathInfo->mpParentPathNode)
		{
			tRoadElement.x = mpRyuPathInfo->mX;
			tRoadElement.y = mpRyuPathInfo->mY;

			//경로정보로 길구축
			mRoad.push_back(tRoadElement);

			mpRyuPathInfo = mpRyuPathInfo->mpParentPathNode;	//다음 경로정보로
		}

		tRoadElement.x = mpRyuPathInfo->mX;
		tRoadElement.y = mpRyuPathInfo->mY;

		//경로정보로 길구축
		mRoad.push_back(tRoadElement);
	}

	tPathInfoForCheck.clear();

	while (!tOpenList.empty())
	{
		SPathInfo* tpPtr = nullptr;
		tpPtr = tOpenList.top();

		delete tpPtr;

		tOpenList.pop();
	}

	while (!tClosedList.empty())
	{
		SPathInfo* tpPtr = nullptr;
		tpPtr = tClosedList.top();

		delete tpPtr;

		tClosedList.pop();
	}


	//최종적으로 완성된 경로(길) 표시
	if (mRoad.size() > 0)
	{
		DisplayRoad();
	}

	mRoad.clear();



	return 0;
}