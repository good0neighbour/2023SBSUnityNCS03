
/*

    동적할당과 해제

*/

//unmanafed language
//언어 차원에서 동적할당된 메모리를 관리해주지 않는다

#include <iostream>
using namespace std;

class CUnit
{
private:    //해당 클래스 내에서만 접근가능
    int mX = 0;

public:
    CUnit();    //생성자
    ~CUnit();   //소멸자

public:     //어디서나 접근 가능
    void DisplayInfo();
};

int main()
{
    //new연산자를 이용하여 힙메모리에 동적할당으로 변수를 만든다.
    //이렇게 만들어진 변수는 이름이 없다.
    //new는 메모리의 주소값을 리턴함으로
    //포인터 변수에 그 값을 담아 간접참조로 해당 메모리를 다룬다.
    int* tpPtr = nullptr;
    tpPtr = new int;




    if (nullptr != tpPtr)
    {
        delete tpPtr;
        tpPtr = nullptr;
    }






    //CUnit tUnit;

    CUnit* tpUnit = nullptr;
    tpUnit = new CUnit;


    //(*tpUnit).DisplayInfo();
    tpUnit->DisplayInfo();  //포인터 멤버 접근 연산자


    if (nullptr != tpUnit)
    {
        delete tpUnit;
        tpUnit = nullptr;
    }




    return 0;
}
//생성자, 소멸자는 클래스 이름과 맞춰 만든다.
//          리턴타입이 아예 없다
//          생성자<-- 객체가 생성될 때 자동으로 호출된다.
//          소멸자<-- 객체가 소멸될 때 자동으로 호출된다.
//작성자가 명시적으로 만들지 않으면, 컴파일러다 만든다.
CUnit::CUnit()
{
    cout << "생성자" << endl;
}
CUnit::~CUnit()
{
    cout << "소멸자" << endl;
}

void CUnit::DisplayInfo()
{
    cout << mX << endl;
}