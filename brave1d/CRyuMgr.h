#pragma once


//용사의 플레이 데이터를 관리하는 매니저 역할의 클래스

/*
	다음의 세 가지 구성을 결합하여 만든다

	i) static을 적용한 해당 클래스 타입의 포인터 변수 mpInstance를 만든다.
	ii) 생성자는 public이 아니다
	iii) GetInstance() 함수의 정의에는 객체의 최대생성개수를 1개로 제한다는 판단제어구조를 위치한다.
*/

class CRyuMgr
{
private:
	static CRyuMgr* mpInstance;// = nullptr;

	//외부에서의 생성 표현을 막는다
private:
	CRyuMgr();
	~CRyuMgr();

public:
	//static예약어를 적용하였으므로 표기법상으로는 멤버함수지만, 전역함수의 성격을 가진다
	static CRyuMgr* GetInstance();
	static void ReleaseInstance();


public:
	//용사의 경험치
	int mExp = 0;
};

