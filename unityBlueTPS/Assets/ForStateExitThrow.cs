using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForStateExitThrow : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //임의의 애니메이션 순간에 다음을 수행한다

        //원래 애니메이션 길이를 정규화된 시간 비율로 연산하여 지금 애니메이션 시간을 구한다
        float tCurTime = animator.GetComponent<CRyuEnemyAgent>().mAniClipThrow.length * stateInfo.normalizedTime;


        //수류탄 생성과 투척
        //this.GetComponent<CRyuEnemyPara>().DoFire();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<CRyuEnemyAgent>().mIsThrowAni = false;
        animator.SetBool("bThrow", false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
