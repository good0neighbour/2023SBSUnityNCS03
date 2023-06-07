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

        //좌후 이동
        mpTransform.Rotate(Vector3.up, tH * mRotateAngle * Time.deltaTime);
        //<--초당 5 degree

        //전후 이동
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
    유니티 게임엔진에서 이동을 하는 방법

    i) 직접 position을 설정한다

    ii) 제공하는 이동변환 함수를 이용한다

    iii) 물리엔진의 힘을 빈다

    iv) 애니메이션에 이동 정보를 포함한다
*/