using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�� ��ũ��Ʈ ������Ʈ�� �ݵ�� Animator������Ʈ�� �䱸�ϵ��� ����� attribute
[RequireComponent(typeof(Animator))]
public class testAttribute_4 : MonoBehaviour
{
    Animator mAnimator = null;

    private void Awake()
    {
        mAnimator = GetComponent<Animator>();

        mAnimator.applyRootMotion = true;
    }
}
