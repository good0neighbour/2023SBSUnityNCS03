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
        BuildBTs();
    }

    void BuildBTs()
    {
        //행동트리를 구축

        //level 4
        ActionNode tANAvoid = new ActionNode(DoAvoid);
        ActionNode tANFollow = new ActionNode(DoFollow);

        //level 3
        //level_3_0
        ActionNode tANIsGrenade = new ActionNode(DoIsGrenade);
        Inverter tNotAvoid = new Inverter(tANAvoid);
        List<Node> tLevel_3_0 = new List<Node>();
        tLevel_3_0.Add(tANIsGrenade);
        tLevel_3_0.Add(tNotAvoid);

        //level_3_1
        ActionNode tANIsArrived = new ActionNode(DoIsArrived);
        Inverter tNotFollow = new Inverter(tANFollow);
        List<Node> tLevel_3_1 = new List<Node>();
        tLevel_3_1.Add(tANIsArrived);
        tLevel_3_1.Add(tNotFollow);

        //level 2
        Selector mSelectAvoid = new Selector(tLevel_3_0);
        Selector mSelectFollow = new Selector(tLevel_3_1);
        ActionNode tANThrowGrenade = new ActionNode(DoThrowGrenade);
        List<Node> tLevel_2 = new List<Node>();
        tLevel_2.Add(mSelectAvoid);
        tLevel_2.Add(mSelectFollow);
        tLevel_2.Add(tANThrowGrenade);

        //level 1
        mRootNode = new Sequence(tLevel_2);
    }



    // Update is called once per frame
    void Update()
    {
        mRootNode.Evaluate();


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
            Debug.Log("Is Grenade, true");

            return NodeStates.SUCCESS;
        }
        else
        {
            return NodeStates.FAILURE;
        }
    }

    NodeStates DoIsArrived()
    {
        //if (true)
        if (Vector3.Distance(this.transform.position, mTargetPosition) <= mDetectedRadius)
        {
            Debug.Log("Is Arrived, true");

            mNavMeshAgent.enabled = false;


            return NodeStates.SUCCESS;
        }
        else
        {
            return NodeStates.FAILURE;
        }
    }

    NodeStates DoAvoid()
    {
        Debug.Log("DoAvoid");

        mNavMeshAgent.enabled = true;
        mNavMeshAgent.SetDestination(mSpawnAnyPosition);

        


        return NodeStates.SUCCESS;
    }

    NodeStates DoFollow()
    {
        Debug.Log("DoFollow");
        mNavMeshAgent.SetDestination(mTargetPosition);

        return NodeStates.SUCCESS;
    }

    NodeStates DoThrowGrenade()
    {
        Debug.Log("<color='red'>Do Throw Grenade</color>");

        mIsGrenade = false;

        return NodeStates.SUCCESS;
    }


    private void OnDrawGizmos()
    {
        ////목적지점을 기즈모를 이용하여 표시
        //Gizmos.color = new Color(1f, 1f, 0f, 1f);
        //Gizmos.DrawWireCube(mTargetPosition, Vector3.one * 0.5f);

        //탐지범위를 기즈모를 이용하여 표시
        Gizmos.color = new Color(1f, 0f, 0f, 1f);
        Gizmos.DrawWireSphere(this.transform.position, mDetectedRadius);
    }
}
