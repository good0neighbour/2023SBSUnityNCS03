using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

    '목표지점에 도달하면 공격을 수행'하는

    인공지능을
    행동트리 기반으로 구현하자.



        Selector를 이용해보자.

        목표지점에 도착했는지 판단을 수행하는 기능도
        ActionNode로 구성하자.
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
        //행동트리를 구축

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
        //행동트리를 수행
        mRootNode.Evaluate();
    }

    NodeStates DoIsArrived()
    {
        //목적지에 도달했으면 성공, 아니면 실패 리턴
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
        //이동
        Debug.Log("DoMove");
        //선형보간을 기반으로 게임오브젝트의 이동을 수행하는 함수다
        this.transform.position = Vector3.MoveTowards(this.transform.position, mTargetPosition, mScalarSpeed * Time.deltaTime);

        return NodeStates.SUCCESS;
    }


    NodeStates DoAttack()
    {
        // 공격동작
        Debug.Log("<color='blue'>Do Attack</color>");

        return NodeStates.SUCCESS;
    }




    //기즈모(게임세계 편집을 위한 UI도구)는 여기에서 렌더링한다
    private void OnDrawGizmos()
    {
        //목적지점을 기즈모를 이용하여 표시
        Gizmos.color = new Color(1f, 1f, 0f, 1f);
        Gizmos.DrawWireCube(mTargetPosition, Vector3.one * 0.5f);
    }
}
