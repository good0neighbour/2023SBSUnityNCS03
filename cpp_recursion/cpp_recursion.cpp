/*
    재귀호출 recursion

*/

#include <iostream>
using namespace std;

//전체 구조에 포함된 부분구조가
//전체 구조와 형태가 같다면
//재귀호출로
//풀이가 가능하다.

unsigned int DoFactorial(unsigned int tN);

int main()
{
    int tResult = DoFactorial(4);
    cout << tResult << endl;

    return 0;
}

unsigned int DoFactorial(unsigned int tN)
{
    if ( 0 == tN )
    {
        //base case
        return 1;
    }
    else
    {
        //recursive case
        //함수 호출이란 함수의 정의부에 시작주소로 가서 함수의 내용을 실행하는 것이다
        //전역 함수이름은 여기서 주소로 나타낸다
        //그러므로, 컴파일러는 해당 함수호출을 해석가능하다.
        //그러므로, 자기자신을 호출하는 표현이 가능하다.
        return tN * DoFactorial(tN - 1);
    }
}