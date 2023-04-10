
#include <iostream>
#include <queue>//priority_queue�� ����
#include <vector>//�����迭
using namespace std;

/*
	�켱����ť�� �̿��Ͽ� �ۼ���
	A*�˰���

	�켱����ť(���⼭�� STL�� priority_queue�� ��� )�� �̿��Ͽ�
	OpenList, ClosedList�� ������� �Ѵ�
	�ֳ��ϸ�
	OpenList ���� �������� �����Ͽ�
	����� ���� ���� ���Ҹ� �� �տ� ��ġ���Ѿ߸� �ϱ� �����̴�.

	���� �ΰ�������
	�����Ϸ��� ������ ���Ұ� OpenList, ClosedList�� �̹� �����ϴ°��� �����ϱ� ����
	������ �ڷᱸ���� ����� ���ڴ�( �켱����ť���� ��ȸ ����� ���� �����̴� )
	�����迭�� ����ϰڴ�

*/

//��� ����
struct SPathInfo
{
	//��� ��ǥ ����
	//��ġ ����
	int mX = 0;	//��
	int mY = 0;	//��

	//���
	int mTotalCost = 0;		//f
	int mCostFromStart = 0;	//g
	int mCostToGoal = 0;	//h

	//������ ��� ��ũ
	SPathInfo* mpParentPathNode = nullptr;
};

//�Լ� ��ü Ŭ����
//SPathInfo�� mTotalCost�� ���ϱ� ���� �Լ� ��ü Ŭ������.
class ComparePathInfo
{
public:
	bool operator()(SPathInfo* tA, SPathInfo* tB)
	{
		//���������� ����
		return tA->mTotalCost > tB->mTotalCost;
	}
};

typedef priority_queue<SPathInfo*, vector<SPathInfo*>, ComparePathInfo> CPriorityQ;


struct SRyuVector
{
	int x = 0;
	int y = 0;
};

//���������� ������ �������
vector<SRyuVector> mRoad;
//���������� ������ ������� ǥ��
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
	CPriorityQ tOpenList;	//�������
	CPriorityQ tClosedList;	//�������
	vector<SPathInfo*> tPathInfoForCheck;	//������ ���Ұ� �������, ������Ͽ� �ִ��� �˻�� �ڷᱸ��
	//(������ ������ �ƴϹǷ�, ������ ������ �ߺ��� ����ϰڴ� )


	//x�׽�Ʈ�� Grid�� �غ�����

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


	//������ ��������� ��Ƶ� ���� ��ũ ���
	SPathInfo* mpRyuPathInfo = nullptr;


	//���� ��ǥ ��ġ
	float tEndX = 4;
	float tEndY = 0;

	//���� ���� ��� ����
	SPathInfo* mpStart = new SPathInfo();
	//mpStart

	//���� ���������� 0, 0���� ����
	mpStart->mX = 0;
	mpStart->mY = 0;
	mpStart->mpParentPathNode = nullptr;	//�ƹ������� �� �Դ�.

	//g
	mpStart->mCostFromStart = 0;

	//h: ���� �������������� �������
	// ũ�� ���� �� ���� ������ �ִ�. ���⼭�� i)�� ����� ����ϰڴ�
	//	i) �������� �����Ÿ� ���
	//	ii) ����ư �Ÿ� ���
	mpStart->mCostToGoal = (tEndX - mpStart->mX) * (tEndX - mpStart->mX) + (tEndY - mpStart->mY) * (tEndY - mpStart->mY);

	//f = g + h
	mpStart->mTotalCost = mpStart->mCostFromStart + mpStart->mCostToGoal;





	//�õ��� �Ǵ�
	tOpenList.push(mpStart);
	tPathInfoForCheck.push_back(mpStart);
	//��������� ���� �������� �ʾҴٰ� ����
	bool mIsRoad = false;

	//���ο� ������� �ĺ����� ���� ��������
	SPathInfo* mpNew = nullptr;

	int tClosest = mpStart->mCostToGoal;

	while (!tOpenList.empty())
	{
		SPathInfo* tpNode = nullptr;

		tpNode = tOpenList.top();
		tOpenList.pop();

		//������ǥ�������� �˻��Ѵ�.
		if (tpNode->mX == tEndX && tpNode->mY == tEndY)
		{
			mpRyuPathInfo = tpNode;

			mIsRoad = true;

			break;
		}
		else
		{
			//��濡 ������ cell�鿡 ���� �˻�
			for (int tDir = 0; tDir < 4; ++tDir)
			{
				//������ cell�� ���� ��������� �����
				mpNew = nullptr;
				mpNew = new SPathInfo();

				//�ش� ��������� ���� �����͸� ��������
				//��ġ ����
				switch (tDir)
				{
				case 0:	//��
				{
					mpNew->mX = tpNode->mX + 1;
					mpNew->mY = tpNode->mY;
				}
				break;
				case 1:	//��, �ϸ� ���� ���� �������� ���ڴ�
				{
					mpNew->mX = tpNode->mX;
					mpNew->mY = tpNode->mY - 1;
				}
				break;
				case 2:	//��
				{
					mpNew->mX = tpNode->mX - 1;
					mpNew->mY = tpNode->mY;
				}
				break;
				case 3:	//��
				{
					mpNew->mX = tpNode->mX;
					mpNew->mY = tpNode->mY + 1;
				}
				break;
				}

				//���� ������ �ش� ����������� �ĺ��� ���� �ʴ´�
				//
				//�ش� ���� �׸��� �ʺ� ��� ���
				//�ش� ���� �׸��� ���̸� ��� ���
				//�ش� ���� ��ֹ��� ���( �� �Ӽ��� 1�̸� ��ֹ� )
				//ClosedList�� �̹� �ִ� ���, OpenList�� �̹� �ִ� ���

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

				//�����˻�
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


				//��𿡼� �Դ�?
				mpNew->mpParentPathNode = tpNode;


				//�����
				int tNewCost = 0;
				//���ο� �ĺ��� ��������� g�� ���Ѵ�
				//�̰��� tpNode�� g���ٰ� mpNew�� tpNode������ �Ÿ��� ���� ���̴�
				tNewCost = tpNode->mCostFromStart + (tpNode->mX - mpNew->mX) * (tpNode->mX - mpNew->mX) + (tpNode->mY - mpNew->mY) * (tpNode->mY - mpNew->mY);
				//g
				mpNew->mCostFromStart = tNewCost;

				//h: ���� �������������� �������
				mpNew->mCostToGoal = (tEndX - mpNew->mX) * (tEndX - mpNew->mX) + (tEndY - mpNew->mY) * (tEndY - mpNew->mY);

				if (tClosest > mpNew->mCostToGoal)
				{
					tClosest = mpNew->mCostToGoal;
					mpRyuPathInfo = mpNew;
				}

				//f = g + h
				mpNew->mTotalCost = mpNew->mCostFromStart + mpNew->mCostToGoal;





				//�˻� ����� �� ���� open list�� ��´�
				tOpenList.push(mpNew);
				tPathInfoForCheck.push_back(mpNew);
			}
		}

		//�˻簡 ���� ���� closed list�� ��´�
		tClosedList.push(tpNode);
		tPathInfoForCheck.push_back(tpNode);
	}

	//������� ����, OpenList�� �����Ͱ� ���ų�, ��θ� ã�� ���̴�.
	if (!mIsRoad)
	{
		cout << "Can't reach the goal." << endl;
	}
	else
	{
		cout << "Road exists." << endl;
	}

	//��������� ��������
	if (nullptr != mpRyuPathInfo)
	{
		SRyuVector tRoadElement;

		while (nullptr != mpRyuPathInfo->mpParentPathNode)
		{
			tRoadElement.x = mpRyuPathInfo->mX;
			tRoadElement.y = mpRyuPathInfo->mY;

			//��������� �汸��
			mRoad.push_back(tRoadElement);

			mpRyuPathInfo = mpRyuPathInfo->mpParentPathNode;	//���� ���������
		}

		tRoadElement.x = mpRyuPathInfo->mX;
		tRoadElement.y = mpRyuPathInfo->mY;

		//��������� �汸��
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


	//���������� �ϼ��� ���(��) ǥ��
	if (mRoad.size() > 0)
	{
		DisplayRoad();
	}

	mRoad.clear();



	return 0;
}