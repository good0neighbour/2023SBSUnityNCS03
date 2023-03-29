
#include <iostream>
using namespace std;
//여기서는 클래스의 멤버함수 포인터를 이용하여
//함수 참조 테이블을 만들어보겠다.

enum
{
    STATE_IDLE = 0,
    STATE_ATTACK
};

class CUnit
{
private:
    int mState = STATE_IDLE;
    //C++에서
    //클래스의 멤버함수는
    //전역함수의 호출의 기전이 조금 다르다( 한 번 더 찾아가야 한다 )
    //그래서 표기법도 다르다
    typedef void (CUnit::*CallFuncState)(); //멤버함수 포인터
    CallFuncState mArray[2] = {&CUnit::DoIdle, &CUnit::DoAttack};   //멤버함수 포인터를 이용한 함수의 참조테이블 구축

protected:
    void DoIdle();
    void DoAttack();

public:
    void SetState(int tState);  //상태 변경(설정)함수
    void Execute();             //상태에 따른 행동 액션 함수
};


int main()
{
    CUnit tUnit;

    tUnit.SetState(STATE_IDLE);
    tUnit.Execute();


    tUnit.SetState(STATE_ATTACK);
    tUnit.Execute();

    return 0;
}


void CUnit::DoIdle()
{
    cout << "DoIdle" << endl;
}
void CUnit::DoAttack()
{
    cout << "DoAttack" << endl;
}

void CUnit::SetState(int tState)
{
    mState = tState;
}
void CUnit::Execute()
{
    //어느 객체의 것이냐 this
    //한 번 더 참조 *
    (this->*mArray[mState])();

    //()함수 호출 연산자
}
//void CUnit::Execute()
//{
//    //관리하려는 코드의 줄수가 길어지면 길어질 수록
//    //버그가 발생할 확률은 당연히 높아진다.
//    //그래서 OOP에서는 이러한 switch구문을 경계한다.
//    switch (mState)
//    {
//    case STATE_IDLE:
//    {
//        DoIdle();
//    }
//    break;
//    case STATE_ATTACK:
//    {
//        DoAttack();
//    }
//    break;
//    }
//}