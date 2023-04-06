

//우선순위큐
//우선순위큐의 특징은 데이터를 입력하면 자동으로 정렬된 상태가 된다.
// 우선순위큐는 힙 자료구조로 만들어진다 ( 힙은 완전이진트리로 만들어진다 )
//  오름차순 --> 최소힙
//  내림차순 --> 최대힙

//<-- STL의 컨테이너 중 priority_queue가 바로 우선순위큐를 타입에 일반화시켜 만들어 둔 것이다.


//step_1
//응용 사용법

#include <iostream>
#include <queue>
using namespace std;

//사각형의 넓이를 기준으로 정렬되어 나오게 하자.

class CRyuRect
{
private:
	int mWidth = 0;		//가로
	int mHeight = 0;	//세로

public:
	//매개변수 있는 생정자
	CRyuRect(int tW, int tH)
		: mWidth(tW), mHeight(tH) //<--초기화 목록 문법
	{
		
	}

	void Render()
	{
		cout << "CRyuRect: " << mWidth << " * " << mHeight << " = " << mWidth * mHeight << endl;
	}

	//오름차순
	bool operator>(const CRyuRect& t) const
	{
		return this->mWidth * this->mHeight > t.mWidth * t.mHeight;
	}

	//내림차순
	bool operator<(const CRyuRect& t) const
	{
		return this->mWidth * this->mHeight < t.mWidth * t.mHeight;
	}
};

//오름차순
typedef priority_queue<CRyuRect, vector<CRyuRect>, greater<CRyuRect>> CPriorityQGreater;
//내림차순
typedef priority_queue<CRyuRect, vector<CRyuRect>, less<CRyuRect>> CPriorityQLess;

int main()
{
	//CPriorityQGreater tPriorityQ;
	CPriorityQLess tPriorityQ;

	CRyuRect tRect_0(1, 5);	//5
	CRyuRect tRect_1(7, 6);	//42
	CRyuRect tRect_2(1, 2);	//2
	CRyuRect tRect_3(8, 2);	//16

	tPriorityQ.push(tRect_0);
	tPriorityQ.push(tRect_1);
	tPriorityQ.push(tRect_2);
	tPriorityQ.push(tRect_3);

	//(1, 2), (1, 5), (8, 2), (7, 6)
	while (!tPriorityQ.empty())
	{
		CRyuRect t = tPriorityQ.top();
		tPriorityQ.pop();

		t.Render();
	}


	return 0;
}


















//step_0
//priority_queue 기본 사용법
//#include <iostream>
//#include <queue>
//using namespace std;
//
//int main()
//{
//    priority_queue<int> tPriorityQ; //기본 설정은 최대힙, 즉 내림차순
//
//    tPriorityQ.push(8);
//    tPriorityQ.push(1);
//    tPriorityQ.push(6);
//    tPriorityQ.push(2);
//
//    //원소가 하나라도 있다면
//    while (!tPriorityQ.empty())
//    {
//        cout << tPriorityQ.top() << endl;//8, 6, 2, 1
//        tPriorityQ.pop();
//    }
//
//
//    return 0;
//}