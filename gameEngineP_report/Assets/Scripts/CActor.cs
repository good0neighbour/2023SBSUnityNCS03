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
    /// ���� �ӵ��� �ӵ� ���Ѹ�ŭ ������ ����
    /// </summary>
    /// <param name="tMoveDimension">���� Ȥ�� �¿� ����</param>
    /// <param name="tDirection">������ Ȥ�� ������</param>
    /// <param name="tParameterName">�ִϸ��̼� �Ű����� �̸�</param>
    private void SetMovingStatus(ref float tMoveDimension, float tDirection, string tParameterName)
    {
        // �ӵ� ���ѿ� ���� ����
        float tSpeedLimit = mSpeedLimit * tDirection;

        // ���� �ӵ��� ���Ѻ��� ���� ��
        if (tSpeedLimit > tMoveDimension)
        {
            tMoveDimension += Time.deltaTime * mMovingSwitchSpeedmult;
            if (tSpeedLimit < tMoveDimension)
            {
                tMoveDimension = tSpeedLimit;
            }

            // Animation Controller ���� ����
            mAnimator.SetFloat(tParameterName, tMoveDimension);
        }
        // ���� �ӵ��� ���Ѻ��� Ŭ ��
        else if (tSpeedLimit < tMoveDimension)
        {
            tMoveDimension -= Time.deltaTime * mMovingSwitchSpeedmult;
            if (tSpeedLimit > tMoveDimension)
            {
                tMoveDimension = tSpeedLimit;
            }

            // Animation Controller ���� ����
            mAnimator.SetFloat(tParameterName, tMoveDimension);
        }
    }

    /// <summary>
    /// ���� �ӵ��� ������ 0���� ����
    /// </summary>
    /// <param name="tMoveDimension">���� Ȥ�� �¿� ����</param>
    /// <param name="tParameterName">�ִϸ��̼� �Ű����� �̸�</param>
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
        #region'�̵� �� ȸ��
        // �¿� ȸ��
        mRotationY += Input.GetAxis("Mouse X");
        transform.localRotation = Quaternion.Euler(0.0f, mRotationY, 0.0f);

        // �ȱ�, �ٱ�
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            mSpeedLimit = 1.0f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            mSpeedLimit = 0.5f;
        }

        // ���� ������ �ִϸ��̼� ����
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

        // �¿� ������ �ִϸ��̼� ����
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

        // ���ΰ� �����¿� �̵�
        float tRadianY = mRotationY * mDegreeToRadian;
        float tCos = Mathf.Cos(tRadianY);
        float tSin = Mathf.Sin(tRadianY);
        mCharacterController.Move(new Vector3(-mMovingLeft * tCos + mMovingForward * tSin, 0.0f, mMovingForward * tCos + mMovingLeft * tSin) * mMoveSpeedmult * Time.deltaTime);
        #endregion

        #region ��� ����
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
