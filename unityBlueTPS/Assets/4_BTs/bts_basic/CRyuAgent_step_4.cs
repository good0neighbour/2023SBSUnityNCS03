using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

    '��ǥ������ �����ϸ�
    Ž�� ���� �ȿ� ��� ������ ����'�ϴ�

    �ΰ�������
    �ൿƮ�� ������� ��������.



        Selector�� �̿��غ���.

        ��ǥ������ �����ߴ��� �Ǵ��� �����ϴ� ��ɵ�
        ActionNode�� ��������.
*/

public class CRyuAgent_step_4 : MonoBehaviour
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

        ActionNode tANDetect = new ActionNode(DoDetect);

        //level 3
        //level_3_0
        ActionNode tANIsArrived = new ActionNode(DoIsArrived);
        Inverter tNotArrived = new Inverter(tANMove);
        List<Node> tLevel_3_0 = new List<Node>();
        tLevel_3_0.Add(tANIsArrived);
        tLevel_3_0.Add(tNotArrived);

        //level_3_1
        ActionNode tANIsDetect = new ActionNode(DoIsDetect);
        Inverter tNotDetect = new Inverter(tANDetect);
        List<Node> tLevel_3_1 = new List<Node>();
        tLevel_3_1.Add(tANIsDetect);
        tLevel_3_1.Add(tNotDetect);

        //level 2
        Selector mSelectArrived = new Selector(tLevel_3_0);
        Selector mSelectDetect = new Selector(tLevel_3_1);
        ActionNode tANAttack = new ActionNode(DoAttack);
        List<Node> tLevel_2 = new List<Node>();
        tLevel_2.Add(mSelectArrived);
        tLevel_2.Add(mSelectDetect);
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



    NodeStates DoIsDetect()
    {
        GameObject tActor = GameObject.FindGameObjectWithTag("tagActor");

        //�ݰ� �ȿ� ��밡 Ž���Ǹ� ����, �ƴϸ� ���� ����
        if (Vector3.Distance(this.transform.position, tActor.transform.position) <= 3f)
        {
            Debug.Log("<color='red>Detect</color>");

            return NodeStates.SUCCESS;
        }
        else
        {
            return NodeStates.FAILURE;
        }
    }

    NodeStates DoDetect()
    {
        Debug.Log("<color='blue'>DoDetect</color>");
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

        //Ž�������� ����� �̿��Ͽ� ǥ��
        Gizmos.color = new Color(1f, 0f, 0f, 1f);
        Gizmos.DrawWireSphere(this.transform.position, 3f);
    }
}
