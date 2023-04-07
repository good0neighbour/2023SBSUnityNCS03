
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


	//������ ��������� ��Ƶ� ���� ��ũ ���
	SPathInfo* mpRyuPathInfo = nullptr;


	//���� ��ǥ ��ġ
	float tEndX = 4;
	float tEndY = 0;

	//���� ���� ��� ����
	SPathInfo* mpStart = new SPathInfo();
	//mpStart

	//�õ��� �Ǵ�
	tOpenList.push(mpStart);
	tPathInfoForCheck.push_back(mpStart);
	//��������� ���� �������� �ʾҴٰ� ����
	bool mIsRoad = false;

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

		}
	}




	return 0;
}