using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//열거형, 미리 정의해둔 값을 나열해둔 타입
enum E_IN_AIR
{
    IN_GROUND,  //땅에 닿아있는 상태
    IN_AIR,     //공중에 떠 있는 상태, 중력 작용
    IN_AIR_NOGRAVITY    //공중에 떠 있는 상태, 무중력
}


public class CPChar_1 : MonoBehaviour
{
    //카메라 오브젝트
    [SerializeField]
    CFollowCam_1 mCamera = null;

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


    //캐릭터 컨트롤러의 isGrounded관찰용도
    [SerializeField]
    bool mIsGrounded = false;

    [SerializeField]
    float mJumpPower = 0.0f; //점프 힘(속력, 속도의 y성분만 취급하고 있다고 가정)

    [SerializeField]
    E_IN_AIR mInAir = E_IN_AIR.IN_GROUND;


    // Start is called before the first frame update
    void Start()
    {
        if (mCharController.isGrounded)
        {
            mInAir = E_IN_AIR.IN_GROUND;
        }
        else
        {
            mInAir = E_IN_AIR.IN_AIR;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!mCharController)
        {
            return;
        }

        //상태 결정 구문
        if (mCharController.isGrounded)
        {
            mInAir = E_IN_AIR.IN_GROUND;
        }

        if (Input.GetKeyUp(KeyCode.Space))  //점프 키 입력이 있다면
        {

            if(mCharController.isGrounded || !mCharController.isGrounded)   //<--사실 이 구문이 필요하지는 않다. 관찰용
            {
                if(mInAir != E_IN_AIR.IN_AIR) //'점프 상태'가 아니라면
                {
                    Debug.Log("Jump Begin");
                    mVecDir.y = mJumpPower;

                    mInAir = E_IN_AIR.IN_AIR;   //'점프 상태'로 '상태 전이'
                }
                else if (mInAir == E_IN_AIR.IN_AIR)
                {
                    Debug.Log("No gravity Begin");

                    mInAir = E_IN_AIR.IN_AIR_NOGRAVITY; //'무중력 부양 상태'로 '상태 전이'
                }
            }
        }



        //결정된 상태를 기반으로 '행동' <-- 여기서 행동은 속도 결정
        //<-- 이 코드 문단에서는 상태 변경은 금한다
        if (mInAir != E_IN_AIR.IN_AIR && mInAir != E_IN_AIR.IN_AIR_NOGRAVITY) //점프 상태 && 무중력부양상태가 아니라면
        {
            //'캐릭터 컨틀롤러'의 작동방식을 고려하여 다음과 같이 처리
            if (!mCharController.isGrounded)
            {
                mVecDir.y = mVecDir.y + GRAVITY * Time.deltaTime;
            }
            else
            {
                float tV = Input.GetAxis("Vertical");   //[-1, 1] 연속적인 값
                float tH = Input.GetAxis("Horizontal"); //[-1, 1] 연속적인 값
                Vector3 tVelocity = new Vector3(tH, 0f, tV);
                mVecDir = mCharController.transform.TransformDirection(tVelocity);

                mVecDir = mVecDir * mScarlarSpeed;
            }
        }
        else if (mInAir == E_IN_AIR.IN_AIR) //점프 상태라면
        {
            mVecDir.y = mVecDir.y + GRAVITY * Time.deltaTime;
        }
        else if (mInAir == E_IN_AIR.IN_AIR_NOGRAVITY)
        {
            //무중력 부양 상태
            //  여기서는 무중력 부양 상태에서 zx평면 이동이 가능하다고 가정.
            float tV = Input.GetAxis("Vertical");   //[-1, 1] 연속적인 값
            float tH = Input.GetAxis("Horizontal"); //[-1, 1] 연속적인 값
            Vector3 tVelocity = new Vector3(tH, 0f, tV);
            mVecDir = mCharController.transform.TransformDirection(tVelocity);

            mVecDir = mVecDir * mScarlarSpeed;
        }

        


        //결정된 속도로 이동, 시간기반 진행( CharacterController컴포넌트의 기능을 이용 )
        mCharController.Move(mVecDir * Time.deltaTime);


        //카메라가 바라보는 방향으로 이동하기 위해 캐릭터의 방향 설정
        //==============
        Vector3 tOffset = mCamera.transform.forward;
        tOffset.y = 0f; //zx평면에서의 방향만 고려하겠다.
        //응시점 구하기 = 캐릭터의 현재위치 + 카메라의 전방 방향( 크기는 1 )
        Vector3 tLookAtPosition = this.transform.position + tOffset;
        //캐릭터가 응시점을 바라보게 한다.
        this.transform.LookAt(tLookAtPosition);
        //==============
    }
}
