using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//������, �̸� �����ص� ���� �����ص� Ÿ��
enum E_IN_AIR
{
    IN_GROUND,  //���� ����ִ� ����
    IN_AIR,     //���߿� �� �ִ� ����, �߷� �ۿ�
    IN_AIR_NOGRAVITY    //���߿� �� �ִ� ����, ���߷�
}


public class CPChar_1 : MonoBehaviour
{
    //������ ��ũ: �Ϲ� źȯ
    [SerializeField]
    GameObject PFBullet = null;

    //������
    [SerializeField]
    GameObject mRifle = null;

    //�������� ��� ����dummy������Ʈ
    [SerializeField]
    GameObject mGrab = null;

    //źȯ �߻� ��ġ ���
    [SerializeField]
    GameObject mPosFire = null;



    [SerializeField]
    Animator mAnimator = null;



    //ī�޶� ������Ʈ
    [SerializeField]
    CFollowCam_1 mCamera = null;

    //ĳ������ �̵��� ����ϴ� ������Ʈ
    [SerializeField]
    CharacterController mCharController = null;

    //���� �ӵ�
    Vector3 mVecDir = Vector3.zero;

    //zx��鿡���� �̵�
    [SerializeField]
    float mScarlarSpeed = 0f;   //zx��鿡���� �ӷ�

    //y�࿡���� �̵�
    [SerializeField]
    float GRAVITY = -9.8f;  //�߷°��ӵ�(�ӷ�)


    //ĳ���� ��Ʈ�ѷ��� isGrounded�����뵵
    [SerializeField]
    bool mIsGrounded = false;

    [SerializeField]
    float mJumpPower = 0.0f; //���� ��(�ӷ�, �ӵ��� y���и� ����ϰ� �ִٰ� ����)

    [SerializeField]
    E_IN_AIR mInAir = E_IN_AIR.IN_GROUND;


    // Start is called before the first frame update
    void Start()
    {
        //�������� �����տ� �����Ѵ�
        mRifle.transform.SetParent(mGrab.transform);
        mRifle.transform.localPosition = Vector3.zero;
        mRifle.transform.localRotation = Quaternion.identity;
        //�߻���ġ ����
        mPosFire = mRifle.GetComponent<CRifle>().mPosFire;





        mAnimator = GetComponent<Animator>();


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

        //���� ���� ����
        if (mCharController.isGrounded)
        {
            mInAir = E_IN_AIR.IN_GROUND;
        }

        if (Input.GetKeyUp(KeyCode.Space))  //���� Ű �Է��� �ִٸ�
        {

            if(mCharController.isGrounded || !mCharController.isGrounded)   //<--��� �� ������ �ʿ������� �ʴ�. ������
            {
                if(mInAir != E_IN_AIR.IN_AIR) //'���� ����'�� �ƴ϶��
                {
                    Debug.Log("Jump Begin");
                    mVecDir.y = mJumpPower;

                    mInAir = E_IN_AIR.IN_AIR;   //'���� ����'�� '���� ����'
                }
                else if (mInAir == E_IN_AIR.IN_AIR)
                {
                    Debug.Log("No gravity Begin");

                    mInAir = E_IN_AIR.IN_AIR_NOGRAVITY; //'���߷� �ξ� ����'�� '���� ����'
                }
            }
        }



        //������ ���¸� ������� '�ൿ' <-- ���⼭ �ൿ�� �ӵ� ����
        //<-- �� �ڵ� ���ܿ����� ���� ������ ���Ѵ�
        if (mInAir != E_IN_AIR.IN_AIR && mInAir != E_IN_AIR.IN_AIR_NOGRAVITY) //���� ���� && ���߷ºξ���°� �ƴ϶��
        {
            //'ĳ���� ��Ʋ�ѷ�'�� �۵������ ����Ͽ� ������ ���� ó��
            if (!mCharController.isGrounded)
            {
                mVecDir.y = mVecDir.y + GRAVITY * Time.deltaTime;
            }
            else
            {
                float tV = Input.GetAxis("Vertical");   //[-1, 1] �������� ��
                float tH = Input.GetAxis("Horizontal"); //[-1, 1] �������� ��
                Vector3 tVelocity = new Vector3(tH, 0f, tV);
                mVecDir = mCharController.transform.TransformDirection(tVelocity);

                mVecDir = mVecDir * mScarlarSpeed;
            }
        }
        else if (mInAir == E_IN_AIR.IN_AIR) //���� ���¶��
        {
            mVecDir.y = mVecDir.y + GRAVITY * Time.deltaTime;
        }
        else if (mInAir == E_IN_AIR.IN_AIR_NOGRAVITY)
        {
            //���߷� �ξ� ����
            //  ���⼭�� ���߷� �ξ� ���¿��� zx��� �̵��� �����ϴٰ� ����.
            float tV = Input.GetAxis("Vertical");   //[-1, 1] �������� ��
            float tH = Input.GetAxis("Horizontal"); //[-1, 1] �������� ��
            Vector3 tVelocity = new Vector3(tH, 0f, tV);
            mVecDir = mCharController.transform.TransformDirection(tVelocity);

            mVecDir = mVecDir * mScarlarSpeed;
        }

        


        //������ �ӵ��� �̵�, �ð���� ����( CharacterController������Ʈ�� ����� �̿� )
        mCharController.Move(mVecDir * Time.deltaTime);


        //ī�޶� �ٶ󺸴� �������� �̵��ϱ� ���� ĳ������ ���� ����
        //==============
        Vector3 tOffset = mCamera.transform.forward;
        tOffset.y = 0f; //zx��鿡���� ���⸸ ����ϰڴ�.
        //������ ���ϱ� = ĳ������ ������ġ + ī�޶��� ���� ����( ũ��� 1 )
        Vector3 tLookAtPosition = this.transform.position + tOffset;
        //ĳ���Ͱ� �������� �ٶ󺸰� �Ѵ�.
        this.transform.LookAt(tLookAtPosition);
        //==============




        //�ִϸ��̼� ����
        Vector3 tZXVec = mVecDir;
        tZXVec.y = 0f;
        float tMag = tZXVec.magnitude; //�ӵ��� ũ��(�ӷ�)�� ����
        mAnimator.SetFloat("fSpeed", tMag);

        test_fSpeed = 0f;



        //���� ���콺 ��ư�� Ŭ���ϸ� �Ϲ�źȯ �߻�
        if (Input.GetMouseButtonDown(0))
        {
            //�Ϲ�źȯ �߻�
            /*
                �߻� �������� ����
                �ӵ� ����
                Ȱ��ȭ�Ѵ�(�̹� ���������Ǿ���)
            */
            GameObject tBullet = Instantiate<GameObject>(PFBullet, mPosFire.transform.position, mPosFire.transform.rotation);

            tBullet.GetComponent<Rigidbody>().AddForce(tBullet.transform.forward * -10f, ForceMode.Impulse);

            //�ִϸ��̼� ����
            //1�� �ִϸ��̼� ���̾��� ����ġ�� 1���� ����
            mAnimator.SetLayerWeight(1, 1f);
            mAnimator.Play(0, 1, 0f);
            //<-- ������ �ִϸ��̼� ���̾, ������ ������ �ִϸ��̼���, ����ȭ�� �ð�0���� �÷���
        }

    }

    //ȭ�鿡�� �����ϱ� ���� �߰�
    float test_fSpeed = 0f;
    private void OnGUI()
    {
        GUI.color = Color.red;

        string tString = $"fSpeed: {test_fSpeed.ToString()}";
        GUI.Label(new Rect(100f, 300f, 500f, 100f), tString);
    }
}
