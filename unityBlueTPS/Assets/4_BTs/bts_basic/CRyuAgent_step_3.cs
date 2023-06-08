using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

    '��ǥ������ �����ϸ� ������ ����'�ϴ�

    �ΰ�������
    �ൿƮ�� ������� ��������.



        Selector�� �̿��غ���.

        ��ǥ������ �����ߴ��� �Ǵ��� �����ϴ� ��ɵ�
        ActionNode�� ��������.
*/

public class CRyuAgent_step_3 : MonoBehaviour
{

    [SerializeField]
    Vector3 mTargetPosition = new Vector3(0f, 0f, 10f);

    float mScalarSpeed = 1f;


    Sequence mRootNode = null;


    // Start is called before the first frame update
    void Start()
    {
        //�ൿƮ���� ����

        //level 4
        ActionNode tANMove = new ActionNode(DoMove);

        //level 3
        ActionNode tANIsArrived = new ActionNode(DoIsArrived);
        Inverter tNot = new Inverter(tANMove);
        List<Node> tLevel_3 = new List<Node>();
        tLevel_3.Add(tANIsArrived);
        tLevel_3.Add(tNot);

        //level 2
        Selector mSelectArrived = new Selector(tLevel_3);
        ActionNode tANAttack = new ActionNode(DoAttack);
        List<Node> tLevel_2 = new List<Node>();
        tLevel_2.Add(mSelectArrived);
        tLevel_2.Add(tANAttack);

        //level 1
        mRootNode = new Sequence(tLevel_2);
    }

    // Update is called once per frame
    void Update()
    {
        //�ൿƮ���� ����
        mRootNode.Evaluate();
    }

    NodeStates DoIsArrived()
    {
        //�������� ���������� ����, �ƴϸ� ���� ����
        if (Vector3.Distance(this.transform.position, mTargetPosition) <= 0.01f)
        {
            Debug.Log("<color='red>Move Complete</color>");

            return NodeStates.SUCCESS;
        }
        else
        {
            return NodeStates.FAILURE;
        }
    }

    NodeStates DoMove()
    {
        //�̵�
        Debug.Log("DoMove");
        //���������� ������� ���ӿ�����Ʈ�� �̵��� �����ϴ� �Լ���
        this.transform.position = Vector3.MoveTowards(this.transform.position, mTargetPosition, mScalarSpeed * Time.deltaTime);

        return NodeStates.SUCCESS;
    }


    NodeStates DoAttack()
    {
        // ���ݵ���
        Debug.Log("<color='blue'>Do Attack</color>");

        return NodeStates.SUCCESS;
    }




    //�����(���Ӽ��� ������ ���� UI����)�� ���⿡�� �������Ѵ�
    private void OnDrawGizmos()
    {
        //���������� ����� �̿��Ͽ� ǥ��
        Gizmos.color = new Color(1f, 1f, 0f, 1f);
        Gizmos.DrawWireCube(mTargetPosition, Vector3.one * 0.5f);
    }
}
