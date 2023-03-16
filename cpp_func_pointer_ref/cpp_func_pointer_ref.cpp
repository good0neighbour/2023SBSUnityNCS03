
#include <iostream>
using namespace std;

void DoSwap(int tA, int tB);

void DoSwapPtr(int* tA, int* tB);

void DoSwapRef(int& tA, int& tB);

int main()
{
    int tA = 3;
    int tB = 2;

    //before
    cout << "tA: " << tA << endl;
    cout << "tB: " << tB << endl;

    //DoSwap(tA, tB);
    //DoSwapPtr(&tA, &tB);
    DoSwapRef(tA, tB);

    //after
    cout << "tA: " << tA << endl;
    cout << "tB: " << tB << endl;
}
//함수가 매개변수를 넘기는 기본방식이 call by value이기 때문이다.
void DoSwap(int tA, int tB)
{
    int tTemp = 0;
    tTemp = tA;
    tA = tB;
    tB = tTemp;
}
//call by address(pointer)
void DoSwapPtr(int* tA, int* tB)   //* 포인터 변수임을 알리는 기호
{
    int tTemp = 0;
    tTemp = *tA;    //* 간접참조
    *tA = *tB;
    *tB = tTemp;
}

//call by reference
void DoSwapRef(int& tA, int& tB)
{
    int tTemp = 0;
    tTemp = tA;
    tA = tB;
    tB = tTemp;
}