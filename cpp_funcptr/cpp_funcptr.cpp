
/*
    int tA = 3;     //직접참조

    int* tpA = &tA;
    *tpA = 7;       //간접참조
    
    함수 포인터

*/

#include <iostream>
using namespace std;


/*
    프로그램 실행파일( 디스크 ) --> 프로세스(메모리)

    프로세스는 메모리를
    프로세스 주소공간으로 다룬다

    프로세스 주소공간

        코드:         우리가 작성한 코드
        데이터:       전역변수, static
        힙:           동적할당한 변수
        스택:         지역변수, 매개변수


    실행파일이란? 코드, 제이터에 들어있는 바이너리 데이터를 파일화한 것이다.
*/

int DoAddictive(int tA, int tB);

int main()
{
    int tResult = 0;
    tResult = DoAddictive(3, 2);        //직접호출
    cout << tResult << endl;



    int (*tpFunc)(int, int) = nullptr;  //함수 포인터 선언

    tpFunc = DoAddictive;               //전역함수의 이름은 함수정의부의 주소를 나타낸다


    tResult = tpFunc(5, 7);             //함수포인터를 이용한 간접호출
    cout << tResult << endl;


    typedef int (*FuncPtr)(int, int);   //FuncPtr은 이제 타입처럼 사용가능하다.

    FuncPtr tpPtr = nullptr;            //이제 tpPtr이 함수포인터

    tpPtr = DoAddictive;

    tResult = tpPtr(1, 2);
    cout << tResult << endl;


    return 0;
}


int DoAddictive(int tA, int tB)
{
    return tA + tB;
}