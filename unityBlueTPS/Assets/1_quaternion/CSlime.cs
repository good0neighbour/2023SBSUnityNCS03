using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSlime : MonoBehaviour
{
    //embedded enum
    //�ش� Ŭ���� ���� �����ؼ� ������
    enum STATE
    {
        WITH_NONE = 0,  //ȸ���� ���� ���� ����

        WITH_ELUER,     //���Ϸ� ���� �̿��� ȸ�� ����
        WITH_QUATERNION //������� �̿��� ȸ�� ����
    }

    [SerializeField]
    STATE mState = STATE.WITH_NONE;

    //������� �̿��� ȸ���� ó�� ���¿� �� ����
    Quaternion mStart = Quaternion.identity;   //������ ������� �ʱ�ȭ( ȸ���� ���� )
    Quaternion mEnd = Quaternion.identity;   //������ ������� �ʱ�ȭ( ȸ���� ���� )

    float mInterpolatePoint = 0f;   //������ �Ű����� t, ó�� ���� 0

    //����Ƽ�� Transform�� ȸ���� �⺻������ ������� �̿��ϵ��� ��������ִ�.
    //<-- �׷��Ƿ� ���Ϸ� ���� ���� ȸ���� ������ ������ �Ѵ�.
    //���Ϸ� ���� ���� ȸ���� ����
    Matrix4x4 mMatRot = Matrix4x4.identity; //������ķ� �ʱ�ȭ
    MeshFilter mMeshFilter = null;          //�޽��� �����ϴ� ������Ʈ( �޽�: �ﰢ���� ����, ������ ���� )
    Vector3[] mOriginVertices;              //���� ����
    Vector3[] mNewVertices;                 //��ȯ�� ����� ���ο� ����


    private void OnGUI()
    {
        //ó�� ���·� �����
        if (GUI.Button(new Rect(0f, 300f, 100f, 100f), "Origin"))
        {
            mStart = Quaternion.identity;
            mEnd = Quaternion.identity;

            //�ش� ���� ������Ʈ�� ȸ�����´� ó�����´�.
            this.transform.rotation = mStart;

            mInterpolatePoint = 0f;

            mState = STATE.WITH_NONE;
        }


        if (GUI.Button(new Rect(0f, 0f, 100f, 100f), "Quaternion"))
        {
            //z, x, y ������ ����� ����
            mEnd = Quaternion.Euler(0f, 0f, 90f) * Quaternion.Euler(90f, 0f, 0f) * Quaternion.Euler(0f, 90f, 0f);

            mState = STATE.WITH_QUATERNION;
        }

        if (GUI.Button(new Rect(100f, 0f, 100f, 100f), "Transform.Rotate"))
        {
            //transform���� �����ϴ� Rotate�� ����� ������� ������� �ִ�.
            //z, x, y
            this.transform.Rotate(0f, 0f, 90f);
            this.transform.Rotate(90f, 0f, 0f);
            this.transform.Rotate(0f, 90f, 0f);

            mState = STATE.WITH_NONE;
        }

        //�� ���� ���Ϸ� ���� ���� ȸ���� ����� ���´�
        //z, x, y
        if (GUI.Button(new Rect(100f, 100f, 150f, 100f), "______Quaternion.Euler"))
        {
            //�� ȸ���� ������� ���� ����� �ƴϴ�.
            mEnd = Quaternion.Euler(90f, 90f, 90f);

            mState = STATE.WITH_ELUER;
        }

        //ȸ�� ��Ŀ� ���� ȸ��
        if (GUI.Button(new Rect(0f, 100f, 100f, 100f), "EULER with MATRIX"))
        {
            //w = TRSv

            //z�� ȸ�� ���
            Matrix4x4 tM = Matrix4x4.identity;
            tM.SetTRS(Vector3.zero, Quaternion.Euler(0f, 0f, 90f), Vector3.one);

            mMatRot = tM * mMatRot; //��ĳ����� ����

            //x�� ȸ�� ���
            tM = Matrix4x4.identity;
            tM.SetTRS(Vector3.zero, Quaternion.Euler(90f, 0f, 0f), Vector3.one);

            mMatRot = tM * mMatRot; //��ĳ����� ����

            //y�� ȸ�� ���
            tM = Matrix4x4.identity;
            tM.SetTRS(Vector3.zero, Quaternion.Euler(0f, 90f, 0f), Vector3.one);

            mMatRot = tM * mMatRot; //��ĳ����� ����

            //MeshFillter������Ʈ�� ����
            mMeshFilter = GetComponentInChildren<MeshFilter>();
            mOriginVertices = mMeshFilter.mesh.vertices;    //�޽��� ������ ����

            //��ȯ�� ���ϱ� ���� ���ο� ��������� ����� ����
            mNewVertices = new Vector3[mOriginVertices.Length];

            int ti = 0;
            while (ti < mOriginVertices.Length)
            {
                //������ ��ġ ��ȯ
                mNewVertices[ti] = mMatRot.MultiplyPoint3x4(mOriginVertices[ti]);

                ++ti;
            }

            //��ȯ�� ����� ��������� ����
            mMeshFilter.mesh.vertices = mNewVertices;


            mState = STATE.WITH_NONE;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        mStart = Quaternion.identity;
        mEnd = Quaternion.identity;

        //�ش� ���� ������Ʈ�� ȸ�����´� ó�����´�.
        this.transform.rotation = mStart;

        mInterpolatePoint = 0f;

        mState = STATE.WITH_NONE;

    }

    // Update is called once per frame
    void Update()
    {
        if (STATE.WITH_NONE != mState)
        {
            //Slerp: Sphere Linear interpolation ���� ���� ����
            this.transform.rotation = Quaternion.Slerp(mStart, mEnd, mInterpolatePoint);
            /*
                Lerp Linear Interpolation
                ��������
                ������ ������(�����Լ�)�� ����Ͽ� ������ �� �� ������ �� ���� ���Ѵ�.
                �� ���� �� �� �� ������ �ٻ�ġ�� ���ϱ� ���� ����̴�.

                Slerp Sphere Linear Interpolation
                ���� ���� ����

                ���������� ������ ���� �ѷ� �� �Ϻ��� ȣ�� ����Ͽ� ǥ���ϴ� ���̴�
                ���� ȣ�� ������ ���Ƿ�
                ������ ���Ŀ� ���Եȴ�.

                ���� ȣ�� ��̹Ƿ�
                ���Ⱑ ���Ѵ�
                �׷��Ƿ� ���� �ε巯��?(�Ϲ����� �����������ٴ� ���� ���̳�����) ��ȭ�� ǥ�������ϴ�


                ���鼱�������� ���� ���� ����Ͽ� �����ȴ�

                P = ( sin( (1 - t)Theta) * P0 + sin(t * Theta) * P1 ) / sinTheta

                    <-- ������ ���� ����
                    <-- [0, 1]���� ����ȭ�� ���� sin ����

            */


            mInterpolatePoint += Time.deltaTime;
        }
    }
}
