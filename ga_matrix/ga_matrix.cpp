
/*
    행렬의 개념과 연산에 대하
    코드로 표현해보자

    3by3 정방행렬을 가정
    <--2D를 다룬다고 가정

*/


#include <iostream>
using namespace std;

//행렬의 정의: 행과 열로 구성된 격자 안에 스칼라를 나열
//3by3 정방행렬
struct SMatrix3x3
{
    float m[3][3];
};

//행렬 출력
void DisplayMatrix(SMatrix3x3& tMat)
{
    for (int tRow = 0; tRow < 3; ++tRow)
    {
        for (int tCol = 0; tCol < 3; ++tCol)
        {
            cout << tMat.m[tRow][tCol] << "\t";
        }
        cout << endl;
    }
}


void ZeroMatrix(SMatrix3x3& tMat)
{
    for (int tRow = 0; tRow < 3; ++tRow)
    {
        for (int tCol = 0; tCol < 3; ++tCol)
        {
            tMat.m[tRow][tCol] = 0.0f;
        }
    }
}
//단위행렬
void Identity(SMatrix3x3& tMat)
{
    tMat.m[0][0] = 1.0f;    tMat.m[0][1] = 0.0f;    tMat.m[0][2] = 0.0f;
    tMat.m[1][0] = 0.0f;    tMat.m[1][1] = 1.0f;    tMat.m[1][2] = 0.0f;
    tMat.m[2][0] = 0.0f;    tMat.m[2][1] = 0.0f;    tMat.m[2][2] = 1.0f;
}

//행렬끼리의 곱셈
void MultiplyMatrix(SMatrix3x3& tResult, SMatrix3x3& tA, SMatrix3x3& tB)
{
    //Mij = 시그마 Aik * Bkj
    /*
    tResult.m[][] = tA.m[][] * tB.m[][] +
                    tA.m[][] * tB.m[][] +
                    tA.m[][] * tB.m[][]
                    */
}



int main()
{
    return 0;
}