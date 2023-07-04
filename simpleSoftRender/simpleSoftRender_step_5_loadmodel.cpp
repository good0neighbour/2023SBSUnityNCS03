#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"

/*
	step_5_loadmodel

	외부 모델 파일의 데이터를 로드하여 렌더링하자.
*/

#include <vector>//가변배열
using namespace std;


#include <fstream>		//file을 stream(흐르는 데이터) 개념으로 다룬다
#include <strstream>	//string을 stream(흐르는 데이터) 개념으로 다룬다


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

	olc::Pixel color; //조명에 의한 음영 색상 정보 <--면 단위로 가정하였다
};
//메쉬: 삼각형의 모음(정점들의 모음)
struct SRyuMesh
{
	vector<SRyuTriangle> tris;
	//<--복사본으로 삼각형을 다루기 위해서 참조를 사용하지 않았다

	bool LoadFromObjFile(string tFilename)
	{
		//input file system ( memory <-- disk )
		ifstream tFile(tFilename);
		if (!tFile.is_open())
		{
			//파일 열기에 실패
			return false;
		}

		//파일 열기 성공

		//정점 목록
		vector<SRyuVector3> tVertices;//가변배열

		//파일에 맨 마지막까지 다음 처리를 수행한다
		while (!tFile.eof())
		{
			char tLine[256] = { 0 };	//한 줄의 텍스트 정보를 담아둘 자역변수
			tFile.getline(tLine, 256);	//파일의 한줄 정보 얻기

			strstream tStr;
			//파싱parsing(구문분석을 통해 의미있는 데이터를 얻는 것)을 위해 사용할 것이다.
			//<-- 공백(스페이스)문자 등을 구분자로 삼아 '토큰(token)'을 얻을 수 있는 기능을 제공한다
			tStr << tLine;	//한 줄 텍스트를 tStr에 담는다

			char tJunk; //불필요한 문자를 선별하여 걸러내기 위한 용도

			//정점 데이터를 기록하고 있는 한 줄 텍스트 정보
			if ('v' == tLine[0])
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
				//삼각형을 이룰 인덱스 정보
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

	SRyuVector3 mPosMainCamera;


	SRyuMesh tMesh;

public:
	Example()
	{
		// Name your application
		sAppName = "Example";
	}

public:
	bool OnUserCreate() override
	{
		//카메라의 초기위치 설정
		mPosMainCamera.x = 0.0f;
		mPosMainCamera.y = 0.0f;
		mPosMainCamera.z = 0.0f;

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


		tMesh.LoadFromObjFile("Resources/cube_888.obj");

		// Called once at the start, so create things here
		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{
		this->Clear(olc::VERY_DARK_BLUE);

		//---렌더링 파이프라인---
		//색상 정보는 기입하지 않았다.( 기본은 검정색 )
		//SRyuMesh tMesh;
		
		//tMesh.tris =
		//{
		//	//윈도우 좌표계 기준: 정점 나열 순서는 CCW Count Clock Wise 반시계방향
		//	//( 수학에서 좌표계 기준: 정점 나열 순서는 CW Clock Wise 시계방향 )
		//	//south
		//	{ 0.0f, 0.0f, 0.0f,			0.0f, 1.0f, 0.0f,		1.0f, 1.0f, 0.0f },
		//	{ 0.0f, 0.0f, 0.0f,			1.0f, 1.0f, 0.0f,		1.0f, 0.0f, 0.0f },

		//	//east
		//	{ 1.0f, 0.0f, 0.0f,			1.0f, 1.0f, 0.0f,		1.0f, 1.0f, 1.0f },
		//	{ 1.0f, 0.0f, 0.0f,			1.0f, 1.0f, 1.0f,		1.0f, 0.0f, 1.0f },

		//	//north
		//	{ 1.0f, 0.0f, 1.0f,			1.0f, 1.0f, 1.0f,		0.0f, 1.0f, 1.0f },
		//	{ 1.0f, 0.0f, 1.0f,			0.0f, 1.0f, 1.0f,		0.0f, 0.0f, 1.0f },

		//	//west
		//	{ 0.0f, 0.0f, 1.0f,			0.0f, 1.0f, 1.0f,		0.0f, 1.0f, 0.0f },
		//	{ 0.0f, 0.0f, 1.0f,			0.0f, 1.0f, 0.0f,		0.0f, 0.0f, 0.0f },

		//	//top 
		//	{ 0.0f, 1.0f, 0.0f,			0.0f, 1.0f, 1.0f,		1.0f, 1.0f, 1.0f },
		//	{ 0.0f, 1.0f, 0.0f,			1.0f, 1.0f, 1.0f,		1.0f, 1.0f, 0.0f },

		//	//bottom
		//	{ 0.0f, 0.0f, 1.0f,			0.0f, 0.0f, 0.0f,		1.0f, 0.0f, 0.0f },
		//	{ 0.0f, 0.0f, 1.0f,			1.0f, 0.0f, 0.0f,		1.0f, 0.0f, 1.0f }
		//};

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

			//삼각형의 무게중심
			SRyuVector3 tPosMid;	//<--목적지점으로 삼겠다
			tPosMid.x = (t.p[0].x + t.p[1].x + t.p[2].x) / 3.0f;
			tPosMid.y = (t.p[0].y + t.p[1].y + t.p[2].y) / 3.0f;
			tPosMid.z = (t.p[0].z + t.p[1].z + t.p[2].z) / 3.0f;
			//벡터의 뺄셈. 임의의 크기의 임의의 방향의 벡터 = 목적지점 - 시작지점
			tViewVector.x = tPosMid.x - mPosMainCamera.x;
			tViewVector.y = tPosMid.y - mPosMainCamera.y;
			tViewVector.z = tPosMid.z - mPosMainCamera.z;

			float tDotView = tViewVector.x * tViewVector.x + tViewVector.y * tViewVector.y + tViewVector.z * tViewVector.z;
			float tLengthView = sqrtf(tDotView);
			//외적벡터의 정규화
			tViewVector.x = tViewVector.x / tLengthView;
			tViewVector.y = tViewVector.y / tLengthView;
			tViewVector.z = tViewVector.z / tLengthView;

			//법선벡터 dot 시선벡터 하여 두 벡터의 위치관계를 대수적으로 판단하자.
			float tDotResult = tNormal.x * tViewVector.x + tNormal.y * tViewVector.y + tNormal.z * tViewVector.z;






			//조명에 의한 음영결정
			//<--램버트 조명 모델
			SRyuVector3 tLightVector = { 0.0f, 0.0f, 1.0f };
			float tDotLight = tLightVector.x * tLightVector.x + tLightVector.y * tLightVector.y + tLightVector.z * tLightVector.z;
			float tLengthLight = sqrtf(tDotLight);
			//시선벡터의 정규화
			tLightVector.x = tLightVector.x / tLengthLight;
			tLightVector.y = tLightVector.y / tLengthLight;
			tLightVector.z = tLightVector.z / tLengthLight;

			//음영을 결정할 '광량' 구하기
			//법선벡터 dot 조명벡터 해서 면에 드리워지는 광량(light mass)를 정한다.
			//[-1, 1]의 값이 나온다.
			float tResultLight = tNormal.x * tLightVector.x + tNormal.y * tLightVector.y + tNormal.z * tLightVector.z;

			//하프 램버트 Half-Lambert 조명 모델
			//[-1, 1] ----> [-0.5, 0.5] ----> [0, 1]
			//보다 음영의 변화가 완만한 형태를 만들었다.
			tResultLight = tResultLight * 0.5f + 0.5f;

			//광량을 기반으로 해당 면의 '픽셀'의 음영 색상 정보 구하기
			olc::Pixel tColor = GetColor(tResultLight);
			t.color = tColor;





			//은면(후면)이 아니면 렌더링한다( 은면(후면)이면 렌더링하지 않는다 )
			if (tDotResult >= 0.0f) //<--후면 컬링 cull back
			//if (tDotResult < 0.0f)//<--전면 컬링 cull front
			{
				//투영변환 행렬 적용
				MultiplyMatrixVector(tMeshTranslate.tris[ti].p[0], tMeshProj.tris[ti].p[0], tMatProj);
				MultiplyMatrixVector(tMeshTranslate.tris[ti].p[1], tMeshProj.tris[ti].p[1], tMatProj);
				MultiplyMatrixVector(tMeshTranslate.tris[ti].p[2], tMeshProj.tris[ti].p[2], tMatProj);

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


				//래스터라이즈
				//전달받은 색상으로 삼각형을 면으로 그리기
				FillTriangle(tMeshProj.tris[ti].p[0].x, tMeshProj.tris[ti].p[0].y,
					tMeshProj.tris[ti].p[1].x, tMeshProj.tris[ti].p[1].y,
					tMeshProj.tris[ti].p[2].x, tMeshProj.tris[ti].p[2].y,
					tMeshProj.tris[ti].color);

				DrawTriangle(
					tMeshProj.tris[ti].p[0].x, tMeshProj.tris[ti].p[0].y,
					tMeshProj.tris[ti].p[1].x, tMeshProj.tris[ti].p[1].y,
					tMeshProj.tris[ti].p[2].x, tMeshProj.tris[ti].p[2].y,
					olc::BLACK
				);
			}

		}

		//---래스터라이즈단계---
		/*for (auto t : tMeshProj.tris)
		{
			DrawTriangle(
				t.p[0].x, t.p[0].y,
				t.p[1].x, t.p[1].y,
				t.p[2].x, t.p[2].y
				);
		}*/


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
	//광량 ----> 음영 픽셀 색상
	//0~1을 0~255로 대응
	olc::Pixel GetColor(float tLightMass)
	{
		olc::Pixel tColor;

		if (tLightMass <= 0.0f)
		{
			tLightMass = 0.0f;
		}

		tColor.r = tLightMass * 255;
		tColor.g = tLightMass * 255;
		tColor.b = tLightMass * 255;

		return tColor;
	}

};

int main()
{
	Example demo;
	if (demo.Construct(320, 240, 2, 2))
		demo.Start();
	return 0;
}