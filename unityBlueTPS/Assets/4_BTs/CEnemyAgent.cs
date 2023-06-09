using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NavMeshAgent������Ʈ�� ��ũ��Ʈ���� �̿��ϱ� ����
using UnityEngine.AI;

public class CEnemyAgent : MonoBehaviour
{
    CPChar_1 mPChar = null;

    //��ã�⸦ �����ϰ�, �������� �̵��ϴ� ����� ���� ������Ʈ
    [SerializeField]
    NavMeshAgent mNavMeshAgent = null;



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


    // Start is called before the first frame update
    void Start()
    {
        //�±׸� �̿��� �˻����� ���ΰ� ĳ���͸� ã��
        //<--�˻����ٴ� �̸� �����صδ� �� ���� ����
        mPChar = GameObject.FindGameObjectWithTag("tagPChar").GetComponent<CPChar_1>();

        //������Ʈ ���� ���
        mNavMeshAgent = GetComponent<NavMeshAgent>();

        //������ ����
        //mNavMeshAgent.SetDestination(mPChar.transform.position);

        //�ڽ��� ó�� �ִ� ���� ������������ �ϴ� ����
        mSpawnAnyPosition = this.transform.position;
        //
        mTargetPosition = mPChar.transform.position;


        //�ൿƮ�� ����
        BuildBTs();
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


        //if (mNavMeshAgent)
        //{
        //    if (mNavMeshAgent.enabled)
        //    {
        //        //������ ����
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
        ////���������� ����� �̿��Ͽ� ǥ��
        //Gizmos.color = new Color(1f, 1f, 0f, 1f);
        //Gizmos.DrawWireCube(mTargetPosition, Vector3.one * 0.5f);

        //Ž�������� ����� �̿��Ͽ� ǥ��
        Gizmos.color = new Color(1f, 0f, 0f, 1f);
        Gizmos.DrawWireSphere(this.transform.position, mDetectedRadius);
    }
}
