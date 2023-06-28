using UnityEngine;

public class CActor : MonoBehaviour
{
    [SerializeField] private float mMovingSwitchSpeedmult = 1.0f;
    private Animator mAnimator = null;
    private CharacterController mCharacterController = null;
    private float mMovingForward = 0.0f;
    private float mMovingLeft = 0.0f;
    private float mRotationY = 0.0f;

    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
        mCharacterController = GetComponent<CharacterController>();
        mRotationY = transform.localRotation.eulerAngles.y;
    }

    private void Update()
    {
        // 좌우 회전
        mRotationY += Input.GetAxis("Mouse X");
        transform.localRotation = Quaternion.Euler(0.0f, mRotationY, 0.0f);

        // 전후 움직임 애니메이션 동작
        if (Input.GetKey(KeyCode.W))
        {
            if (1.0f > mMovingForward)
            {
                mMovingForward += Time.deltaTime * mMovingSwitchSpeedmult;
                if (1.0f < mMovingForward)
                {
                    mMovingForward = 1.0f;
                }

                // Animation Controller 변수 설정
                mAnimator.SetFloat("MovingForward", mMovingForward);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (-1.0f < mMovingForward)
            {
                mMovingForward -= Time.deltaTime * mMovingSwitchSpeedmult;
                if (-1.0f > mMovingForward)
                {
                    mMovingForward = -1.0f;
                }

                // Animation Controller 변수 설정
                mAnimator.SetFloat("MovingForward", mMovingForward);
            }
        }
        else
        {
            switch (mMovingForward)
            {
                case 0.0f:
                    break;

                default:
                    if (0 < mMovingForward)
                    {
                        mMovingForward -= Time.deltaTime * mMovingSwitchSpeedmult;
                        if (0.0f > mMovingForward)
                        {
                            mMovingForward = 0.0f;
                        }
                    }
                    else
                    {
                        mMovingForward += Time.deltaTime * mMovingSwitchSpeedmult;
                        if (0.0f < mMovingForward)
                        {
                            mMovingForward = 0.0f;
                        }
                    }
                    mAnimator.SetFloat("MovingForward", mMovingForward);
                    break;
            }
        }

        // 좌우 움직임 애니메이션 동작
        if (Input.GetKey(KeyCode.A))
        {
            if (1.0f > mMovingLeft)
            {
                mMovingLeft += Time.deltaTime * mMovingSwitchSpeedmult;
                if (1.0f < mMovingLeft)
                {
                    mMovingLeft = 1.0f;
                }

                // Animation Controller 변수 설정
                mAnimator.SetFloat("MovingLeft", mMovingLeft);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (-1.0f < mMovingLeft)
            {
                mMovingLeft -= Time.deltaTime * mMovingSwitchSpeedmult;
                if (-1.0f > mMovingLeft)
                {
                    mMovingLeft = -1.0f;
                }

                //Animation Controller 변수 설정
                mAnimator.SetFloat("MovingLeft", mMovingLeft);
            }
        }
        else
        {
            switch (mMovingLeft)
            {
                case 0.0f:
                    break;

                default:
                    if (0 < mMovingLeft)
                    {
                        mMovingLeft -= Time.deltaTime * mMovingSwitchSpeedmult;
                        if (0.0f > mMovingLeft)
                        {
                            mMovingLeft = 0.0f;
                        }
                    }
                    else
                    {
                        mMovingLeft += Time.deltaTime * mMovingSwitchSpeedmult;
                        if (0.0f < mMovingLeft)
                        {
                            mMovingLeft = 0.0f;
                        }
                    }
                    mAnimator.SetFloat("MovingLeft", mMovingLeft);
                    break;
            }
        }

        // 주인공 전후좌우 이동
        mCharacterController.Move(new Vector3());
    }
}
