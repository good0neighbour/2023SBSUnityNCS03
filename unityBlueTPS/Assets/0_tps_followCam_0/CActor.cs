using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CActor : MonoBehaviour
{
    Transform mpTransform = null;

    [SerializeField]
    float mRotateAngle = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        mpTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float tV = Input.GetAxis("Vertical");
        float tH = Input.GetAxis("Horizontal");

        //���� �̵�
        mpTransform.Rotate(Vector3.up, tH * mRotateAngle * Time.deltaTime);
        //<--�ʴ� 5 degree

        //���� �̵�
        Vector3 tVelocity = Vector3.zero;
        tVelocity = mpTransform.forward * tV * 5.0f;

        if (!tVelocity.Equals(Vector3.zero))
        {
            mpTransform.Translate(tVelocity * Time.deltaTime, Space.World);
            //vs Vector3.forward (0, 0, 1)
        }
    }
}

/*
    ����Ƽ ���ӿ������� �̵��� �ϴ� ���

    i) ���� position�� �����Ѵ�

    ii) �����ϴ� �̵���ȯ �Լ��� �̿��Ѵ�

    iii) ���������� ���� ���

    iv) �ִϸ��̼ǿ� �̵� ������ �����Ѵ�
*/