using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

    '��ǥ������ ����'�ϴ�

    �ΰ�������
    �ൿƮ�� ������� ��������.

*/

public class CRyuAgent_step_0 : MonoBehaviour
{

    [SerializeField]
    Vector3 mTargetPosition = new Vector3(0f, 0f, 10f);

    float mScalarSpeed = 1f;


    Sequence mRootNode = null;


    // Start is called before the first frame update
    void Start()
    {
        //�ൿƮ���� ����

        //level 2
        ActionNode tANMove = new ActionNode(DoMove);
        List<Node> tLevel_2 = new List<Node>();
        tLevel_2.Add(tANMove);

        //level 1
        mRootNode = new Sequence(tLevel_2);
    }

    // Update is called once per frame
    void Update()
    {
        //�ൿƮ���� ����
        mRootNode.Evaluate();
    }

    NodeStates DoMove()
    {
        //�̵�
        Debug.Log("DoMove");
        //���������� ������� ���ӿ�����Ʈ�� �̵��� �����ϴ� �Լ���
        this.transform.position = Vector3.MoveTowards(this.transform.position, mTargetPosition, mScalarSpeed * Time.deltaTime);

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

    //�����(���Ӽ��� ������ ���� UI����)�� ���⿡�� �������Ѵ�
    private void OnDrawGizmos()
    {
        //���������� ����� �̿��Ͽ� ǥ��
        Gizmos.color = new Color(1f, 1f, 0f, 1f);
        Gizmos.DrawWireCube(mTargetPosition, Vector3.one * 0.5f);
    }
}
