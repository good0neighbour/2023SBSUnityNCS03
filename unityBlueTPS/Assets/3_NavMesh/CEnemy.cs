using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
    ����Ƽ�� Navigation�� ũ�� ������ ���� �� ������ �����ȴ�

    i) NavMesh:         �̸� ����ũ�� �������� �����
    ii) NavMeshAgent:   �̸� ����ũ�� ���������� ������� ��ã�⸦ ����, ���ӿ�����Ʈ�� �̵� ���
    iii) NavMeshObstacle ������Ʈ: ���� �߿� ��ġ�� �̵���ų �� �ִ� ���� ��ֹ�
                    Carve�ɼ��� ���� '���� ��'�� ���������� ����ŷ�� ���� �����ϴ�.

    �����޽� ��ũ�� ���� �� ������ �����Ѵ�.

    i)Generate OffMesh Links: NavMesh���� �����ϴ� �����޽���ũ ����̴�.
        <-- ���� �и��� NavMesh�������� ������ ���ִ� ������.
        <-- NavMesh ������ ���Ե� ���� ������.

    ii) OffMesh Link ������Ʈ: ������Ʈ ���·� �����ϴ� �����޽���ũ ����̴�.
        <-- ����ũ�� ���� �ʾƵ� ����ȴ�.
        <-- ���� �и��� NavMesh�������� ������ ���ִ� ������.
        <-- ��������, ������ ���� �ۼ��ڰ� Ŀ���͸���¡ �� �� �ְ� ������� �ִ�.
        <-- Ư��ȭ�� ������.


    Area
    ������ ���� ������ '���'�� ����ġ�� �����ϴ� ���̴�.

*/


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
