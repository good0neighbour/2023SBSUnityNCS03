using UnityEngine;

public class CActor : MonoBehaviour
{
    [SerializeField] private float mMovingSwitchSpeedmult = 1.0f;
    private Animator mAnimator = null;
    private float mMovingForward = 0.0f;
    private float mMovingLeft = 0.0f;

    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        // ���� ������ �ִϸ��̼� ����
        if (Input.GetKey(KeyCode.W))
        {
            if (1.0f > mMovingForward)
            {
                mMovingForward += Time.deltaTime * mMovingSwitchSpeedmult;
                if (1.0f < mMovingForward)
                {
                    mMovingForward = 1.0f;
                }

                // Animation Controller ���� ����
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

                // Animation Controller ���� ����
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

        // �¿� ������ �ִϸ��̼� ����
        if (Input.GetKey(KeyCode.A))
        {
            if (1.0f > mMovingLeft)
            {
                mMovingLeft += Time.deltaTime * mMovingSwitchSpeedmult;
                if (1.0f < mMovingLeft)
                {
                    mMovingLeft = 1.0f;
                }

                // Animation Controller ���� ����
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

                //Animation Controller ���� ����
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
    }
}
