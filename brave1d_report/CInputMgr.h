#pragma once

//클래스 전방 선언
class CBrave;

//사용자 입력을 관리하는 클래스
class CInputMgr
{
private:
	//오직 한 인스턴스만 필요하기 때문에 싱글턴 패턴 적용
	static CInputMgr* mInstance;

private:
	//외부에서 임의로 객체 생성하는 것을 방지하기 위해 생성자를 은닉화
	CInputMgr();
	//생성자 은닉화와 통일성을 맞추기 위해 소멸자도 은닉화
	~CInputMgr();

public:
	//사용자의 키보드 입력에 대한 처리를 추상화
	//게임 루프 종료 여부를 전달하기 위해 bool을 반환
	bool KeyInput(char tMoveDir, CBrave* tBrave);
	//인스턴스에 접근하게 해줄 함수
	static CInputMgr* GetInstance();
	//인스턴스 해제 함수
	static void ReleaseInstance();
};

