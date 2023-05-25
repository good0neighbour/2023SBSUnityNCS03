using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIKAni : MonoBehaviour
{
    [SerializeField]
    Animator mAnimator = null;

    [SerializeField]
    GameObject mLookAt = null;

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

    private void OnAnimatorIK(int layerIndex)
    {
        if (mIsOn)
        {
            //���� ����ϴ� ����̶� �ٶ󺸴� IK����� �ƿ� �Լ��� ������� �ִ�.
            //avatar�� ������� �۵��Ѵ�
            mAnimator.SetLookAtWeight(1.0f);
            mAnimator.SetLookAtPosition(mLookAt.transform.position);
        }
        else
        {
            mAnimator.SetLookAtWeight(0.0f);
        }
    }



}
