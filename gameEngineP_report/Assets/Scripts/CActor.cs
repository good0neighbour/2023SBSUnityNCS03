using UnityEngine;

public class CActor : MonoBehaviour
{
    [SerializeField] private float mMoveSpeedmult = 1.0f;
    [SerializeField] private float mMovingSwitchSpeedmult = 1.0f;
    private Animator mAnimator = null;
    private CharacterController mCharacterController = null;
    private float mMovingForward = 0.0f;
    private float mMovingLeft = 0.0f;
    private float mRotationY = 0.0f;
    private float mDegreeToRadian = Mathf.PI / 180.0f;
    private float mSpeedLimit = 0.5f;

    /// <summary>
    /// 현재 속도를 속도 제한만큼 서서히 설정
    /// </summary>
    /// <param name="tMoveDimension">전후 혹은 좌우 방향</param>
    /// <param name="tDirection">정방향 혹은 역방향</param>
    /// <param name="tParameterName">애니메이션 매개변수 이름</param>
    private void SetMovingStatus(ref float tMoveDimension, float tDirection, string tParameterName)
    {
        // 속도 제한에 방향 적용
        float tSpeedLimit = mSpeedLimit * tDirection;

        // 현재 속도가 제한보다 작을 때
        if (tSpeedLimit > tMoveDimension)
        {
            tMoveDimension += Time.deltaTime * mMovingSwitchSpeedmult;
            if (tSpeedLimit < tMoveDimension)
            {
                tMoveDimension = tSpeedLimit;
            }

            // Animation Controller 변수 설정
            mAnimator.SetFloat(tParameterName, tMoveDimension);
        }
        // 현재 속도가 제한보다 클 때
        else if (tSpeedLimit < tMoveDimension)
        {
            tMoveDimension -= Time.deltaTime * mMovingSwitchSpeedmult;
            if (tSpeedLimit > tMoveDimension)
            {
                tMoveDimension = tSpeedLimit;
            }

            // Animation Controller 변수 설정
            mAnimator.SetFloat(tParameterName, tMoveDimension);
        }
    }

    /// <summary>
    /// 현재 속도를 서서히 0으로 설정
    /// </summary>
    /// <param name="tMoveDimension">전후 혹은 좌우 방향</param>
    /// <param name="tParameterName">애니메이션 매개변수 이름</param>
    private void SetMovingStatus(ref float tMoveDimension, string tParameterName)
    {
        if (0 < tMoveDimension)
        {
            tMoveDimension -= Time.deltaTime * mMovingSwitchSpeedmult;
            if (0.0f > tMoveDimension)
            {
                tMoveDimension = 0.0f;
            }
        }
        else
        {
            tMoveDimension += Time.deltaTime * mMovingSwitchSpeedmult;
            if (0.0f < tMoveDimension)
            {
                tMoveDimension = 0.0f;
            }
        }
        mAnimator.SetFloat(tParameterName, tMoveDimension);
    }

    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
        mCharacterController = GetComponent<CharacterController>();
        mRotationY = transform.localRotation.eulerAngles.y;
    }

    private void Update()
    {
        #region'이동 및 회전
        // 좌우 회전
        mRotationY += Input.GetAxis("Mouse X");
        transform.localRotation = Quaternion.Euler(0.0f, mRotationY, 0.0f);

        // 걷기, 뛰기
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            mSpeedLimit = 1.0f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            mSpeedLimit = 0.5f;
        }

        // 전후 움직임 애니메이션 동작
        if (Input.GetKey(KeyCode.W))
        {
            SetMovingStatus(ref mMovingForward, 1.0f, "MovingForward");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            SetMovingStatus(ref mMovingForward, -1.0f, "MovingForward");
        }
        else
        {
            switch (mMovingForward)
            {
                case 0.0f:
                    break;

                default:
                    SetMovingStatus(ref mMovingForward, "MovingForward");
                    break;
            }
        }

        // 좌우 움직임 애니메이션 동작
        if (Input.GetKey(KeyCode.A))
        {
            SetMovingStatus(ref mMovingLeft, 1.0f, "MovingLeft");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            SetMovingStatus(ref mMovingLeft, -1.0f, "MovingLeft");
        }
        else
        {
            switch (mMovingLeft)
            {
                case 0.0f:
                    break;

                default:
                    SetMovingStatus(ref mMovingLeft, "MovingLeft");
                    break;
            }
        }

        // 주인공 전후좌우 이동
        float tRadianY = mRotationY * mDegreeToRadian;
        float tCos = Mathf.Cos(tRadianY);
        float tSin = Mathf.Sin(tRadianY);
        mCharacterController.Move(new Vector3(-mMovingLeft * tCos + mMovingForward * tSin, 0.0f, mMovingForward * tCos + mMovingLeft * tSin) * mMoveSpeedmult * Time.deltaTime);
        #endregion

        #region 사격 개시
        if (Input.GetMouseButtonDown(0))
        {
            mAnimator.SetLayerWeight(1, 1.0f);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            mAnimator.SetLayerWeight(1, 0.0f);
        }
        #endregion
    }
}
