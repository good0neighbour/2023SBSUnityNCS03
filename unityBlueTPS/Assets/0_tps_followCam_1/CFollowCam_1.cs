using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFollowCam_1 : MonoBehaviour
{
    [SerializeField]
    GameObject mPChar = null;

    //������, ĳ���ͷκ��� ������( �󸶳� ������ �ִ����� ���� ���� )
    [SerializeField]
    Vector3 mOffset = Vector3.zero;

    float mXVal = 0f;   //���콺 X�Է°�
    float mYVal = 0f;   //���콺 Y�Է°�

    //ĳ���ͷκ��� ī�޶� ������ �Ÿ�, ����
    [SerializeField]
    float mArmLength = 0.0f;

    bool mIsCameraRotation = false;


    // Start is called before the first frame update
    void Start()
    {
        //����Ƽ �����Ϳ��� ������ ���� ����Ͽ� ����صд�.
        //  ������ ���� = �������� - ��������
        //mOffset = this.transform.position - mPChar.transform.position;
        //mYVal = this.transform.rotation.eulerAngles.x;  //���Ϸ��� x�� ȸ���� degree

        //ī�޶� �� ���� ����
        mOffset = new Vector3(0f, 0f, -1f * mArmLength);
        mYVal = 30f;    //x�� ȸ�������� �ϴ� ���� ����( degree )
        mYVal = this.transform.rotation.eulerAngles.x;  //���Ϸ��� x�� ȸ���� degree

        //������ ȸ������ �ѹ� ����
        this.transform.rotation = Quaternion.Euler(mYVal, mXVal, 0f);

        mIsCameraRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mIsCameraRotation = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            mIsCameraRotation = false;
        }

        //���콺 ������ ��ư�� �����ִ� ��쿡��, ī�޶��� ȸ�� ������ �ϵ��� �Ѵ�
        if (mIsCameraRotation)
        {
            float tMouseX = Input.GetAxis("Mouse X");   //[-1, 1]
            float tMouseY = Input.GetAxis("Mouse Y");   //[[-1, 1]

            mXVal = mXVal + tMouseX;
            mYVal = mYVal + tMouseY * (-1.0f);
            //������ ��ǥ�� �������δ� y�� ���� ������ �Ʒ����ε�
            //����Ƽ�� ��ǥ��� y�� ���� ������ �����̹Ƿ�
            //-1�� �����־� �����.

            //Quaternion ����� <-- �� ���� ���� �����Ͽ� ���� ��ü��
            //Quaternion vs Euler
            this.transform.rotation = Quaternion.Euler(mYVal, mXVal, 0f);
            //<-- ���콺 �Է¿� ����Ͽ� ī�޶��� x�� ȸ��( mouse y �Է°��� ���� ), y�� ȸ��( mouse x �Է°��� ���� )�� �Ϸ��� �ϴ� ���̴�
        }
    }

    private void LateUpdate()
    {
        //ī�޶��� ��ġ�� ĳ���ͷκ��� �����¸�ŭ ������ ��ġ�� ����
        //this.transform.position = mPChar.transform.position + mOffset;

        //ī�޶��� ȭ������ ����� ���������� ����Ͽ� ī�޶��� ��ġ�� ����
        //<-- ��������δ� ĳ���͸� �߽ɿ� �ΰ� ī�޶� ȸ���Ѵ�
        this.transform.position = mPChar.transform.position + this.transform.rotation * mOffset;
        //this.transform.rotation * mOffset: ����� * ������ ��������
        //������� ������ ȸ���� ���� �������� ��� �����ϴ�.
        //  �� ���⼭�� mOffset�̶�� ���͸�
        //  ����� ����(������� �ǹ�)���� ��������
        //  �ش� ���⿡ �°� ȸ��(ũ��� �״��, ������ ����)��Ű��
        //  �ٽ� ����� �������� ���� ����(������� �ǹ�)���� �������
        //  3D����(�������� �ǹ�)�� ���ͷ� �����ִ� ���̴�
    }
}
