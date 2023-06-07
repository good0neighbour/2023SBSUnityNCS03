using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
    유니티의 Navigation은 크게 다음과 같이 세 가지로 구성된다

    i) NavMesh:         미리 베이크된 지형정보 만들기
    ii) NavMeshAgent:   미리 베이크된 지형정보를 기반으로 길찾기를 수행, 게임오브젝트의 이동 기능
    iii) NavMeshObstacle 컴포넌트: 실행 중에 위치를 이동시킬 수 있는 동적 장애물
                    Carve옵션을 통해 '실행 중'에 지형정보의 베이킹을 변경 가능하다.

    오프메쉬 링크는 다음 두 가지를 제공한다.

    i)Generate OffMesh Links: NavMesh에서 제공하는 오프메쉬링크 기능이다.
        <-- 서로 분리된 NavMesh정보끼리 연결을 해주는 정보다.
        <-- NavMesh 정보에 포함된 범용 정보다.

    ii) OffMesh Link 컴포넌트: 컴포넌트 형태로 제공하는 오프메쉬링크 기능이다.
        <-- 베이크가 되지 않아도 적용된다.
        <-- 서로 분리된 NavMesh정보끼르 연결을 해주는 정보다.
        <-- 시작지점, 끝지점 등을 작성자가 커스터마이징 할 수 있게 만들어져 있다.
        <-- 특수화된 정보다.


    Area
    임의의 지형 영역에 '비용'의 가중치를 적용하는 것이다.

*/


//NavMeshAgent컴포넌트를 스크립트에서 이용하기 위해
using UnityEngine.AI;

public class CEnemy : MonoBehaviour
{
    CPChar_1 mPChar = null;

    //길찾기를 수행하고, 목적지로 이동하는 기능을 담은 컴포넌트
    [SerializeField]
    NavMeshAgent mNavMeshAgent = null;

    // Start is called before the first frame update
    void Start()
    {
        //태그를 이용한 검색으로 주인공 캐릭터를 찾음
        //<--검색보다는 미리 연동해두는 게 가장 좋다
        mPChar = GameObject.FindGameObjectWithTag("tagPChar").GetComponent<CPChar_1>();

        //컴포넌트 참조 얻기
        mNavMeshAgent = GetComponent<NavMeshAgent>();

        //목적지 설정
        mNavMeshAgent.SetDestination(mPChar.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (mNavMeshAgent)
        {
            if (mNavMeshAgent.enabled)
            {
                //목적지 설정
                mNavMeshAgent.SetDestination(mPChar.transform.position);
            }
        }
    }
}
