using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CScenePlayGame : MonoBehaviour
{
    //슬라임 터치 시마다 얻을 점수
    public int mScore = 0;

    //플레이 게임 UI
    public CUIPlayGame mpUIPlayGame = null;


    public CGrid mpGrid = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Input 유니티에서 제공하는 입력 전담 클래스
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("left mouse btn");

            //'반직선Ray'과 임의의 물체의 '충돌'
            //<--충돌(물리작용)이 일어나야 하므로 슬라임에 충돌체(collider)컴포넌트를 추가한다

            //마우스를 클릭한 지점으로부터 3D공간에 수직으로 가상의 반직선을 만든다
            Ray tRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            bool tIsCollision = false;
            RaycastHit tHit;    //반직선과 물체의 충돌관련 정보
            //Physics 물리 전담 클래스
            tIsCollision = Physics.Raycast(tRay, out tHit, Mathf.Infinity);
            
            if(tIsCollision)
            {
                //충돌이다
                Debug.Log("<color='green'>ray is collision</color>");

                //태그tag(게임내에서 사용되는 일종의 식별용 꼬리표) 검사
                if (tHit.collider.CompareTag("tagEnemy"))
                {
                    //슬라임 터치
                    Debug.Log("<color='red'>Slime Touched</color>");

                    //점수 증가
                    mScore += 10;

                    Debug.Log($"<color='blue'>{mScore.ToString()}</color>");

                    //UI갱신
                    mpUIPlayGame.UpdateScore(mScore);

                    //슬라임의 데미지 애니메이션 수행
                    mpGrid.mpCurrentSlime.DoAniDamage();
                }
            }


        }
        
        //if (Input.GetMouseButtonDown(1))
        //{
        //    Debug.Log("right mouse btn");
        //}

        //if (Input.GetMouseButtonDown(2))
        //{
        //    Debug.Log("mouse wheel btn");
        //}
    }
}
