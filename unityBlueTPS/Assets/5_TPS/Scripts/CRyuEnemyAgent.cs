using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CRyuEnemyAgent : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent mNavMeshAgent = null;

    [SerializeField]
    GameObject mTarget = null;

    [SerializeField]
    Animator mAnimator = null;




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


    //수류탄 투척 애니 여부
    [SerializeField]
    public bool mIsThrowAni = false;

    //투척 애니메이션 클립
    [SerializeField]
    public AnimationClip mAniClipThrow = null;


    // Start is called before the first frame update
    void Start()
    {

        //길찾기 테스트
        mNavMeshAgent = GetComponent<NavMeshAgent>();
        mAnimator = GetComponent<Animator>();


        mTarget = FindObjectOfType<CPChar_1>().gameObject;

        //자신이 처음 있던 곳을 생성지점으로 일단 가정
        mSpawnAnyPosition = this.transform.position;
        mTargetPosition = mTarget.transform.position;

        //행동트리 구축
        BuildBTs();
        //mNavMeshAgent.SetDestination(mTarget.transform.position);
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
        //float tSpeed = mNavMeshAgent.velocity.magnitude;
        //mAnimator.SetFloat("fSpeed", tSpeed);
    }

    NodeStates DoIsGrenade()
    {
        if (mIsGrenade)
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

        //Throw애니메이션이 끝나면 다음의 동작을 수행
        if(!mIsThrowAni)
        {
            mNavMeshAgent.enabled = true;
            mNavMeshAgent.SetDestination(mSpawnAnyPosition);

            //애니메이션 제어
            mAnimator.applyRootMotion = false;
            //root motion 비활성화: 애니메이션에 포함된 위치 애니메이션을 비활성화
            mAnimator.SetFloat("fSpeed", mNavMeshAgent.velocity.magnitude);
        }

        return NodeStates.SUCCESS;
    }

    NodeStates DoFollow()
    {
        Debug.Log("DoFollow");
        mNavMeshAgent.SetDestination(mTargetPosition);

        //애니메이션 제어
        mAnimator.SetFloat("fSpeed", mNavMeshAgent.velocity.magnitude);

        return NodeStates.SUCCESS;
    }

    NodeStates DoThrowGrenade()
    {
        Debug.Log("<color='red'>Do Throw Grenade</color>");

        mIsGrenade = false;

        //애니메이션 제어
        mIsThrowAni = true;
        mAnimator.SetBool("bThrow", mIsThrowAni);
        mAnimator.applyRootMotion = true;   //root motion 활성화: 애니메이션에 포함된 위치 애니메이션을 활성화

        //수류탄 생성과 투척
        //this.GetComponent<CRyuEnemyPara>().DoFire();


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
