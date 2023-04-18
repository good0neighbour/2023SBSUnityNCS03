
/*
    행렬의 개념과 연산에 대하
    코드로 표현해보자

    3by3 정방행렬을 가정
    <--2D를 다룬다고 가정

    //동차좌표 개념을 이용하기 위해
    //동차좌표 개념 이용이란? <-- n + 1차원의 힘을 발어 n차원의 임의의 개념을 설명한다
*/



#include <iostream>
#include <cmath>
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


void Zero(SMatrix3x3& tMat)
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
    for (int tRow = 0; tRow < 3; ++tRow)
    {
        for (int tCol = 0; tCol < 3; ++tCol)
        {
            tResult.m[tRow][tCol] = tA.m[tRow][0] * tB.m[0][tCol] +
                                    tA.m[tRow][1] * tB.m[1][tCol] +
                                    tA.m[tRow][2] * tB.m[2][tCol];
        }
    }
}

//행렬식: 임의의 행렬의 스칼라 평가값
//  여인수 전개(라플라스 전개)에 의한 방식으로 구하자.
float Determinent(SMatrix3x3& tM)
{
    float tDet = 0.0f;

    tDet = tM.m[0][0] * (tM.m[1][1] * tM.m[2][2] - tM.m[1][2] * tM.m[2][1]) -
           tM.m[1][0] * (tM.m[0][1] * tM.m[2][2] - tM.m[0][2] * tM.m[2][1]) +
           tM.m[2][0] * (tM.m[0][1] * tM.m[1][2] - tM.m[0][2] * tM.m[1][1]);

    return tDet;
}

//역행렬
//  A^-1 = (1 / detA) * adjA
// 
//      adjA구하기: i)전치, ii)여인수행렬
// 
//역행렬이 존재하지 않는 경우를 고려하여 행렬식 값을 리턴하도록 설계
float Invert(SMatrix3x3& tResult, SMatrix3x3& tM)
{
    float tDet = 0.0f;

    tDet = Determinent(tM);
    //가역이 아닌지 검사
    if (abs(tDet - 0.0f) < FLT_EPSILON)
    {
        cout << "역행렬이 존재하지 않는다" << endl;
        return tDet;
    }

    //행렬식 값이 0이 아니므로 역행렬을 구한다

    float iDet = 1.0f / tDet;

    tResult.m[0][0] = (tM.m[1][2] * tM.m[2][2] - tM.m[2][1] * tM.m[1][2]) * iDet;
    tResult.m[0][1] = (tM.m[2][1] * tM.m[0][2] - tM.m[0][1] * tM.m[2][2]) * iDet;
    tResult.m[0][2] = (tM.m[0][1] * tM.m[1][2] - tM.m[1][1] * tM.m[0][2]) * iDet;

    tResult.m[1][0] = (tM.m[2][0] * tM.m[1][2] - tM.m[1][0] * tM.m[2][2]) * iDet;
    tResult.m[1][1] = (tM.m[0][0] * tM.m[2][2] - tM.m[2][0] * tM.m[0][2]) * iDet;
    tResult.m[1][2] = (tM.m[0][2] * tM.m[1][0] - tM.m[0][0] * tM.m[1][2]) * iDet;

    tResult.m[2][0] = (tM.m[1][0] * tM.m[2][1] - tM.m[2][0] * tM.m[1][1]) * iDet;
    tResult.m[2][1] = (tM.m[0][1] * tM.m[2][0] - tM.m[0][0] * tM.m[2][1]) * iDet;
    tResult.m[2][2] = (tM.m[0][0] * tM.m[1][1] - tM.m[0][1] * tM.m[1][0]) * iDet;

    return tDet;
}



int main()
{
    SMatrix3x3 tMatA;
    //영행렬로 설정
    Zero(tMatA);
    DisplayMatrix(tMatA);

    cout << endl;
    //단위행렬로 설정
    Identity(tMatA);
    DisplayMatrix(tMatA);

    //행렬끼리의 곱셈
    SMatrix3x3 tMatResult;
    Zero(tMatResult);

    /*
        |1 0||1 1|  =   |1 1|
        |1 2||0 0|      |1 1|
    */
    //X행렬
    SMatrix3x3 tX =
    {
        1.0f, 0.0f, 0.0f,
        1.0f, 2.0f, 0.0f,
        0.0f, 0.0f, 0.0f
    };
    //Y행렬
    SMatrix3x3 tY =
    {
        1.0f, 1.0f, 0.0f,
        0.0f, 0.0f, 0.0f,
        0.0f, 0.0f, 0.0f
    };

    cout << endl;
    MultiplyMatrix(tMatResult, tX, tY);
    DisplayMatrix(tMatResult);



    return 0;
}