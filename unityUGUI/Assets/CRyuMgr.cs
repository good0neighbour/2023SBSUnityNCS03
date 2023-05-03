/*
    '싱글턴 패턴'을 적용해보자
    singleton pattern
    <-- 객체의 최대 생성개수를 1개로 제한하는 것이 목적인 패턴

    아주 정직한 첫 번째 버전


    i) mpInst를 static을 적용한다
    ii) 생성자는 public이 아니다
    iii)GetInst 함수 안에는 객체를 1개로 생성제한하는 판단 구문이 존재한다
    
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRyuMgr
{
    private static CRyuMgr mpInst = null;

    //아이템 도감 정보( 단 여기서는 간단하게 하기 위해 이미지에 대해서만 구축한다 )
    //  Sprite: UI와 Unity2D에서 사용가능하도록 유니티에서 분류하여 만들어놓은 Texture 종류
    public Sprite[] mSprites = null;



    //인벤토리 정보 ( 획득 아이템 목록 정보 )
    public List<CItemInfo> mInventory = new List<CItemInfo>();

    
    public void CreateRyu()
    {
        //Resources클래스는
        //특수 폴더인 Resources폴더와 함께 사용한다.
        //'파일'인 '애셋'을 스크립트 상에서 '메모리'의 '인스턴스'로 로드하는 것이다.
        mSprites = Resources.LoadAll<Sprite>("Sprites/item");
    }

    private CRyuMgr()
    {
        Debug.Log("CRyuMgr.CRyuMgr");
    }
    //1개만 인스턴스화한다
    public static CRyuMgr GetInst()
    {
        if(null == mpInst)
        {
            mpInst = new CRyuMgr();
        }

        return mpInst;
    }
}


/*
    C#에서 객체 생성 단계

    임의의 타입으로
    '첫 번째' 인스턴스'를 생성할 시
    수행되는 과정은 다음과 같다.

    정적변수 단계

        i) 정적 변수의 저장공간(메모리)를 0으로 초기화
        ii) 정적 변수에 대한 초기화 구문을 수행

        iii) 정적 생성자 수행
            만약에 상속관계라면
            가) 베이스 클래스의 정적 생성자 수행
            나) 자신의 정적 생성자 수행

    ============
    인스턴스 변수 단계

        i) 인스턴스 변수의 저장공간(메모리)를 0으로 초기화
        ii) 인스턴스 변수에 대한 초기화 구문을 수행

        iii) 인스턴스 생성자 수행
            만약에 상속관계라면
            가) 베이스 클래스의 인스턴스 생성자 수행
            나) 자신의 인스턴스 생성자 수행

*/