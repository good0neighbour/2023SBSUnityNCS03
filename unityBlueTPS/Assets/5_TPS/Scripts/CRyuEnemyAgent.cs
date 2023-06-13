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
    //����ź ���� ����
    [SerializeField]
    bool mIsGrenade = false;

    //������ ��������
    [SerializeField]
    Vector3 mSpawnAnyPosition = Vector3.zero;

    //������ ��������
    [SerializeField]
    Vector3 mTargetPosition = Vector3.zero;

    //������ �������������� �ݰ�
    [SerializeField]
    float mDetectedRadius = 7f;

    //�ൿƮ��
    Sequence mRootNode = null;


    //����ź ��ô �ִ� ����
    [SerializeField]
    public bool mIsThrowAni = false;

    //��ô �ִϸ��̼� Ŭ��
    [SerializeField]
    public AnimationClip mAniClipThrow = null;


    // Start is called before the first frame update
    void Start()
    {

        //��ã�� �׽�Ʈ
        mNavMeshAgent = GetComponent<NavMeshAgent>();
        mAnimator = GetComponent<Animator>();


        mTarget = FindObjectOfType<CPChar_1>().gameObject;

        //�ڽ��� ó�� �ִ� ���� ������������ �ϴ� ����
        mSpawnAnyPosition = this.transform.position;
        mTargetPosition = mTarget.transform.position;

        //�ൿƮ�� ����
        BuildBTs();
        //mNavMeshAgent.SetDestination(mTarget.transform.position);
    }
    void BuildBTs()
    {
        //�ൿƮ���� ����

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

        //Throw�ִϸ��̼��� ������ ������ ������ ����
        if(!mIsThrowAni)
        {
            mNavMeshAgent.enabled = true;
            mNavMeshAgent.SetDestination(mSpawnAnyPosition);

            //�ִϸ��̼� ����
            mAnimator.applyRootMotion = false;
            //root motion ��Ȱ��ȭ: �ִϸ��̼ǿ� ���Ե� ��ġ �ִϸ��̼��� ��Ȱ��ȭ
            mAnimator.SetFloat("fSpeed", mNavMeshAgent.velocity.magnitude);
        }

        return NodeStates.SUCCESS;
    }

    NodeStates DoFollow()
    {
        Debug.Log("DoFollow");
        mNavMeshAgent.SetDestination(mTargetPosition);

        //�ִϸ��̼� ����
        mAnimator.SetFloat("fSpeed", mNavMeshAgent.velocity.magnitude);

        return NodeStates.SUCCESS;
    }

    NodeStates DoThrowGrenade()
    {
        Debug.Log("<color='red'>Do Throw Grenade</color>");

        mIsGrenade = false;

        //�ִϸ��̼� ����
        mIsThrowAni = true;
        mAnimator.SetBool("bThrow", mIsThrowAni);
        mAnimator.applyRootMotion = true;   //root motion Ȱ��ȭ: �ִϸ��̼ǿ� ���Ե� ��ġ �ִϸ��̼��� Ȱ��ȭ

        //����ź ������ ��ô
        //this.GetComponent<CRyuEnemyPara>().DoFire();


        return NodeStates.SUCCESS;
    }


    private void OnDrawGizmos()
    {
        ////���������� ����� �̿��Ͽ� ǥ��
        //Gizmos.color = new Color(1f, 1f, 0f, 1f);
        //Gizmos.DrawWireCube(mTargetPosition, Vector3.one * 0.5f);

        //Ž�������� ����� �̿��Ͽ� ǥ��
        Gizmos.color = new Color(1f, 0f, 0f, 1f);
        Gizmos.DrawWireSphere(this.transform.position, mDetectedRadius);
    }
}
