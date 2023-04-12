/*
    이 예시에서는 컴포넌트 디자인 패턴에 대해 잠깐 살펴보고 가자.

*/
#include <iostream>
#include <string>
using namespace std;

//CSprite라는 기능이 있다고 가정( 여기서는 편의를 위해 string을 CSprite로 삼았다 )
typedef string CSprite;

//임의의 그래픽 출력 엔진
class CGraphics
{
public:
    void DrawSprite(float tX, CSprite tSprite)
    {
        cout << "DrawSprite" << tX << "   " << tSprite << endl;
    }
};

//before
//우리가 흔히 짜던 지금까지의 방식
// 이동관련 코드 등이 뭉뚱그려져 CUnit이라는 개념을 만들고 있다.
// 
// 
//임의의 개임모브젝트를 나타내는 클래스
//이 게임오브젝트는 외관이 화면에 표시되고, 이동 기능을 가진다
class CUnit
{
private:
    //일차원 세계를 가정
    float mX = 0.0f;
    float mVelocity = 0.0f;
    //외관은 스프라이트로 나타낸다고 가정
    CSprite mSprStand = "SprStand";

public:
    CUnit()
        :mX(0.0f), mVelocity(0.0f)
    {
    }

    void Update(float t)
    {
        mX = mX + mVelocity * t;
        cout << "Update " << mX << endl;
    }
    void Display(CGraphics& tG)
    {
        tG.DrawSprite(mX, mSprStand);
    }

};

//새롭게 구성될 게임오브젝트: 컴포넌트의 조립으로 만들어지는 개념이다.
class CUnitRyu; //클래스 전방선언

//after
//물리 처리 컴포넌트
class CPhysicsComponent
{
public:
    void Update(CUnitRyu& tUnit, float t);
};
//그래픽 처리 컴포넌트
class CGraphicComponent
{
private:
    CSprite mSprSprite = "SprStand";    //그래픽 처리 컴포넌트 부품이므로 그래픽 자원도 가진다 (관련 데이터까지 응집 )

public:
    void Update(CUnitRyu& tUnit, CGraphics& tG);
};

//컴포넌트의 조립으로 만든다
class CUnitRyu
{
public:
    float mX = 0.0f;
    float mVelocity = 0.0f;

public:
    CPhysicsComponent mPhysics;
    CGraphicComponent mGraphic;

public:
    void Update(float t);
    void Display(CGraphics& tG);
};




int main()
{
    CGraphics tGraphics;


    CUnit tUnit;

    tUnit.Update(0.0016f);
    tUnit.Display(tGraphics);


    //
    CUnitRyu tUnitRyu;

    tUnitRyu.Update(0.0016f);
    tUnitRyu.Display(tGraphics);

    return 0;
}

void CPhysicsComponent::Update(CUnitRyu& tUnit, float t)
{
    tUnit.mX = tUnit.mX + tUnit.mVelocity * t;
    cout << "Update " << tUnit.mX << endl;
}

void CGraphicComponent::Update(CUnitRyu& tUnit, CGraphics& tG)
{
    tG.DrawSprite(tUnit.mX, this->mSprSprite);
}

void CUnitRyu::Update(float t)
{
    //물리 컴포넌트에게 위임
    mPhysics.Update(*this, t);
}
void CUnitRyu::Display(CGraphics& tG)
{
    //그래픽 컴포넌트에게 위임
    mGraphic.Update(*this, tG);
}