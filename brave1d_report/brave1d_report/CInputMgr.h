#pragma once

//클래스 전방 선언
class CBrave;
class CSlime;
class CUIPlay;

//사용자 입력을 관리하는 클래스
class CInputMgr
{
private:
	//오직 한 인스턴스만 필요하기 때문에 싱글턴 패턴 적용
	static CInputMgr* mInstance;
	//main 스크립트로부터 콘솔 표시용 객체를 참조해오기 위함
	CUIPlay* mUI;

private:
	//외부에서 임의로 객체 생성하는 것을 방지하기 위해 생성자를 은닉화
	//콘솔 표시용 클래스를 새로 생성하지 않기 위해 기존에 있던 것을 tUI로 참조
	CInputMgr(CUIPlay* tUI);
	//생성자 은닉화와 통일성을 맞추기 위해 소멸자도 은닉화
	~CInputMgr();

public:
	//사용자의 키보드 입력에 대한 처리를 추상화
	//게임 루프 종료 여부를 전달하기 위해 bool을 반환
	bool KeyInput(char tMoveDir, CBrave* tBrave);
	//전투 전용 함수
	//매개변수가 더 필요해서 함수를 오버로드한다.
	bool KeyInput(char tMoveDir, CBrave* tBrave, CSlime* tSlime);
	//처음 생성시 반드시 호출할 것, 오버로드
	static CInputMgr* GetInstance(CUIPlay* tUI);
	//인스턴스에 접근하게 해줄 함수
	static CInputMgr* GetInstance();
	//인스턴스 해제 함수
	static void ReleaseInstance();
};

