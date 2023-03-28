// ga_fsm.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>
using namespace std;

//상태 분류
enum
{
    STATE_IDLE = 0, //대기상태
    STATE_ATTACK    //공격상태
};

//상태에 짜른 임의의 행동
//대기 행동
void DoIdle()
{
    cout << "do idle" << endl;
}
//공격행동
void DoAttack()
{
    cout << "do ATTACK" << endl;
}

int main()
{
    //상태를 나타낸는 변수
    int tState = STATE_IDLE;

    //상태를 변경했다고 가정
    tState = STATE_IDLE;

    //아래의 구문은 조건문을 모두 평가한다
    //상태에 따른 행동 실행
    if (STATE_IDLE == tState)
    {
        DoIdle();
    }

    if (STATE_ATTACK == tState)
    {
        DoAttack();
    }



    tState = STATE_IDLE;
    //if~ else if ~ else 조건문리 참이 될때까지는 모두 조건문 평가,
    //만약 참인 경우가 있다면 그 절을 수행하고 전체구조를 바로 빠져나감
    //<-- 그러므로 위의 구문보다 연산을 더 적게 수행할 가능성이 크다.
    if (STATE_IDLE == tState)
    {
        DoIdle();
    }
    else if (STATE_ATTACK == tState)
    {
        DoAttack();
    }



    tState = STATE_IDLE;
    //아래 구문은 바로 해당하는 라벨로 가서 그 절을 수행한 후 break를 만나면 전체구조를 빠져나간다.
    //<-- 그러므로 위의 if~else if~else 보다 연산이 더 적은 것이다.
    switch (tState)
    {
    case STATE_IDLE:
    {
        DoIdle();
    }
    break;
    case STATE_ATTACK:
    {
        DoAttack();
    }
    break;
    }





    typedef void (*CFuncPtr)();
    //함수 참조 테이블 개념을 이용하여
    //아래의 상태에 따른 행동 코드를 작성
    CFuncPtr tArray[2] = {DoIdle, DoAttack};
    /*
        
        <-- 위의 switch구문과 이것을 비교해보면
        
        속도면에서는 동일하다고 볼 수 있다. O(1)

        
        코드의 관리 유연성 측면에서 보면
        switch구문은 상태나 상태에 따른 행동의 추가, 변경, 삭제에 때해
        해당 문단 전체를 들여다봐야 하는 단점이 있다.
        반면에
        함수 참조 테이블을 이용한 방식은
        행동의 추가, 변경, 삭제는
        해당 상태(에 따른 행동)에 대응하는 함수를 만들고
        함수 등록 부분을 수정하면 되므로
        방법이 정형화되어있다.
        그러므로 추가, 변경, 삭제에 유연하다
        <-- 호출 부분은 동일한 형태로 추상화되어 있다
    */


    //상태 변경
    tState = STATE_IDLE;
    //상태에 따른 행동
    tArray[tState]();


    //상태 변경
    tState = STATE_ATTACK;
    //상태에 따른 행동
    tArray[tState]();

    return 0;
}