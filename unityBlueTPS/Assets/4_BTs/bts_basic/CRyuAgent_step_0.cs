using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

    '목표지점에 도달'하는

    인공지능을
    행동트리 기반으로 구현하자.




    행동트리 Behaviour Tree
    :트리 자료구조를 이용하여
    에이전트의 인공지능의 제어구조를 만드는 것이다.

    노드의 평가에 따라 실행의 흐름이 이루어진다

    행동트리의 노드의 특징
    반드시 리턴값을 가진다.
    Success ( true )
    failure ( false )
    running

    행동트리의 노드의 종류

        Sequence: 자식 노드 중 하나라도 false를 리턴하면 Sequence노드도 false를 리턴하며 종료
        Selector: 자식 노드 중 하나라도 true를 리턴하면 Selector노드도 true를 리턴하며 종료
        ActionNode: 실제 행동을 수행하는 노드, 단말 노드로 만들어진다

        Inverter: Not연산의 기능을 담당하는 노드

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
        //행동트리를 구축

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
        //행동트리를 수행
        mRootNode.Evaluate();
    }

    NodeStates DoMove()
    {
        //이동
        Debug.Log("DoMove");
        //선형보간을 기반으로 게임오브젝트의 이동을 수행하는 함수다
        this.transform.position = Vector3.MoveTowards(this.transform.position, mTargetPosition, mScalarSpeed * Time.deltaTime);

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

    //기즈모(게임세계 편집을 위한 UI도구)는 여기에서 렌더링한다
    private void OnDrawGizmos()
    {
        //목적지점을 기즈모를 이용하여 표시
        Gizmos.color = new Color(1f, 1f, 0f, 1f);
        Gizmos.DrawWireCube(mTargetPosition, Vector3.one * 0.5f);
    }
}
