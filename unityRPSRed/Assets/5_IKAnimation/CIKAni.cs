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

    //���� ���� �ֱ⿡ ���� ���������� ȣ��Ǵ� �Լ���.
    private void OnAnimatorIK(int layerIndex)
    {
        if (mIsOn)
        {
            //���� ����ϴ� ����̶� �ٶ󺸴� IK����� �ƿ� �Լ��� ������� �ִ�.
            //avatar�� ������� �۵��Ѵ�
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
