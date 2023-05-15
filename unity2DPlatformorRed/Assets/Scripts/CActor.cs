using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CActor : MonoBehaviour
{
    // ����Ƽ ������ ���� ����
    [SerializeField]
    GameObject PFBullet = null;

    //�ش� Ŭ���� ������ ����ϱ� ���� ��������� ����
    CUIPlayGame mUI = null;


    [SerializeField]
    GameObject mFirePos = null; //źȯ �߻� ��ġ

    [SerializeField]
    float mScalarSpeed = 2.0f;

    SpriteRenderer mSprRdr = null;
    Rigidbody2D mRigidBody = null;

    //Ŭ���� ���ο��� ���Ǵ� ����
    //źȯ�߻����, �⺻�� ������ ����
    Vector3 mDirFire = Vector3.right;

    private void Awake()
    {
        //�̸� �˻��Ͽ� ã�Ƶ���.
        //�ҽ��ڵ忡�� �����صθ�, ������ ��쿡 �ҽ��ڵ常 ������ �����ȴ�.
        mSprRdr = this.GetComponentInChildren<SpriteRenderer>();
        mRigidBody = this.GetComponent<Rigidbody2D>();
    }



    // Start is called before the first frame update
    void Start()
    {
        //step_1
        //����?�� �˻��ϹǷ�, �Ź� �˻��ϴ� ��캸�� ����.
        //mUI = FindObjectOfType<CUIPlayGame>();
    }


    float tH;
    //�������� ���� ���� �̺�Ʈ �Լ�
    // Update is called once per frame
    void Update()
    {
        /*
            ���ӿ������� �Ϲ������� ��ü�� �̵��� ����� �����
                �밳 ������ ����.

            i) ��ǥ�� ���� ����
            ii) �����Ǵ� �̵� �Լ��� ����ϴ� ���
            iii) F = ma�� ���� ���

            iv) ���ϸ��̼����� ����� ���
        */

        //���Է� ���
        tH = Input.GetAxis("Horizontal");
        //��� ȭ��ǥ �Է¿� ����� ����, ���������� ��� ���
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Vector3 tJumpForce = Vector3.up * 12f;
            mRigidBody.AddForce(tJumpForce, ForceMode2D.Impulse);
        }

        //�����̽� �� �Է¿� ����� źȯ�߻�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject tBullet = Instantiate<GameObject>(PFBullet,
                //this.transform.position,
                mFirePos.transform.position,
                Quaternion.identity);

            //���� �� �˻��� �ȴٸ�, �̸� CBullet�� ����� �ش� ��ũ��Ʈ���� �����ص���.
            Vector3 tBulletForce = mDirFire * 20f;  //���ΰ� ĳ������ ���⿡ ���� �߻���� ����
            tBullet.GetComponent<Rigidbody2D>().AddForce(tBulletForce, ForceMode2D.Impulse);
        }

        //�̵���ȯ �Լ��� �̿��� �̵�
        //�ð� ��� ����, x�� �̵�
        //Vector3 tVelocity = Vector3.right * tH * mScalarSpeed * Time.deltaTime;
        //this.transform.Translate(tVelocity, Space.Self);

        //�����ۿ뿡 �ٰ��� �̵� �ڵ�
        //<-- �ð����� 1�ʿ� ����� �ڵ��̹Ƿ� Time.deltaTime�� �����ߴ�.
        Vector3 tVelocity = Vector3.right * tH * mScalarSpeed;  //<--x�࿡ �� ���� ����
        tVelocity.y = mRigidBody.velocity.y;                //<--y�࿡ �� ���� ����

        //��ü�� �ӵ��� ���� ��������.
        this.mRigidBody.velocity = tVelocity;


        //������ ������ �̿��� �� ������ ��ġ������ ����� �Ǵ�
        Vector3 tMoveDir = tVelocity.normalized;    //����ȭ
        if (Vector3.Dot(tMoveDir, Vector3.right) >= 1.0f)
        {
            //������ �������� �̵��ϰ� �ִ�
            mSprRdr.flipX = false;
            //���� �̹����� ������ �������� ������� �����Ƿ� ������ �ʴ´�

            //źȯ�߻� ���� ����
            mDirFire = Vector3.right;
        }
        else if (Vector3.Dot(tMoveDir, Vector3.right) <= -1.0f)
        {
            //���� �������� �̵��ϰ� �ִ�
            mSprRdr.flipX = true;
            //���� �̹����� ������ �������� ������� �����Ƿ� �����´�

            //źȯ�߻� ���� ����
            mDirFire = Vector3.left;
        }




        

    }

    //���� �ۿ뿡 ���� ���� �̺�Ʈ �Լ�

    //���
    //�����ۿ뿡 ���� ���� �ֱ�� �̵���ȯ ���� �ֱ⸦ ����, �� ���鿡 �����Ÿ��� ������ �ذ��� ���� �ִ�.
    //������, ����̴�.
    private void FixedUpdate()
    {
        //Vector3 tVelocity = Vector3.right * tH * mScalarSpeed * Time.deltaTime;
        //this.transform.Translate(tVelocity, Space.Self);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("tagMovePlatform"))
        {
            //�浹�� ���۵Ǵ� ������
            //�̵��÷������� �θ�� �Ͽ� transform�� ���������� ������ �ΰڴ�.
            this.transform.SetParent(collision.gameObject.transform);


            //UI����
            //step_0
            //FindObjectOfType Ÿ������ '�˻�'�ؼ� �ش� ���ӿ�����Ʈ�� ã���ش�.
            //���׷���(�����δ� Ʈ���ڷᱸ��)�� �˻��ؾ� �Ǵ� ����� ���.
            //      �������� O(n)
            //CUIPlayGame tUI = FindObjectOfType<CUIPlayGame>();
            //if (null != tUI)
            //{
            //    tUI.BuildUI();
            //}

            //step_1
            //mUI.BuildUI();

            //step_2
            //�������� ������ ������ ��������Ʈ�� ����Ͽ� ����ȣ���Ͽ���
            //<-- �˻� ����� ���� �ʴ´�
            CUIPlayGame.mAction();  //����ȣ��
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //�浹�� ����Ǵ� ������
        //�̵��÷������� �θ�� �Ͽ� transform�� ���������� �����ϰڴ�.
        this.transform.SetParent(null);
    }


}
