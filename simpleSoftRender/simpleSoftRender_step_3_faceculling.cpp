#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"

/*
	step_3_faceculling

	은면제거 hidden face culling
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
	float mTheta = 0.0f;

public:
	Example()
	{
		// Name your application
		sAppName = "Example";
	}

public:
	bool OnUserCreate() override
	{
		//test
		SRyuTriangle t;	//삼각형을 하나 가정하자
		SRyuVector3 tLineA;	//A벡터
		SRyuVector3 tLineB;	//B벡터

		t.p[0] = { 0.0f, 0.0f, 0.0f };
		t.p[1] = { 0.0f, 1.0f, 0.0f };
		t.p[2] = { 1.0f, 1.0f, 0.0f };

		tLineA.x = t.p[1].x - t.p[0].x;
		tLineA.y = t.p[1].y - t.p[0].y;
		tLineA.z = t.p[1].z - t.p[0].z;

		tLineB.x = t.p[2].x - t.p[0].x;
		tLineB.y = t.p[2].y - t.p[0].y;
		tLineB.z = t.p[2].z - t.p[0].z;

		SRyuVector3 tNormal = { 0 };
		//외적은 교환법칙이 성립하지 않는다

		//// A cross B
		//tNormal.x = tLineA.y * tLineB.z - tLineA.z * tLineB.y;
		//tNormal.y = tLineA.z * tLineB.x - tLineA.x * tLineB.z;
		//tNormal.z = tLineA.x * tLineB.y - tLineA.y * tLineB.x;

		// B cross A
		tNormal.x = tLineB.y * tLineA.z - tLineB.z * tLineA.y;
		tNormal.y = tLineB.z * tLineA.x - tLineB.x * tLineA.z;
		tNormal.z = tLineB.x * tLineA.y - tLineB.y * tLineA.x;


		//외적벡터의 크기를 구하자
		float tDotThis = tNormal.x* tNormal.x + tNormal.y * tNormal.y + tNormal.z * tNormal.z;
		float tLength = sqrtf(tDotThis);
		//외적벡터의 정규화
		tNormal.x = tNormal.x / tLength;
		tNormal.y = tNormal.y / tLength;
		tNormal.z = tNormal.z / tLength;

		//char tszTemp[256] = { 0 };
		printf("tNormal: %f, %f, %f\n", tNormal.x, tNormal.y, tNormal.z);


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
			//south
			{ 0.0f, 0.0f, 0.0f,			0.0f, 1.0f, 0.0f,		1.0f, 1.0f, 0.0f },
			{ 0.0f, 0.0f, 0.0f,			1.0f, 1.0f, 0.0f,		1.0f, 0.0f, 0.0f },

			//east
			{ 1.0f, 0.0f, 0.0f,			1.0f, 1.0f, 0.0f,		1.0f, 1.0f, 1.0f },
			{ 1.0f, 0.0f, 0.0f,			1.0f, 1.0f, 1.0f,		1.0f, 0.0f, 1.0f },

			//north
			{ 1.0f, 0.0f, 1.0f,			1.0f, 1.0f, 1.0f,		0.0f, 1.0f, 1.0f },
			{ 1.0f, 0.0f, 1.0f,			0.0f, 1.0f, 1.0f,		0.0f, 0.0f, 1.0f },

			//west
			{ 0.0f, 0.0f, 1.0f,			0.0f, 1.0f, 1.0f,		0.0f, 1.0f, 0.0f },
			{ 0.0f, 0.0f, 1.0f,			0.0f, 1.0f, 0.0f,		0.0f, 0.0f, 0.0f },

			//top 
			{ 0.0f, 1.0f, 0.0f,			0.0f, 1.0f, 1.0f,		1.0f, 1.0f, 1.0f },
			{ 0.0f, 1.0f, 0.0f,			1.0f, 1.0f, 1.0f,		1.0f, 1.0f, 0.0f },

			//bottom
			{ 0.0f, 0.0f, 1.0f,			0.0f, 0.0f, 0.0f,		1.0f, 0.0f, 0.0f },
			{ 0.0f, 0.0f, 1.0f,			1.0f, 0.0f, 0.0f,		1.0f, 0.0f, 1.0f }
		};

		//--기하단계--

		//월드변환

		//scale 변환 행렬
		float tScaleScalar = 1.0f;//100.0f;

		float tMatScale[4][4] = { 0.0f };
		tMatScale[0][0] = 1.0f * tScaleScalar;
		tMatScale[1][1] = 1.0f * tScaleScalar;
		tMatScale[2][2] = 1.0f * tScaleScalar;
		tMatScale[3][3] = 1.0f;
		//스케일 변환 행렬을 적용한 결과 정점
		SRyuMesh tMeshScale;
		tMeshScale.tris = tMesh.tris;

		for (int ti = 0; ti < tMesh.tris.size(); ++ti)
		{
			MultiplyMatrixVector(tMesh.tris[ti].p[0], tMeshScale.tris[ti].p[0], tMatScale);
			MultiplyMatrixVector(tMesh.tris[ti].p[1], tMeshScale.tris[ti].p[1], tMatScale);
			MultiplyMatrixVector(tMesh.tris[ti].p[2], tMeshScale.tris[ti].p[2], tMatScale);
		}




		mTheta = mTheta + 1.0f * fElapsedTime;

		//회전변환행렬
		////z축 회전
		//float tMatRotate[4][4] = { 0.0f };
		//tMatRotate[0][0] = cosf(mTheta);
		//tMatRotate[1][1] = cosf(mTheta);
		//tMatRotate[0][1] = sinf(mTheta);
		//tMatRotate[1][0] = -1.0f * sinf(mTheta);
		//tMatRotate[2][2] = 1.0f;
		//tMatRotate[3][3] = 1.0f;
		////x축 회전
		//float tMatRotate[4][4] = { 0.0f };
		//tMatRotate[0][0] = 1.0f;
		//tMatRotate[1][1] = cosf(mTheta);
		//tMatRotate[1][2] = sinf(mTheta);
		//tMatRotate[2][1] = -1.0f * sinf(mTheta);
		//tMatRotate[2][2] = cosf(mTheta);
		//tMatRotate[3][3] = 1.0f;
		//y축 회전
		float tMatRotate[4][4] = { 0.0f };
		tMatRotate[0][0] = cosf(mTheta);
		tMatRotate[0][2] = -1.0f * sinf(mTheta);
		tMatRotate[1][1] = 1.0f;
		tMatRotate[2][0] = sinf(mTheta);
		tMatRotate[2][2] = cosf(mTheta);
		tMatRotate[3][3] = 1.0f;
		//스케일 변환 행렬을 적용한 결과 정점
		SRyuMesh tMeshRotate;
		tMeshRotate.tris = tMeshScale.tris;

		for (int ti = 0; ti < tMeshScale.tris.size(); ++ti)
		{
			MultiplyMatrixVector(tMeshScale.tris[ti].p[0], tMeshRotate.tris[ti].p[0], tMatRotate);
			MultiplyMatrixVector(tMeshScale.tris[ti].p[1], tMeshRotate.tris[ti].p[1], tMatRotate);
			MultiplyMatrixVector(tMeshScale.tris[ti].p[2], tMeshRotate.tris[ti].p[2], tMatRotate);
		}

		//이동변환
		float tMatTranslate[4][4] = { 0.0f };
		tMatTranslate[0][0] = 1.0f;
		tMatTranslate[1][1] = 1.0f;
		tMatTranslate[2][2] = 1.0f;
		tMatTranslate[3][3] = 1.0f;

		tMatTranslate[3][2] = 3.0f;	//z축 양의 방향으로 5만큼 이동

		//이동변환 변환 행렬을 적용한 결과 정점
		SRyuMesh tMeshTranslate;
		tMeshTranslate.tris = tMeshRotate.tris;

		for (int ti = 0; ti < tMeshRotate.tris.size(); ++ti)
		{
			MultiplyMatrixVector(tMeshRotate.tris[ti].p[0], tMeshTranslate.tris[ti].p[0], tMatTranslate);
			MultiplyMatrixVector(tMeshRotate.tris[ti].p[1], tMeshTranslate.tris[ti].p[1], tMatTranslate);
			MultiplyMatrixVector(tMeshRotate.tris[ti].p[2], tMeshTranslate.tris[ti].p[2], tMatTranslate);
		}




		
		//뷰변환


		//투영변환
		
		//float tNear = 0.7f;
		//float tFar = 1.0;
		//float tR = 1.0f * 0.5f;
		//float tL = -1.0f * 1.0f * 0.5f;
		//float tT = 0.5f * 0.5f;
		//float tB = -1.0f * 0.5f * 0.5f;

		////단위행렬로 일단 만들자
		//float tMatProj[4][4] = { 0.0f };
		////tMatProj[0][0] = 1.0f;
		////tMatProj[1][1] = 1.0f;
		////tMatProj[2][2] = 1.0f;
		////tMatProj[3][3] = 1.0f;
		//tMatProj[0][0] = (2.0f * tNear) / (tR - tL);
		//tMatProj[1][1] = (2.0f * tNear) / (tT - tB);
		//tMatProj[2][2] = (-1.0f * (tFar + tNear)) / (tFar - tNear);
		//tMatProj[3][2] = -2.0f * tNear * (tFar / (tFar - tNear));
		////tMatProj[2][3] = -1.0f;
		////카메라가 바라보는 방향이 z축 양의 방향이라고 가정한다
		//tMatProj[2][3] = 1.0f;//<---그래서 -1에서 1로 수정
		//tMatProj[3][3] = 0.0f;

		//tMatProj[2][0] = (tR + tL) / (tR - tL);
		//tMatProj[2][1] = (tT + tB) / (tT - tB);



		//'시야각'과 '종행비'를 고려하여 수정한 버전

		//시야각 FOV Field Of View
		float tFov = 90.0f;	//<--degree
		float tFovRad = 1.0f / tanf((tFov * 0.5f) * (3.14159f / 180.0f));//<--radian

		//종횡비 AspectRatio
		float tAspectRatio = (float)ScreenHeight() / (float)ScreenWidth();

		float tNear = 0.7f;
		float tFar = 100.0f;
		//float tR = 1.0f * 0.5f;
		//float tL = -1.0f * 1.0f * 0.5f;
		//float tT = 0.5f * 0.5f;
		//float tB = -1.0f * 0.5f * 0.5f;

		float tMatProj[4][4] = { 0.0f };
		tMatProj[0][0] = tAspectRatio * tFovRad;
		tMatProj[1][1] = tFovRad;	//<-- (2 * n) / (t - b) = tFovRad
		tMatProj[2][2] = (-1.0f * (tFar + tNear)) / (tFar - tNear);
		tMatProj[3][2] = -2.0f * tNear * (tFar / (tFar - tNear));

		tMatProj[2][3] = 1.0f;//<---그래서 -1에서 1로 수정
		tMatProj[3][3] = 0.0f;

		//tMatProj[2][0] = (tR + tL) / (tR - tL);	//<--사실 0이다
		//tMatProj[2][1] = (tT + tB) / (tT - tB);	//<--사실 0이다


		//투영 변환 행렬을 적용한 결과 정점
		SRyuMesh tMeshProj;
		tMeshProj.tris = tMeshTranslate.tris;

		for (int ti = 0; ti < tMeshTranslate.tris.size(); ++ti)
		{
			//---임의의 삼각형의 법선 벡터 구하기 ---
			SRyuTriangle t = tMeshTranslate.tris[ti];	//삼각형을 하나 가정하자
			SRyuVector3 tLineA;	//A벡터
			SRyuVector3 tLineB;	//B벡터

			tLineA.x = t.p[1].x - t.p[0].x;
			tLineA.y = t.p[1].y - t.p[0].y;
			tLineA.z = t.p[1].z - t.p[0].z;

			tLineB.x = t.p[2].x - t.p[0].x;
			tLineB.y = t.p[2].y - t.p[0].y;
			tLineB.z = t.p[2].z - t.p[0].z;

			SRyuVector3 tNormal = { 0 };
			
			// B cross A
			tNormal.x = tLineB.y * tLineA.z - tLineB.z * tLineA.y;
			tNormal.y = tLineB.z * tLineA.x - tLineB.x * tLineA.z;
			tNormal.z = tLineB.x * tLineA.y - tLineB.y * tLineA.x;


			//외적벡터의 크기를 구하자
			float tDotThis = tNormal.x * tNormal.x + tNormal.y * tNormal.y + tNormal.z * tNormal.z;
			float tLength = sqrtf(tDotThis);
			//외적벡터의 정규화
			tNormal.x = tNormal.x / tLength;
			tNormal.y = tNormal.y / tLength;
			tNormal.z = tNormal.z / tLength;

			//---시선벡터 view vector( camera vector )---
			SRyuVector3 tViewVector;



			//은면(후면)이 아니면 렌더링한다( 은면(후면)이면 렌더링하지 않는다 )



			//투영변환 행렬 적용
			MultiplyMatrixVector(tMeshTranslate.tris[ti].p[0], tMeshProj.tris[ti].p[0], tMatProj);
			MultiplyMatrixVector(tMeshTranslate.tris[ti].p[1], tMeshProj.tris[ti].p[1], tMatProj);
			MultiplyMatrixVector(tMeshTranslate.tris[ti].p[2], tMeshProj.tris[ti].p[2], tMatProj);

			//뷰포트 변환
			//스크린 공간의 가운데를 원점으로 삼는다
			tMeshProj.tris[ti].p[0].x += 1.0f;
			tMeshProj.tris[ti].p[0].y += 1.0f;

			tMeshProj.tris[ti].p[1].x += 1.0f;
			tMeshProj.tris[ti].p[1].y += 1.0f;

			tMeshProj.tris[ti].p[2].x += 1.0f;
			tMeshProj.tris[ti].p[2].y += 1.0f;
			//정규 뷰 볼륨의 근평면에 각각의 축의 부호방향으로 스케일업한다.
			//<--스크린 공간 전체를 뷰포트로 보고 정규 뷰 볼륨의 근평면에 대응시켰다.
			tMeshProj.tris[ti].p[0].x *= 0.5f * ScreenWidth();
			tMeshProj.tris[ti].p[0].y *= 0.5f * ScreenHeight();

			tMeshProj.tris[ti].p[1].x *= 0.5f * ScreenWidth();
			tMeshProj.tris[ti].p[1].y *= 0.5f * ScreenHeight();

			tMeshProj.tris[ti].p[2].x *= 0.5f * ScreenWidth();
			tMeshProj.tris[ti].p[2].y *= 0.5f * ScreenHeight();

		}

		//---래스터라이즈단계---
		for (auto t : tMeshProj.tris)
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