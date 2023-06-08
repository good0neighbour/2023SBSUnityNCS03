using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NavMeshAgent컴포넌트를 스크립트에서 이용하기 위해
using UnityEngine.AI;

public class CEnemyAgent : MonoBehaviour
{
    CPChar_1 mPChar = null;

    //길찾기를 수행하고, 목적지로 이동하는 기능을 담은 컴포넌트
    [SerializeField]
    NavMeshAgent mNavMeshAgent = null;



    //AI
    //수류탄 소지 여부
    [SerializeField]
    bool mIsGrenade = false;

    //임의의 스폰지점
    [SerializeField]
    Vector3 mSpawnAnyPosition = Vector3.zero;

    //임의의 목적지점
    [SerializeField]
    Vector3 mTargetPosition = Vector3.zero;

    //임의의 목적지점에서의 반경
    [SerializeField]
    float mDetectedRadius = 7f;

    //행동트리
    Sequence mRootNode = null;


    // Start is called before the first frame update
    void Start()
    {
        //태그를 이용한 검색으로 주인공 캐릭터를 찾음
        //<--검색보다는 미리 연동해두는 게 가장 좋다
        mPChar = GameObject.FindGameObjectWithTag("tagPChar").GetComponent<CPChar_1>();

        //컴포넌트 참조 얻기
        mNavMeshAgent = GetComponent<NavMeshAgent>();

        //목적지 설정
        //mNavMeshAgent.SetDestination(mPChar.transform.position);

        //자신이 처음 있던 곳을 생성지점으로 일단 가정
        mSpawnAnyPosition = this.transform.position;
        //
        mTargetPosition = mPChar.transform.position;


        //행동트리 구축

    }

    // Update is called once per frame
    void Update()
    {
        //if (mNavMeshAgent)
        //{
        //    if (mNavMeshAgent.enabled)
        //    {
        //        //목적지 설정
        //        mNavMeshAgent.SetDestination(mPChar.transform.position);
        //    }
        //}
    }

    NodeStates DoIsGrenade()
    {
        if(mIsGrenade)
        {
            return NodeStates.SUCCESS;
        }
        else
        {
            return NodeStates.FAILURE;
        }
    }

    NodeStates DoIsArrive()
    {
        if(true)
        {
            return NodeStates.SUCCESS;
        }
        else
        {
            return NodeStates.FAILURE;
        }
    }

    NodeStates DoAvoid()
    {
        return NodeStates.SUCCESS;
    }

    NodeStates DoFollow()
    {
        return NodeStates.SUCCESS;
    }

    NodeStates DoThrowGrenade()
    {
        return NodeStates.SUCCESS;
    }


}
