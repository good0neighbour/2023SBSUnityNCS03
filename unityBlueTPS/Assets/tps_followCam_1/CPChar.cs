using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPChar : MonoBehaviour
{
    //캐릭터의 이동을 담당하는 컴포넌트
    [SerializeField]
    CharacterController mCharController = null;

    //최종 속도
    Vector3 mVecDir = Vector3.zero;

    //zx평면에서의 이동
    [SerializeField]
    float mScarlarSpeed = 0f;   //zx평면에서의 속력

    //y축에서의 이동
    [SerializeField]
    float GRAVITY = -9.8f;  //중력가속도(속력)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!mCharController)
        {
            return;
        }

        if (mCharController.isGrounded)
        {
            //was...touching ground..when last moving

            //zx평면에서의 이동
            float tV = Input.GetAxis("Vertical");   //[-1, 1] 연속적인 값
            float tH = Input.GetAxis("Horizontal"); //[-1, 1] 연속적인 값

            //tV를 z축 요소로, tH를 x축 요소로, y축 요소는 결정하지 않음
            Vector3 tVelocity = new Vector3(tH, 0f, tV);

            //월드좌표에서의 벡터 = TransformDirection(절대좌표에서의 벡터)
            mVecDir = mCharController.transform.TransformDirection(tVelocity);

            //속도 결정
            /*
                오일러 축차적 방법에 의한 속도, 위치 구하기

                Azx = 0
                Vzx = Vzx + Azx * t

                Szx = Szx + Vzx * t
            */
            mVecDir = mVecDir * mScarlarSpeed;
        }
        else
        {
            //y축 중력가속도 운동

            //속도 결정
            /*
                오일러 축차적 방법에 의한 속도, 위치 구하기

                Ay = GRAVITY
                Vy = Vy + Ay * t
                Sy = Sy + Vy * t
            */

            mVecDir.y = mVecDir.y + GRAVITY * Time.deltaTime;
        }


        //결정된 속도로 이동, 시간기반 진행( CharacterController컴포넌트의 기능을 이용 )
        mCharController.Move(mVecDir * Time.deltaTime);
    }
}
