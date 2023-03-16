// cpp_pointer_array.cpp : 이 파일에는 'main' 함수가 포함됩니다. 거기서 프로그램 실행이 시작되고 종료됩니다.
//

#include <iostream>


//포인터 변수: '주소'를 '값'으로 가지는 '변수'

//원시배열: 동일한 타입의 원소들의 (물리적으로 )'연속적'인 메모리 블럭

//배열을 함수에 매개변수로 넘기는 표기방식
void DoChange(int tArray[][2], int tRow, int tCol, int tValue);

void DoChangePtr( int(*tpPtr)[2], int tRow, int tCol, int tValue);


void DoChange1D(int tArray[], int, int);

void DoChange1DPtr(int* tpPtr, int, int);

int main()
{
    //step_0 포인터 변수의 선언과 사용
    int tA = 7;

    //포인터 변수임을 선언
    int* tpA = nullptr;

    tpA = &tA;

    //간접참조
    *tpA = 777;

    std::cout << tA << std::endl;

    //step_1 원시배열
    int tArray[5] = { 777, 333, 1, 2, 3 };

    tArray[0] = 7;

    std::cout << std::endl;
    for (auto t : tArray)
    {
        std::cout << t << std::endl;
    }

    //포인터 증가 연산자, 간접참조
    //배열의 이름을 배열의 시작주소값이다.
    //<-- 포인터와 배열의 공통점은 주소값을 다룬다는 것이다.
    *(tArray + 1) = 9;

    std::cout << std::endl;
    for (auto t : tArray)
    {
        std::cout << t << std::endl;
    }


    //step_2 2차원 배열
    int tArray2D[3][2] =
    {
        { 1, 0 },
        { 0, 2 },
        { 0, 0 }
    };

    //임의접근 random access
    // 배열의 이름은 배열의 시작주소 값이다.
    //tArray2D[0][0] = 7;
    //DoChange(tArray2D, 0, 0, 7);
    DoChangePtr(tArray2D, 0, 0, 7);


    std::cout << std::endl;
    for (int ti = 0; ti < 3; ++ti)
    {
        for (int tj = 0; tj < 2; ++tj)
        {
            std::cout << tArray2D[ti][tj] << "\t";
        }

        std::cout << std::endl;
    }







    int tArray1D[3] = { 1, 2, 3 };

    //다음 한 줄을 함수로 만들어 프로그램 구조를 변경해보세요.
    //tArray1D[0] = 7;
    //DoChange1D(tArray1D, 0, 7);
    DoChange1DPtr(tArray1D, 0, 7);

    std::cout << std::endl;
    for (int ti = 0; ti < 3; ++ti)
    {
        std::cout << tArray1D[ti] << "\t";
    }



    return 0;
}
//포인터와 배열은 주소값을 다룬다는 공통점이 있다.
//다음 표기는 배열을 매개변수로 넘기는 표기이지만, 실상은 주소값을 다뤄 임의의 원소에 접근한다.
void DoChange(int tArray[][2], int tRow, int tCol, int tValue)
{
    tArray[tRow][tCol] = tValue;
}



void DoChangePtr(int(*tpPtr)[2], int tRow, int tCol, int tValue)
{
    //tpPtr[tRow][tCol] = tValue;

    int* tpRyu = *(tpPtr + tRow);   //2차원 수준에서 시작 주소값에 포인터증가 연산하여 간접참조
    *(tpRyu + tCol) = tValue;       //1차원 수준에서 포인터 증가 연산하여 간접참조
}



void DoChange1D(int tArray[], int tIndex, int tValue)
{
    tArray[tIndex] = tValue;
}

void DoChange1DPtr(int* tpPtr, int tIndex, int tValue)
{
    tpPtr[tIndex] = tValue;
}