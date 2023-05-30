using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIKAni : MonoBehaviour
{
    [SerializeField]
    Animator mAnimator = null;

    [SerializeField]
    GameObject mLookAt = null;

    [SerializeField]
    GameObject mGrab = null;

    bool mIsOn = false;

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "IK on"))
        {
            mIsOn = true;
        }

        if (GUI.Button(new Rect(100, 0, 100, 100), "IK off"))
        {
            mIsOn = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //게임 갱신 주기에 맞춰 지속적으로 호출되는 함수다.
    private void OnAnimatorIK(int layerIndex)
    {
        if (mIsOn)
        {
            //자주 사용하는 기능이라 바라보는 IK기능은 아예 함수가 만들어져 있다.
            //avatar를 기반으로 작동한다
            mAnimator.SetLookAtWeight(1.0f);
            mAnimator.SetLookAtPosition(mLookAt.transform.position);


            if (mGrab)
            {
                mAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
                mAnimator.SetIKPosition(AvatarIKGoal.RightHand, mGrab.transform.position);

                mAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
                mAnimator.SetIKRotation(AvatarIKGoal.RightHand, mGrab.transform.rotation);
            }


        }
        else
        {
            mAnimator.SetLookAtWeight(0.0f);

            //if (mGrab)
            //{
                mAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
                mAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);
            //}
        }
    }



}
