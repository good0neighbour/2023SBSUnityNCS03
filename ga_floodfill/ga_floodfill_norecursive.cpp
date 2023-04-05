#include <iostream>
#include <stack> //���� �����̳ʸ� ����ϱ� ���� ����

using namespace std;
//�÷��� �� �˰����� ����͹����� ����ڴ�
//�̰��� ����� ���ؼ��� ���� �ڷᱸ���� �ʿ��ϴ�
//
//��ġ ����(��, ��)�� ����ص� �ڷᱸ��
stack<int> mIntStack;



/*
	�ڷᱸ��: �ڷḦ ��Ƶδ� ������
	<-- �׷��Ƿ� �ڷᱸ������ ������ �� �ٸ��� �׷��Ƿ� Ư¡�� �� �ٸ���

	�迭: ������ Ÿ���� ���ҵ��� �������� �޸� ��
	��ũ�� ����Ʈ: ��尡 �����Ϳ� ��ũ�� ������, ������ ��ũ�� ���� �������� ����� �ڷᱸ��
		<-- �����͸� �߰�, �����ϴµ� �ɸ��� �ð��� O(1)�̴�.

	���� ���� ������ �ִ� �ڷᱸ��
		����: LIFO	Last Input First Out
		ť: FIFO	First Input First Out

	Ʈ��
	����Ʈ��
	����Ž��Ʈ��

	�ؽ�

	�׷���

*/

//2���� ����Grid
//0: �� ��, 1: ĥ�� ��, 2: ��(���)
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
	//���� �ڷᱸ���� ���Ҹ� ��� ������
	while (!mIntStack.empty())
	{
		mIntStack.pop();
	}


	//�õ��� �Ǵ�
	mIntStack.push(tCol);
	mIntStack.push(tRow);

	//���ȣ���� ����͹��������� �ݺ�������� ���������
	//���ÿ� ���Ұ� �ϳ��� �ִٸ� �ݺ�
	while (!mIntStack.empty())
	{
		tRow = mIntStack.top();
		mIntStack.pop();

		tCol = mIntStack.top();
		mIntStack.pop();
		//�̹� ĥ�� ���̰ų� ��(���)���
		if (1 == Grid[tRow][tCol] || 2 == Grid[tRow][tCol])
		{
			continue;
		}

		//�� ���̶��
		//ĥ�Ѵ�
		Grid[tRow][tCol] = 1;


		//��, ��, ��, ��	4���� ��ġ������ �����ڷᱸ���� �ִ´�
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
//���α׷��� �ӵ�, ������,
//���α׷��� ���� ���ɼ� ���� ���ο� �дٸ�
//���� ����� �����Ѵٸ�, ��͹������ٴ� ����͹����� ����� �����ϴ� ���� ����
unsigned int DoFactorial(unsigned int tN);

int main()
{
	int tResult = DoFactorial(33);
	cout << tResult << endl;

	return 0;
}
//�� ��� ������ ���丮�� �Լ�
//�� ��� ������ �����
//����
// i) ��� ������ ���ؼ� �Լ�ȣ�� ����� ���� ���
// ii) ��� ������ ���ؼ� ���� ���� �÷ο� stack overflow�� �Ͼ ���ɼ��� ����
//����
//i) ��� ������ ���ؼ� ������ ���� ��ٷӴ�
unsigned int DoFactorial(unsigned int tN)
{
	if (0 == tN)
	{
		return 1;
	}
	else
	{
		//������ ������ ��Ƶ� ����
		int tTemp = 1;
		//���ȣ�� ������ �ڵ�� �ݺ�������� �Ǿ���.
		for (int ti = tN; ti > 0; --ti)
		{
			tTemp = tTemp * ti;
		}

		return tTemp;
	}
}
*/