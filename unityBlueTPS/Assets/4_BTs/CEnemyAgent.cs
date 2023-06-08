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

    }

    // Update is called once per frame
    void Update()
    {
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
