﻿#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"

/*
	step_8_frusturum_clip
	
	'시야절두체'의 평면들을 기준으로 클리핑clipping 처리
	(<-- 삼각형을 잘라내어 새로운 삼각형 목록을 만드는 것을 포함한다.)
*/

#include <vector>//가변배열
#include <algorithm>
using namespace std;


#include <fstream>		//file을 stream(흐르는 데이터) 개념으로 다룬다
#include <strstream>	//string을 stream(흐르는 데이터) 개념으로 다룬다

#include <math.h>


//3차원 공간에서 벡터와 위치(정점)를 다루기 위해 정의
struct SRyuVector3
{
	float x = 0.0f;
	float y = 0.0f;
	float z = 0.0f;
};

//벡터의 덧셈
SRyuVector3 operator+(const SRyuVector3& p, const SRyuVector3& q)
{
	SRyuVector3 t;

	t.x = p.x + q.x;
	t.y = p.y + q.y;
	t.z = p.z + q.z;

	return t;
}
SRyuVector3 operator-(const SRyuVector3& p, const SRyuVector3& q)
{
	SRyuVector3 t;

	t.x = p.x - q.x;
	t.y = p.y - q.y;
	t.z = p.z - q.z;

	return t;
}
//벡터의 스칼라곱셈
SRyuVector3 operator*(const float& s, SRyuVector3& p)
{
	SRyuVector3 t;

	t.x = s*p.x;
	t.y = s * p.y;
	t.z = s * p.z;

	return t;
}
SRyuVector3 operator/(SRyuVector3& p, const float& s)
{
	SRyuVector3 t;

	//s는 0이면 안됨
	if (!(abs(s) < FLT_EPSILON))	//0이 아니라면 
	{
		t.x = p.x / s;
		t.y = p.y / s;
		t.z = p.z / s;
	}

	return t;
}
//벡터의 내적
float dotProduct(SRyuVector3& p, SRyuVector3& q)
{
	return p.x * q.x + p.y * q.y + p.z * q.z;
}
//벡터의 외적
SRyuVector3 crossProduct(SRyuVector3& p, SRyuVector3& q)
{
	SRyuVector3 t;
	t.x = p.y*q.z - p.z*q.y;
	t.y = p.z*q.x - p.x*q.z;
	t.z = p.x*q.y - p.y*q.x;

	return t;
}
//벡터의 정규화
void Normalize(SRyuVector3& p)
{
	float tLength = sqrtf(dotProduct(p, p));

	if ( !(abs(tLength) < FLT_EPSILON) )	//0이 아니라면 
	{
		p = p / tLength;		//스칼라곱셈
	}
}


struct SMat4x4
{
	float m[4][4] = { 0.0f };
};
//Mij = 시그마 Aik*Bkj
SMat4x4 operator*(const SMat4x4& A, const SMat4x4& B)
{
	SMat4x4 M = { 0.0f };

	for (int i = 0;i<4;++i)
	{
		for (int j = 0;j < 4;++j)
		{
			for (int k = 0;k < 4;++k)
			{
				M.m[i][j] += A.m[i][k] * B.m[k][j];
			}
		}
	}	

	return M;
}

//뷰변환 행렬을 만드는 함수들
//pos: 카메라의 위치
//target: 응시점
//up: 월드좌표계의 상방벡터
SMat4x4 MatrixPointAt(SRyuVector3& pos, SRyuVector3& target, SRyuVector3& up)
{
	SRyuVector3 newForward = target - pos;
	Normalize(newForward);

	SRyuVector3 projectionUpOntoNewForward = dotProduct(up, newForward) * newForward;
	SRyuVector3 newUp = up - projectionUpOntoNewForward;
	Normalize(newUp);

	SRyuVector3 newRight = crossProduct(newUp, newForward);

	SMat4x4 t = { 0.0f };

	t.m[0][0] = newRight.x;
	t.m[1][0] = newRight.y;
	t.m[2][0] = newRight.z;
	t.m[0][1] = newUp.x;
	t.m[1][1] = newUp.y;
	t.m[2][1] = newUp.z;
	t.m[0][2] = newForward.x;
	t.m[1][2] = newForward.y;
	t.m[2][2] = newForward.z;
	t.m[3][0] = pos.x;
	t.m[3][1] = pos.y;
	t.m[3][2] = pos.z;
	t.m[3][3] = 1.0f;

	return t;
}

SMat4x4 quickInverse(SMat4x4& m)
{
	SMat4x4 inv = { 0.0f };

	inv.m[0][0] = m.m[0][0];
	inv.m[1][0] = m.m[1][0];
	inv.m[2][0] = m.m[2][0];
	inv.m[3][0] = -(m.m[3][0] * m.m[0][0] + m.m[3][1] * m.m[1][0] + m.m[3][2] * m.m[2][0]);
	inv.m[0][1] = m.m[0][1];
	inv.m[1][1] = m.m[1][1];
	inv.m[2][1] = m.m[2][1];
	inv.m[3][1] = -(m.m[3][0] * m.m[0][1] + m.m[3][1] * m.m[1][1] + m.m[3][2] * m.m[2][1]);
	inv.m[0][2] = m.m[0][2];
	inv.m[1][2] = m.m[1][2];
	inv.m[2][2] = m.m[2][2];
	inv.m[3][2] = -(m.m[3][0] * m.m[0][2] + m.m[3][1] * m.m[1][2] + m.m[3][2] * m.m[2][2]);
	inv.m[3][3] = 1.0f;

	return inv;
}















//삼각형: 정점 3개로 이루어진 도형이다.
struct SRyuTriangle
{
	SRyuVector3 p[3];

	olc::Pixel color;	//조명에 의한 음영 색상 정보 <--면 단위로 가정하였다 
};
//메쉬: 삼각형들의 모음(정점들의 모음)
struct SRyuMesh
{
	vector<SRyuTriangle> tris;
	//<--복사본으로 삼각형을 다루기 위해서 참조를 사용하지 않았다 

	bool LoadFromObjFile(string tFilename)
	{
		//input file stream ( memory <-- disk )
		ifstream tFile(tFilename);
		if (!tFile.is_open())
		{
			//파일 열기에 실패
			return false;
		}

		//파일 열기 성공 

		//정점 목록
		vector<SRyuVector3> tVertices;//가변배열

		//파일에 맨 마지막 까지 다음 처리를 수행한다
		while (!tFile.eof())
		{
			char tLine[256] = { 0 };		//한 줄의 텍스트 정보를 담아둘 지역변수 
			tFile.getline(tLine, 256);	//파일의 한줄 정보 얻기 

			strstream tStr;	
			//파싱parsing(구문분석을 통해 의미있는 데이터를 얻는 것)을 위해 사용할 것이다. 
			//<-- 공백(스페이스)문자 등을 구분자로 삼아 '토큰(token)'을 얻을 수 있는 기능을 제공한다 
			tStr << tLine;		//한 줄 텍스트를 tStr에 담는다 

			char tJunk;	//불필요한 문자를 선별하여 걸러내기 위한 용도 

			//정점 데이터를 기록하고 있는 한 줄 텍스트 정보
			if ( 'v' == tLine[0])
			{
				SRyuVector3 tPos;

				//파싱하여 의도한 데이터를 얻어낸다.
				tStr >> tJunk >> tPos.x >> tPos.y >> tPos.z;

				//정점 데이터를 목록에 담아둔다.
				tVertices.push_back(tPos);
			}
			//면(삼각형)을 기록하고 있는 한 줄 텍스트 정보
			if ('f' == tLine[0])
			{
				//삼각형을 이룰 인덱스 정보들 
				int tFace[3];

				//파싱하여 의도한 데이터를 얻어낸다.
				tStr >> tJunk >> tFace[0] >> tFace[1] >> tFace[2];

				//인덱스에 기반하여 삼각형 정보를 구축하여 자료구조에 담아둔다.
				this->tris.push_back({ tVertices[tFace[0] - 1], tVertices[tFace[1] - 1], tVertices[tFace[2] - 1] });
			}
		}

		return true;
	}
};





// Override base class with your custom functionality
class Example : public olc::PixelGameEngine
{
	float mTheta = 0.0f;

	SRyuVector3 mPosMainCamera;//카메라의 위치 
	SRyuVector3 mDirLook;	//바라보는 방향


	SRyuMesh tMesh;

public:
	Example()
	{
		// Name you application
		sAppName = "Example";
	}

public:
	bool OnUserCreate() override
	{
		//카메라의 초기위치 설정
		mPosMainCamera.x = 0.0f;
		mPosMainCamera.y = 0.0f;
		mPosMainCamera.z = 0.0f;

		//전방을 바라봄
		mDirLook.x = 0.0f;
		mDirLook.y = 0.0f;
		mDirLook.z = 1.0f;

		//test
		SRyuTriangle t;			//삼각형을 하나 가정하자
		SRyuVector3 tLineA;		//A벡터
		SRyuVector3 tLineB;		//B벡터

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
		//tNormal.x = tLineA.y*tLineB.z - tLineA.z*tLineB.y;
		//tNormal.y = tLineA.z*tLineB.x - tLineA.x*tLineB.z;
		//tNormal.z = tLineA.x*tLineB.y - tLineA.y*tLineB.x;

		// B cross A
		tNormal.x = tLineB.y * tLineA.z - tLineB.z * tLineA.y;
		tNormal.y = tLineB.z * tLineA.x - tLineB.x * tLineA.z;
		tNormal.z = tLineB.x * tLineA.y - tLineB.y * tLineA.x;


		//외적벡터의 크기를 구하자
		float tDotThis = tNormal.x* tNormal.x + tNormal.y * tNormal.y + tNormal.z * tNormal.z;
		float tLength = sqrtf(tDotThis);
		//외적벡터의 정규화
		tNormal.x = tNormal.x/tLength;
		tNormal.y = tNormal.y / tLength;
		tNormal.z = tNormal.z / tLength;

		//char tszTemp[256] = { 0 };
		printf("tNormal: %f, %f, %f\n", tNormal.x, tNormal.y, tNormal.z);


		tMesh.LoadFromObjFile("Resources/slime.obj");

		// Called once at the start, so create things here
		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{
		//input
		if (GetKey(olc::Key::LEFT).bHeld)
		{
			mPosMainCamera.x = mPosMainCamera.x - 50.0f * fElapsedTime;
		}
		if (GetKey(olc::Key::RIGHT).bHeld)
		{
			mPosMainCamera.x = mPosMainCamera.x + 50.0f * fElapsedTime;
		}

		if (GetKey(olc::Key::UP).bHeld)
		{
			mPosMainCamera.y = mPosMainCamera.y - 50.0f * fElapsedTime;
		}
		if (GetKey(olc::Key::DOWN).bHeld)
		{
			mPosMainCamera.y = mPosMainCamera.y + 50.0f * fElapsedTime;
		}

		if (GetKey(olc::Key::W).bHeld)
		{
			mPosMainCamera.z = mPosMainCamera.z + 50.0f * fElapsedTime;
		}
		if (GetKey(olc::Key::S).bHeld)
		{
			mPosMainCamera.z = mPosMainCamera.z - 50.0f * fElapsedTime;
		}



		//render
		this->Clear(olc::VERY_DARK_BLUE);
		
		//---렌더링 파이프라인 ---
		//색상 정보는 기입하지 않았다.( 기본은 검정색 )
		//SRyuMesh tMesh;
		
		//tMesh.tris =
		//{
		//	//윈도우 좌표계 기준: 정점 나열 순서는 CCW Count Clock Wise 반시계방향
		//	//( 수학에서 좌표계 기준:  정점 나열 순서는 CW Clock Wise 시계방향 )			
		//	//south
		//	{ 0.0f, 0.0f, 0.0f,			0.0f, 1.0f, 0.0f,	1.0f, 1.0f, 0.0f },
		//	{ 0.0f, 0.0f, 0.0f,			1.0f, 1.0f, 0.0f,		1.0f, 0.0f, 0.0f },

		//	//east
		//	{ 1.0f, 0.0f, 0.0f,			1.0f, 1.0f, 0.0f,		1.0f, 1.0f, 1.0f },
		//	{ 1.0f, 0.0f, 0.0f,			1.0f, 1.0f, 1.0f,		1.0f, 0.0f, 1.0f },

		//	//north
		//	{ 1.0f, 0.0f, 1.0f,			1.0f, 1.0f, 1.0f,		0.0f, 1.0f, 1.0f },
		//	{ 1.0f, 0.0f, 1.0f,			0.0f, 1.0f, 1.0f,		0.0f, 0.0f, 1.0f },

		//	//west
		//	{ 0.0f, 0.0f, 1.0f,			0.0f, 1.0f, 1.0f,		0.0f, 1.0f, 0.0f },
		//	{ 0.0f, 0.0f, 1.0f,			0.0f, 1.0f, 0.0f,	0.0f, 0.0f, 0.0f },

		//	//top 
		//	{ 0.0f, 1.0f, 0.0f,			0.0f, 1.0f, 1.0f,		1.0f, 1.0f, 1.0f },
		//	{ 0.0f, 1.0f, 0.0f,			1.0f, 1.0f, 1.0f,		1.0f, 1.0f, 0.0f },

		//	//bottom
		//	{ 0.0f, 0.0f, 1.0f,			0.0f, 0.0f, 0.0f,	1.0f, 0.0f, 0.0f },
		//	{ 0.0f, 0.0f, 1.0f,			1.0f, 0.0f, 0.0f,	1.0f, 0.0f, 1.0f },
		//};

		//--기하단계--

		//월드변환

		//scale 변환 행렬
		float tScaleScalar = 1.0f;//100.0f;

		float tMatScale[4][4] = { 0.0f };
		tMatScale[0][0] = 1.0f*tScaleScalar;
		tMatScale[1][1] = 1.0f * tScaleScalar;
		tMatScale[2][2] = 1.0f * tScaleScalar;
		tMatScale[3][3] = 1.0f;
		//스케일 변환 행렬을 적용한 결과 정점
		SRyuMesh tMeshScale;
		tMeshScale.tris = tMesh.tris;
		
		for (int ti = 0; ti<tMesh.tris.size(); ++ti)
		{
			MultiplyMatrixVector(tMesh.tris[ti].p[0], tMeshScale.tris[ti].p[0], tMatScale);
			MultiplyMatrixVector(tMesh.tris[ti].p[1], tMeshScale.tris[ti].p[1], tMatScale);
			MultiplyMatrixVector(tMesh.tris[ti].p[2], tMeshScale.tris[ti].p[2], tMatScale);
		}




		mTheta = mTheta + 1.0f * fElapsedTime;
		//mTheta = 115.0f;

		//회전변환행렬
		////z축 회전
		//float tMatRotate[4][4] = { 0.0f };
		//tMatRotate[0][0] = cosf(mTheta);
		//tMatRotate[1][1] = cosf(mTheta);
		//tMatRotate[0][1] = sinf(mTheta);
		//tMatRotate[1][0] = -1.0f* sinf(mTheta);
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

		tMatTranslate[3][2] = 15.0f;	//z축 양의 방향으로  이동

		//이동 변환 행렬을 적용한 결과 정점
		SRyuMesh tMeshTranslate;
		tMeshTranslate.tris = tMeshRotate.tris;		

		for (int ti = 0; ti < tMeshRotate.tris.size(); ++ti)
		{
			MultiplyMatrixVector(tMeshRotate.tris[ti].p[0], tMeshTranslate.tris[ti].p[0], tMatTranslate);
			MultiplyMatrixVector(tMeshRotate.tris[ti].p[1], tMeshTranslate.tris[ti].p[1], tMatTranslate);
			MultiplyMatrixVector(tMeshRotate.tris[ti].p[2], tMeshTranslate.tris[ti].p[2], tMatTranslate);
		}





		//뷰변환
		//월드 좌표계의 상방벡터 
		SRyuVector3 tDirUp = { 0.0f, 1.0f, 0.0f };
		//바라보는 지점
		SRyuVector3 tPosTarget = mPosMainCamera + mDirLook;
		
		//뷰변환 행렬 구하기 
		SMat4x4 tMatViewInverse = MatrixPointAt(mPosMainCamera, tPosTarget, tDirUp);
		SMat4x4 tMatView = quickInverse(tMatViewInverse);


		//이동 변환 행렬을 적용한 결과 정점
		SRyuMesh tMeshView;
		tMeshView.tris = tMeshTranslate.tris;

		for (int ti = 0; ti < tMeshTranslate.tris.size(); ++ti)
		{
			MultiplyMatrixVector(tMeshTranslate.tris[ti].p[0], tMeshView.tris[ti].p[0], tMatView.m);
			MultiplyMatrixVector(tMeshTranslate.tris[ti].p[1], tMeshView.tris[ti].p[1], tMatView.m);
			MultiplyMatrixVector(tMeshTranslate.tris[ti].p[2], tMeshView.tris[ti].p[2], tMatView.m);
		}





		//시야절두체 클리핑 테스트
		//'클립' 처리된 삼각형 들을 담아둘 삼각형 목록
		list<SRyuTriangle> tClippedTriangles;

		







		//투영변환
		//아주 정직한 버전 
		//float tNear = 0.7f;
		//float tFar = 1.0f;
		//float tR = 1.0f * 0.5f;
		//float tL = -1.0f * 1.0f * 0.5f;
		//float tT = 0.5f * 0.5f;
		//float tB = -1.0f * 0.5f * 0.5f;
		//
		////단위행렬 로 일단 만들자
		//float tMatProj[4][4] = { 0.0f };
		////tMatProj[0][0] = 1.0f;
		////tMatProj[1][1] = 1.0f;
		////tMatProj[2][2] = 1.0f;
		////tMatProj[3][3] = 1.0f;
		//tMatProj[0][0] = (2.0f*tNear)/(tR - tL);
		//tMatProj[1][1] = (2.0f * tNear) / (tT - tB);
		//tMatProj[2][2] = -1.0f*(tFar + tNear)/(tFar-tNear);
		//tMatProj[3][2] = -2.0f * tNear * (tFar / (tFar - tNear));
		////tMatProj[2][3] = -1.0f;
		////카메라가 바라보는 방향이 z축 양의 방향이라고 가정한다
		//tMatProj[2][3] = 1.0f;//<---그래서 -1에서 1로 수정
		//tMatProj[3][3] = 0.0f;

		//tMatProj[2][0] = (tR + tL) / (tR - tL);
		//tMatProj[2][1] = (tT + tB) / (tT - tB);



		//'시야각'과 '종횡비'를 고려하여 수정한 버전 

		//시야각 FOV Field Of View
		float tFov = 90.0f;		//<--degree
		float tFovRad = 1.0f / tanf((tFov * 0.5f) * (3.14159f / 180.0f));//<--radian

		//종횡비 AspectRatio
		float tAspectRatio = (float)ScreenHeight() / (float)ScreenWidth();

		float tNear = 0.1f;
		float tFar = 100.0f;
		//float tR = 1.0f * 0.5f;
		//float tL = -1.0f * 1.0f * 0.5f;
		//float tT = 0.5f * 0.5f;
		//float tB = -1.0f * 0.5f * 0.5f;

		float tMatProj[4][4] = { 0.0f };
		tMatProj[0][0] = tAspectRatio *tFovRad;
		tMatProj[1][1] = tFovRad;				//<-- (2*n)/(t-b) = tFovRad 
		tMatProj[2][2] = -1.0f * (tFar + tNear) / (tFar - tNear);
		tMatProj[3][2] = -2.0f * tNear * (tFar / (tFar - tNear));
		
		tMatProj[2][3] = 1.0f;//<---그래서 -1에서 1로 수정
		tMatProj[3][3] = 0.0f;

		//tMatProj[2][0] = (tR + tL) / (tR - tL);			//<--사실 0이다
		//tMatProj[2][1] = (tT + tB) / (tT - tB);			//<--사실 0이다




		//'래스터라이즈' 를 적용할 삼각형 목록
		vector<SRyuTriangle> tRasterTriangles;


		//투영 변환 행렬을 적용한 결과 정점
		SRyuMesh tMeshProj;
		//tMeshProj.tris = tMeshView.tris;

		for (int ti = 0; ti < tMeshView.tris.size(); ++ti)
		{
			//---임의의 삼각형의 법선 벡터 구하기 ---
			SRyuTriangle t = tMeshView.tris[ti];			//삼각형을 하나 가정하자
			SRyuVector3 tLineA;		//A벡터
			SRyuVector3 tLineB;		//B벡터

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

			//삼각형의 무게중심 
			SRyuVector3 tPosMid; //<--목적지점으로 삼겠다 
			tPosMid.x = (t.p[0].x + t.p[1].x + t.p[2].x)/3.0f;
			tPosMid.y = (t.p[0].y + t.p[1].y + t.p[2].y) / 3.0f;
			tPosMid.z = (t.p[0].z + t.p[1].z + t.p[2].z) / 3.0f;
			//벡터의 뺄셈. 임의의 크기의 임의의 방향의 벡터 = 목적지점 - 시작지점
			tViewVector.x = tPosMid.x - mPosMainCamera.x;
			tViewVector.y = tPosMid.y - mPosMainCamera.y;
			tViewVector.z = tPosMid.z - mPosMainCamera.z;

			float tDotView = tViewVector.x * tViewVector.x + tViewVector.y * tViewVector.y + tViewVector.z * tViewVector.z;
			float tLengthView = sqrtf(tDotView);
			//시선벡터의 정규화
			tViewVector.x = tViewVector.x / tLengthView;
			tViewVector.y = tViewVector.y / tLengthView;
			tViewVector.z = tViewVector.z / tLengthView;

			//법선벡터 dot 시선벡터 하여 두 벡터의 위치관계를 대수적으로 판단하자.
			float tDotResult = tNormal.x * tViewVector.x + tNormal.y * tViewVector.y + tNormal.z * tViewVector.z;






			//조명에 의한 음영결정 
			//<--램버트 조명 모델
			SRyuVector3 tLightVector = {0.0f, 0.0f, 1.0f};
			float tDotLight = tLightVector.x * tLightVector.x + tLightVector.y * tLightVector.y + tLightVector.z * tLightVector.z;
			float tLengthLight = sqrtf(tDotLight);
			//조명(빛)벡터의 정규화
			tLightVector.x = tLightVector.x / tLengthLight;
			tLightVector.y = tLightVector.y / tLengthLight;
			tLightVector.z = tLightVector.z / tLengthLight;

			//음영(궁극적으로는 픽셀 색상)을 결정할 '광량' 구하기
			//'법선벡터 dot 조명벡터' 해서 면에 드리워지는 광량(light mass)를 정한다.
			//[-1,1]의 값이 나온다.
			float tResultLight = tNormal.x * tLightVector.x + tNormal.y * tLightVector.y + tNormal.z * tLightVector.z;

			//하프 램버트 Half-Lambert 조명 모델 
			//		[-1, 1] ----> [-0.5, 0.5] ----> [0,1] 
			//		보다 음영의 변화가 완만한 형태를 만들었다.
			tResultLight = tResultLight * 0.5f + 0.5f;

			//광량을 기반으로 해당 면의 '픽셀'의 음영 색상 정보 구하기 
			olc::Pixel tColor = GetColor(tResultLight);
			t.color = tColor;





			//은면(후면)이 아니면 렌더링한다( 은면(후면)이면 렌더링하지 않는다 )
			//if (tDotResult >= 0.0f) //<--후면 컬링 cull back
			//if (tDotResult < 0.0f)	//<--전면 컬링 cull front
			//{
				//뷰변환, 조명적용된 삼각형들을 tClippedTriangles에 담는다 
				tClippedTriangles.push_back(t);
			//}

		}



		//클립 처리 수행
		SRyuVector3 tPointOnPlane = { 0.0f, 0.0f, 10.0f };
		SRyuVector3 tNormalToPlane = { 0.0f, 0.0f, 1.0f };
		ClipByPlane(tPointOnPlane, tNormalToPlane, tClippedTriangles);


		//클립 처리된 삼각형 갯수만큼 tMeshProj의 삼각형 을 만든다.
		for (auto t = tClippedTriangles.begin(); t != tClippedTriangles.end(); ++t)
		{
			SRyuTriangle tri;
			tMeshProj.tris.push_back(tri);
		}

		//투영변환, 뷰포트변환 적용
		int ti = 0;
		for (auto t : tClippedTriangles)
		{
			//투영변환 행렬 적용
			MultiplyMatrixVector(t.p[0], tMeshProj.tris[ti].p[0], tMatProj);
			MultiplyMatrixVector(t.p[1], tMeshProj.tris[ti].p[1], tMatProj);
			MultiplyMatrixVector(t.p[2], tMeshProj.tris[ti].p[2], tMatProj);

			//색상정보도 다음 렌더링 단계로 전달
			tMeshProj.tris[ti].color = t.color;

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


			tRasterTriangles.push_back(tMeshProj.tris[ti]);

			++ti;
		}








		
		//렌더링 순서를 정렬
		//z-sort 알고리즘( 기하단계에서 정점 단위로 이루어진다 ) <--O(n)
		// <--- 요즘 렌더링 파이프라인에서는 다른 방법(z-buffer, depth buffer, 픽셀단위 <--O(1))을 사용한다.
		//<-- 삼각형의 무게중심의 z값을 기준으로 하여 내림차순 정렬하였다. ( 화면 안쪽으로 들어갈수록 z+가정)
		std::sort(tRasterTriangles.begin(), tRasterTriangles.end(),

			[](SRyuTriangle& tri_0, SRyuTriangle& tri_1)
			{
				//삼각형의 무게중심 
				SRyuVector3 tPosMid_0;
				tPosMid_0.z = (tri_0.p[0].z + tri_0.p[1].z + tri_0.p[2].z) / 3.0f;

				//삼각형의 무게중심 
				SRyuVector3 tPosMid_1;
				tPosMid_1.z = (tri_1.p[0].z + tri_1.p[1].z + tri_1.p[2].z) / 3.0f;

				//내림차순 정렬 
				return tPosMid_0.z > tPosMid_1.z;
			}
		);

		//p.s.  Z-fighting : 두 개 이상의 폴리곤이 위치가 같은 경우 어느 폴리곤이 먼저 렌더링될지 랜덤하게 결정되므로 
		//								깜빡거리거나 하는 현상이 일어난다. 이를 Z-fighting이라고 한다.
		//								<-- 근본적인 해결책은 없다고 한다.


		//---래스터라이즈단계---
		for (auto t: tRasterTriangles)
		{
			FillTriangle(t.p[0].x, t.p[0].y,
					t.p[1].x, t.p[1].y,
					t.p[2].x, t.p[2].y,
					t.color);

			DrawTriangle(
				t.p[0].x, t.p[0].y,
				t.p[1].x, t.p[1].y,
				t.p[2].x, t.p[2].y,
				olc::BLACK
				);
		}


		return true;
	}
	// Mij = 시그마 Aik*Bkj
	//행벡터와 행렬의 곱셈
	void MultiplyMatrixVector(SRyuVector3& tIn, SRyuVector3& tOut, float tM[][4])
	{
		tOut.x = tIn.x * tM[0][0] + tIn.y * tM[1][0] + tIn.z * tM[2][0] + 1.0f * tM[3][0];
		tOut.y = tIn.x * tM[0][1] + tIn.y * tM[1][1] + tIn.z * tM[2][1] + 1.0f * tM[3][1];
		tOut.z = tIn.x * tM[0][2] + tIn.y * tM[1][2] + tIn.z * tM[2][2] + 1.0f * tM[3][2];

		float tW = tIn.x * tM[0][3] + tIn.y * tM[1][3] + tIn.z * tM[2][3] + 1.0f * tM[3][3];
		//왜곡된 공간 보정
		if (tW != 0.0f)
		{
			tOut.x = tOut.x / tW;
			tOut.y = tOut.y / tW;
			tOut.z = tOut.z / tW;
		}
	}
	//광량 ----> 음영 픽셀 색상
	//0~1 을 0~255 로 대응
	olc::Pixel GetColor(float tLightMass)
	{
		olc::Pixel tColor;

		if (tLightMass <= 0.0f)
		{
			tLightMass = 0.0f;
		}

		tColor.r = tLightMass*255;
		tColor.g = tLightMass * 255;
		tColor.b = tLightMass * 255;

		return tColor;
	}

	/*
		게임프로그래밍에서 다루는 평면의 방정식
		P dot N = d

		P: 평면 위에 임의의 한점
		N: 평면에 법선벡터
		d: 원점과 평면의 최소거리
	
		pointOnPlane: P
		normalVectorToPlane: N
		tris: 삼각형 목록
	*/
	void ClipByPlane(SRyuVector3& pointOnPlane, SRyuVector3& normalVectorToPlane, std::list<SRyuTriangle>& tris)
	{
		//주어진 삼각형 목록을 순회한다
		for (auto t = tris.begin();t != tris.end();)
		{
			SRyuTriangle& tri = (*t);

			int tCountVertex = CountVeticesOnCorrectSide(pointOnPlane, normalVectorToPlane, tri);

			if (3 == tCountVertex)
			{
				//삼각형이 시야절두체에 포함된 경우

				//클리핑 처리가 필요없다
				//렌더링 대상에 포함해야 하므로 아무 처리 없이 다음으로 넘어간다
				++t;
			}
			else if (2 == tCountVertex)
			{
				//삼각형의 일부만 시야절두체에 포함된 경우( 정점 2개 )
				// 
				//삼각형의 p[0]이 위치하는 '세가지 경우'를 모두 처리하기 위해 이렇게 표현
				while (OnCorrectSideOfPlane(pointOnPlane, normalVectorToPlane, tri.p[0]))
				{
					RotateTriangle(tri);
				}

				//p[0](의 값)이 바깥쪽에 있는 상태가 된다.
				SRyuVector3 tInter_0 = IntersectionOfLineAndPlane(pointOnPlane, normalVectorToPlane, tri.p[0], tri.p[1]);
				SRyuVector3 tInter_1 = IntersectionOfLineAndPlane(pointOnPlane, normalVectorToPlane, tri.p[0], tri.p[2]);


				SRyuTriangle tNewTri_0 = { tri.p[1], tri.p[2], tInter_0 };
				tNewTri_0.color = tri.color;
				SRyuTriangle tNewTri_1 = { tri.p[2], tInter_1, tInter_0 };
				tNewTri_1.color = tri.color;

				//기존 삼각형은 제거
				t = tris.erase(t);
				//새로운 삼각형들은 추가
				tris.insert(t, tNewTri_0);
				tris.insert(t, tNewTri_1);
			}
			else if (1 == tCountVertex)
			{
				//삼각형의 일부만 시야절두체에 포함된 경우( 정점 1개 )

				//삼각형의 p[0]이 위치하는 '세가지 경우'를 모두 처리하기 위해 이렇게 표현
				while ( !OnCorrectSideOfPlane(pointOnPlane, normalVectorToPlane, tri.p[0]) )
				{
					RotateTriangle(tri);
				}

				//p[0](의 값)이 안쪽에 있는 상태가 된다.
				SRyuVector3 tInter_0 = IntersectionOfLineAndPlane(pointOnPlane, normalVectorToPlane, tri.p[0], tri.p[1]);
				SRyuVector3 tInter_1 = IntersectionOfLineAndPlane(pointOnPlane, normalVectorToPlane, tri.p[0], tri.p[2]);
				
				//새로운 삼각형 생성 과 데이터 설정
				SRyuTriangle tNewTri = {tri.p[0], tInter_0, tInter_1};
				tNewTri.color = tri.color;

				//기존 삼각형은 제거
				t = tris.erase(t);
				//새로운 삼각형은 추가
				tris.insert(t, tNewTri);
			}
			else if (0 == tCountVertex)
			{
				//삼각형이 시야절두체에 포함되지 않은 경우

				//삼각형 목록에서 삼각형 제거( 렌더링 대상에 포함하지 않는다 )
				t = tris.erase(t);
			}			
		}
	}
	/*
		평면
		pointOnPlane: P
		normalVectorToPlane: N

		직선(선분)
		firstPoint: 시점
		lastPoint: 종점
	*/
	SRyuVector3 IntersectionOfLineAndPlane(SRyuVector3& pointOnPlane, SRyuVector3& normalVectorToPlane, SRyuVector3& firstPoint, SRyuVector3& lastPoint)
	{
		//목적지점 - 시작지점
		SRyuVector3 tLineDir = lastPoint - firstPoint;

		float planeEqnConstant = dotProduct(normalVectorToPlane, pointOnPlane);	//P dot N = d
		//선분과 평면의 교차점의 위치에 해당하는 '비율'값을 구함
		float intersectionTime = (planeEqnConstant - dotProduct(normalVectorToPlane, firstPoint)) / (dotProduct(normalVectorToPlane, tLineDir));

		//벡터의 연산으로 '교차점'을 구함
		SRyuVector3 tIntersectionPoint = intersectionTime * tLineDir + firstPoint;

		return tIntersectionPoint;
	}


	void RotateTriangle(SRyuTriangle& tri)
	{
		SRyuVector3 tTemp = tri.p[0];
		tri.p[0] = tri.p[1];
		tri.p[1] = tri.p[2];
		tri.p[2] = tTemp;
	}
	/*
		P dot N = d

		pointOnPlane: P
		normalVectorToPlane: N

		somePoint: 삼각형의 임의의 한 점
	*/
	//평면의 안쪽에(올바른쪽) 삼각형의 임의의 한 점이 있는지 판단하는 함수
	bool OnCorrectSideOfPlane(SRyuVector3& pointOnPlane, SRyuVector3& normalVectorToPlane, SRyuVector3& somePoint)
	{
		SRyuVector3 tVector = somePoint - pointOnPlane;
		Normalize(tVector);

		//벡터의 내적 연산으로 두 벡터의 위치관계를 대수적으로 판단
		//하여 
		//평면의 안쪽에(올바른쪽) 임의의 한 점이 있는지 판단
		return (dotProduct(normalVectorToPlane, tVector) >= 0.0f);

		return false;
	}
	//평면의 안쪽(올바른 쪽)에 임의의 삼각형의 정점 몇개가 들어있는지 판단하는 함수
	int CountVeticesOnCorrectSide(SRyuVector3& pointOnPlane, SRyuVector3& normalVectorToPlane, SRyuTriangle& tri)
	{
		//bool ---> int : type cast 0,1
		return OnCorrectSideOfPlane(pointOnPlane, normalVectorToPlane, tri.p[0]) +
			OnCorrectSideOfPlane(pointOnPlane, normalVectorToPlane, tri.p[1]) +
			OnCorrectSideOfPlane(pointOnPlane, normalVectorToPlane, tri.p[2]);
	}


};

int main()
{
	Example demo;
	if (demo.Construct(320, 240, 2, 2))
		demo.Start();
	return 0;
}