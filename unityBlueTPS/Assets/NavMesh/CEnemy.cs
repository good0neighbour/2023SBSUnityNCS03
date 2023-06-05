using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NavMeshAgent������Ʈ�� ��ũ��Ʈ���� �̿��ϱ� ����
using UnityEngine.AI;

public class CEnemy : MonoBehaviour
{
    CPChar_1 mPChar = null;

    //��ã�⸦ �����ϰ�, �������� �̵��ϴ� ����� ���� ������Ʈ
    [SerializeField]
    NavMeshAgent mNavMeshAgent = null;

    // Start is called before the first frame update
    void Start()
    {
        //�±׸� �̿��� �˻����� ���ΰ� ĳ���͸� ã��
        //<--�˻����ٴ� �̸� �����صδ� �� ���� ����
        mPChar = GameObject.FindGameObjectWithTag("tagPChar").GetComponent<CPChar_1>();

        //������Ʈ ���� ���
        mNavMeshAgent = GetComponent<NavMeshAgent>();

        //������ ����
        mNavMeshAgent.SetDestination(mPChar.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (mNavMeshAgent)
        {
            if (mNavMeshAgent.enabled)
            {
                //������ ����
                mNavMeshAgent.SetDestination(mPChar.transform.position);
            }
        }
    }
}
