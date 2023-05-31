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
    }
}
