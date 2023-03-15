

#include <iostream>

using namespace std;

void DoSwap(int&, int&);

int main()
{
    int tA = 3;
    int tB = 2;

    //before
    cout << tA << endl;
    cout << tB << endl;

    //두 정수의 값을 교환
    DoSwap(tA, tB);


    //after
    cout << endl;
    cout << tA << endl;
    cout << tB << endl;

    return 0;
}
//함수가 매개변수를 넘기는 기본방식은 call by value다.

void DoSwap(int& tA, int& tB)
{
    //두 정수의 값을 교환
    int tTemp = 0;
    tTemp = tA;
    tA = tB;
    tB = tTemp;
}