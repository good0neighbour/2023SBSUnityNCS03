
#include <iostream>

using namespace std;

//함수 function: 기능 부품,
//<-- 코드의 추상화

//함수 사용의 3단계: 선언, 정의, 호출
//
//선언: 호출 측에 함수의 형태를 알리는 것
//정의: 실제 함수의 동작을 만드는 것
//호출: 함수를 실행하여 사용하는 것

int DoAddictive(int, int);
int DoMinus(int, int);
int DoMultiply(int, int);
float DoDevide(float, float);

int main()
{
    int tA = 3;
    int tB = 2;

    int tResult = 0;


    //정수의 사칙연산
    //더하기
    tResult = DoAddictive(tA, tB);//tA + tB;
    cout << "+의 결과값: " << tResult << endl;

    //빼기
    tResult = DoMinus(tA, tB);//tA - tB;
    cout << "-의 결과값: " << tResult << endl;

    //곱하기
    tResult = DoMultiply(tA, tB);//tA * tB;
    cout << "*의 결과값: " << tResult << endl;

    //나누기
    float tResultF = 0.0f;
    tResultF = DoDevide((float)tA, (float)tB);//(float)tA / (float)tB;
    //형변환 type cast 타입규칙을 잠깐 바꾼다.
    cout << "/의 결과값: " << tResultF << endl;




    return 0;
}



int DoAddictive(int tA, int tB)
{
    int tResult = 0;

    tResult = tA + tB;

    return tResult;
}
int DoMinus(int tA, int tB)
{
    int tResult = 0;

    tResult = tA - tB;

    return tResult;
}
int DoMultiply(int tA, int tB)
{
    int tResult = 0;

    tResult = tA * tB;

    return tResult;
}
float DoDevide(float tA, float tB)
{
    float tResult = 0.0f;

    tResult = tA / tB;

    return tResult;
}