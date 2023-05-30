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


    // Start is called before the first frame update
    void Start()
    {
        //����Ƽ �����Ϳ��� ������ ���� ����Ͽ� ����صд�.
        //������ ���� = �������� - ��������
        mOffset = this.transform.position - mPChar.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float tMouseX = Input.GetAxis("Mouse X");
        float tMouseY = Input.GetAxis("Mouse Y");

        mXVal = mXVal + tMouseX;
        mYVal = mYVal + tMouseY;

        //Quaternion ����� <-- �� ���� ���� �����Ͽ� ���� ��ü��
        //Quaternion vs Euler
        this.transform.rotation = Quaternion.Euler(mYVal, mXVal, 0f);
        //<-- ���콺 �Է¿� ����Ͽ� ī�޶��� x�� ȸ��( mouse y �Է°��� ���� ), y�� ȸ��( mouse x �Է°��� ���� )�� �Ϸ��� �ϴ� ���̴�
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
