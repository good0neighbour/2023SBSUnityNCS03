#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"

/*
	software renderer를 심플하게 작성해보자.

	<-- 렌더링 파이프라인의 심화이해( 벡터, 행렬 개념 포함 )




	행벡터를 기준으로 한다
*/

#include <vector>//가변배열
using namespace std;

//3차원 공간에서 벡터와 위치(정점)를 다루기 위해 정의
struct SRyuVector3
{
	float x = 0.0f;
	float y = 0.0f;
	float z = 0.0f;
};
//삼각형: 정점 3개로 이루어진 도형이다.
struct SRyuTriangle
{
	SRyuVector3 p[3];
};
//메쉬: 삼각형의 모음(정점들의 모음)
struct SRyuMesh
{
	vector<SRyuTriangle> tris;
	//<--복사본으로 삼각형을 다루기 위해서 참조를 사용하지 않았다
};


// Override base class with your custom functionality
class Example : public olc::PixelGameEngine
{
public:
	Example()
	{
		// Name your application
		sAppName = "Example";
	}

public:
	bool OnUserCreate() override
	{
		// Called once at the start, so create things here
		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{
		this->Clear(olc::VERY_DARK_BLUE);

		//---렌더링 파이프라인---
		SRyuMesh tMesh;
		tMesh.tris =
		{
			//윈도우 좌표계 기준: 정점 나열 순서는 CCW Count Clock Wise 반시계방향
			//( 수학에서 좌표계 기준: 정점 나열 순서는 CW Clock Wise 시계방향 )
			{0.0f, 0.0f, 0.0f,	0.0f, 1.0f, 0.0f,	1.0f, 0.0f, 0.0f}
		};

		//--기하단계--

		//월드변환

		//scale 변환
		float tScaleScalar = 100.0f;
		float tMatScale[4][4] = { 0.0f };
		tMatScale[0][0] = 1.0f * tScaleScalar;
		tMatScale[1][1] = 1.0f * tScaleScalar;
		tMatScale[2][2] = 1.0f * tScaleScalar;
		tMatScale[3][3] = 1.0f;
		//스케일 변환 행렬을 적용한 결과 정점
		SRyuMesh tMeshScale;
		tMeshScale.tris =
		{
			{0.0f, 0.0f, 0.0f,	0.0f, 0.0f, 0.0f,	0.0f, 0.0f, 0.0f}
		};

		for (int ti = 0; ti < tMesh.tris.size(); ++ti)
		{
			MultiplyMatrixVector(tMesh.tris[ti].p[0], tMeshScale.tris[ti].p[0], tMatScale);
			MultiplyMatrixVector(tMesh.tris[ti].p[1], tMeshScale.tris[ti].p[1], tMatScale);
			MultiplyMatrixVector(tMesh.tris[ti].p[2], tMeshScale.tris[ti].p[2], tMatScale);
		}



		
		//뷰변환


		//투영변환


		//---래스터라이즈단계---
		for (auto t : tMeshScale.tris)
		{
			DrawTriangle(
				t.p[0].x, t.p[0].y,
				t.p[1].x, t.p[1].y,
				t.p[2].x, t.p[2].y
				);
		}


		return true;
	}
	// Mij = 시그마 Aik * Bkj
	//행벡터와 행렬의 곱셈
	void MultiplyMatrixVector(SRyuVector3& tIn, SRyuVector3& tOut, float tM[][4])
	{
		tOut.x = tIn.x * tM[0][0] + tIn.y * tM[1][0] + tIn.z * tM[2][0] + 1.0f * tM[3][0];
		tOut.y = tIn.x * tM[0][1] + tIn.y * tM[1][1] + tIn.z * tM[2][1] + 1.0f * tM[3][1];
		tOut.z = tIn.x * tM[0][2] + tIn.y * tM[1][2] + tIn.z * tM[2][2] + 1.0f * tM[3][2];

		float tW = tIn.x * tM[0][3] + tIn.y * tM[1][3] + tIn.z * tM[2][3] + 1.0f * tM[3][3];
		//왜곡된 동간 보정
		if (tW != 0.0f)
		{
			tOut.x = tOut.x / tW;
			tOut.y = tOut.y / tW;
			tOut.z = tOut.z / tW;
		}
	}

};

int main()
{
	Example demo;
	if (demo.Construct(320, 240, 2, 2))
		demo.Start();
	return 0;
}